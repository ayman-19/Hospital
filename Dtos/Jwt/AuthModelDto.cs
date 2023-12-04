using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Jwt
{
	public class AuthModelDto
	{
        public string UserId { get; set; }
        public string Massage { get; set; }
        public bool IsAuthanticated { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpireOn { get; set; }
        public DateTime RefreshTokenExpireOn { get; set; }
    }
}
