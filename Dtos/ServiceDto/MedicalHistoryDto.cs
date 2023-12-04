using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ServiceDto
{
	public class MedicalHistoryDto
	{
		[Required]
        public int DoctorId { get; set; }
		[Required]
		public int PatientId { get; set; }
		[Required, DataType(DataType.Date)]
		public DateTime DateTime { get; set; }
		[Required]
		public bool Stutas { get; set; }
		[Required, MaxLength(250)]
		public string Surgeries { get; set; }
		[Required, MaxLength(250)]
		public string Medication { get; set; }
	}
}
