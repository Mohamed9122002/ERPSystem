using ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles;
using ERPSystem.BusinessLogicLayer.HRServices.DepartmentS;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.BusinessLogicLayer.HRServices.JobPositionS;
using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using ERPSystem.PresentationLayer.ViewModels;
using ERPSystem.PresentationLayer.ViewModels.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ERPSystem.PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            #region Add Services To The Container 
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ERPDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<EmployeeMappingProfile>();
                cfg.AddProfile<DepartmentMappingProfile>();
                cfg.AddProfile<DepartmentMappingProfilePre>();
                cfg.AddProfile<JobPositionMappingProfile>();
                cfg.AddProfile<JobPositionMappingProfilePre>();
                cfg.AddProfile<EmloyeeMappingProfilePre>();
            });
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDepartmentService,DepartmentService>();
            builder.Services.AddScoped<IJobPositionServices, JobPositionServices>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
