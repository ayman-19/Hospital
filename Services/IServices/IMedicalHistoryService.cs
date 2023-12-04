using Domain.Models;
using Dtos.ServiceDto;
namespace Services.IServices
{
	public interface IMedicalHistoryService
	{
		Task<MedicalHistory> GetMedicalHistoryByIdAysnc(int id);
		Task DeleteMedicalHistoryByIdAysnc(int id);
		Task UpdateMedicalHistoryByIdAysnc(int id, MedicalHistoryDto dto);
		Task AddMedicalHistoryAysnc(MedicalHistoryDto dto);
		Task<IEnumerable<MedicalHistory>> GetAllAsync();
		Task<IEnumerable<MedicalHistory>> GetAllByDateAsync(DateTime date);
		Task<bool> AnyExistByIdAysnc(int id);
	}
}
