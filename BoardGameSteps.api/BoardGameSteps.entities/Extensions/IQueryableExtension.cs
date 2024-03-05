using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;

namespace BoardGameSteps.entities.Extensions;
public static class IQueryableExtension
{
	public static IQueryable<TEntity> OrderByDynamic<TEntity>(
		this IQueryable<TEntity> query,
		PropertyInfo? property,
		bool isDescending = false
	)
		where TEntity : BaseEntity<TEntity>
	{
		if (property == null)
			return !isDescending
				? query.OrderBy(x => x.Id)
				: query.OrderByDescending(x => x.Id);

		var entityType = typeof(TEntity);
		var propertyType = entityType.GetProperty(property.Name);

		if (propertyType == null)
			throw new ArgumentException($"The {property.Name} property doesn't exist in the {entityType.Name} entity.");

		if (isDescending)
			return query.OrderByDescending(x => property.GetValue(x, null));

		return query.OrderBy(x => property.GetValue(x, null));
	}

	public static IQueryable<T> AsPagedQuery<T>(
		this IQueryable<T> query,
		int? from = null,
		int? size = null
	)
	{
		if (from == null && size == null)
			return query;

		if(size < 0)
			throw new ArgumentException("Size value can't be a negative number");

		if(from < 0)
			throw new ArgumentException("From value can't be a negative number");

		var sizeNotNullValue = size ?? 0;
		var fromNotNullValue = from ?? 1;
		var page = sizeNotNullValue * (fromNotNullValue - 1);

		if (page < 0) 
			page = 0;

		var skippedQuery = query.Skip(page);

		if(size == null)
			return skippedQuery;

		var takeQuery = query.Take(size.Value);

		return takeQuery;
	}
}
