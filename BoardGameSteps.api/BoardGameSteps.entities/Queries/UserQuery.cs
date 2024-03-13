using BoardGameSteps.entities.Models;

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

	protected override IQueryable<User> Include(IQueryable<User> query)
	{
		return query;
	}
}

public class UserInsertQuery(User entity) : BaseInsertQuery<User>(entity)
{
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
}

public class UserUpdateQuery(User entity) : BaseUpdateQuery<User>(entity)
{
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
			errors.Add("A Name is necessary for the update of a User.");

		if (string.IsNullOrEmpty(Entity.Surname))
			errors.Add("A Surname is necessary for the update of a User.");

		if (string.IsNullOrEmpty(Entity.Nickname))
			errors.Add("A Nickname is necessary for the update of a User.");

		return errors;
	}
}

public class UserDeleteQuery(User entity) : BaseDeleteQuery<User>(entity)
{
	protected override List<string> GetValidateErrors()
	{
		var errors = new List<string>
		{
			"This action can't be perfored."
		};

		return errors;
	}
}
