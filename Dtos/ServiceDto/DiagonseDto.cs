using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ServiceDto
{
	public class DiagonseDto
	{
        public string DoctorName { get; set; }
        public string Diagonsis { get; set; }
		public DateTime Date { get; set; }
		public DateTime StratTime { get; set; }
		public DateTime EndTime { get; set; }
	}
}
