using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMasterClass
{
    class S11Abstract
    {
        public static void Main()
        {
            // Can't do this
            //Shape shape1 = new Shape;

            Shape cube1 = new Cube(3);
            cube1.GetInfo();
            Console.WriteLine($"The cube has a volume of: {((Cube)cube1).Volume()}");

            Sphere sphere1 = new Sphere(4);
            sphere1.GetInfo();
            Console.WriteLine($"The sphere has a volume of: {sphere1.Volume()}");

            Shape[] shapes = { new Sphere(6), new Cube(3.3333) };
            foreach (Shape shape in shapes)
            {
                shape.GetInfo();
                Console.WriteLine($"{shape.Name} has a volume of {shape.Volume()}");

                Cube iceCube = shape as Cube; // Say I want an object as a specific data type, an alternative to casting.
                // It works with reference or nullable types.
                if (iceCube == null) Console.WriteLine("This shape is not a cube");

                if(shape is Cube)
                {
                    Console.WriteLine("This shape is a cube");
                }

                object cube2 = new Cube(7);
                Cube cube3 = (Cube)cube2;
                Console.WriteLine($"{cube3.Name} has a volume of {cube3.Volume()}");
            }


            return;
        }
    }

    abstract class Something
    {
        public abstract void Smooth();
    }

    // Unlike an interface, an abstract class acts like a base class.
    // A class cannot inherit from multiple abstract classes
    // But can inherit from multiple interfaces.
    abstract class Shape
    {
        public string Name { get; set; }

        // Virtual methods can have a default implementation
        public virtual void GetInfo()
        {
            Console.WriteLine($"\nThis is a {Name}");
        }

        public abstract double Volume(); // Abstract methods cannot have an implementation. Think interface.
    }

    class Cube : Shape
    {
        public double Length { get; set; }

        public Cube(double length)
        {
            Name = "Cube";
            Length = length;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"The cube has a length of {Length}");
        }

        public override double Volume()
        {
            return Math.Pow(Length, 3);
        }
    }

    class Sphere : Shape
    {
        public double Radius { get; set; }

        public Sphere(double radius)
        {
            Name = "Sphere";
            Radius = radius;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"The sphere has a radius of {Radius}");
        }

        public override double Volume()
        {
            return (4/3)*Math.PI*Math.Pow(Radius, 3);
        }
    }
}
