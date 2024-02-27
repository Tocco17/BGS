using BoardGameSteps.api.Requests;
using BoardGameSteps.api.Responses;
using BoardGameSteps.entities.Models;

using Microsoft.AspNetCore.Mvc;

namespace BoardGameSteps.api.Controllers;

public class BaseEntityController<TEntity> : ControllerBase, IEntityController<TEntity>
	where TEntity : BaseEntity
{
	public Task<ActionResult<IDeleteEntityResponse<TEntity>>> DeleteAsync(IDeleteEntityRequest<TEntity> request)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<IEnumerable<TEntity>>> GetAsync(IGetEntityRequest<TEntity> request)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<TEntity>> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<int>> GetCountAsync(IGetEntityRequest<TEntity> request)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<IPostEntityResponse<TEntity>>> PostAsync(IPostEntityRequest<TEntity> request)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<IEnumerable<IPostEntityResponse<TEntity>>>> PostMultipleAsync(IEnumerable<IPostEntityRequest<TEntity>> requests)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<IPutEntityResponse<TEntity>>> PutAsync(IPutEntityRequest<TEntity> request)
	{
		throw new NotImplementedException();
	}
}
