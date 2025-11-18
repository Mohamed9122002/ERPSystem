using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos;
using ERPSystem.BusinessLogicLayer.HRServices.DepartmentS;
using ERPSystem.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class DepartmentController(IDepartmentService _departmentService ,IWebHostEnvironment _environment,ILogger<DepartmentController> _logger ,IMapper _mapper) :Controller
    {
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel departmentView)
        {
            if (ModelState.IsValid) // server side validation 
            {
                try
                {
                    var departmentDto = _mapper.Map<CreatedDepartmentDto>(departmentView);
                    int result = await _departmentService.CreateDepartmentAsync(departmentDto);
                    string Message;
                    if (result > 0)
                        Message = $"Department {departmentView.Name}Is Created Successful";
                    else
                        Message = $"Department {departmentView.Name} can not Be Created";
                    TempData["Message"] = Message;
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else                  
                        _logger.LogError(ex.Message);
                    
                }
            }
            return View(departmentView);
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var department = await _departmentService.GetDepartmentByIdAsync(Id.Value);
            if (department is null) return NotFound();
            return View(department);
        }

        #region Updated Department 
        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var department = await _departmentService.GetDepartmentByIdAsync(Id.Value);
            if (department is null) return NotFound();
            var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);
            return View(departmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel departmentEditViewModel, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UpdatedDepartment = _mapper.Map<UpdatedDepartmentDto>(departmentEditViewModel);
                    int result = await _departmentService.UpdateDepartmentAsync(UpdatedDepartment);
                    if (result > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department is Not Updated");
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
                        return View("ErrorView", ex);
                    }

                }
            }
            return View(departmentEditViewModel);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = await _departmentService.DeleteDepartmentAsync(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is Not Deleted");
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
    }
}
