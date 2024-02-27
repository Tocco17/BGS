using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Queries;

namespace BoardGameSteps.entities.Repositories;
internal interface IRepository<TEntity>
	where TEntity : BaseEntity
{
	Task<IEnumerable<TEntity>> SelectAsync(BaseSelectQuery<TEntity>? query = null);
	Task<int> CountAsync(BaseSelectQuery<TEntity>? query = null);
}
