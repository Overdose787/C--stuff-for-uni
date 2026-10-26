namespace eggsbasket.main.shared;

public class hunter
{
    private string name;
    private double health;
    private int gold;
    private int arrows;

    public hunter(string nme)
    {
        name = nme;
        health = 1;
        gold = 10;
        arrows = 0;
    }

    internal string retriveinfo()
    {
        return $"Hunters name => {name}\n health => {health}\n wealth => {gold}\n munition => {arrows}";
    }
    
    void hunt()
    {
        Console.WriteLine($"hunter{name} is gunting using arrows - {arrows}");
    }
}