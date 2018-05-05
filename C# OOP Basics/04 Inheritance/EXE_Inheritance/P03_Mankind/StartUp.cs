using System;

namespace P03_Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var studentParams = Console.ReadLine().Split();
            var firstName = studentParams[0];
            var lastName = studentParams[1];
            var facultyNumber = studentParams[2];

            var workerParams = Console.ReadLine().Split();
            var workerFirstName = workerParams[0];
            var workerLastName = workerParams[1];
            var salary = decimal.Parse(workerParams[2]);
            var workHours = decimal.Parse(workerParams[3]);

            try
            {
                var student = new Student(firstName, lastName, facultyNumber);
                var worker = new Worker(workerFirstName, workerLastName, salary, workHours);

                Console.WriteLine(student);
                Console.WriteLine(  );
                Console.WriteLine(worker);
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
