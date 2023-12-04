using Infrastructure.IRepositories;
using Infrastructure.Repositories;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public async Task DeleteUserByIdAysnc(string userId)
		{
			var user = await _unitOfWork.Users.GetAsync(u => u.Id == userId);
			await _unitOfWork.Users.Delete(user);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task<bool> AnyExistByIdAysnc(string id)
			=> await _unitOfWork.Users.IsAnyExistAsync(u => u.Id == id);
	}
}
