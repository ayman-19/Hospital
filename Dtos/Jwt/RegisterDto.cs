using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Jwt
{
	public class RegisterDto
	{
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
		[Required]
		[MaxLength(100)]
		public string LastName { get; set; }
		[Required]
		[MaxLength(300)]
		public string Address { get; set; }
		[Required]
		[MaxLength(100)]
		public string UsarName { get; set; }
		[Required]
		[DataType(DataType.EmailAddress),MaxLength(250)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
		[Required]
		[MinLength(8)]
		public string Password { get; set; }
		[DataType(DataType.Password),Compare(nameof(Password))]
		[Required]
		[MinLength(8)]
		public string ConfirmPassword { get; set; }

    }
}
