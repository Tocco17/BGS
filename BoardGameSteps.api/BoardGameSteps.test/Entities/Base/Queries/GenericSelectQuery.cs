using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Queries;
using BoardGameSteps.test.Entities.Base.Entities;

namespace BoardGameSteps.test.Entities.Base.Queries;
internal class GenericSelectQuery : BaseSelectQuery<GenericEntity>
{
	public string? StringGenericEntityProperty { get; set; } = null;

	protected override IQueryable<GenericEntity> GetSelectQuery(IQueryable<GenericEntity> query)
	{
		if(!string.IsNullOrEmpty(StringGenericEntityProperty))
			query = query.Where(x => x.StringGenericEntityProperty == StringGenericEntityProperty);

		return query;
	}

	protected override IQueryable<GenericEntity> Include(IQueryable<GenericEntity> query)
	{
		return query;
	}
}
