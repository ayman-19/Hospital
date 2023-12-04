using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	[PrimaryKey(nameof(PatientId), nameof(AppointmentId))]

	public class PatientsAttendAppointments
	{
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }
		[ForeignKey(nameof(AppointmentId))]
		public Appointment Appointment { get; set; }
        public string Symptoms { get; set; }
    }
}
