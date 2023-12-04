using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ServiceDto
{
	public class ScheduleDto
	{
		[Required,DataType(DataType.DateTime)]
		public DateTime StartTime { get; set; }
		[Required, DataType(DataType.DateTime)]
		public DateTime EndTime { get; set; }
		[Required, DataType(DataType.DateTime)]
		public DateTime BreakTime { get; set; }
		[Required, DataType(DataType.Date)]
		public DateTime Day { get; set; }
	}
}
