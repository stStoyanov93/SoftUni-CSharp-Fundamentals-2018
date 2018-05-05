using System;

namespace P04_Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var smartphone = new Smartphone();
            var phoneNumbers = Console.ReadLine().Split();

            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(number));
            }

            var urls = Console.ReadLine().Split();

            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
