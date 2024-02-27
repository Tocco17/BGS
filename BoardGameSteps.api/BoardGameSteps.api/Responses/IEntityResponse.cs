using BoardGameSteps.entities.Models;

namespace BoardGameSteps.api.Responses;

public interface IPostEntityResponse<TEntity>
	where TEntity : BaseEntity
{
}

public interface IPutEntityResponse<TEntity>
	where TEntity : BaseEntity
{
}

public interface IDeleteEntityResponse<TEntity>
	where TEntity : BaseEntity
{
}
