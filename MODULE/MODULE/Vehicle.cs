using System.IO.Pipes;

namespace MODULE;

public abstract class Vehicle
{
    private char _type;
    private decimal _standartCost;
    private decimal _standartPerKG;
    private decimal _costPerKG;

    private bool _isAvaible = true;

    private int _distanceRestrictionsKM ;
    private int _weightRestrictionsKG ;

    public int getWeightRestrictionsKG() => _weightRestrictionsKG;
    public int getDistanceRestrictionsKM() => _distanceRestrictionsKM;
    public bool getAvailability() => _isAvaible;

    public decimal getStandartCost() => _standartCost;

    public decimal getStandartPerKG() => _standartPerKG;

    public decimal getCostPerKG() => _costPerKG;

    public char getType() => _type;

    public Vehicle(char type , decimal standartCost, decimal standartPerKM, decimal costPerKG , int distanceRestrictionsKM , int weightRestrictionsKM)
    {
        if (standartCost <= 0)
        {
            throw new ArgumentException("Standart cost must be greater than zero");
        }
        _standartCost = standartCost;

        if (standartPerKM <= 0)
        {
            throw new ArgumentException("Standart per km must be greater than zero");
        }
        _standartPerKG = standartPerKM;

        if (costPerKG <= -1)
        {
            throw new ArgumentException("Cost per kg must be positive");
        }
        _costPerKG = costPerKG;

        if (weightRestrictionsKM <= 0)
        {
            throw new ArgumentException("Weight Restrictions per km must be greater than zero");
        }
        _weightRestrictionsKG = weightRestrictionsKM;

        if (distanceRestrictionsKM <= -1)
        {
            throw new ArgumentException("Distance Restrictions per km must bepositive");
        }
        _distanceRestrictionsKM = distanceRestrictionsKM;

        if (type != 'c' && type != 'b' && type != 't')
        {
            throw new ArgumentException($"Invalid vehicle type - {type}");
        }

        _type = type;

    }

    virtual public bool canTake(Order order)
    {
        if (order.getWeight() <= _weightRestrictionsKG && _isAvaible)
        {
            return true;
        }
        return false;
    }

    abstract public decimal CalculateCost(Order order);
}
