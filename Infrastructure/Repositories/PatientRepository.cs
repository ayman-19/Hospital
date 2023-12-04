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
    public class PatientRepository : Repository<Patient>, IPatientRepository
	{
		public PatientRepository(HospitalDbContext context) : base(context)
		{
		}
	}
}
