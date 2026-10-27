namespace eggsbasket.main.shared;

public abstract class entity
{
    private string name;
    private double health;
    public entity(string nme)
    {
        health = 1.0;
        name = nme;
    }
    internal string retrivename()
    {
        return name;
    }

    internal void takedamage(double damage)
    {
        if (damage > 0)
        {
           health -= damage; 
        }
        
    }
    internal double gethealth()
    {
        return health;
    }
    abstract internal string retriveinfo();
    
}
public class hunter : entity
{
    
    private int gold;
    private int arrows;

    public hunter(string nme):base(nme)
    {
        gold = 10;
        arrows = 0;
    }

    internal override string retriveinfo()
    {
        return $"Hunters name => {retrivename()}\n health => {gethealth() * 100}\n wealth => {gold}\n munition => {arrows}";
    }
    
    public int getgold() => gold;
    public int getarrows() => arrows;
    public int setgold(int vl) => gold += vl;
    public int setarrows(int vl) => arrows += vl;
    public void hunt()
    {
        if (arrows >= 1)
        {
            Console.WriteLine($"hunter{retrivename()} is gunting using arrows - {arrows}");
            if (new Random().Next(0, 10) == 1)
            {
                takedamage(new Random().NextDouble() - 0.3);
                Console.WriteLine($"Hunter had an sucsesful hunt! - remaining health - {(int)(gethealth() * 100)}");
                gold += new Random().Next(0, 25);
            }
            else
            {
                takedamage(new Random().NextDouble() - 0.3);
                Console.WriteLine("tough luck , nothing!!");
            }
            arrows--;
        }
        else
        {
            Console.WriteLine("What do you expect me to hunt with?");
        }
        
    }
}

public class shop
{
    public void buy(int howmuch, ref hunter player)
    {
        for (int i = 0; i < howmuch; i++)
        {
            if (player.getgold() >= 5)
            {
                player.setarrows(1);
                player.setgold(-5);
            }
            else
            {
                Console.WriteLine($"{player.getgold()}$? , Look buddy its not charity , no money - no product");
                break;
            }
        }
    }
}

public class methodscontainer
{
    public void choicelp(ref int ch , int max = 3, int min = 1){
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out ch))
            {
                if (ch >= min && ch <= max)
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine("enter a valid option , stupid");
                continue;
            }
            Console.WriteLine(" enter a number , stupid");
        }
    }
}