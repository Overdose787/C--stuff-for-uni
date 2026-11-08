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

    private List<Order> _carryingNow;
    
    public Vehicle(char type , decimal standartCost, decimal standartPerKM, decimal costPerKG , int distanceRestrictionsKM , int weightRestrictionsKG)
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

        if (weightRestrictionsKG <= 0)
        {
            throw new ArgumentException("Weight Restrictions per km must be greater than zero");
        }
        _weightRestrictionsKG = weightRestrictionsKG;

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

    public void AddPackage(Order order)
    {
        double total = 0;
        foreach (var VARIABLE in _carryingNow)
        {
            total += VARIABLE.getWeight();
        }

        if (order.getWeight() + total >= _weightRestrictionsKG)
        {
            return;
        }
        _carryingNow.Add(order);
    }
    public void Deliver(List<Order> orders)
    {
        if (_carryingNow.Count == 0)
        {
            FlipType();
        }
        
        orders.Remove(_carryingNow[0]);
        _carryingNow.RemoveAt(0);
    }
    public void FlipType()
    {
        if (!_isAvaible && _carryingNow.Count == 0)
        {
            _isAvaible = true;
        }
        else if (_isAvaible && _carryingNow.Count > 0)
        {
            _isAvaible = false;
        }
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