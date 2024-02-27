using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Queries;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Repositories;
public class UserRepository : BaseRepository<User>
{
	public UserRepository(DbContext dbContext) : base(dbContext)
	{
	}
}
