namespace MODULE;

public class Truck : Vehicle
{
    public Truck() : base('t' , 200 , 15 , (decimal)0.5 , 0 , 900)
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