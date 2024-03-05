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
			StringGenericEntityProperty = "TestInsert",
		};
		var insertQuery = new GenericInsertQuery(entity);
		var count = await _repo.InsertAsync(insertQuery);

		if (count != 1)
			Assert.Fail($"Count of inserted entities is {count}, while it should be 1.");

		Assert.True(true);
	}

	[Fact]
	public async Task TestNewGuid()
	{
		var entity = new GenericEntity
		{
			StringGenericEntityProperty = "TestNewGuid",
		};
		var insertQuery = new GenericInsertQuery(entity);

		var initialGuid = entity.Id;

		await _repo.InsertAsync(insertQuery);

		var newGuid = entity.Id;

		if (newGuid == Guid.Empty)
			Assert.Fail("The guid is empty.");

		Assert.True(true);
	}

	[Fact]
	public async Task TestDuplicateGuid()
	{
		var firstEntity = new GenericEntity
		{
			StringGenericEntityProperty = "TestDuplicateGuid First",
		};
		var firstInsertQuery = new GenericInsertQuery(firstEntity);

		await _repo.InsertAsync(firstInsertQuery);

		var firstId = firstEntity.Id;

		var secondEntity = new GenericEntity
		{
			Id = firstId,
			StringGenericEntityProperty = "TestDuplicateGuid Second",
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
			StringGenericEntityProperty = "TestSelectAfterInsert",
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

	[Fact]
	public async Task TestMultipleInsert()
	{
		var entities = new List<GenericEntity>
		{
			new GenericEntity
			{
				StringGenericEntityProperty = "TestMultipleInsert First",
			},
			new GenericEntity
			{
				StringGenericEntityProperty = "TestMultipleInsert Second",
			},
			new GenericEntity
			{
				StringGenericEntityProperty = "TestMultipleInsert Third",
			}
		};
		var insertQuery = entities.Select(e => new GenericInsertQuery(e));

		var count = await _repo.InsertMultipleAsync(insertQuery);

		if (count != entities.Count())
		{
			var elements = await _repo.SelectAsync();
			var ids = elements.Select(e => e.StringGenericEntityProperty);
			var idJoin = string.Join(" | ", ids);

			Assert.Fail($"Entities: {entities.Count} | Count: {count}. Id: {idJoin}");
		}

		Assert.True(true);
	}

	[Fact]
	public async Task TestWrongValidateMultipleInsert()
	{
		try
		{
			var entities = new List<GenericEntity>
			{
				new GenericEntity
				{
					StringGenericEntityProperty = "TestWrongValidateMultipleInsert First",
				},
				new GenericEntity
				{
					StringGenericEntityProperty = "TestWrongValidateMultipleInsert Second",
				},
				new GenericEntity
				{
					StringGenericEntityProperty = "TestWrongValidateMultipleInsert Third",
				},
				new GenericEntity(),
			};
			var insertQuery = entities.Select(e => new GenericInsertQuery(e));

			var count = await _repo.InsertMultipleAsync(insertQuery);

			Assert.Fail($"It should have thrown an exception. | Entities: {entities.Count} | Count: {count}.");
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
}
