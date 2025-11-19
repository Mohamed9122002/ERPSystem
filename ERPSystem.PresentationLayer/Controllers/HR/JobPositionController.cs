using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using ERPSystem.BusinessLogicLayer.DataTransferObject.DepartmentDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.JobPositionDtos;
using ERPSystem.BusinessLogicLayer.HRServices.JobPositionS;
using ERPSystem.DataAccessLayer.Modules.HR;
using ERPSystem.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class JobPositionController(IJobPositionServices _positionServices, IMapper _mapper, ILogger<JobPositionController> _logger, IWebHostEnvironment _environment) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var positions = await _positionServices.GetAllJobPositionsAsync();
            return View(positions);
        }
        // Additional actions (Create, Edit, Delete) would go here
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobPositionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jobPosition = _mapper.Map<CreatedJobPositionDto>(viewModel);
                    int result = await _positionServices.CreateJobPositionAsync(jobPosition);
                    string Message;
                    if (result > 0)
                    {
                        Message = $"jobPosition {viewModel.Title}Is Created Successful";
                        TempData["Message"] = Message;
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);

                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var jobPos = await _positionServices.GetJobPositionByIdAsync(Id.Value);
            if (jobPos is null) return NotFound();
            return View(jobPos);
        }
        public async Task<IActionResult> Updated(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var jobPosition = await _positionServices.GetJobPositionByIdAsync(Id.Value);
            if (jobPosition is null) return NotFound();
            var jobPosViewModel = _mapper.Map<JobPositionViewModel>(jobPosition);
            return View(jobPosViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Updated(JobPositionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jobPositionDto = _mapper.Map<UpdatedJobPositionDto>(viewModel);
                    int result = await _positionServices.UpdateJobPositionAsync(jobPositionDto);                   string Message;
                    if (result > 0)
                    {
                        Message = $"Job Position {viewModel.Title} Is Updated Successful";
                        TempData["Message"] = Message;
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("***************");
                    Console.WriteLine(ex);
                    Console.WriteLine("***************");
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
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
                bool Deleted = await _positionServices.DeleteJobPositionAsync(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "JobPosition is Not Deleted");
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
