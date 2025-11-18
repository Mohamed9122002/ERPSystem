using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class EmployeeController(IEmployeeService _employeeService, ILogger<EmployeeController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public async Task<IActionResult> Index(string? employeeSearchName)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(employeeSearchName);
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    var employeeDto = new CreatedEmployeeDto()
                    {
                        FullName = model.FullName,
                        NationalID = model.NationalID,
                        Phone = model.Phone,
                        Email = model.Email,
                        HireDate = model.HireDate,
                        Status = model.Status,
                        DepartmentId = model.DepartmentId,
                        JobPositionId = model.JobPositionId,
                        ShiftId = model.ShiftId
                    };
                    int result = await _employeeService.CreateEmployeeAsync(employeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Not Created");
                        //return View(employeeDTO);
                    }
                }
                catch (Exception ex)
                {
                    // log Exception
                    if (_environment.IsDevelopment())
                    {
                        // 1. Environment Development => Log Error in Console and Return same view with error message
                        ModelState.AddModelError(string.Empty, ex.Message);
                        //return View(employeeDTO);
                    }
                    else
                    {
                        // 2. Environment Deployment
                        // Log Error in File | Table in DataBase And Return Error View
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(model);

        }

    }
}
