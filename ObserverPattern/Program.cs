using System;
using ObserverPattern;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new Products
            var appleWatch = new Product("Apple Watch Series 8",12000);
            var iphone = new Product("Iphone14", 550000);

            //Observer
            var musaObserver = new MusaObserver("Musa Kucuk");
            var jackObserver = new JackObserver("Hugh Jackman");

            Amazon amazon = new Amazon();

            amazon.Register(musaObserver, appleWatch);
            amazon.Register(jackObserver, iphone);
            amazon.Register(jackObserver, appleWatch);

            // Send notification to all observer
            amazon.NotifyAll();

            // Send a notification for specific product
            //amazon.NotifyForProductName("Iphone14");

           
            
            
        }
    }
}
