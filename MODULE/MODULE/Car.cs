namespace MODULE;

public class Car : Vehicle
{
    public Car() : base('c', 50, 8, 1, 0, 30)
    {
        
    }
    override public decimal CalculateCost(Order order)
    {
        return getStandartCost() + order.getDistance() * getStandartPerKG() + (decimal)(order.getWeight() * (double)getCostPerKG());
    }
}