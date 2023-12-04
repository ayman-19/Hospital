using Infrastructure.DbContext;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly HospitalDbContext _context;
		protected readonly DbSet<TEntity> _entities;

		public Repository(HospitalDbContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}
		public async Task AddAsync(TEntity entity) =>
		 await _entities.AddAsync(entity);
		public async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
			await _entities.BulkInsertAsync(entities);

		public async Task Delete(TEntity entity) =>
		await Task.Run(() => _entities.Remove(entity));

		public async Task DeleteRangeAsync(IEnumerable<TEntity> entities) =>
			await _entities.BulkDeleteAsync(entities);

		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> pridecate, string[] includes = default!, bool astracking = true)
		{
			var src = _entities.AsQueryable();

			if (!astracking)
				src = src.AsNoTracking();


			if (includes != null)
				foreach (var include in includes)
					src = src.Where(pridecate).Include(include);

			return await src.FirstOrDefaultAsync(pridecate);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> pridecate = null, string[] includes = null, bool astracking = true)
		{
			var src = _entities.AsQueryable();
			if (pridecate is not null)
			{
				if (includes is not null)
				{
					if (!astracking)
						src = src.AsNoTracking();
					foreach (var include in includes)
						src = src.Where(pridecate).Include(include).AsQueryable();
				}
				else
				{
					if (!astracking)
						src = src.AsNoTracking();
					src = src.Where(pridecate).AsQueryable();
				}

			}
			else
			{
				if (includes is not null)
				{
					if (!astracking)
						src = src.AsNoTracking();
					foreach (var include in includes)
						src = src.Include(include).AsQueryable();
				}
				else
				{
					if (!astracking)
						src = src.AsNoTracking();
				}
			}
			return await src.ToListAsync();
		}

		public async Task<bool> IsAnyExistAsync(Expression<Func<TEntity, bool>> pridecate) =>
			 await _entities.AnyAsync(pridecate);

		public async Task Update(TEntity entity) =>
			await Task.Run(() => _entities.Update(entity));

		public async Task UpdateRangeAsync(IEnumerable<TEntity> entities) =>
			await _entities.BulkUpdateAsync(entities);
	}
}
