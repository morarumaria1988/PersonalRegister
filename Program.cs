using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
}

class EmployeeRegistry
{
    private List<Employee> employees;

    public EmployeeRegistry()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void PrintRegistry()
    {
        Console.WriteLine("Personalregister:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"Namn: {employee.Name}, Lön: {employee.Salary}");
        }
    }

    static void Main(string[] args)
    {
        var registry = new EmployeeRegistry();

        while (true)
        {
            try
            {
                Console.Write("Ange anställdens namn: ");
                var name = Console.ReadLine();
                Console.Write("Ange anställdens lön: ");
                var salary = double.Parse(Console.ReadLine());

                var employee = new Employee { Name = name, Salary = salary };
                registry.AddEmployee(employee);
            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktig inmatning. Försök igen.");
            }

            Console.Write("Vill du lägga till fler anställda? (ja/nej): ");
            var moreEmployees = Console.ReadLine();
            if (string.Equals(moreEmployees, "nej", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            while (!string.Equals(moreEmployees, "ja", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Felaktig inmatning. Skriv ja eller nej: ");
                moreEmployees = Console.ReadLine();
            }
        }

        registry.PrintRegistry();
    }
}
