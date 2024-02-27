using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Repositories;
public class UserRepository
{
	protected readonly DbContext _dbContext;
	protected readonly DbSet<User> _dbSet;

	public UserRepository(DbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<User>();
	}

	public Task<TDbResponse> SelectAsync<TDbResponse>(IDbRequest<TEntity, TDbResponse> request)
	{
		var query = _dbSet.AsSelectQueriable(request);


		throw new NotImplementedException();
	}
}
