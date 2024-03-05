using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Exceptions;
using BoardGameSteps.test.Entities.Base.Contextes;
using BoardGameSteps.test.Entities.Base.Entities;
using BoardGameSteps.test.Entities.Base.Queries;
using BoardGameSteps.test.Fixtures;

namespace BoardGameSteps.test.Entities.Tests.Queries;
public class BaseInsertQueryTest : IClassFixture<DatabaseFixture>
{
	private readonly GenericDbContext _context;

	public BaseInsertQueryTest(DatabaseFixture fixture)
	{
		_context = fixture.DbContext;
	}

	[Fact]
	public void TestValidate()
	{
		try
		{
			var entity = new GenericEntity();
			var insertQuery = new GenericInsertQuery(entity);
			insertQuery.Validate();
		}
		catch (InsertQueryValidateException)
		{
			Assert.True(true);
		}
		catch (Exception ex)
		{
			Assert.Fail(ex.Message);
		}
	}

	[Fact]
	public void TestInsert()
	{

	}
}
