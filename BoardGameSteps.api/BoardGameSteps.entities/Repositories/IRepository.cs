using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Queries;

namespace BoardGameSteps.entities.Repositories;
internal interface IRepository<TEntity>
	where TEntity : BaseEntity<TEntity>
{
	Task<IEnumerable<TEntity>> SelectAsync(BaseSelectQuery<TEntity>? query = null);
	Task<TEntity?> SelectFirstOrDefaultAsync(BaseSelectQuery<TEntity>? query = null);
	Task<TEntity?> SelectSingleOrDefaultAsync(BaseSelectQuery<TEntity>? query = null);
	Task<int> CountAsync(BaseSelectQuery<TEntity>? query = null);

	Task<int> InsertAsync(BaseInsertQuery<TEntity> query);
	Task<int> InsertMultipleAsync(IEnumerable<BaseInsertQuery<TEntity>> queries);

	Task<int> UpdateAsync(BaseUpdateQuery<TEntity> query);
	Task<int> UpdateMultipleAsync(IEnumerable<BaseUpdateQuery<TEntity>> queries);

	Task<int> DeleteAsync(BaseDeleteQuery<TEntity> query);
	Task<int> DeleteMultipleAsync(IEnumerable<BaseDeleteQuery<TEntity>> queries);
}
