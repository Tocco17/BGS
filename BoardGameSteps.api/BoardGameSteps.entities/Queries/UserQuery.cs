using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Queries;
public class UserQuery
{
	public Guid? Id { get; set; } = null;
	public string? Name { get; set; } = null;
	public string? Surname { get; set; } = null;
	public string? Nickname { get; set; } = null;

	public IQueryable<User> SelectQuery(DbSet<User> dbSet)
	{
		var query = dbSet.AsQueryable();

		if (Id != null) 
			query = query.Where(x => x.Id == Id);

		if (Name != null) 
			query = query.Where(x => x.Name == Name);

		if (Surname != null) 
			query = query.Where(x => x.Surname == Surname);

		if (Nickname != null) 
			query = query.Where(x => x.Nickname == Nickname);

		return query;
	}
}
