using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ServiceDto
{
	public class AppointmentDto
	{
		[Required,DataType(DataType.Date)]
		public DateTime Date { get; set; }
		[Required, DataType(DataType.DateTime)]
		public DateTime StratTime { get; set; }
		[Required, DataType(DataType.DateTime)]
		public DateTime EndTime { get; set; }
		[Required]
		public bool Stutas { get; set; }
		[Required]
		public int DoctorId { get; set; }
		[Required]
		public int PatientId { get; set; }
		[Required]
		public string Diagonseis { get; set; }
		[Required]
		public string Symptoms { get; set; }
	}
}
