using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Exceptions;

namespace BoardGameSteps.entities.Queries;
public abstract class BaseInsertQuery<TEntity>
	where TEntity : BaseEntity<TEntity>
{
    public TEntity Entity { get; set; } = null!;

	protected BaseInsertQuery(TEntity entity)
	{
		Entity = entity;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <exception cref="InsertQueryValidateException"></exception>
	public void Validate()
	{
		var errors = GetValidateErrors();

		if(errors == null) 
			return;

		if (errors.Count == 0)
			return;

		var errorMessage = string.Join("\n", errors);

		throw new InsertQueryValidateException(errorMessage);
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
