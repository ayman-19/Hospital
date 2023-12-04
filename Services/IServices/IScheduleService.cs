using Domain.Models;
using Dtos.ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
	public interface IScheduleService
	{
		Task<Schedule> GetScheduleByIdAysnc(int id);
		Task DeleteScheduleByIdAysnc(int id);
		Task UpdateScheduleByIdAysnc(int id, ScheduleDto dto);
		Task AddScheduleAysnc(ScheduleDto dto);
		Task<IEnumerable<Schedule>> GetAllAsync();
		Task<IEnumerable<Schedule>> GetAllByDateAsync(DateTime date);
		Task<bool> AnyExistByIdAysnc(int id);
	}
}
