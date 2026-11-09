namespace MODULE;

public class Bike : Vehicle
{
    public Bike() : base('b' , 20 , 5 , 0 , 10 , 3)
    {
    }

    public override bool canTake(Order order)
    {
        if (order.getWeight() <= getWeightRestrictionsKG() && order.getDistance() <= getDistanceRestrictionsKM() && getAvailability())
        {
            return true;
        }
        return false;
    }

    override public decimal CalculateCost(Order order)
    {        
        return getStandartCost() + order.getDistance() * getStandartPerKG();
    }
}