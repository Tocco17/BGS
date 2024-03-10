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

namespace BoardGameSteps.test.Entities.Tests.Repositories;
public class BaseRepositoryTest : IClassFixture<DatabaseFixture>
{
	//private readonly GenericDbContext _context = fixture.DbContext;
	private readonly GenericRepository _repo;
	private readonly IEnumerable<GenericEntity> _baseDb;

	public BaseRepositoryTest(DatabaseFixture fixture)
	{
		_repo = new(fixture.DbContext);

		_baseDb = new List<GenericEntity>
		{
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseRepositoryTest Constructor first",
			},
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseRepositoryTest Constructor second",
			},
			new()
			{
				Id = Guid.NewGuid(),
				StringGenericEntityProperty = "BaseRepositoryTest Constructor third",
			},
		};

		var insertQueries = _baseDb.Select(x => new GenericInsertQuery(x));
		_ = _repo.InsertMultipleAsync(insertQueries);
	}

	[Fact]
	public async Task TestSelectFixture()
	{
		var entities = await _repo.SelectAsync();

		if (entities == null)
			Assert.Fail("Entities are null.");

		Assert.True(true);
	}

	[Fact]
	public async Task TestConstructorInsert()
	{
		var entities = await _repo.SelectAsync();

		if (entities.Count() != _baseDb.Count())
			Assert.Fail($"Number of entities selected from db should be the same of baseDb. Entities: {entities.Count()} | Base DB: {_baseDb.Count()}");
		Assert.True(true);
	}

}
