using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Queries;
using BoardGameSteps.test.Entities.Base.Entities;

namespace BoardGameSteps.test.Entities.Base.Queries;
public class GenericInsertQuery : BaseInsertQuery<GenericEntity>
{
	public GenericInsertQuery(GenericEntity entity) : base(entity)
	{
	}

	protected override GenericEntity GetInizitializedEntity()
	{
		return this.Entity;
	}

	protected override List<string> GetValidateErrors()
	{
		var errors = new List<string>();

		if (string.IsNullOrEmpty(Entity.StringGenericEntityProperty))
			errors.Add("StringGenericEntityProperty can't be null.");

		return errors;
	}
}
