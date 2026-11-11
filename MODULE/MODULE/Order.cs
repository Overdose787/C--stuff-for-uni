namespace MODULE;

public class Order
{
    private int _id;
    private string _desctiption;
    private double _weightKG;
    private int _distanceKM;
    public Order(int id, string desctiption, double weightKG, int distanceKM)
    {
        _id = id;
        _desctiption = desctiption;

        if (_weightKG < 0)
        {
            throw new Exception("weight must be positive");
        }
        _weightKG = weightKG;
        
        if (distanceKM < 0)
        {
            throw new Exception("distance must be positive");
        }
        _distanceKM = distanceKM;
    }

    public int getId() => _id;
    public double getWeight() => _weightKG;
    public int getDistance() => _distanceKM; 
}