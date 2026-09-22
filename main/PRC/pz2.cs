// в масиві все іде по порядко [1 , 2  , 3] індексація з 0 якщо мова не луа
// зубчастий масив - це масив з масивами кароче , і всі масиви можуть мать різну довжину
// //
namespace thing
{
    internal class pz2
    {
        //ignore this if you are here for THE task , it`s theory
        static void B_runit() 
        {
            int[] array = new int[10]; //дефолт арей
            
            int[,] twodemarray = new int[3, 4]; // 2 вимірний
            
            int[][] jaggedArray = new int[3][]; //зубчастий
            
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[4];
            
            //масиви не заповнені тому будуть 0 , тому що default значення , яке можна присвоювати змінним є нулем
            
            for (int i = 0 ; i < jaggedArray.Length ; i++)
            {
                Console.WriteLine($"Now {i}:");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine($"{jaggedArray[i][j]} ");
                }
            }
        }

        public static void systemd()
        {
            Random rnd = new Random();
            int groups = rnd.Next(3, 6);
            
            static void filler(ref int[][] tofill)
            {
                Random rnd = new Random();
                for (int i = 0; i < tofill.Length; i++)
                {
                    int students = rnd.Next(10, 31);
                    tofill[i] = new int[students];
                    for (int j = 0; j < students; j++)
                    {
                        tofill[i][j] = rnd.Next(0, 101);
                    }
                }
            }
            static void printer(int[][] toprint)
            {
                Console.WriteLine("prepeare for getting console absolutely trashed");
                for (int i = 0; i < toprint.Length; i++){
                    Console.WriteLine($"doing - {i}");
                    for (int j = 0; j < toprint[i].Length; j++)
                    {
                        Console.WriteLine($"thing[{i}][{j}] - {toprint[i][j]}");
                    }
                }
            }
            static double avgForALLupREQ(int[][] array)
            {
                double sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i].Average();
                }
                sum /= array.Length;
                return sum;
            }
            static int findMIN(int[][] array)
            {
                int min = array[0].Min(); //welp same thing here , anyways ill write the manual thing
                for (int i = 1; i < array.Length; i++)
                {
                    if(array[i].Min() < min)
                    {
                        min = array[i].Min();
                    }
                }
                return min;
            }
            static int findNAX(int[][] array)
            {
                int max = array[0].Max(); //welp same thing here , anyways ill write the manual thing
                for (int i = 1; i < array.Length; i++)
                {
                    if(array[i].Max() < max)
                    {
                        max = array[i].Max();
                    }
                }
                return max;
            }
            
            int[][] jaggedArray = new int[groups][];
            filler(ref jaggedArray);
            //since i discovered Avarage method , there is no need to write function for counting avg among one group :p , but if i would id just do nested loop thing add up all marks and / on array.Lenght
            
            //printer(jaggedArray);
            
            Console.WriteLine($"avg among all - {avgForALLupREQ(jaggedArray)}");
            Console.WriteLine($"avg among group 1 - {jaggedArray[0].Average()}");
            Console.WriteLine($"lowest and highest amongs all group - {findMIN(jaggedArray)} and {findNAX(jaggedArray)} ");
            Console.WriteLine($"lowest in group 3 - {jaggedArray[2].Min()}");//wond add Max() u get the idea
            
            Console.WriteLine("now as i told promised il do the manual thing instead of ready methods");
            Console.WriteLine($"avg amongst all - {manualshit.avgforallmanual(jaggedArray)}");
            Console.WriteLine($"avg amongst group 1 - {manualshit.avgforonemanual(jaggedArray , 0)}");
            Console.WriteLine($"minimal for all - {manualshit.minallMAnual(jaggedArray)}");
            Console.WriteLine($"max for group 3 - {manualshit.maxforgroup(jaggedArray , 2)}");
        }
    }
    internal class manualshit()
    {
        internal static double avgforallmanual(int[][] array)
        {
            double sum = 0;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                    count++;
                }
            }
            return sum / count;
        }//we con go deeper in the rabbithole if we ,make our own method of lenght but i dont think task needs it
        internal static double avgforonemanual(int[][] array, int group)
        {
            double sum = 0;
            for (int i = 0; i < array[group].Length; i++)
            {
                sum += array[group][i];
            }
            return sum / array[group].Length;
        }

        internal static int minallMAnual(int[][] array)
        {
            int min = array[0][0];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                    }
                }
            }
            return min;// for max i need to just change operator near min to > , so i wont do other method
        }

        internal static int maxforgroup(int[][] array, int group)
        {
            int max = array[group][0];
            for (int i = 0; i < array[group].Length; i++)
            {
                if (array[group][i] > max)
                {
                    max = array[group][i];
                }
            }
            return max;
        }
    }
}