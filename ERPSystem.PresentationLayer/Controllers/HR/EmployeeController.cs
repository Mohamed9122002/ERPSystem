using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class EmployeeController(IEmployeeService _employeeService ,IMapper mapper, ILogger<EmployeeController> _logger, IWebHostEnvironment _environment) : Controller
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
                   var employeeDto = mapper.Map<CreatedEmployeeDto>(model);
                    int result = await _employeeService.CreateEmployeeAsync(employeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Not Created");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(model);

        }

        #region Details Updated , Delete
        public async Task<IActionResult> Details(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var employee = await _employeeService.GetEmployeeByIdAsync(Id.Value);
            if(employee is null) return NotFound();
            return View(employee);

        }
        public async Task<IActionResult> Updated(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var employee = await _employeeService.GetEmployeeByIdAsync(Id.Value);
            var employeeUpdated =  mapper.Map<EmployeeViewModel>(employee);
            return View(employeeUpdated);
        }
        [HttpPost]
        public async Task<IActionResult> Updated([FromRoute] int? Id,EmployeeViewModel employeeViewModel)
        {
            if (!Id.HasValue) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var EmployeeUpdated = mapper.Map<UpdatedEmployeeDto>(employeeViewModel);
                    int result = await _employeeService.UpdateEmployeeAsync(EmployeeUpdated);
                    if (result > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee is Not Updated");
                        return View(employeeViewModel);
                    }
                }
                catch(Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);                
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(employeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = await _employeeService.DeleteEmployeeAsync(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
        }
        #endregion
    }
}
