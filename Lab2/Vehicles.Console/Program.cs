using Vehicles.Common.Entities;
using Vehicles.Common.Infrastructure.Async;

var service = new AsyncTicketService();
await service.LoadAsync("./tickets.json");

Parallel.For(0, 1000, async (i) =>
{
    var value = Ticket.Create(
        Random.Shared.Next(10, 100), 
        $"TK{Random.Shared.Next(10000, 99999)}");
    
    await service.CreateAsync(value);
});

var entries = (await service.ReadAllAsync()).ToList();
var min = entries.Min(e => e.Price);
var max = entries.Max(e => e.Price);
var average = entries.Average(e => e.Price);

Console.WriteLine($"Total: {entries.Count}");
Console.WriteLine($"Min: {min:F2}");
Console.WriteLine($"Max: {max:F2}");
Console.WriteLine($"Average: {average:F2}");

//await service.SaveAsync("tickets.json");