using System.ComponentModel.DataAnnotations;

namespace BoardGameSteps.entities.Models;
public class User : BaseEntity<User>
{
	[Required] public string Name { get; set; } = null!;
	[Required] public string Surname { get; set; } = null!;
	[Required] public string Nickname { get; set; } = null!;

	public override User Duplicate()
	{
		var user = new User
		{
			Id = Id,
			Name = Name,
			Surname = Surname,
			Nickname = Nickname
		};
		return user;
	}
}
