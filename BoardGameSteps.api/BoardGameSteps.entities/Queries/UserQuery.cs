using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Models;

using Microsoft.EntityFrameworkCore;

namespace BoardGameSteps.entities.Queries;
public class UserSelectQuery : BaseSelectQuery<User>
{
	public string? Name { get; set; } = null;
	public string? Surname { get; set; } = null;
	public string? Nickname { get; set; } = null;

	protected override IQueryable<User> GetSelectQuery(IQueryable<User> query)
	{
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

public class UserInsertQuery : BaseInsertQuery<User>
{
	public UserInsertQuery(User entity) : base(entity)
	{
	}

	protected override User GetInizitializedEntity()
	{
		var entity = new User
		{
			Name = this.Entity.Name,
			Surname = this.Entity.Surname,
			Nickname = this.Entity.Nickname,
		};
		return entity;
	}

	protected override List<string> GetValidateErrors()
	{
		var errors = new List<string>();

		if (string.IsNullOrEmpty(Entity.Name))
			errors.Add("A Name is necessary for the insert of a User.");

		if (string.IsNullOrEmpty(Entity.Surname))
			errors.Add("A Surname is necessary for the insert of a User.");

		if (string.IsNullOrEmpty(Entity.Nickname))
			errors.Add("A Nickname is necessary for the insert of a User.");

		return errors;
	}

	protected override void Initialize(User entity)
	{
		entity.Name = this.Entity.Name;
		entity.Surname = this.Entity.Surname;
		entity.Nickname = this.Entity.Nickname;
	}
}
