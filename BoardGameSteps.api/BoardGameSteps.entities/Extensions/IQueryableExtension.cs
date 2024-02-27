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
		string? propertyName,
		bool isDescending = false
	)
		where TEntity : BaseEntity
	{
		if (propertyName == null)
			return !isDescending
				? query.OrderBy(x => x.Id)
				: query.OrderByDescending(x => x.Id);

		var entityType = typeof(TEntity);
		var property = entityType.GetProperty(propertyName);

		if (property == null)
			throw new ArgumentException($"The {propertyName} property doesn't exist in the {entityType.Name} entity.");

		if (isDescending)
			return query.OrderByDescending(x => property.GetValue(x, null));

		return query.OrderBy(x => property.GetValue(x, null));
	}

	public static IQueryable<TEntity> OrderByDynamic<TEntity>(
		this IQueryable<TEntity> query,
		PropertyInfo? property,
		bool isDescending = false
	)
		where TEntity : BaseEntity
	{
		if (property == null)
			return !isDescending
				? query.OrderBy(x => x.Id)
				: query.OrderByDescending(x => x.Id);

		var entityType = typeof(TEntity);
		var propertyType = property.PropertyType;

		if(!propertyType.Equals(entityType))
			throw new ArgumentException($"The {property.Name} property doesn't exist in the {entityType.Name} entity.");

		if (isDescending)
			return query.OrderByDescending(x => property.GetValue(x, null));

		return query.OrderBy(x => property.GetValue(x, null));
	}

	public static IQueryable<T> AsPagedQuery<T>(
		this IQueryable<T> query,
		int? from,
		int? size
	)
	{
		return query;
	}
}
