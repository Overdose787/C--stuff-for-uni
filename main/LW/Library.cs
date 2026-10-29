using eggsbasket.main.shared;

namespace eggsbasket.main.LW;

public class Library : methods
{
    public void run()
    {
        Random rnd = new Random();
        
        book[] books = new shared.book[10];
        reader[] readers = new reader[3];
        
        int[] temp_ids = new int[10];
        
        for (int i = 0; i <= books.Length - 1; i++)
        {
            if (books[i] == null)
            {
                for (int j = 0; j < temp_ids.Length; j++)
                {
                    int temp_unique_id = rnd.Next(1, 999999999);
                    if (temp_ids[j] == temp_unique_id || temp_ids[i] > 0)
                    {
                        continue;
                    }
                    temp_ids[j] = temp_unique_id;
                    books[i] = new book($"authorname{i}", temp_unique_id); 
                    break;
                }
            }
        }

        for (int i = 0; i < temp_ids.Length; i++)
        {
            temp_ids[i] = 0;
        }

        for (int i = 0; i < readers.Length; i++)
        {
            if (readers[i] == null)
            {
                int temp_unique_id = rnd.Next(1, 999999999);
                for (int id = 0; id < temp_ids.Length; id++)
                {
                    if (temp_ids[id] == temp_unique_id || temp_ids[id] > 0)
                    {
                        continue;
                    }
                    temp_ids[id] = temp_unique_id;
                    readers[i] = new reader($"reader{i}" , temp_unique_id);
                    break;
                }
            }
        }
        
        
        Console.WriteLine("Printing books ");
        foreach (var VARIABLE in books)
        {
            Console.WriteLine($"Authors name - {VARIABLE.getName()}\nUid - {VARIABLE.getid()}");
            Console.WriteLine("------------------------------");
        }

        Console.ReadKey();
        Console.Clear();
        
        Console.WriteLine("printing users");
        foreach (var VARIABLE in readers)
        {
            if (VARIABLE == null)
            {
                Console.WriteLine("??? what the fuck");
                continue;
            }
            Console.WriteLine($"name - {VARIABLE.getName()}\nUid - {VARIABLE.getid()}\nbooks rented - \r");
            VARIABLE.listbooks((int)flags.onlynum);
            Console.WriteLine("------------------------------");
        }
        
        Console.ReadKey();
        Console.Clear();
        
        addbookviaid(books[3].getid() , ref books ,ref readers[1]);
        addbookviaid(books[3].getid() , ref books ,ref readers[2]);
        
        
        readers[1].listbooks();
        readers[2].listbooks();
        
        rembookviaid(books[1].getid() , ref books ,ref readers[0]);
        rembookviaid(books[3].getid() , ref books ,ref readers[1]);
        
        readers[1].listbooks();
        
    }
}