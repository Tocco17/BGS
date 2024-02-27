using BoardGameSteps.entities.Models;

namespace BoardGameSteps.api.Requests;

public interface IGetEntityRequest<TEntity>
	where TEntity : BaseEntity
{
}

public interface IPostEntityRequest<TEntity>
	where TEntity : BaseEntity
{
}

public interface IPutEntityRequest<TEntity>
	where TEntity : BaseEntity
{
}

public interface IDeleteEntityRequest<TEntity>
	where TEntity : BaseEntity
{
}
