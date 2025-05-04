using Bogus;
using Microsoft.EntityFrameworkCore;
using Vehicles.Common.ValueObjects;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Services;

public static class DatabaseSeeder
{
    private static readonly Faker<TrainModel> TrainsFaker = new Faker<TrainModel>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Name, f => f.Commerce.ProductName())
        .RuleFor(x => x.Capacity, f => f.Random.Number(100, 150))
        .RuleFor(x => x.Color, f => f.Random.Hexadecimal())
        .RuleFor(x => x.Type, f => f.Random.Enum<LocomotiveType>(LocomotiveType.Other));
    
    public static async Task Seed(DbContext context, bool useSeeding, CancellationToken token = default)
    {
        if (useSeeding is false)
            return;
        
        context.Set<TrainModel>().AddRange(TrainsFaker.Generate(20));
        await context.SaveChangesAsync(token);
    }
}