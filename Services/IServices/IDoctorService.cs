using Domain.Models;
using Dtos.Presintation;
using Dtos.ServiceDto;

namespace Services.IServices
{
	public interface IDoctorService
	{
		Task<Doctor> GetDoctorByIdAysnc(int id);
		Task<IEnumerable<MedicalHistory>> DoctorViewHistoryAsync(int doctorId);
		Task<Doctor> DeleteDoctorByIdAysnc(int id);
		Task UpdateDoctorByIdAysnc(int id, DoctorDto dto);
		Task AddDoctorAysnc(DoctorDto dto);
		Task<IEnumerable<ViewDoctor>> GetAllAsync();
		Task<bool> AnyExistByIdAysnc(int id);
		Task<IEnumerable<DiagonseDto>> GetAppointmentsDoctorByIdAsync(int doctorId);
		Task AddDoctorToSchduleAsync(int doctorId, int scheduleId);
	}
}
