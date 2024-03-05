using BoardGameSteps.entities.Models;

namespace BoardGameSteps.api.Responses;

public interface IPostEntityResponse<TEntity>
	where TEntity : BaseEntity<TEntity>
{
}

public interface IPutEntityResponse<TEntity>
	where TEntity : BaseEntity<TEntity>
{
}

public interface IDeleteEntityResponse<TEntity>
	where TEntity : BaseEntity<TEntity>
{
}
