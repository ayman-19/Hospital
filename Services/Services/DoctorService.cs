using Domain.Models;
using Dtos.Presintation;
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
	public class DoctorService : IDoctorService
	{
		private readonly IUnitOfWork _unitOfWork;

		public DoctorService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task AddDoctorAysnc(DoctorDto dto)
		{
			await _unitOfWork.Doctors.AddAsync(new Doctor
			{
				Gender = dto.Gender,
				UserId = dto.UserId,
			});
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task AddDoctorToSchduleAsync(int doctorId, int scheduleId)
		{
			if (!await _unitOfWork.DoctorsHaveSchedules.IsAnyExistAsync(d => d.DoctorId == doctorId && d.ScheduleId == scheduleId))
				await _unitOfWork.DoctorsHaveSchedules.AddAsync(new DoctorsHaveSchedules
				{
					DoctorId = doctorId,
					ScheduleId = scheduleId
				});
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<bool> AnyExistByIdAysnc(int id)
		=> await _unitOfWork.Doctors.IsAnyExistAsync(d => d.Id == id);

		public async Task<Doctor> DeleteDoctorByIdAysnc(int id)
		{
			var doctor = await _unitOfWork.Doctors.GetAsync(includes: new string[] { "User" }, pridecate: d => d.Id == id, astracking: false);
			await _unitOfWork.Doctors.Delete(doctor);
			await _unitOfWork.SaveChangesAsync();
			return doctor;
		}

		public async Task<IEnumerable<MedicalHistory>> DoctorViewHistoryAsync(int doctorId)
		{
			var doctor = await GetDoctorByIdAysnc(doctorId);
			if (doctor.DoctorsViewHistories is not null)
			{
				var histories = doctor.DoctorsViewHistories.Select(h => h.MedicalHistory).ToList();
				return histories;
			}
			return new List<MedicalHistory>();
		}

		public async Task<IEnumerable<ViewDoctor>> GetAllAsync()
		{
			var doctors = await _unitOfWork.Doctors.GetAllAsync(includes: new string[] { "User", "Diagonses", "DoctorsViewHistories" });
			var views = doctors.Select(d => new ViewDoctor
			{
				Address = d.User.Address,
				Diagonsis = d.Diagonses!.Select(d => d.Diagnosis).ToList(),
				Gender = d.Gender.ToString(),
				Name = $"{d.User.FirstName} {d.User.LastName}"
			});
			return views;
		}
		

		public async Task<IEnumerable<DiagonseDto>> GetAppointmentsDoctorByIdAsync(int doctorId)
		{
			var doctor = await GetDoctorByIdAysnc(doctorId);
			var appointments = doctor.Diagonses!.Select(a => new DiagonseDto
			{
				DoctorName = $"{doctor.User.FirstName} {doctor.User.LastName}",
				Diagonsis = a.Diagnosis,
				Date = a.Appointment.Date,
				EndTime = a.Appointment.EndTime,
				StratTime = a.Appointment.StratTime,
			}).ToList();
			return appointments;
		}

		public async Task<Doctor> GetDoctorByIdAysnc(int id)
		=> await _unitOfWork.Doctors.GetAsync(d => d.Id == id, includes: new string[] { "User", "Diagonses.Appointment", "DoctorsViewHistories.MedicalHistory" }, astracking: false);

		public async Task UpdateDoctorByIdAysnc(int id, DoctorDto dto)
		{
			await _unitOfWork.Doctors.Update(new Doctor
			{
				Id = id,
				Gender = dto.Gender,
				UserId = dto.UserId,
			});
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
