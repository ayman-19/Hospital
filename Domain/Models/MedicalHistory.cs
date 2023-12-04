using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class MedicalHistory
	{
		public int Id { get; set; }
		public DateTime DateTime { get; set; }
		public bool Stutas { get; set; }
		public string Surgeries { get; set; }
		public string Medication { get; set; }
		public List<DoctorsViewHistory>? DoctorsViewHistories { get; set; }
		public List<PatientFillHistory>? PatientFillHistories { get; set; }


		public MedicalHistory()
		{
			DoctorsViewHistories = new List<DoctorsViewHistory>(0);
			PatientFillHistories = new List<PatientFillHistory>(0);
		}
	}
}
