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
	where TEntity : BaseEntity
{
	public Guid? Id { get; set; } = null;
	public int? From { get; set; } = null;
    public int? Size { get; set; } = null;
	public PropertyInfo? OrderBy { get; set; } = null;
	public bool IsOrderDescending { get; set; } = false;

    public IQueryable<TEntity> GetSelectQuery(DbSet<TEntity> dbSet)
	{
		var query = GetBaseSelectQuery(dbSet);
		query = query.AsPagedQuery(From, Size);
		return query;
	}

    public IQueryable<TEntity> GetSelectFirstQuery(DbSet<TEntity> dbSet)
	{
		var query = GetBaseSelectQuery(dbSet);
		query = query.AsPagedQuery(size: 1);
		return query;
	}

	public IQueryable<TEntity> GetCountQuery(DbSet<TEntity> dbSet)
	{
		var query = GetBaseSelectQuery(dbSet);
		return query;
	}

	private IQueryable<TEntity> GetBaseSelectQuery(DbSet<TEntity> dbSet)
	{
		var query = dbSet.AsQueryable();

		if (Id != null)
			query = query.Where(x => x.Id == Id);

		query = GetSelectQuery(query);
		query = query.OrderByDynamic(OrderBy, IsOrderDescending);

		return query;
	}

	protected abstract IQueryable<TEntity> GetSelectQuery(IQueryable<TEntity> query);
}
