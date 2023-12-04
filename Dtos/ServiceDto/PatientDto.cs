using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ServiceDto
{
	public class PatientDto
	{
		[Required]
		public string UserId { get; set; }
		[Required]
		public Gender Gender { get; set; }
	}
}
