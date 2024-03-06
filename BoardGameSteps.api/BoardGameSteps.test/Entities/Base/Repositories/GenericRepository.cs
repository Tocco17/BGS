using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Repositories;
using BoardGameSteps.test.Entities.Base.Entities;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.test.Entities.Base.Repositories;
public class GenericRepository(DbContext dbContext) : BaseRepository<GenericEntity>(dbContext)
{
}
