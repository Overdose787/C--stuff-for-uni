namespace MODULE;

public class DeliveryService
{
    public bool ProcessOrder(Order order , Vehicle vehicle)
    {
        if (vehicle.canTake(order))
        {
            Console.WriteLine($"proccesing order - {order.getId()} by - {vehicle.getType()}");
            vehicle.AddPackage(order);
            vehicle.FlipType();
            return true;
        }
        return false;
    }

    public void resetall(Vehicle[] vehicles , List<Order> orders)
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
            foreach (Bike VARIABLE in vehicles) 
            {
                if (VARIABLE.getType() == optimal && VARIABLE.getAvailability())
                {
                    Console.WriteLine("found avaiable optimal vehicle");
                    return VARIABLE;
                }
            } 
            foreach (var VARIABLE in vehicles)
            {
                if (VARIABLE.getAvailability())
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

            if (VARIABLE.getAvailability())
            {
                Console.WriteLine("found avaiable optimal vehicle");
                return VARIABLE;
            }
        }
        return null;
    }
}