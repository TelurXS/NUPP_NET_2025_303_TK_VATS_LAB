using Vehicles.Common.Entities;
using Vehicles.Common.Extensions;
using Vehicles.Common.Infrastructure;
using Vehicles.Common.ValueObjects;

var id = Guid.NewGuid();

var train = new Train(id, "Train N24", "Black", 150, LocomotiveType.Steam);

var service = new TrainService();
service.Load("./trains.json");

service.Create(train);

PrintAll(service.ReadAll());

var found = service.Read(id);

if (found is null)
    throw new Exception("No train found");

train.Paint("Green");

PrintAll(service.ReadAll());

service.Update(train);

PrintAll(service.ReadAll());

service.Remove(train);

PrintAll(service.ReadAll());

service.Create(train);
//service.Save("./trains.json");

Console.WriteLine($"Total Count: " + Vehicle.VehiclesCount);

void PrintAll(IEnumerable<Vehicle> vehicles)
{
    foreach (var entry in vehicles)
    {
        Console.WriteLine(entry.ToDetailedString());
    }
    
    Console.WriteLine("=================================================");
}