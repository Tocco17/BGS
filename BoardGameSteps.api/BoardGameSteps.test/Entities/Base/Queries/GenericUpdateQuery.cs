using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Queries;
using BoardGameSteps.test.Entities.Base.Entities;

namespace BoardGameSteps.test.Entities.Base.Queries;
public class GenericUpdateQuery(GenericEntity entity) : BaseUpdateQuery<GenericEntity>(entity)
{
	protected override GenericEntity GetInizitializedEntity()
	{
		var entity = new GenericEntity
		{
			StringGenericEntityProperty = this.Entity.StringGenericEntityProperty,
		};
		return entity;
	}

	protected override List<string> GetValidateErrors()
	{
		var errors = new List<string>();

		if (string.IsNullOrEmpty(this.Entity.StringGenericEntityProperty))
			errors.Add("StringGenericEntityProperty must be valorized.");

		return errors;
	}
}
