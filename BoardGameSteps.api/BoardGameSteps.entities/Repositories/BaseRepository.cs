using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Queries;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Repositories;
public abstract class BaseRepository<TEntity>(DbContext dbContext) : IRepository<TEntity>
	where TEntity : BaseEntity<TEntity>
{
	protected readonly DbContext _dbContext = dbContext;
	protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

	public async Task<int> CountAsync(BaseSelectQuery<TEntity>? query = null)
	{
		var selectQuery = query?.GetCountQuery(_dbSet) ?? _dbSet.AsQueryable();
		var result = await selectQuery.CountAsync();
		return result;
	}

	public async Task<int> DeleteAsync(BaseDeleteQuery<TEntity> query)
	{
		query.Validate();
		var entity = query.Entity;
		_dbSet.Remove(entity);
		var count = await _dbContext.SaveChangesAsync();
		return count;
	}

	public async Task<int> DeleteMultipleAsync(IEnumerable<BaseDeleteQuery<TEntity>> queries)
	{
		foreach(var query in queries)
			query.Validate();

		var entities = queries.Select(x => x.Entity);
		_dbSet.RemoveRange(entities);
		var count = await _dbContext.SaveChangesAsync();
		return count;
	}

	public async Task<int> InsertAsync(BaseInsertQuery<TEntity> query)
	{
		query.Validate();

		var entity = query.Initialize();
		await _dbSet.AddAsync(entity);

		var count = await _dbContext.SaveChangesAsync();
		return count;
	}

	public async Task<int> InsertMultipleAsync(IEnumerable<BaseInsertQuery<TEntity>> queries)
	{
		foreach (var query in queries)
			query.Validate();

		var entities = queries.Select(q => q.Initialize());

		await _dbSet.AddRangeAsync(entities);
		var count = await _dbContext.SaveChangesAsync();
		return count;
	}

	public async Task<IEnumerable<TEntity>> SelectAsync(BaseSelectQuery<TEntity>? query = null)
	{
		var selectQuery = query?.GetSelectQuery(_dbSet) ?? _dbSet.AsQueryable();
		var result = await selectQuery.ToListAsync();
		return result;
	}

	public async Task<TEntity?> SelectFirstOrDefaultAsync(BaseSelectQuery<TEntity>? query = null)
	{
		var selectQuery = query?.GetSelectFirstQuery(_dbSet) ?? _dbSet.AsQueryable();
		var result = await selectQuery.FirstOrDefaultAsync();
		return result;
	}

	public async Task<TEntity?> SelectSingleOrDefaultAsync(BaseSelectQuery<TEntity>? query = null)
	{
		var selectQuery = query?.GetSelectQuery(_dbSet) ?? _dbSet.AsQueryable();
		var result = await selectQuery.SingleOrDefaultAsync();
		return result;
	}

	public async Task<int> UpdateAsync(BaseUpdateQuery<TEntity> query)
	{
		query.Validate();

		var entity = query.Initialize();
		_dbSet.Update(entity);

		var count = await _dbContext.SaveChangesAsync();
		return count;
	}

	public async Task<int> UpdateMultipleAsync(IEnumerable<BaseUpdateQuery<TEntity>> queries)
	{
		foreach (var query in queries)
			query.Validate();

		var entities = queries.Select(q => q.Initialize());

		_dbSet.UpdateRange(entities);

		var count = await _dbContext.SaveChangesAsync();
		return count;
	}
}