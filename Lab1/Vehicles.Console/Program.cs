
using Vehicles.Common;
using Vehicles.Common.Extensions;
using Vehicles.Common.Infrastructure;

var id = Guid.NewGuid();

var train = new Train(id, "Train N24", "Black", 150, Train.LocomotiveType.Steam);

var service = new TrainService();
service.Load("./trains.json");

service.Create(train);

foreach (var entry in service.ReadAll())
{
    Console.WriteLine(entry.ToDetailedString());
}

train = service.Read(id);

if (train is null)
    throw new Exception("No train found");

train.Paint("Green");

foreach (var entry in service.ReadAll())
{
    Console.WriteLine(entry.ToDetailedString());
}

service.Update(train);

foreach (var entry in service.ReadAll())
{
    Console.WriteLine(entry.ToDetailedString());
}

service.Remove(train);

foreach (var entry in service.ReadAll())
{
    Console.WriteLine(entry.ToDetailedString());
}

service.Create(train);
//service.Save("./trains.json");