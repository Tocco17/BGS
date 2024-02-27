using BoardGameSteps.api.Requests;
using BoardGameSteps.api.Responses;
using BoardGameSteps.entities.Models;

using Microsoft.AspNetCore.Mvc;

namespace BoardGameSteps.api.Controllers;

public interface IEntityController<TEntity>
	where TEntity : BaseEntity
{
	Task<ActionResult<IEnumerable<TEntity>>> GetAsync(IGetEntityRequest<TEntity> request);
	Task<ActionResult<TEntity>> GetByIdAsync(int id);
	Task<ActionResult<int>> GetCountAsync(IGetEntityRequest<TEntity> request);
	Task<ActionResult<IPostEntityResponse<TEntity>>> PostAsync(IPostEntityRequest<TEntity> request);
	Task<ActionResult<IEnumerable<IPostEntityResponse<TEntity>>>> PostMultipleAsync(IEnumerable<IPostEntityRequest<TEntity>> requests);
	Task<ActionResult<IPutEntityResponse<TEntity>>> PutAsync(IPutEntityRequest<TEntity> request);
	Task<ActionResult<IDeleteEntityResponse<TEntity>>> DeleteAsync(IDeleteEntityRequest<TEntity> request);
}
