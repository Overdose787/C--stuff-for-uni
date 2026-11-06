using MODULE;

Random ranD = new Random();

char[] tempTypes = new char[3];
tempTypes[0] = 'c';
tempTypes[1] = 't';
tempTypes[2] = 'b';

Vehicle[] vehicles = new Vehicle[10];
Order[] orders = new Order[20];

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

for (int i = 0; i < orders.Length; i++)
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

    double randomWeight = ranD.Next(1, 1000);
    int randomDistance = ranD.Next(0, 100);

    orders[i] = new Order(randomId , $"desc - {i}" , randomWeight ,randomDistance );
}

Console.WriteLine("Build complete");
Console.ReadKey();
Console.Clear();
Console.WriteLine("Showing vehicles");

foreach (var VARIABLE in vehicles)
{
    Console.WriteLine(VARIABLE.getType());
}
