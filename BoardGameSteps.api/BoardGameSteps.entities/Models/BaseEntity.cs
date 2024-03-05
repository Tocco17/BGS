using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Models;

[PrimaryKey(nameof(Id))]
public abstract class BaseEntity<TEntity>
    where TEntity : BaseEntity<TEntity>
{
    public Guid Id { get; set; }

    public abstract TEntity Duplicate();
}
