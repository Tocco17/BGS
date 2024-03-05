using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Contexts;
using BoardGameSteps.entities.Models;
using BoardGameSteps.entities.Queries;
using BoardGameSteps.test.Fixtures;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace BoardGameSteps.test.Entities.Queries;
public class BaseSelectQueryTest : IClassFixture<DatabaseFixture>
{
	private readonly DatabaseFixture _fixture;
	private readonly BgsDbContext _context;

	public BaseSelectQueryTest(DatabaseFixture fixture)
	{
		_fixture = fixture;
		_context = fixture.DbContext;
	}

	[Fact]
	public void TestWrongProperty()
	{
		try
		{
			var prova = new Prova();
			var provaType = prova.GetType();
			var provaProperty = provaType.GetProperty("ProvaProperty");

			if (provaProperty == null)
				Assert.Fail("Property not found, but it should exists.");

			var userDbSet = _context.Users;
			if (userDbSet == null)
				Assert.Fail("User Db is null.");

			var selectQueryObject = new UserSelectQuery
			{
				OrderBy = provaProperty
			};
			var query = selectQueryObject.GetSelectQuery(userDbSet);
			Assert.True(false);
		}
		catch (ArgumentException)
		{
			Assert.True(true);
		}


	}

	[Fact]
	public void TestRightProperty()
	{
		var user = new User();
		var userType = user.GetType();
		var idProperty = userType.GetProperty("Id");

		if (idProperty == null)
			Assert.Fail("Property not found, but it should exists.");

		var userDbSet = _context.Users;
		if (userDbSet == null)
			Assert.Fail("User Db is null.");

		var selectQueryObject = new UserSelectQuery
		{
			OrderBy = idProperty
		};
		var query = selectQueryObject.GetSelectQuery(userDbSet);

		Assert.True(true);
	}
}
