using Dtos.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IJwtServices;
using Services.IServices;
using Services.Services;

namespace Hospital.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize]
	public class DoctorController : ControllerBase
	{
		private readonly IDoctorService _doctorService;
		private readonly IUserService _userService;
		private readonly IAppointmentService _appointmentService;
		private readonly IScheduleService _scheduleService;

		public DoctorController(IDoctorService doctorService, IUserService userService, IAppointmentService appointmentService, IScheduleService scheduleService)
		{
			_doctorService = doctorService;
			_userService = userService;
			_appointmentService = appointmentService;
			_scheduleService = scheduleService;
		}
		/// <summary>
		/// Get Doctor
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetDoctorByIdAysnc")]
		public async Task<IActionResult> GetDoctorByIdAysnc(int id)
		{
			if (!await _doctorService.AnyExistByIdAysnc(id))
				return NotFound();
			var appointment = await _doctorService.GetDoctorByIdAysnc(id);
			return Ok(appointment);
		}
		/// <summary>
		/// Add Doctor To Schdule
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, ActionName("AddDoctorToSchdule")]
		public async Task<IActionResult> AddDoctorToSchduleAsync(int doctorId, int scheduleId)
		{
			if (!await _doctorService.AnyExistByIdAysnc(doctorId)) return NotFound();
			if (!await _scheduleService.AnyExistByIdAysnc(scheduleId)) return NotFound();
			await _doctorService.AddDoctorToSchduleAsync(doctorId, scheduleId);
			return Ok();
		}
		/// <summary>
		/// Doctor View History
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("DoctorViewHistory")]
		public async Task<IActionResult> DoctorViewHistoryAsync(int doctorId)
		{
			if (!await _doctorService.AnyExistByIdAysnc(doctorId)) return NotFound();
			var hostories = await _doctorService.DoctorViewHistoryAsync(doctorId);
			return Ok(hostories);
		}
		/// <summary>
		/// Get Appointments Doctor By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAppointmentsDoctorById")]
		public async Task<IActionResult> GetAppointmentsDoctorByIdAsync(int doctorId)
		{
			if (!await _doctorService.AnyExistByIdAysnc(doctorId)) return NotFound();

			var appointments = await _doctorService.GetAppointmentsDoctorByIdAsync(doctorId);
			return Ok(appointments);
		}
		/// <summary>
		/// Delete Doctor
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("DeleteDoctorByIdAysnc")]

		public async Task<IActionResult> DeleteDoctorByIdAysnc(int id)
		{
			if (!await _doctorService.AnyExistByIdAysnc(id))
				return NotFound();

			var doctor = await _doctorService.DeleteDoctorByIdAysnc(id);
			await _userService.DeleteUserByIdAysnc(doctor.UserId);
			return Ok("Delete Completed");
		}
		/// <summary>
		/// Update Doctor
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPut, ActionName("UpdateDoctorByIdAysnc")]
		public async Task<IActionResult> UpdateDoctorByIdAysnc(int id, [FromForm] DoctorDto dto)
		{
			if (!await _doctorService.AnyExistByIdAysnc(id))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			await _doctorService.UpdateDoctorByIdAysnc(id, dto);
			return Ok("Update Completed");
		}
		/// <summary>
		/// Add Doctor
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, ActionName("AddDoctorAysnc")]
		public async Task<IActionResult> AddDoctorAysnc([FromForm] DoctorDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (!await _userService.AnyExistByIdAysnc(dto.UserId))
				return BadRequest("Not Register!");
			await _doctorService.AddDoctorAysnc(dto);
			return Ok("Add Completed");
		}
		/// <summary>
		/// GetAll Doctor
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllAsync")]
		public async Task<IActionResult> GetAllByAsync() => Ok(await _doctorService.GetAllAsync());
	}
}
