using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Extensions;
using BoardGameSteps.entities.Models;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Queries;
public abstract class BaseSelectQuery<TEntity>
	where TEntity : BaseEntity<TEntity>
{
	public Guid? Id { get; set; } = null;
	public int? From { get; set; } = null;
    public int? Size { get; set; } = null;
	public PropertyInfo? OrderBy { get; set; } = null;
	public bool IsOrderDescending { get; set; } = false;

    public IQueryable<TEntity> GetSelectQuery(DbSet<TEntity> dbSet)
	{
		var query = GetBaseSelectQuery(dbSet);
		query = GetOrderedQuery(query);
		query = query.AsPagedQuery(From, Size);
		query = Include(query);
		return query;
	}

    public IQueryable<TEntity> GetSelectFirstQuery(DbSet<TEntity> dbSet)
	{
		var query = GetBaseSelectQuery(dbSet);
		query = GetOrderedQuery(query);
		query = query.AsPagedQuery(size: 1);
		query = Include(query);
		return query;
	}

	public IQueryable<TEntity> GetCountQuery(DbSet<TEntity> dbSet)
	{
		var query = GetBaseSelectQuery(dbSet);
		return query;
	}

	public IOrderedQueryable<TEntity> GetOrderedQuery(IQueryable<TEntity> query)
	{
		var orderedQuery = query.OrderByDynamic(OrderBy, IsOrderDescending);
		return orderedQuery;
	}

	private IQueryable<TEntity> GetBaseSelectQuery(DbSet<TEntity> dbSet)
	{
		var query = dbSet.AsQueryable();

		if (Id != null)
			query = query.Where(x => x.Id == Id);

		query = GetSelectQuery(query);

		return query;
	}


	protected abstract IQueryable<TEntity> GetSelectQuery(IQueryable<TEntity> query);
	protected abstract IQueryable<TEntity> Include(IQueryable<TEntity> query);
}
