using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Queries;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Repositories;
public abstract class BaseRepository<TEntity> : IRepository<TEntity>
	where TEntity : BaseEntity
{
	protected readonly DbContext _dbContext;
	protected readonly DbSet<TEntity> _dbSet;

	public BaseRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<TEntity>();
	}

	public async Task<IEnumerable<TEntity>> SelectAsync(BaseSelectQuery<TEntity>? query = null)
	{
		var selectQuery = query?.GetSelectQuery(_dbSet) ?? _dbSet.AsQueryable();
		var result = await selectQuery.ToListAsync();
		return result;
	}
}