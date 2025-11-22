using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos;
using ERPSystem.BusinessLogicLayer.DataTransferObject.EmployeeDtos;
using ERPSystem.BusinessLogicLayer.HRServices.AttendanceS;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.PresentationLayer.ViewModels;
using ERPSystem.PresentationLayer.ViewModels.Attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class AttendanceController(IAttendanceService attendanceService, IEmployeeService employeeService, IMapper mapper, IWebHostEnvironment environment, ILogger<AttendanceController> logger) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var attendances = await attendanceService.GetAllAttendanceAsync();
            return View(attendances);
        }
        [HttpPost]
        public async Task<IActionResult> CheckIn([FromRoute] int Id)
        {
            var attendance = await attendanceService.CheckInAsync(Id);
            TempData["Message"] = "Check-in successful at " + attendance.CheckIn?.ToString("T");
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(int Id)
        {
            var attendance = await attendanceService.CheckOutAsync(Id);
            TempData["Message"] = "Check-out successful at " + attendance.CheckOut?.ToString("T");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Create()
        {
            var employees = await employeeService.GetAllEmployeesAsync(null);
            ViewBag.EmployeeList = new SelectList(employees, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AttendanceViewModel attendanceViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var attendanceDtos = mapper.Map<CreateAttendanceDto>(attendanceViewModel);
                    var result = await attendanceService.CreateAttendanceAsync(attendanceDtos);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var employees = await employeeService.GetAllEmployeesAsync(null);
                    ViewBag.EmployeeList = new SelectList(employees, "Id", "FullName");
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex, "An error occurred while creating attendance record.");
                }
                else
                {
                    logger.LogError(ex, "An error occurred while creating attendance record.");
                }
                var employees = await employeeService.GetAllEmployeesAsync(null);
                ViewBag.EmployeeList = new SelectList(employees, "Id", "FullName");
            }
            return View(attendanceViewModel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var attendance = await attendanceService.GetAttendanceByIdAsync(id.Value);
            if (attendance is null) return NotFound();
            var attendanceViewModel = mapper.Map<AttendanceViewModel>(attendance);
            return View(attendanceViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = await attendanceService.DeleteAttendanceAsync(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Attendance is Not Deleted");
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
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var attendance = await attendanceService.GetAttendanceByIdAsync(id.Value);
            if (attendance is null) return NotFound();
            var attendanceViewModel = mapper.Map<AttendanceViewModel>(attendance);
            return View(attendanceViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AttendanceViewModel attendanceViewModel, [FromRoute] int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    var attendanceDto = mapper.Map<UpdateAttendanceDto>(attendanceViewModel);
                    int result = await attendanceService.UpdateAttendanceAsync(attendanceDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                //An error occurred while saving the entity changes. See the inner exception for details.
                Console.WriteLine(ex.Message);

                if (environment.IsDevelopment())
                {
                    logger.LogError(ex, "An error occurred while updating attendance record.");
                }
                else
                {
                    logger.LogError(ex, "An error occurred while updating attendance record.");
                }
            }
            return View(attendanceViewModel);
        }
    }
}