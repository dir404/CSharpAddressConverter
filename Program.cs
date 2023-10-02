using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAddressConverter
{
    class Address
    {
        public string Index { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }

        public override string ToString()
        {
            return $"Address: {Index}, {Country}, {City}, {Street}, {House}, {Apartment}";
        }
    }

    class Converter
    {
        private double Usd { get; set; }
        private double Eur { get; set; }
        private double Pln { get; set; }

        public Converter(double usd, double eur, double pln)
        {
            Usd = usd;
            Eur = eur;
            Pln = pln;
        }

        public double UahToCurrency(double amount, string currency)
        {
            switch (currency.ToUpper())
            {
                case "USD":
                    return amount / Usd;
                case "EUR":
                    return amount / Eur;
                case "PLN":
                    return amount / Pln;
                default:
                    return -1;
            }
        }

        public double CurrencyToUah(double amount, string currency)
        {
            switch (currency.ToUpper())
            {
                case "USD":
                    return amount * Usd;
                case "EUR":
                    return amount * Eur;
                case "PLN":
                    return amount * Pln;
                default:
                    return -1; 
            }
        }
    }

    class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Employee(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        public (double, double) CalculateSalary(string position, int experience)
        {
            var positions = new Dictionary<string, double>
            {
                { "MANAGER", 30000 },
                { "DEVELOPER", 40000 },
                { "DESIGNER", 35000 }
            };
            var baseSalary = positions.ContainsKey(position.ToUpper()) ? positions[position.ToUpper()] : 25000;
            if (experience > 5)
            {
                baseSalary += 5000;
            }
            var tax = baseSalary * 0.15;
            return (baseSalary, tax);
        }

        public override string ToString()
        {
            return $"Employee: {LastName}, {FirstName}";
        }
    }

    class User
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; }

        public User(string login, string firstName, string lastName, int age)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            RegistrationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"User: {Login}, {FirstName}, {LastName}, {Age}, {RegistrationDate}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var address = new Address
            {
                Index = "12345",
                Country = "Україна",
                City = "Київ",
                Street = "Вулиця Київська",
                House = "12",
                Apartment = "34"
            };

            Console.WriteLine(address);

            var converter = new Converter(28.0, 33.0, 7.0);

            Console.WriteLine("1000 UAH to USD: " + converter.UahToCurrency(1000, "USD"));
            Console.WriteLine("100 EUR to UAH: " + converter.CurrencyToUah(100, "EUR"));

            var employee = new Employee("Петров", "Іван");

            var (salary, tax) = employee.CalculateSalary("DEVELOPER", 7);
            Console.WriteLine(employee);
            Console.WriteLine($"Salary: {salary} UAH");
            Console.WriteLine($"Tax: {tax} UAH");

            var user = new User("user123", "Іван", "Петров", 30);

            Console.WriteLine(user);
            Console.ReadLine();
        }
    }
}
