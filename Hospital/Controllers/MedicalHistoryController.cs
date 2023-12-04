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
	public class MedicalHistoryController : ControllerBase
	{
		private readonly IMedicalHistoryService _medicalHistoryService;
		private readonly IDoctorService _doctorService;

		public MedicalHistoryController(IMedicalHistoryService medicalHistoryService,IDoctorService doctorService)
		{
			_medicalHistoryService = medicalHistoryService;
			_doctorService = doctorService;
		}
		/// <summary>
		/// Get MedicalHistory
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetMedicalHistoryByIdAysnc")]
		public async Task<IActionResult> GetMedicalHistoryByIdAysnc(int id)
		{
			if (!await _medicalHistoryService.AnyExistByIdAysnc(id))
				return NotFound();
			var appointment = await _medicalHistoryService.GetMedicalHistoryByIdAysnc(id);
			return Ok(appointment);
		}
		/// <summary>
		/// Delete MedicalHistory
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("DeleteMedicalHistoryByIdAysnc")]

		public async Task<IActionResult> DeleteMedicalHistoryByIdAysnc(int id)
		{
			if (!await _medicalHistoryService.AnyExistByIdAysnc(id))
				return NotFound();

			await _medicalHistoryService.DeleteMedicalHistoryByIdAysnc(id);
			return Ok("Delete Completed");
		}
		/// <summary>
		/// Update MedicalHistory
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPut, ActionName("UpdateMedicalHistoryByIdAysnc")]
		public async Task<IActionResult> UpdateMedicalHistoryByIdAysnc(int id, [FromForm] MedicalHistoryDto dto)
		{
			if (!await _medicalHistoryService.AnyExistByIdAysnc(id))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			await _medicalHistoryService.UpdateMedicalHistoryByIdAysnc(id, dto);
			return Ok("Update Completed");
		}
		/// <summary>
		/// Add MedicalHistory
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, ActionName("AddMedicalHistoryAysnc")]
		public async Task<IActionResult> AddMedicalHistoryAysnc([FromForm] MedicalHistoryDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (!await _doctorService.AnyExistByIdAysnc(dto.DoctorId))
				return BadRequest("Doctor Not Found!");
			await _medicalHistoryService.AddMedicalHistoryAysnc(dto);
			return Ok("Add Completed");
		}
		/// <summary>
		/// GetAll MedicalHistory
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllAsync")]
		public async Task<IActionResult> GetAllAsync() => Ok(await _medicalHistoryService.GetAllAsync());
		/// <summary>
		/// GetAllByDate MedicalHistory
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllByDateAsync")]
		public async Task<IActionResult> GetAllByDateAsync(DateTime date) => Ok(await _medicalHistoryService.GetAllByDateAsync(date));
	}
}
