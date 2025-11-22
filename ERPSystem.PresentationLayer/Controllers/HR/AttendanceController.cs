using AutoMapper;
using ERPSystem.BusinessLogicLayer.DataTransferObject.AttendanceDtos;
using ERPSystem.BusinessLogicLayer.HRServices.AttendanceS;
using ERPSystem.BusinessLogicLayer.HRServices.EmployeeS;
using ERPSystem.PresentationLayer.ViewModels.Attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ERPSystem.PresentationLayer.Controllers.HR
{
    public class AttendanceController(IAttendanceService attendanceService , IEmployeeService employeeService,IMapper mapper, IWebHostEnvironment environment, ILogger<AttendanceController> logger) : Controller
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
        public async Task<IActionResult> CheckOut( int Id)
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
    }
}
