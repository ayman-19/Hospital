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
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
	{
		public AppointmentRepository(HospitalDbContext context) : base(context)
		{
		}
	}
}
