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
	public class SchedulesController : ControllerBase
	{
		private readonly IScheduleService _scheduleService;

		public SchedulesController(IScheduleService scheduleService)
        {
			_scheduleService = scheduleService;
		}
		/// <summary>
		/// Get Schedule
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetScheduleByIdAysnc")]
		public async Task<IActionResult> GetScheduleByIdAysnc(int id)
		{
			if (!await _scheduleService.AnyExistByIdAysnc(id))
				return NotFound();
			var appointment = await _scheduleService.GetScheduleByIdAysnc(id);
			return Ok(appointment);
		}
		/// <summary>
		/// Delete Schedule
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("DeleteScheduleByIdAysnc")]

		public async Task<IActionResult> DeleteScheduleByIdAysnc(int id)
		{
			if (!await _scheduleService.AnyExistByIdAysnc(id))
				return NotFound();
			await _scheduleService.DeleteScheduleByIdAysnc(id);
			return Ok("Delete Completed");
		}
		/// <summary>
		/// Update Schedule
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPut, ActionName("UpdateScheduleByIdAysnc")]
		public async Task<IActionResult> UpdateScheduleByIdAysnc(int id, [FromForm] ScheduleDto dto)
		{
			if (!await _scheduleService.AnyExistByIdAysnc(id))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			await _scheduleService.UpdateScheduleByIdAysnc(id, dto);
			return Ok("Update Completed");
		}
		/// <summary>
		/// Add Schedule
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, ActionName("AddScheduleAysnc")]
		public async Task<IActionResult> AddScheduleAysnc([FromForm] ScheduleDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			await _scheduleService.AddScheduleAysnc(dto);
			return Ok("Add Completed");
		}
		/// <summary>
		/// GetAll Schedule
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllAsync")]
		public async Task<IActionResult> GetAllAsync() => Ok(await _scheduleService.GetAllAsync());
		/// <summary>
		/// GetAllByDate Schedule
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet, ActionName("GetAllByDateAsync")]
		public async Task<IActionResult> GetAllByDateAsync(DateTime date) => Ok(await _scheduleService.GetAllByDateAsync(date));
	}
}
