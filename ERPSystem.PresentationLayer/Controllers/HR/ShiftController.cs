using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.ShiftDtos;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.BusinessLogicLayer.HRServices.ShiftS;
using ERPSystem.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class ShiftController(IShiftService _shiftService, IEmployeeService _employeeService, ILogger<ShiftController> logger, IWebHostEnvironment environment, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var shifts = await _shiftService.GetAllShiftsAsync(); 
            var shiftDtos = mapper.Map<List<ShiftDto>>(shifts);
            return View(shiftDtos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShiftViewModel shiftViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createShiftDto = mapper.Map<CreateShiftDto>(shiftViewModel);
                    var result = await _shiftService.CreateShiftAsync(createShiftDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to create shift.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex, "An error occurred while creating a shift.");
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    logger.LogError(ex, "An error occurred while creating a shift.");
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                }
            }
            return View(shiftViewModel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var shift = await _shiftService.GetShiftByIdAsync(id.Value);
            if (shift is null) return NotFound();
            var shiftViewModel = mapper.Map<ShiftViewModel>(shift);
            var employees = await _employeeService.GetAllEmployeesAsync(null);
            shiftViewModel.AllEmployees = mapper.Map<List<EmployeeDto>>(employees);

            return View(shiftViewModel);
        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var shift = _shiftService.GetShiftByIdAsync(id.Value).Result;
            if (shift is null) return NotFound();
            var shiftViewModel = mapper.Map<ShiftViewModel>(shift);
            return View(shiftViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? Id, ShiftViewModel shiftViewModel)
        {
            if (!Id.HasValue) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var shiftDto = mapper.Map<UpdateShiftDto>(shiftViewModel);
                    var result = await _shiftService.UpdateShiftAsync(shiftDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to update shift.");
                    }
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                    {
                        logger.LogError(ex, "An error occurred while updating a shift.");
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        logger.LogError(ex, "An error occurred while updating a shift.");
                        ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                    }
                }
            }
            return View(shiftViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = await _shiftService.DeleteShiftAsync(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Shift is Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex, "An error occurred while deleting a shift.");
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    logger.LogError(ex, "An error occurred while deleting a shift.");
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                }
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AssignEmployees(int shiftId, List<int> employeesId)
        {
            if (shiftId == 0) return BadRequest();
            try
            {
                var result = await _shiftService.AssignEmployeesToShiftAsync(shiftId, employeesId);
                if (result)
                    return RedirectToAction(nameof(Index), new { id = shiftId });
                else
                    TempData["ErrorMessage"] = "Failed to assign employees.";

            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex, "An error occurred while assigning employees to a shift.");
                    TempData["ErrorMessage"] = ex.Message;
                }
                else
                {
                    logger.LogError(ex, "An error occurred while assigning employees to a shift.");
                    TempData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                }
            }
                return RedirectToAction(nameof(Details), new { id = shiftId });
        }
    }
}
