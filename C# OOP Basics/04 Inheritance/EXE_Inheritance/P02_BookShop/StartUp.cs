using System;

namespace P02_BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var author = Console.ReadLine();
                var title = Console.ReadLine();
                var price = decimal.Parse(Console.ReadLine());

                var normalBook = new Book(author, title, price);
                var goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(normalBook);
                Console.WriteLine();
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
