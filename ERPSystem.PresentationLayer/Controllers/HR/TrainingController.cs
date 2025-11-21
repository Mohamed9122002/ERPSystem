using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.TrainingDtos;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.BusinessLogicLayer.HRServices.TrainingS;
using ERPSystem.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class TrainingController(ITrainingService trainingService ,IEmployeeService employeeService ,IMapper mapper ,IWebHostEnvironment environment ,ILogger<TrainingController> logger) :Controller
    {
        public async Task<IActionResult> Index()
        {
            var trainings = await trainingService.GetAllTrainingsAsync();
            return View(trainings);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( TrainingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var trainingDto = mapper.Map<CreateTrainingDto>(viewModel);
                    int result = await  trainingService.CreateAsync(trainingDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Training Not Created");
                    }
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        logger.LogError(ex.Message);
                    }
                }
            }
            return View(viewModel);

        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var training = await trainingService.GetByIdAsync(Id.Value);
            var trainingUpdated = mapper.Map<TrainingViewModel>(training);
            return View(trainingUpdated);
        }
        public async Task<IActionResult> Updated(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var training = await trainingService.GetByIdAsync(Id.Value);
            var trainingUpdated = mapper.Map<TrainingViewModel>(training);
            return View(trainingUpdated);
        }
        [HttpPost]
        public async Task<IActionResult> Updated([FromRoute] int? Id, TrainingViewModel trainingViewModel)
        {
            if (!Id.HasValue) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var TrainingUpdated = mapper.Map<UpdateTrainingDto>(trainingViewModel);
                    int result = await trainingService.UpdateAsync(TrainingUpdated);
                    if (result > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Training is Not Updated");
                    }
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                    {
                        logger.LogError(ex.Message);
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(trainingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = await trainingService.DeleteAsync(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Trainig is Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
        }

        public async Task<IActionResult> AssignEmployeeTraining(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var training = await  trainingService.GetByIdAsync(Id.Value);
            var model = new AssignEmployeeViewModel
            {
                TrainingId = training.Id,
                TrainingTitle = training.Title,
                SelectedEmployeeIds = training.Employees.Select(et => et.EmployeeId).ToList(),
                Employees = (List<EmployeeDto>)await employeeService.GetAllEmployeesAsync(null)
            }; 
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> AssignEmployeeTraining(AssignEmployeeToTrainingDto dto)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("AssignEmployeeTraining", new { id = dto.TrainingId });

            var success = await trainingService.AssignEmployeesAsync(dto);
            if (!success) return NotFound();

            return RedirectToAction("Details", new { id = dto.TrainingId });
        }
    }
}
