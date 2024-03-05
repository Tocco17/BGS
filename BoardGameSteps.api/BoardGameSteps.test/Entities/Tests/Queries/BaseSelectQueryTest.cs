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
using BoardGameSteps.test.Entities.Base.Contextes;
using BoardGameSteps.test.Entities.Base.Entities;
using BoardGameSteps.test.Entities.Base.Queries;
using BoardGameSteps.test.Fixtures;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace BoardGameSteps.test.Entities.Tests.Queries;
public class BaseSelectQueryTest : IClassFixture<DatabaseFixture>
{
	private readonly GenericDbContext _context;

	public BaseSelectQueryTest(DatabaseFixture fixture)
	{
		_context = fixture.DbContext;
	}

	[Fact]
	public void TestWrongProperty()
	{
		try
		{
			var entity = new GenericClass();
			var entityType = entity.GetType();
			var entityProperty = entityType.GetProperty("StringGenericClassProperty");

			if (entityProperty == null)
				Assert.Fail("Property not found, but it should exists.");

			var entityDbSet = _context.GenericEntities;
			if (entityDbSet == null)
				Assert.Fail("User Db is null.");

			var selectQueryObject = new GenericSelectQuery
			{
				OrderBy = entityProperty
			};
			var query = selectQueryObject.GetSelectQuery(entityDbSet);
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
		var entity = new GenericEntity();
		var entityType = entity.GetType();
		var idProperty = entityType.GetProperty("Id");

		if (idProperty == null)
			Assert.Fail("Property not found, but it should exists.");

		var entityDbSet = _context.GenericEntities;
		if (entityDbSet == null)
			Assert.Fail("User Db is null.");

		var selectQueryObject = new GenericSelectQuery
		{
			OrderBy = idProperty
		};
		var query = selectQueryObject.GetSelectQuery(entityDbSet);

		Assert.True(true);
	}
}
