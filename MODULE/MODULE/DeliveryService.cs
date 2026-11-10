namespace MODULE;

public class DeliveryService
{
    public void ProcessOrder(Order order , Vehicle vehicle)
    {
        if (vehicle.canTake(order))
        {
            Console.WriteLine($"proccesing order - {order.getId()} by - {vehicle.getType()}");
            vehicle.AddPackage(order);
            vehicle.FlipType();
            return;
        }
        return;
    }

    public void DeliverAll(Vehicle[] vehicles , List<Order> orders)
    {
        foreach (var VARIABLE in vehicles)
        {
            VARIABLE.Deliver(orders);
        }
    }

    public char getOptimal(Order order)
    {
        if (order.getWeight() <= 3)
        {
            return 'b';
        }
        if (order.getWeight() <= 30)
        {
            return 'c';
        }
        return 't';
    }

    public Vehicle GetOptimalAvaiable(Vehicle[]  vehicles, Order order)
    {
        char optimal = getOptimal(order);

        if (optimal == 'b')
        {
            for (int i = 0; i < vehicles.Length; i++)
            {

                if (vehicles[i] is not Bike)
                {
                    continue;
                }
                
                if (vehicles[i].getType() == optimal && vehicles[i].canTake(order))
                {
                    Console.WriteLine("found avaiable optimal vehicle");
                    return vehicles[i];
                }
            }
            foreach (var VARIABLE in vehicles)
            {
                if (VARIABLE.canTake(order))
                {
                    Console.WriteLine("found avaiable optimal vehicle");
                    return VARIABLE;
                }
            }
        }

        foreach (var VARIABLE in vehicles)
        {
            if (VARIABLE.getType() == 'b')
            {
                continue;
            }

            if (VARIABLE.getAvailability() && VARIABLE.canTake(order))
            {
                Console.WriteLine("found avaiable optimal vehicle");
                return VARIABLE;
            }
        }
        return null;
    }
}