using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
        public IUserRepository Users { get; }
        public IAppointmentRepository Appointments { get; }
        public IMedicalHistoryRepository MedicalHistories { get; }
        public IDiagonseRepository Diagonses { get; }
        public IDoctorRepository Doctors { get; }
        public IDoctorsHaveSchedulesRepository DoctorsHaveSchedules { get; }
        public IDoctorsViewHistoryRepository DoctorsViewHistories { get; }
        public IPatientAttendAppointmentRepository PatientAttendAppointments { get; }
        public IPatientFillHistoryRepository PatientFillHistories { get; }
        public IPatientRepository Patients { get; }
        public IRefreshTokenRepository RefreshTokens { get; }
        public IScheduleRepository Schedules { get; }
    }
}
