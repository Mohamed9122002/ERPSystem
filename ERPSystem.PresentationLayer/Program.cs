using ERPSystem.BusinessLogicLayer.DataTransferObject.Profiles;
using ERPSystem.BusinessLogicLayer.HRServices.AttendanceS;
using ERPSystem.BusinessLogicLayer.HRServices.DepartmentS;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.BusinessLogicLayer.HRServices.JobPositionS;
using ERPSystem.BusinessLogicLayer.HRServices.PayrollItemS;
using ERPSystem.BusinessLogicLayer.HRServices.PayrollItemTypeS;
using ERPSystem.BusinessLogicLayer.HRServices.ShiftS;
using ERPSystem.BusinessLogicLayer.HRServices.TrainingS;
using ERPSystem.DataAccessLayer.Contexts;
using ERPSystem.DataAccessLayer.Repositories.UOW;
using ERPSystem.PresentationLayer.ViewModels;
using ERPSystem.PresentationLayer.ViewModels.Profiles;
using Microsoft.AspNetCore.Mvc;
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
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            builder.Services.AddDbContext<ERPDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(cfg => { },
                typeof(EmployeeMappingProfile).Assembly,
                typeof(EmloyeeMappingProfilePre).Assembly
                );
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IJobPositionServices, JobPositionServices>();
            builder.Services.AddScoped<ITrainingService, TrainingService>();
            builder.Services.AddScoped<IShiftService, ShiftService>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();
            builder.Services.AddScoped<IPayrollItemTypeService, PayrollItemTypeService>();
            builder.Services.AddScoped<IPayrollItemService, PayrollItemService>();
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
