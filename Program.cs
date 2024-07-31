using System;


namespace Padelbooker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose mode:");
            Console.WriteLine("1. 1 field in 2 weeks at 20h");
            Console.WriteLine("2. All field in X days for a week");
            string mode = Console.ReadLine();
            if (mode == "1")
            {
                Navigation.BookAllFields(14,"18");
            }
            else
            {
                Console.WriteLine("In how many days?");
                int delay = Convert.ToInt32(Console.ReadLine());
                Navigation.WeekStartingInXDays(delay);
            }

            

        }
    }
}
