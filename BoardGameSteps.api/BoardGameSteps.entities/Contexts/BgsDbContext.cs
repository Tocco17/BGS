using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Contexts;
public class BgsDbContext : DbContext
{
	public BgsDbContext(DbContextOptions options) : base(options)
	{
	}

    public DbSet<User>	Users { get; set; }
}
