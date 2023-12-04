

using Domain.Models;
using Infrastructure.DbContext;
using Infrastructure.IRepositories;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
	{
		public UserRepository(HospitalDbContext context) : base(context)
		{
		}
	}
}
