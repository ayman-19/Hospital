using Domain.Models;
using Dtos.ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
	public interface IAppointmentService
	{
		Task<Appointment> GetAppointmentByIdAysnc(int id);
		Task DeleteAppointmentByIdAysnc(int id);
		Task UpdateAppointmentByIdAysnc(int id, AppointmentDto dto);
		Task AddAppointmentAysnc(AppointmentDto dto);
		Task<IEnumerable<Appointment>> GetAllAsync();
		Task<IEnumerable<Appointment>> GetAllByDateAsync(DateTime date);
		Task<bool> AnyExistByIdAysnc(int id);
	}
}
