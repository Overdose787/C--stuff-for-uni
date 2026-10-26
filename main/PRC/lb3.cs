using eggsbasket.main.shared;

namespace eggsbasket.PRC;

public class lb3
{
    public void run()
    {
        hunter hunter = new hunter("dodik");
        
        Console.WriteLine(hunter.retriveinfo());
        while (true)
        {
            Console.WriteLine($" | hunt | | shop | | actions |");

            byte choice = 0;
            
            Console.WriteLine($" enter a number from 1 to 3 that will represent choise");
            while (true)
            {
                if (byte.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= 3)
                    {
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("enter a valid option , stupid");
                    continue;
                }
                Console.WriteLine(" enter a number , stupid");
            }
            break;
        }
    }
}