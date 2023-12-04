using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Jwt
{
	public class LoginDto
	{
		[Required]
		[DataType(DataType.EmailAddress),MaxLength(255)]
        public string Email { get; set; }
		[Required]
		[DataType(DataType.Password), MinLength(8)]
		public string Password { get; set; }
	}
}
