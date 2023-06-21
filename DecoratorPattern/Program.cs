using System;

namespace DecoratorPattern 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dellLaptop = new DellLaptop();
            dellLaptop.OpenLid();
            dellLaptop.CloseLid();

            Console.WriteLine("---------");

            var appleLaptop = new AppleLaptop();
            appleLaptop.OpenLid();
            appleLaptop.CloseLid();
        }
    }

    // 1950s
    public class Computer
    {
        public void Start()
        {
            Console.WriteLine($"{GetType().Name} is starting");
        }

        public void ShutDown()
        {
            Console.WriteLine($"{GetType().Name} is shutting down");
        }
    }

    // 1970s
    public class Laptop : Computer
    {
        public void OpenLid()
        {
            Console.WriteLine($"{GetType().Name} is opening lid");

        }
        public void CloseLid()
        {
            Console.WriteLine($"{GetType().Name} is closing lid");
        }
    }

    // 1990s

    class LaptopDecorator : Laptop
    {
        public virtual void OpenLid()
        {
            base.OpenLid();
        }

        public virtual void  CloseLid()
        {
            base.CloseLid();
        }
    }

    class DellLaptop : LaptopDecorator
    {
        public override void OpenLid()
        {
            // Do something
            base.OpenLid();
        }
        public override void CloseLid()
        {
            // Do something
            base.CloseLid();
        }
    }

    class AppleLaptop : LaptopDecorator
    {
        public override void OpenLid()
        {
            // Do something
            base.OpenLid();
        }
        public override void CloseLid()
        {
            // Do something
            base.CloseLid();
        }
    }

    
    
}

