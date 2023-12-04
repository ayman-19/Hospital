using Domain.Models;
using Dtos.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Services;

namespace Hospital.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize]
	public class PatientController : ControllerBase
	{
		private readonly IPatientService _patientService;
		private readonly IUserService _userService;

		public PatientController(IPatientService patientService,IUserService userService)
        {
			_patientService = patientService;
			_userService = userService;
		}
	
		/// <summary>
		/// Get Patient
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetPatientByIdAysnc")]
		public async Task<IActionResult> GetPatientByIdAysnc(int id)
		{
			if (!await _patientService.AnyExistByIdAysnc(id))
				return NotFound();
			var appointment = await _patientService.GetPatientByIdAysnc(id);
			return Ok(appointment);
		}
		/// <summary>
		/// Delete Patient
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("DeletePatientByIdAysnc")]

		public async Task<IActionResult> DeletePatientByIdAysnc(int id)
		{
			if (!await _patientService.AnyExistByIdAysnc(id))
				return NotFound();

			var doctor = await _patientService.DeletePatientByIdAysnc(id);
			await _userService.DeleteUserByIdAysnc(doctor.UserId);
			return Ok("Delete Completed");
		}
		/// <summary>
		/// Update Patient
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPut, ActionName("UpdatePatientByIdAysnc")]
		public async Task<IActionResult> UpdatePatientByIdAysnc(int id, [FromForm] PatientDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!await _patientService.AnyExistByIdAysnc(id))
				return NotFound();

			await _patientService.UpdatePatientByIdAysnc(id, dto);
			return Ok("Update Completed");
		}
		/// <summary>
		/// Add Patient
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, ActionName("AddPatientAysnc")]
		public async Task<IActionResult> AddPatientAysnc([FromForm] PatientDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (!await _userService.AnyExistByIdAysnc(dto.UserId))
				return BadRequest("Not Register!");
			await _patientService.AddPatientAysnc(dto);
			return Ok("Add Completed");
		}
		/// <summary>
		/// GetAll Patient
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllAsync")]
		public async Task<IActionResult> GetAllByAsync() => Ok(await _patientService.GetAllAsync());
	}
}
