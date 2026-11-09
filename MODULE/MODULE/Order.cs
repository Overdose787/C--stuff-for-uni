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
        _weightKG = weightKG;
        _distanceKM = distanceKM;
    }

    public int getId() => _id;
    public double getWeight() => _weightKG;
    public int getDistance() => _distanceKM; 
}