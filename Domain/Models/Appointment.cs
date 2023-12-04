using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Appointment
	{
        public Appointment()
        {
            Diagonses = new (0);
			PatientsAttendAppointments = new(0);
		}
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StratTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Stutas { get; set; }
        public List<Diagonse>? Diagonses { get; set; }
        public List<PatientsAttendAppointments>? PatientsAttendAppointments { get; set; }
    }
}
