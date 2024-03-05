using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGameSteps.entities.Contexts;
using BoardGameSteps.test.Entities.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.test.Entities.Base.Contextes;
public class GenericDbContext : BgsDbContext
{
    public GenericDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<GenericEntity> GenericEntities { get; set; } = null!;
}
