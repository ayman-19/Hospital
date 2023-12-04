using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [PrimaryKey(nameof(PatientId),nameof(MedicalHistoryId))]
	public class PatientFillHistory
	{
        public int PatientId { get; set; }
        public int MedicalHistoryId { get; set; }
        [ForeignKey(nameof(MedicalHistoryId))]
        public MedicalHistory MedicalHistory { get; set; }
		[ForeignKey(nameof(PatientId))]

		public Patient Patient { get; set; }
    }
}
