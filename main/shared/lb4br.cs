namespace eggsbasket.main.shared;

enum flags
{
    list = 0,
    onlynum = 1
}

public abstract class stdinfo
{
    private string name;
    private int id;
    
    public stdinfo(string name , int id)
    {
        this.name = name;
        this.id = id;
    }
    
    public int getid() => id;
    public string getName() => name;
}
public class book : stdinfo
{
    public bool taken = false;

    public book(string Aname, int id) : base(Aname , id) {}
    
}

public class reader : stdinfo
{ 
    List<book> taken_books;

    public reader(string name, int id) : base(name, id)
    {
        taken_books = new List<book>();
    }
    
    public void addbook(book book)
    {
        taken_books.Add(book);
    }

    public bool rembook(book book)
    {
        for (int i = 0; i < taken_books.Count; i++)
        {
            if (taken_books[i].getid() == book.getid())
            {
                taken_books.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void listbooks(int flags = (int)flags.list)
    {
        switch (flags)
        {
            case (int)shared.flags.list:
                if (taken_books.Count == 0)
                {
                    Console.WriteLine($"no books had been rented yet");
                    return;
                }
                foreach (book book in taken_books)
                {
                    Console.WriteLine($"aname - {book.getName()} | id - {book.getid()}");
                }
                break;
            case (int)shared.flags.onlynum:
                Console.WriteLine(taken_books.Count);
                break;
        }
    }
}

public abstract class methods
{
    public void addbookviaid(int bkid, ref book[] books, ref reader reader)
    {
        foreach (book book in books)
        {
            if (book.getid() == bkid && book.taken != true)
            {
                reader.addbook(book);
                book.taken = true;
                Console.WriteLine($"sucsess");
                return;
            }
            else if (book.getid() == bkid && book.taken)
            {
                Console.WriteLine("book had been taken");
                return;
            }
        }

        Console.WriteLine($"no book found with such id or it is already taken");
    }

    public void rembookviaid(int bkid, ref book[] books, ref reader reader)
    {
        foreach (book book in books)
        {
            if (book.getid() == bkid && book.taken)
            {
                if (reader.rembook(book))
                {
                    book.taken = false;
                    Console.WriteLine("sucsess");
                    return;
                }
            }
        }

        Console.WriteLine($"no book found with such id in current user");
    }
}