using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.test.Entities.Base.Entities;
using BoardGameSteps.test.Entities.Base.Queries;
using BoardGameSteps.test.Entities.Base.Repositories;
using BoardGameSteps.test.Fixtures;

namespace BoardGameSteps.test.Entities.Tests.Queries;
public class BaseDeleteQueryTest : IClassFixture<DatabaseFixture>
{
	private readonly GenericRepository _repo;

	private readonly IEnumerable<GenericEntity> _baseDb;

	public BaseDeleteQueryTest(DatabaseFixture fixture)
	{
		_repo = new(fixture.DbContext);

		_baseDb =
		[
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseDeleteQueryTest Constructor first",
			},
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseDeleteQueryTest Constructor second",
			},
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseDeleteQueryTest Constructor third",
			},
		];

		var insertQueries = _baseDb.Select(x => new GenericInsertQuery(x));
		_ = _repo.InsertMultipleAsync(insertQueries);
	}

	[Fact]
	public async Task TestDelete()
	{
		var entity = _baseDb.First();

		var deleteQuery = new GenericDeleteQuery(entity);
		var count = await _repo.DeleteAsync(deleteQuery);

		if (count != 1)
			Assert.Fail($"Delete fail: count {count} | it should be 1.");

		var entities = await _repo.SelectAsync();
		if (entities.Any(e => e.Id == entity.Id))
			Assert.Fail("Entity still present.");

		Assert.True(true);
	}
}
