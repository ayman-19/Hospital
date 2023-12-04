using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
	[PrimaryKey(nameof(MedicalHistoryId), nameof(DoctorId))]
	public class DoctorsViewHistory
	{

		public int DoctorId { get; set; }
		public int MedicalHistoryId { get; set; }
		[ForeignKey(nameof(MedicalHistoryId))]
		[JsonIgnore]
		public MedicalHistory MedicalHistory { get; set; }
		[ForeignKey(nameof(DoctorId))]
		[JsonIgnore]
		public Doctor Doctor { get; set; }
	}
}
