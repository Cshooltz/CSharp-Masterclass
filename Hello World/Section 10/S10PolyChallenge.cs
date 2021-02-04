using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    // Section 10, lesson 110
    // Polymorphism challenge
    class S10PolyChallenge
    {
        static public void Main()
        {
            Car SimpleCar = new Car(200, "Red");

            BMW MyBMW = new BMW(250, "Silver", "M3");

            Audi MyAudi = new Audi(150, "Green", "A4");

            var Cars = new List<Car> { SimpleCar, MyBMW, MyAudi };

            foreach(Car c in Cars)
            {
                c.ShowDetails();
                c.Repair();
                Console.WriteLine("---");
            }

            MyBMW.SetCarIDInfo(1234, "Scott");
            MyAudi.SetCarIDInfo(5678, "Mika");
            MyBMW.GetCarIDInfo();
            MyAudi.GetCarIDInfo();

            return;
        }
    }

    // Lesson 112
    // Demonstrates the Has A relationship. 
    class CarIDInfo
    {
        public int IDNum { get; set; } = 0;
        public string Owner { get; set; } = "No owner";
    }

    class Car
    {
        public int HP { get; set; }
        public string Color { get; set; }

        protected CarIDInfo carIDInfo = new CarIDInfo();

        public void SetCarIDInfo(int idNum, string owner)
        {
            carIDInfo.IDNum = idNum;
            carIDInfo.Owner = owner;
        }

        public void GetCarIDInfo()
        {
            Console.WriteLine($"The car has the ID of {carIDInfo.IDNum} and is owned by {carIDInfo.Owner}");
        }

        public Car()
        {
            HP = 1;
            Color = "Brown";
            // It's a horse, get it?
            return;
        }

        public Car(int horsePower, string color)
        {
            this.HP = horsePower;
            this.Color = color;
            return;
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Vehicle Details: {HP} Horsepower - Color is {Color}");
            return;
        }

        public virtual void Repair()
        {
            Console.WriteLine("Car was repaired!");
            return;
        }
    }

    class BMW : Car
    {
        public string Model { get; set; }
        private string Brand { get; } = "BMW";

        public BMW() : base()
        {
            Model = "";
            return;
        }

        public BMW(int horsePower, string color, string model) : base(horsePower, color)
        {
            Model = model;
            return;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Vehicle Details: Make is {Brand} - Model is {Model} - {HP} Horsepower - Color is {Color}");
        }

        public sealed override void Repair()
        {
            Console.WriteLine($"The {Brand} {Model} car was repaired!");
        }
    }

    class M3 : BMW
    {
        public M3() : base()
        {
            Model = "";
            return;
        }

        public M3(int horsePower, string color)
        {
            HP = horsePower;
            Color = color;
            Model = "M3";
            return;
        }

        /* Cannot inherit from sealed members. Sealed can also be used on a class itself to stop all inheritance. 
        public override void Repair()
        {

        }*/
    }


    class Audi : Car
    {
        public string Model { get; set; }
        private string Brand { get; } = "Audi";

        public Audi() : base()
        {
            Model = "";
            return;
        }

        public Audi(int horsePower, string color, string model) : base(horsePower, color)
        {
            Model = model;
            return;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Vehicle Details: Make is {Brand} - Model is {Model} - {HP} Horsepower - Color is {Color}");
        }

        public override void Repair()
        {
            Console.WriteLine($"The {Brand} {Model} car was repaired!");
        }
    }
}
