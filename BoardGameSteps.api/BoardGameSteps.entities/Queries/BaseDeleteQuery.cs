using BoardGameSteps.entities.Exceptions;
using BoardGameSteps.entities.Models;

namespace BoardGameSteps.entities.Queries;
public abstract class BaseDeleteQuery<TEntity>(TEntity entity)
	where TEntity : BaseEntity<TEntity>
{
	public TEntity Entity { get; set; } = entity;

	/// <summary>
	/// 
	/// </summary>
	/// <exception cref="DeleteQueryValidateException"></exception>
	public void Validate()
	{
		var errors = GetValidateErrors();

		if (errors == null)
			return;

		if (errors.Count == 0)
			return;

		var errorMessage = string.Join("\n", errors);

		throw new DeleteQueryValidateException(errorMessage);
	}

	protected abstract List<string> GetValidateErrors();
}
