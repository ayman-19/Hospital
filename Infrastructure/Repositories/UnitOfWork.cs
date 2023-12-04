using Infrastructure.DbContext;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly HospitalDbContext context;

		public UnitOfWork(HospitalDbContext context,
			IUserRepository users,
			IAppointmentRepository appointments,
			IDiagonseRepository diagonses,
			IDoctorRepository doctors,
			IDoctorsHaveSchedulesRepository doctorsHaveSchedules,
			IDoctorsViewHistoryRepository doctorsViewHistories,
			IPatientAttendAppointmentRepository patientAttendAppointments,
			IPatientFillHistoryRepository patientFillHistories,
			IPatientRepository patients,
			IRefreshTokenRepository refreshTokens,
			IScheduleRepository schedules,
			IMedicalHistoryRepository medicalHistories)
		{
			this.context = context;
			Users = users;
			Appointments = appointments;
			Diagonses = diagonses;
			Doctors = doctors;
			DoctorsHaveSchedules = doctorsHaveSchedules;
			DoctorsViewHistories = doctorsViewHistories;
			PatientAttendAppointments = patientAttendAppointments;
			PatientFillHistories = patientFillHistories;
			Patients = patients;
			RefreshTokens = refreshTokens;
			Schedules = schedules;
			MedicalHistories = medicalHistories;
		}
		public IUserRepository Users { get; }

		public IAppointmentRepository Appointments { get; }

		public IDiagonseRepository Diagonses { get; }

		public IDoctorRepository Doctors { get; }

		public IDoctorsHaveSchedulesRepository DoctorsHaveSchedules { get; }

		public IDoctorsViewHistoryRepository DoctorsViewHistories { get; }

		public IPatientAttendAppointmentRepository PatientAttendAppointments { get; }

		public IPatientFillHistoryRepository PatientFillHistories { get; }

		public IPatientRepository Patients { get; }

		public IRefreshTokenRepository RefreshTokens { get; }

		public IScheduleRepository Schedules { get; }

		public IMedicalHistoryRepository MedicalHistories { get; }

		public async Task<int> SaveChangesAsync()=>
			await context.SaveChangesAsync();
	}
}
