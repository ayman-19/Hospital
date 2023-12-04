using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Presintation
{
	public class ViewDoctor
	{
        public string Name { get; set; }
        public List<string> Diagonsis { get; set; }
		public string Address { get; set; }
		public string Gender { get; set; }
	}
}
