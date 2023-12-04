using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.JwtServices
{
	public class Jwt
	{
        public string Key { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public double AccessTokenExiretionDate { get; set; }
        public double RefreshTokenExiretionDate { get; set; }
    }
}
