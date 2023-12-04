using Domain.Models;
using Dtos.ServiceDto;
using Infrastructure.IRepositories;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AppointmentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task AddAppointmentAysnc(AppointmentDto dto)
		{
			var appointment = new Appointment
			{
				Date = dto.Date,
				EndTime = dto.EndTime,
				StratTime = dto.StratTime,
				Stutas = dto.Stutas,
			};
			appointment.Diagonses.Add(new Diagonse
			{
				DoctorId = dto.DoctorId,
				Diagnosis = dto.Diagonseis
			});
			appointment.PatientsAttendAppointments.Add(new PatientsAttendAppointments
			{
				PatientId = dto.PatientId,
				Symptoms = dto.Symptoms,
			});
			await _unitOfWork.Appointments.AddAsync(appointment);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task<bool> AnyExistByIdAysnc(int id) =>
			await _unitOfWork.Appointments.IsAnyExistAsync(a => a.Id == id);

		public async Task DeleteAppointmentByIdAysnc(int id)
		{
			var appointment = await _unitOfWork.Appointments.GetAsync(a => a.Id == id, astracking: false);

			await _unitOfWork.Appointments.Delete(appointment);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<IEnumerable<Appointment>> GetAllAsync() =>
			 await _unitOfWork.Appointments.GetAllAsync();

		public async Task<IEnumerable<Appointment>> GetAllByDateAsync(DateTime date) =>
			await _unitOfWork.Appointments.GetAllAsync(a => a.Date.Date.Equals(date.Date));

		public Task<Appointment> GetAppointmentByIdAysnc(int id)
			=> _unitOfWork.Appointments.GetAsync(a => a.Id == id);
		public async Task UpdateAppointmentByIdAysnc(int id, AppointmentDto dto)
		{
			await _unitOfWork.Appointments.Update(new Appointment
			{
				Id = id,
				Date = dto.Date,
				EndTime = dto.EndTime,
				StratTime = dto.StratTime,
				Stutas = dto.Stutas,
			});
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
