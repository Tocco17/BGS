using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Queries;
using BoardGameSteps.test.Entities.Base.Entities;

namespace BoardGameSteps.test.Entities.Base.Queries;
public class GenericDeleteQuery(GenericEntity entity) : BaseDeleteQuery<GenericEntity>(entity)
{
	protected override List<string> GetValidateErrors()
	{
		var errors = new List<string>();

		return errors;
	}
}
