using Domain.Models;
using Dtos.ServiceDto;
using Infrastructure.IRepositories;
using Services.IServices;

namespace Services.Services
{
	public class PatientService : IPatientService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PatientService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public async Task AddPatientAysnc(PatientDto dto)
		{
			await _unitOfWork.Patients.AddAsync(new Patient
			{
				Gender = dto.Gender,
				UserId = dto.UserId,
			});
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<bool> AnyExistByIdAysnc(int id) => await _unitOfWork.Patients.IsAnyExistAsync(p => p.Id == id);
		public async Task<Patient> DeletePatientByIdAysnc(int id)
		{
			var patient =await _unitOfWork.Patients.GetAsync(p=>p.Id == id, includes: new string[] { "User" });
			await _unitOfWork.Patients.Delete(patient);
			await _unitOfWork.SaveChangesAsync();
			return patient;
		}

		public async Task<IEnumerable<Patient>> GetAllAsync() => await _unitOfWork.Patients.GetAllAsync(includes: new string[] { "User", "PatientFillHistories", "PatientsAttendAppointments" });

		public async Task<Patient> GetPatientByIdAysnc(int id)
			=> await _unitOfWork.Patients.GetAsync(p => p.Id == id, includes: new string[] { "User", "PatientFillHistories", "PatientsAttendAppointments" });

		public async Task UpdatePatientByIdAysnc(int id, PatientDto dto)
		{
			await _unitOfWork.Patients.Update(new Patient
			{
				Id = id,
				UserId = dto.UserId,
				Gender = dto.Gender,
			});
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
