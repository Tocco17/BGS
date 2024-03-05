using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Exceptions;
using BoardGameSteps.test.Entities.Base.Contextes;
using BoardGameSteps.test.Entities.Base.Entities;
using BoardGameSteps.test.Entities.Base.Queries;
using BoardGameSteps.test.Entities.Base.Repositories;
using BoardGameSteps.test.Fixtures;

namespace BoardGameSteps.test.Entities.Tests.Queries;
public class BaseInsertQueryTest : IClassFixture<DatabaseFixture>
{
	private readonly GenericDbContext _context;
	private readonly GenericRepository _repo;

	public BaseInsertQueryTest(DatabaseFixture fixture)
	{
		_context = fixture.DbContext;
		_repo = new GenericRepository(fixture.DbContext);
	}

	[Fact]
	public async Task TestValidate()
	{
		try
		{
			var entity = new GenericEntity();
			var insertQuery = new GenericInsertQuery(entity);
			await _repo.InsertAsync(insertQuery);
			Assert.Fail("It should have gone in error.");
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
	public async Task TestInsert()
	{
		var entity = new GenericEntity
		{
			StringGenericEntityProperty = "test",
		};
		var insertQuery = new GenericInsertQuery(entity);
		var count = await _repo.InsertAsync(insertQuery);

		if(count != 1)
			Assert.Fail($"Count of inserted entities is {count}, while it should be 1.");

		Assert.True(true);
	}

	[Fact]
	public async Task TestNewGuid()
	{
		var entity = new GenericEntity
		{
			StringGenericEntityProperty = "test",
		};
		var insertQuery = new GenericInsertQuery(entity);

		var initialGuid = entity.Id;

		await _repo.InsertAsync(insertQuery);

		var newGuid = entity.Id;

		if(newGuid == Guid.Empty)
			Assert.Fail("The guid is empty.");

		Assert.True(true);
	}

	[Fact]
	public async Task TestDuplicateGuid()
	{
		var firstEntity = new GenericEntity
		{
			StringGenericEntityProperty = "test",
		};
		var firstInsertQuery = new GenericInsertQuery(firstEntity);

		await _repo.InsertAsync(firstInsertQuery);

		var firstId = firstEntity.Id;

		var secondEntity = new GenericEntity
		{
			Id = firstId,
			StringGenericEntityProperty = "test",
		};
		var secondInsertQuery = new GenericInsertQuery(secondEntity);

		await _repo.InsertAsync(secondInsertQuery);

		if (firstEntity.Id == secondEntity.Id)
			Assert.Fail("Id can't be duplicate");

		Assert.True(true);
	}

	[Fact]
	public async Task TestSelectAfterInsert()
	{
		var entity = new GenericEntity
		{
			StringGenericEntityProperty = "test",
		};
		var insertQuery = new GenericInsertQuery(entity);
		await _repo.InsertAsync(insertQuery);

		var id = entity.Id;

		var query = new GenericSelectQuery()
		{
			Id = id,
		};
		var selectedEntity = await _repo.SelectAsync(query);

		if (selectedEntity.Count() != 1)
			Assert.Fail("No entity has been found.");

		Assert.True(true);
	}
}
