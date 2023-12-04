using Domain.Models;
using Infrastructure.DbContext;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
	{
		public DoctorRepository(HospitalDbContext context) : base(context)
		{
		}
	}
}
