using Domain.Models;
using Dtos.ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
	public interface IPatientService
	{
		Task<Patient> GetPatientByIdAysnc(int id);
		Task<Patient> DeletePatientByIdAysnc(int id);
		Task UpdatePatientByIdAysnc(int id, PatientDto dto);
		Task AddPatientAysnc(PatientDto dto);
		Task<IEnumerable<Patient>> GetAllAsync();
		Task<bool> AnyExistByIdAysnc(int id);
	}
}
