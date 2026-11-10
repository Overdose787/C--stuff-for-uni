using MODULE;

Random ranD = new Random();
DeliveryService deliveryService = new DeliveryService();

char[] tempTypes = new char[3];
tempTypes[0] = 'c';
tempTypes[1] = 't';
tempTypes[2] = 'b';

Vehicle[] vehicles = new Vehicle[10];
List<Order> orders = new List<Order>();
int[] tempIds = new int[20];

for (int i = 0; i < vehicles.Length; i++)
{
    char randomChar = tempTypes[ranD.Next(0, tempTypes.Length)];
    switch (randomChar)
    {
        case 'c':
            vehicles[i] = new Car();
            break;
        case 't':
            vehicles[i] = new Truck();
            break;
        case 'b':
            vehicles[i] = new Bike();
            break;
    }
}

for (int i = 0; i < 19; i++)
{
    int randomId = ranD.Next(0, 999999999);
    
    foreach (int id in tempIds)
    {
        if (id == randomId)
        {
            continue;
        }
        tempIds[i] = randomId;
        break;
    }

    double randomWeight = ranD.Next(1, 901);
    int randomDistance = ranD.Next(1, 30);
    
    orders.Add(new Order(randomId , $"desc - {i}" , randomWeight ,randomDistance ));
}
/*
Console.WriteLine("Build complete");
Console.ReadKey();
Console.Clear();
Console.WriteLine("Showing vehicles");

foreach (var VARIABLE in vehicles)
{
    Console.WriteLine(VARIABLE.getType());
}
Console.ReadKey();
Console.Clear();

Console.WriteLine("Showing orders");

foreach (var VARIABLE in orders)
{
    Console.WriteLine(VARIABLE.getId() + "= distance =>" + VARIABLE.getDistance());
    
}

Console.ReadKey();
Console.Clear();
*/
decimal total = 0;
while (true)
{
    Console.WriteLine($"All orders now - {orders.Count}");
    foreach(var VARIABLE in orders)
    {
        Vehicle VehicleThatWillTake = deliveryService.GetOptimalAvaiable(vehicles,VARIABLE); //here we finding vehicle that can take order using get optimal and shit
        
        if (VehicleThatWillTake == null)
        {
            continue;
        }
        
        deliveryService.ProcessOrder(VARIABLE , VehicleThatWillTake); //here we adding order to vehicle 

        decimal cost = VehicleThatWillTake.CalculateCost(VARIABLE);
        total += cost;
        Console.WriteLine($"cost of delivery - {VARIABLE.getId()} - {cost}$");
    }
    
    deliveryService.DeliverAll(vehicles , orders); //here we updating shit
    Console.WriteLine("------------------");
    Console.WriteLine($"summary\ntotal wealth acuulated : {total}$");
    Console.WriteLine("------------------");
    
    if (orders.Count == 0)
    {
        break;
    }
    
}