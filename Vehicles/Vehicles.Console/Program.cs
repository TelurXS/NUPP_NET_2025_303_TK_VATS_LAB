using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Vehicles.Common.Contracts;
using Vehicles.Common.Entities;
using Vehicles.Common.Extensions;
using Vehicles.Common.ValueObjects;
using Vehicles.Infrastructure.MsSql.Extensions;
using Vehicles.Infrastructure.NoSql.Extensions;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Extensions;
using Vehicles.Infrastructures.Models;

var services = new ServiceCollection();

//services.AddSqlServerDataContext();
services.AddMongoDbDataContext();
services.AddInfrastructure();

services.AddTransient(p => new Faker<Train>()
    .RuleFor(x => x.Id, f => f.Random.Guid())
    .RuleFor(x => x.Name, f => f.Commerce.ProductName())
    .RuleFor(x => x.Capacity, f => f.Random.Number(100, 150))
    .RuleFor(x => x.Color, f => f.Random.Hexadecimal())
    .RuleFor(x => x.Type, f => f.Random.Enum<LocomotiveType>(LocomotiveType.Other))
);

var provider = services.BuildServiceProvider();

var service = provider.GetRequiredService<IAsyncCrudService<TrainModel>>();
var faker = provider.GetRequiredService<Faker<Train>>();
var context = provider.GetRequiredService<IDataContext>();
var mapper = provider.GetRequiredService<IEntityMapper>();

await context.Database.EnsureCreatedAsync();

// Generating
//foreach (var i in Enumerable.Range(0, 10))
//{
//    var mapped = mapper.ToModel(faker.Generate());
//    await service.CreateAsync(mapped);
//}

var train = mapper.ToModel(faker.Generate());

// Creating
if (await service.CreateAsync(train))
{
    Console.WriteLine("Created: "  + mapper.FromModel(train).ToDetailedString());
}

var toUpdate = mapper.ToModel(faker.Generate());
train.Name = toUpdate.Name;
train.Capacity = toUpdate.Capacity;
train.Color = toUpdate.Color;
train.Type = toUpdate.Type;

// Updating
if (await service.UpdateAsync(train))
{
    Console.WriteLine("Updated");
}

var result = await service.ReadAsync(train.Id);

// Reading
if (result is not null)
{
    Console.WriteLine("Found " + mapper.FromModel(result).ToDetailedString());
}

// Deleting
if (await service.RemoveAsync(train))
{
    Console.WriteLine("Deleted");
}

// Reading All
var entries = (await service.ReadAllAsync()).ToList();

foreach (var entry in entries)
{
    var mapped = mapper.FromModel(entry);
    Console.WriteLine(mapped.ToDetailedString());
}

Console.WriteLine($"Count {entries.Count}");