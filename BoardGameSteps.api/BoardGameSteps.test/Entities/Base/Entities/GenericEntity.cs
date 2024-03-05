using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGameSteps.entities.Models;

namespace BoardGameSteps.test.Entities.Base.Entities;
public class GenericEntity : BaseEntity
{
    public string StringGenericEntityProperty { get; set; } = null!;

    public override BaseEntity Duplicate()
    {
        throw new NotImplementedException();
    }
}
