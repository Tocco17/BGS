using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.test.Entities.Base.Contextes;
using BoardGameSteps.test.Entities.Base.Entities;
using BoardGameSteps.test.Entities.Base.Queries;
using BoardGameSteps.test.Entities.Base.Repositories;
using BoardGameSteps.test.Fixtures;

namespace BoardGameSteps.test.Entities.Tests.Queries;
public class BaseUpdateQueryTest : IClassFixture<DatabaseFixture>
{
	//private readonly GenericDbContext _context = fixture.DbContext;

	private readonly GenericRepository _repo;

	private readonly IEnumerable<GenericEntity> _baseDb;

	public BaseUpdateQueryTest(DatabaseFixture fixture)
	{
		_repo = new(fixture.DbContext);

		_baseDb =
		[
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseInsertQueryTest Constructor first",
			},
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseInsertQueryTest Constructor second",
			},
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseInsertQueryTest Constructor third",
			},
		];

		var insertQueries = _baseDb.Select(x => new GenericInsertQuery(x));
		_ = _repo.InsertMultipleAsync(insertQueries);
	}

	[Fact]
	public async Task TestUpdate()
	{
		var entityFromBase = _baseDb.First();
		var entityFromDb = await _repo.SelectSingleOrDefaultAsync(new GenericSelectQuery
		{
			Id = entityFromBase.Id,
		});

		if (entityFromDb == null)
			Assert.Fail("Entity not present in db.");

		var updatedEntity = new GenericEntity
		{
			Id = entityFromBase.Id,
			StringGenericEntityProperty = "TestUpdate Updated",
		};

		var count = await _repo.UpdateAsync(new GenericUpdateQuery(updatedEntity));
		if (count != 1)
			Assert.Fail($"Number of updated entities: {count}");

		Assert.True(true);
	}

	//[Fact]
	//public async Task TestUpdate()
	//{
	//	var entity = new GenericEntity
	//	{
	//		StringGenericEntityProperty = "TestUpdate first",
	//	};
	//	var insertQuery = new GenericInsertQuery(entity);
	//	await _repo.InsertAsync(insertQuery);

	//	var selectQuery = new GenericSelectQuery
	//	{
	//		Id = entity.Id,
	//	};
	//	var toBeUpdateEntity = await _repo.SelectSingleOrDefaultAsync(selectQuery);

	//	if (toBeUpdateEntity == null)
	//		Assert.Fail("To Be Update Entity is null.");

	//	toBeUpdateEntity.StringGenericEntityProperty = "TestUpdate second";

	//	var updateQuery = new GenericUpdateQuery(toBeUpdateEntity);
	//	var count = await _repo.UpdateAsync(updateQuery);

	//	if(count != 1)
	//		Assert.Fail($"Count of inserted entities is {count}, while it should be 1.");

	//	Assert.True(true);
	//}

	//[Fact]
	//public async Task TestUpdate2()
	//{
	//	var firstEntityFromDb = _baseDb.First();
	//	if (firstEntityFromDb == null)
	//		Assert.Fail("firstEntityFromDb should not be null.");

	//	var selectQuery = new GenericSelectQuery
	//	{
	//		Id = firstEntityFromDb.Id,
	//	};
	//	var toBeUpdateEntity = await _repo.SelectSingleOrDefaultAsync(selectQuery);

	//	if (toBeUpdateEntity == null)
	//		Assert.Fail("To Be Update Entity is null.");

	//	toBeUpdateEntity.StringGenericEntityProperty = "TestUpdate second";

	//	var updateQuery = new GenericUpdateQuery(toBeUpdateEntity);
	//	var count = await _repo.UpdateAsync(updateQuery);

	//	if (count != 1)
	//		Assert.Fail($"Count of inserted entities is {count}, while it should be 1.");

	//	Assert.True(true);
	//}

	//[Fact]
	//public async Task TestUpdate3()
	//{
	//	var entity = _baseDb.First();
	//	if (entity == null)
	//		Assert.Fail("entity should not be null.");

	//	entity.StringGenericEntityProperty = "TestUpdate first";

	//	var updateQuery = new GenericUpdateQuery(entity);
	//	var count = await _repo.UpdateAsync(updateQuery);

	//	if (count != 1)
	//		Assert.Fail($"Count of inserted entities is {count}, while it should be 1.");

	//	Assert.True(true);
	//}
}
