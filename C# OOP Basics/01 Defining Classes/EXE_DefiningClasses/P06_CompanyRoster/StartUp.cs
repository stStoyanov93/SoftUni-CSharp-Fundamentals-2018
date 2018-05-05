using System;
using System.Linq;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();

            var name = input[0];
            var salary = decimal.Parse(input[1]);
            var position = input[2];
            var department = input[3];

            var emp = new Employee()
            {
                Name = name,
                Salary = salary,
                Position = position,
                Department = department
            };

            if (input.Length == 5 && input[4].Contains("@"))
            {
                emp.Email = input[4];
            }
            else if (input.Length == 5)
            {
                emp.Age = int.Parse(input[4]);
            }
            else if (input.Length == 6)
            {
                emp.Email = input[4];
                emp.Age = int.Parse(input[5]);
            }

            employees.Add(emp);

        }

        var highestAverageSalaryDepartment = employees
            .GroupBy(e => e.Department)
            .Select(d => new
            {
                DepartmentName = d.Key,
                AverageSalary = d.Average(e => e.Salary),
                Employees = d.OrderByDescending(e => e.Salary).ToList()
            })
            .OrderByDescending(d => d.AverageSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment.DepartmentName}");

        foreach (var e in highestAverageSalaryDepartment.Employees)
        {
            Console.Write($"{e.Name} {e.Salary:f2} ");

            if (e.Email == null)
            {
                Console.Write("n/a ");
            }
            else
            {
                Console.Write($"{e.Email} ");
            }

            if (e.Age == 0)
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine($"{e.Age}");
            }
        }
    }
}

