using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Models;

[PrimaryKey(nameof(Id))]
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public abstract BaseEntity Duplicate();
}
