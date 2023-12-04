using Domain.Models;
using Dtos.ServiceDto;
using Infrastructure.IRepositories;
using Services.IServices;

namespace Services.Services
{
	public class MedicalHistoryService : IMedicalHistoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public MedicalHistoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task AddMedicalHistoryAysnc(MedicalHistoryDto dto)
		{
			var history = new MedicalHistory
			{
				DateTime = dto.DateTime,
				Medication = dto.Medication,
				Stutas = dto.Stutas,
				Surgeries = dto.Surgeries,
			};

			history.DoctorsViewHistories!.Add(new DoctorsViewHistory
			{
				DoctorId = dto.DoctorId,
			});
			history.PatientFillHistories!.Add(new PatientFillHistory
			{
				PatientId = dto.PatientId,
			});
			 await _unitOfWork.MedicalHistories.AddAsync(history);

			await _unitOfWork.SaveChangesAsync();
		}
		public async Task AddRangeMedicalHistoryAysnc(IEnumerable<MedicalHistoryDto> dtos)
		{
			List<MedicalHistory> MedicalHistory = new List<MedicalHistory>();

			foreach (var dto in dtos)
				MedicalHistory.Add(new MedicalHistory
				{
					Surgeries = dto.Surgeries,
					DateTime = dto.DateTime,
					Medication = dto.Medication,
					Stutas = dto.Stutas
				});
			await _unitOfWork.MedicalHistories.AddRangeAsync(MedicalHistory);
		}
		public Task<bool> AnyExistByIdAysnc(int id) => _unitOfWork.MedicalHistories.IsAnyExistAsync(m => m.Id == id);

		public async Task DeleteMedicalHistoryByIdAysnc(int id)
		{
			var entity = await _unitOfWork.MedicalHistories.GetAsync(m => m.Id == id, astracking: false);
			await _unitOfWork.MedicalHistories.Delete(entity);
			await _unitOfWork.SaveChangesAsync();
		}


		public async Task<IEnumerable<MedicalHistory>> GetAllAsync() => await _unitOfWork.MedicalHistories.GetAllAsync();

		public async Task<IEnumerable<MedicalHistory>> GetAllByDateAsync(DateTime date) => await _unitOfWork.MedicalHistories.GetAllAsync(m => m.DateTime.Day == date.Day);


		public async Task<MedicalHistory> GetMedicalHistoryByIdAysnc(int id) => await _unitOfWork.MedicalHistories.GetAsync(m => m.Id == id);

		public async Task UpdateMedicalHistoryByIdAysnc(int id, MedicalHistoryDto dto)
		{
			await _unitOfWork.MedicalHistories.Update(new MedicalHistory
			{
				Id = id,
				DateTime = dto.DateTime,
				Medication = dto.Medication,
				Stutas = dto.Stutas,
				Surgeries = dto.Surgeries,
			});
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
