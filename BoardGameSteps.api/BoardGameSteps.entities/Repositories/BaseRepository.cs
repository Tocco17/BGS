﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Exceptions;
using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Queries;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Repositories;
public abstract class BaseRepository<TEntity> : IRepository<TEntity>
	where TEntity : BaseEntity<TEntity>
{
	protected readonly DbContext _dbContext;
	protected readonly DbSet<TEntity> _dbSet;

	public BaseRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<TEntity>();
	}

	public async Task<int> CountAsync(BaseSelectQuery<TEntity>? query = null)
	{
		var selectQuery = query?.GetCountQuery(_dbSet) ?? _dbSet.AsQueryable();
		var result = await selectQuery.CountAsync();
		return result;
	}

	public Task<int> DeleteAsync(TEntity entity)
	{
		_dbSet.Remove(entity);
		var count = _dbContext.SaveChangesAsync();
		return count;
	}

	public Task<int> DeleteMultipleAsync(IEnumerable<TEntity> entity)
	{
		_dbSet.RemoveRange(entity);
		var count = _dbContext.SaveChangesAsync();
		return count;
	}

	public Task<int> InsertAsync(BaseInsertQuery<TEntity> query)
	{
		query.Validate();

		var entity = query.Initialize();
		_dbSet.AddAsync(entity);

		var count = _dbContext.SaveChangesAsync();
		return count;
	}

	public Task<int> InsertMultipleAsync(IEnumerable<TEntity> entity)
	{
		_dbSet.AddRangeAsync(entity);
		var count = _dbContext.SaveChangesAsync();
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

	public Task<int> UpdateAsync(TEntity entity)
	{
		_dbSet.Update(entity);
		var count = _dbContext.SaveChangesAsync();
		return count;
	}

	public Task<int> UpdateMultipleAsync(IEnumerable<TEntity> entity)
	{
		_dbSet.UpdateRange(entity);
		var count = _dbContext.SaveChangesAsync();
		return count;
	}
}