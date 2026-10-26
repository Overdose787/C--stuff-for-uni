namespace eggsbasket.main.LW;

public class Lw1
{
    public static void Run()
    {
        int a, b, c;
        input_sides(out a, out b, out c);
        Console.WriteLine(check_for_pos(a, b, c));
        bool istriangleexi = Checkfortriangle(a, b, c);
        Console.WriteLine(istriangleexi);
        if (istriangleexi)
        {
            Console.WriteLine(PerimeterOftriangle(a, b, c));
            Console.WriteLine(Permiter2(a, b, c));
            Console.WriteLine(WhichTriangle(a, b, c));
        }
        else
        {
            Console.WriteLine($"triangle does not exist , further operation is canceled || Checkfortriangle says - {istriangleexi}");
        }
        
    }
    
    public static void input_sides(out int a, out int b, out int c)
    {
        string input;
        a = 0;
        b = 0;
        c = 0;
        for (int i = 0; i < 3;)
        {
            Console.Write($"Enter an integer for {i + 1} - side : ");
            input = Console.ReadLine();
            if (i == 0 && int.TryParse(input, out a))
            {
                i++;
            }
            else if (i == 1 && int.TryParse(input, out b))
            {
                i++;
            }
            else if (i == 2 && int.TryParse(input, out c))
            {
                i++;
            }
            else
            {
                Console.WriteLine("enter a number value");
            }
        }
    }

    public static bool check_for_pos(int a, int b, int c)
    {
        if (a > 0 && b > 0 && c > 0)
        {
            return true;
        }

        return false;
    }

    public static bool Checkfortriangle(int a, int b, int c)
    {
        if (a + b > c && a + c > b && b + c > a)
        {
            return true;
        }

        return false;
    }

    public static int PerimeterOftriangle(int a, int b, int c)
    {
        return a + b + c;
    }

    public static double Permiter2(int a, int b, int c)
    {
        double p = (a + b + c) / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static bool Ptheorem(int a, int b, int c)
    {
        static bool in_ifeven(double mega, double combined_mini)
        {
            if (mega == combined_mini)
            {
                return true;
            }
            return false;
        }
        double Da = Math.Pow(a, 2);
        double Db = Math.Pow(b, 2);
        double Dc = Math.Pow(c, 2);
        
        if (Da > Db && Da > Dc && in_ifeven(Da , Db+Dc))
        {
            return true;
        }
        else if (Da < Db && Db > Dc && in_ifeven(b, Da + Dc))
        {
            return true;
        }
        else if (Dc > Da  && Dc > Db && in_ifeven(Dc, Da + Db))
        {
            return true;
        }
        return false;
    }

    public static bool IsTrianglearb(int a, int b, int c)
    {
        double Da = Math.Pow(a, 2);
        double Db = Math.Pow(b, 2);
        double Dc = Math.Pow(c, 2);

        double alpha = Math.Acos(Math.Cos((Db + Dc - Da) / (2 * b * c)));
        double beta = Math.Acos(Math.Cos((Da + Dc - Db) / (2 * a * c)));
        double gamma = 180 - (alpha + beta);

        if (alpha != 90 && alpha != beta && alpha != gamma && beta != 90 && beta != gamma && gamma != 90)
        {
            return true;
        }
        return false;
    }
    public static string WhichTriangle(int a, int b, int c)
    {
        if (a == b && b == c)
        {
            return "Рівносторонній";
        }
        else if (a == b && a != c || b == c && b != a)
        {
            return "Рівнобедрений";
        }
        else if (Ptheorem(a, b, c))
        {
            return "Прямокутний";
        }
        else if (a != b && b != c && IsTrianglearb(a, b, c))
        {
            return "довільний";
        }
        return "something went wrong";
    }
}