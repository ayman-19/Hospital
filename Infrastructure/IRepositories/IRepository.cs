
using System.Linq.Expressions;

namespace Infrastructure.IRepositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task AddAsync(TEntity entity);
		Task Update(TEntity entity);
		Task Delete(TEntity entity);
		Task<bool> IsAnyExistAsync(Expression<Func<TEntity, bool>> pridecate);
		Task AddRangeAsync(IEnumerable<TEntity> entities);
		Task UpdateRangeAsync(IEnumerable<TEntity> entities);
		Task DeleteRangeAsync(IEnumerable<TEntity> entities);
		Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> pridecate, string[] includes= default!, bool astracking = true);
		Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> pridecate = default!, string[] includes = default!, bool astracking = true);
	}
}
