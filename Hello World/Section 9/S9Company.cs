using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

// This file is for Inheritance Challenge 2 of section 9.
// Inludes calling the base constructor. 
namespace CSMasterClass
{     
    class S9Company
    {
        public static void Main()
        {
            Employee Steve = new Employee("Engineer", "Steve", 75000M);
            Boss Chuck = new Boss("Widget Manufacturing", "Chuck", 90000M, "Buick LeSabre");
            Trainee Todd = new Trainee("Sales Rep", "Todd", 30000M, 20, 20);

            Console.WriteLine($"{Chuck.x}");

            Steve.Work();
            Chuck.Lead();
            Todd.Work();
            Todd.Learn();
            return;
        }
    }

    class Employee
    {
        public int x = 0;
        public  string Name { get; set; }
        public string FirstName { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
            Name = "Employee";
            FirstName = "";
            Salary = 50000M;
        }

        public Employee(string positionName, string firstName, decimal salary)
        {
            this.Name = positionName;
            this.FirstName = firstName;
            this.Salary = salary;
            return;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{FirstName} is a {Name} employee.");
            return;
        }

        public void Pause()
        {
            Console.WriteLine($"{FirstName} Takes a break.");
            return;
        }
    }

    class Boss : Employee
    {
        public new int x = 15;
        public string CompanyCar { get; set; }

        public Boss()
        {
            Name = "Boss";
            FirstName = "";
            Salary = 100000M;
        }

        public Boss(string positionName, string firstName, decimal salary, string companyCar) : base(positionName, firstName, salary)
        {
            this.CompanyCar = companyCar;
            return;
        }

        public void Lead()
        {
            Console.WriteLine($"{FirstName} is a {Name} leader that drives a {CompanyCar}.");
            return;
        }
    }

    class Trainee : Employee
    {
        public int WorkingHours { get; set; }
        public int SchoolHours { get; set; }

        public Trainee()
        {
            Name = "Trainee";
            FirstName = "";
            Salary = 25000M;
            WorkingHours = 20;
            SchoolHours = 20;
        }

        public Trainee(string positionName, string firstName, decimal salary, int workingHours, int schoolHours) : base(positionName, firstName, salary)
        {
            this.WorkingHours = workingHours;
            this.SchoolHours = schoolHours;
            return;
        }

        public void Learn()
        {
            Console.WriteLine($"{FirstName} is a trainee learning to be a {Name}");
            return;
        }

        public override void Work()
        {
            Console.WriteLine($"{FirstName}, who is a trainee {Name}, has {WorkingHours} working hours per week.");
            return;
        }
    }
}
