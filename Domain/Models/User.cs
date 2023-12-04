using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class User : IdentityUser
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
