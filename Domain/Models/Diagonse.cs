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
    [PrimaryKey(nameof(AppointmentId),nameof(DoctorId))]
	public class Diagonse
	{
        public string Diagnosis { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey(nameof(AppointmentId))]
		[JsonIgnore]
		public Appointment Appointment { get; set; }
        [ForeignKey(nameof(DoctorId))]
        [JsonIgnore]
        public Doctor Doctors { get; set; }
    }
}
