using eggsbasket.main.shared;

namespace eggsbasket.PRC;

public class lb3 : methodscontainer
{
    public void run()
    {
        hunter hunter = new hunter("dodik");
        hunter hunter2 = new hunter("dodik2");
        
        Console.WriteLine("2 players thing ");
        
        Console.WriteLine(hunter.retriveinfo());
        Console.WriteLine("-------------");
        Console.WriteLine(hunter2.retriveinfo());
        
        ref hunter current_hunter = ref hunter2;
        
        int choice = 0;
        
        while (true) //main even loop
        {
            Console.WriteLine($"current idiot that plays - {current_hunter.retrivename()}");
            Console.WriteLine($" | hunt | | shop | | actions |");
            
            Console.WriteLine($" enter a number from 1 to 3 that will represent choise");
            
            choicelp(ref choice);
            
            switch (choice)
            {
                case 1:
                    current_hunter.hunt();
                    break;
                case 2:
                    Console.WriteLine("I need to think what to do... buying over 100 arrows would raise suspicions");
                    choicelp(ref choice , 100);
                    new shop().buy(choice,ref current_hunter);
                    break;
                case 3:
                    Console.WriteLine("|Kill yourself| |Describe yourself|");
                    choicelp(ref choice , 2);
                    if (choice == 2)
                    {
                        Console.WriteLine(current_hunter.retriveinfo());
                    }
                    else
                    {
                        current_hunter.takedamage(10.0);
                    }
                    break;
            }

            if (hunter.gethealth() <= 0)
            {
                Console.WriteLine($"You are dead , not big surprise\n winner - {hunter2.retrivename()}");
                break;
            }
            else if (hunter2.gethealth() <= 0)
            {
                Console.WriteLine($"You are dead , not big surprise\n winner - {hunter.retrivename()}");
                break;
            }
            Console.WriteLine($"{current_hunter.retrivename()} your time`s up , now its other one time");
            if (current_hunter.retrivename() == hunter.retrivename())
            {
                current_hunter = ref hunter2;
            }
            else
            {
                current_hunter = ref hunter;
            }
        }
    }
}