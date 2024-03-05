using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.test.Entities.Base.Contextes;
using BoardGameSteps.test.Entities.Base.Repositories;
using BoardGameSteps.test.Fixtures;

namespace BoardGameSteps.test.Entities.Tests.Repositories;
public class BaseRepositoryTest(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
{
	//private readonly GenericDbContext _context = fixture.DbContext;
	private readonly GenericRepository _repo = new(fixture.DbContext);

	[Fact]
	public async Task TestSelectFixture()
	{
		var entities = await _repo.SelectAsync();

		if (entities == null)
			Assert.Fail("Entities are null.");

		Assert.True(true);
	}

}
