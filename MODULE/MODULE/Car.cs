namespace MODULE;

public class Car : Vehicle
{
    public Car() : base('c', 50, 8, 1, 0, 30)
    {

    }
    override public decimal CalculateCost(Order order)
    {
        if (!canTake(order))
        {
            Console.WriteLine("cant take");
            return -1;
        }

        return getStandartCost() + order.getDistance() * getStandartPerKG() + (decimal)(order.getWeight() * (double)getCostPerKG());
    }
}
