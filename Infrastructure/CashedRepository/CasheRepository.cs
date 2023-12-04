using Domain.Models;
using Infrastructure.IRepositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CashedRepository
{
	public class CasheRepository : IAppointmentRepository
	{
		private readonly IRepository<Appointment> repository;
		private readonly IMemoryCache memoryCache;
		static string key = "CDC32626-B67A-4D4B-9F80-2DF97410EE7D";
		public CasheRepository(IRepository<Appointment> repository,IMemoryCache memoryCache)
        {
			this.repository = repository;
			this.memoryCache = memoryCache;
		}
		public Task<Appointment>? GetAsync(Expression<Func<Appointment, bool>> pridecate, string[] includes = null, bool astracking = true)
		{
			return memoryCache.GetOrCreate(key,
				async factory =>
				{
					factory.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
					return await repository.GetAsync(pridecate);
				}
				);
		}

		public Task AddAsync(Appointment entity)
		{
			throw new NotImplementedException();
		}

		public Task AddRangeAsync(IEnumerable<Appointment> entities)
		{
			throw new NotImplementedException();
		}

		public Task Delete(Appointment entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteRangeAsync(IEnumerable<Appointment> entities)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Appointment>> GetAllAsync(Expression<Func<Appointment, bool>> pridecate = null, string[] includes = null, bool astracking = true)
		{
			throw new NotImplementedException();
		}

		
		public Task<bool> IsAnyExistAsync(Expression<Func<Appointment, bool>> pridecate)
		{
			throw new NotImplementedException();
		}

		public Task Update(Appointment entity)
		{
			throw new NotImplementedException();
		}

		public Task UpdateRangeAsync(IEnumerable<Appointment> entities)
		{
			throw new NotImplementedException();
		}
	}
}
