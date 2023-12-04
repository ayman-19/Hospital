using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Schedule
	{
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BreakTime { get; set; }
        public DateTime Day { get; set; }
        public virtual List<DoctorsHaveSchedules> DoctorsHaveSchedules { get; set; }
    }
}
