using Domain.Models;
using Dtos.ServiceDto;
using Infrastructure.IRepositories;
using Services.IServices;

namespace Services.Services
{
	public class ScheduleService : IScheduleService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ScheduleService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task AddScheduleAysnc(ScheduleDto dto)
		{
			await _unitOfWork.Schedules.AddAsync(new Schedule
			{
				BreakTime = dto.BreakTime,
				Day = dto.Day,
				EndTime = dto.EndTime,
				StartTime = dto.StartTime,
			});
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<bool> AnyExistByIdAysnc(int id) => await _unitOfWork.Schedules.IsAnyExistAsync(s => s.Id == id);
		public async Task DeleteScheduleByIdAysnc(int id)
		{
			var schedule = await _unitOfWork.Schedules.GetAsync(s => s.Id == id, astracking: false);
			await _unitOfWork.Schedules.Delete(schedule);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<IEnumerable<Schedule>> GetAllAsync() => await _unitOfWork.Schedules.GetAllAsync(includes: new string[] { "DoctorsHaveSchedules" });

		public async Task<IEnumerable<Schedule>> GetAllByDateAsync(DateTime date) => await _unitOfWork.Schedules.GetAllAsync(s => s.Day.Day == date.Day, includes: new string[] { "DoctorsHaveSchedules" });
		public async Task<Schedule> GetScheduleByIdAysnc(int id) => await _unitOfWork.Schedules.GetAsync(s => s.Id == id, new string[] { "DoctorsHaveSchedules" });

		public async Task UpdateScheduleByIdAysnc(int id, ScheduleDto dto)
		{
			await _unitOfWork.Schedules.Update(new Schedule
			{
				Id = id,
				Day = dto.Day,
				BreakTime = dto.BreakTime,
				EndTime = dto.EndTime,
				StartTime = dto.StartTime,
			});
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
