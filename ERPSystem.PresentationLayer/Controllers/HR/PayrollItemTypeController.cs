using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.PayrollItemTypeDtos;
using ERPSystem.BusinessLogicLayer.HRServices.PayrollItemTypeS;
using ERPSystem.PresentationLayer.ViewModels.Payroll_temType;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class PayrollItemTypeController(IPayrollItemTypeService payrollItemTypeService, IMapper mapper, ILogger<PayrollItemTypeController> logger, IWebHostEnvironment environment) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var payrollItemTypes = await payrollItemTypeService.GetAllPayrollItemType();
            return View(payrollItemTypes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PayrollItemTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var payrollItemTypeModel = mapper.Map<PayrollItemTypeViewModel, CreatePayrollItemTypeDto>(viewModel);
                    var result = await payrollItemTypeService.CreatePayrollItemType(payrollItemTypeModel);
                    if (result > 0)
                    {
                        TempData["Success"] = "Payroll Item Type created successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " PayrollItem Type Not Created");
                    }
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                    {
                        logger.LogError(ex, "An error occurred while creating Item Type record.");
                    }
                    else
                    {
                        logger.LogError(ex, "An error occurred while creating Item Type record.");
                    }
                }
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var payrollItemType = await payrollItemTypeService.GetPayrollItemTypeById(id.Value);
            if (payrollItemType is null) return NotFound();
            var payrollItemTypeViewModel = mapper.Map<PayrollItemTypeViewModel>(payrollItemType);
            return View(payrollItemTypeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PayrollItemTypeViewModel viewModel, [FromRoute] int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var payrollItemTypeModel = mapper.Map<PayrollItemTypeViewModel, UpdatePayrollItemTypeDto>(viewModel);
                    var result = await payrollItemTypeService.UpdatePayrollItemType(payrollItemTypeModel);
                    if (result > 0)
                    {
                        TempData["Success"] = "Payroll Item Type Updated successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = "Payroll Item Type Not Updated !";
                        ModelState.AddModelError(string.Empty, " PayrollItem Type Not updated");
                    }
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                    {
                        logger.LogError(ex, "An error occurred while creating Item Type record.");
                    }
                    else
                    {
                        logger.LogError(ex, "An error occurred while creating Item Type record.");
                    }
                }
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = await payrollItemTypeService.DeleteAsync(id);
                if (Deleted)
                {
                    TempData["Success"] = "Payroll Item Type Deleted successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Payroll Item Type Not Deleted !";
                    ModelState.AddModelError(string.Empty, " PayrollItem Type is Not Deleted");
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex, "An error occurred while deleting Payroll Item Type record.");
                }
                else
                {
                    logger.LogError(ex, "An error occurred while deleting Payroll Item Type record.");
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
