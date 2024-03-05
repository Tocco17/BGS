using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.test.Entities.Base.Contextes;
using BoardGameSteps.test.Entities.Base.Repositories;
using BoardGameSteps.test.Fixtures;

namespace BoardGameSteps.test.Entities.Tests.Repositories;
public class BaseRepositoryTest : IClassFixture<DatabaseFixture>
{
	private readonly GenericDbContext _context;
	private readonly GenericRepository _repo;

	public BaseRepositoryTest(DatabaseFixture fixture)
	{
		_context = fixture.DbContext;
		_repo = new GenericRepository(fixture.DbContext);
	}

	[Fact]
	public async Task TestSelectFixture()
	{
		var entities = await _repo.SelectAsync();

		if (entities == null)
			Assert.Fail("Entities are null.");

		Assert.True(true);
	}

}
