using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Repositories;
public abstract class BaseRepository<TEntity> 
	where TEntity : BaseEntity
{
	protected readonly DbContext _dbContext;
	protected readonly DbSet<TEntity> _dbSet;

	public BaseRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<TEntity>();
	}

	public Task<TDbResponse> SelectAsync<TDbResponse>(IDbRequest<TEntity, TDbResponse> request)
	{
		var query = _dbSet.AsSelectQueriable(request);


		throw new NotImplementedException();
	}
}

public interface IDbRequest<TEntity, TDbResponse>
	where TEntity : BaseEntity
{
	IQueryable<TDbResponse> Query(DbSet<TEntity> dbSet);
}