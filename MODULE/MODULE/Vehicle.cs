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

        if (costPerKG <= 0)
        {
            throw new ArgumentException("Cost per kg must be greater than zero");
        }
        _costPerKG = costPerKG;

        if (weightRestrictionsKM <= 0)
        {
            throw new ArgumentException("Weight Restrictions per km must be greater than zero");
        }
        _weightRestrictionsKG = weightRestrictionsKM;

        if (distanceRestrictionsKM <= 0)
        {
            throw new ArgumentException("Distance Restrictions per km must be greater than zero");
        }
        _distanceRestrictionsKM = distanceRestrictionsKM;
        
        switch (type)
        {
            case 'a':
                _type = 'a';
                return;
            case 'b':
                _type = 'b';
                return;
            case 't':
                _type = 't';
                return;
        }
        throw new ArgumentException("Invalid vehicle type");
    }
}