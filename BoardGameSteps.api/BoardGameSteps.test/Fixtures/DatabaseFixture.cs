using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoardGameSteps.entities.Contexts;
using BoardGameSteps.test.Entities.Base.Contextes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameSteps.test.Fixtures;

public class DatabaseFixture : IDisposable
{
	public GenericDbContext DbContext;

	public DatabaseFixture()
	{
		var serviceProvider = new ServiceCollection()
			.AddDbContext<GenericDbContext>(options =>
				options.UseInMemoryDatabase(databaseName: "TestDatabase"))
			.BuildServiceProvider();

		DbContext = serviceProvider.GetRequiredService<GenericDbContext>();
		DbContext.Database.EnsureCreated();
	}

	public void Dispose()
	{
		DbContext.Dispose();
	}
}

[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
	// This class has no code, and is never created. Its purpose is simply
	// to be the place to apply [CollectionDefinition] and all the
	// ICollectionFixture<> interfaces.
}
