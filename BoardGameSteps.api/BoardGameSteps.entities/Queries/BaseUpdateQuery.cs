﻿using BoardGameSteps.entities.Exceptions;
using BoardGameSteps.entities.Models;

namespace BoardGameSteps.entities.Queries;
public abstract class BaseUpdateQuery<TEntity>(TEntity entity)
	where TEntity : BaseEntity<TEntity>
{
	public TEntity Entity { get; set; } = entity;

	/// <summary>
	/// 
	/// </summary>
	/// <exception cref="UpdateQueryValidateException"></exception>
	public void Validate()
	{
		var errors = GetValidateErrors();

		if (errors == null)
			return;

		if (errors.Count == 0)
			return;

		var errorMessage = string.Join("\n", errors);

		throw new UpdateQueryValidateException(errorMessage);
	}

	public TEntity Initialize()
	{
		var entity = GetInizitializedEntity();
		entity.Id = Guid.NewGuid();
		return entity;
	}

	protected abstract TEntity GetInizitializedEntity();

	protected abstract List<string> GetValidateErrors();
}
