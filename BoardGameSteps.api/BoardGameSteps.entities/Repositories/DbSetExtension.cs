using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Repositories;
public static class DbSetExtension
{
	public static IQueryable<TEntity> AsSelectQueriable<TEntity, TDbResponse>(this DbSet<TEntity> dbSet, IDbRequest<TEntity, TDbResponse> request)
		where TEntity : BaseEntity
	{
		throw new NotImplementedException();
	}
}
