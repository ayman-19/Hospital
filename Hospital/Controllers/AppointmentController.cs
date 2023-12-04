using Dtos.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Hospital.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(Roles ="Doctor")]
	public class AppointmentController : ControllerBase
	{
		private readonly IAppointmentService _appointmentService;
		private readonly IDoctorService _doctorService;
		private readonly IPatientService _patientService;

		public AppointmentController(IAppointmentService appointmentService,IDoctorService doctorService,IPatientService patientService)
        {
			_appointmentService = appointmentService;
			_doctorService = doctorService;
			_patientService = patientService;
		}
		/// <summary>
		/// Get Appointement
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet,ActionName("GetAppointmentByIdAysnc")]
		public async Task<IActionResult> GetAppointmentByIdAysnc(int id)
		{
			if (!await _appointmentService.AnyExistByIdAysnc(id)) 
				return NotFound();
			var appointment = await _appointmentService.GetAppointmentByIdAysnc(id);
			return Ok(appointment);
		}
		/// <summary>
		/// Delete Appointement
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("DeleteAppointmentByIdAysnc")]
	
		public async Task<IActionResult> DeleteAppointmentByIdAysnc(int id)
		{
			if (!await _appointmentService.AnyExistByIdAysnc(id))
				return NotFound();
			await _appointmentService.DeleteAppointmentByIdAysnc(id);
			return Ok("Delete Completed");
		}
		/// <summary>
		/// Update Appointement
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPut, ActionName("UpdateAppointmentByIdAysnc")]
		public async Task<IActionResult> UpdateAppointmentByIdAysnc(int id,[FromForm] AppointmentDto dto)
		{
			if (!await _appointmentService.AnyExistByIdAysnc(id))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			await _appointmentService.UpdateAppointmentByIdAysnc(id, dto);
			return Ok("Update Completed");
		}
		/// <summary>
		/// Add Appointement
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, ActionName("AddAppointmentAysnc")]
		public async Task<IActionResult> AddAppointmentAysnc([FromForm] AppointmentDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if(!await _doctorService.AnyExistByIdAysnc(dto.DoctorId)) return BadRequest("Doctor Not Found!");
			if (!await _patientService.AnyExistByIdAysnc(dto.PatientId)) return BadRequest("Patient Not Found!");
			await _appointmentService.AddAppointmentAysnc(dto);
			return Ok("Add Completed");
		}
		/// <summary>
		/// GetAll Appointement
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllAsync")]
		public async Task<IActionResult> GetAllAsync() => Ok(await _appointmentService.GetAllAsync());
		/// <summary>
		/// GetAllByDate Appointement
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllByDateAsync")]
		public async Task<IActionResult> GetAllByDateAsync(DateTime date) => Ok(await _appointmentService.GetAllByDateAsync(date));
	}
}
