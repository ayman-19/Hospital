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
    public class MedicalHistoryRepository : Repository<MedicalHistory>, IMedicalHistoryRepository
	{
		public MedicalHistoryRepository(HospitalDbContext context) : base(context)
		{
		}
	}
}
