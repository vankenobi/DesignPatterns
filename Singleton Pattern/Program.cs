using System;
using Singleton_Pattern;

namespace SingletonPattern 
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // The object creates only one time on runtime and we can access the object
            // The processs is runnig just two seconds.
            
            Console.WriteLine(DateTime.Now.ToLongTimeString().ToString());
            var countries = await CountryBuilder.Instance.GetCountries();

            foreach (var item in countries)
            {
                Console.WriteLine(item.Name);
            }

            var countries2 = CountryBuilder.Instance.GetCountries();
            Console.WriteLine(DateTime.Now.ToLongTimeString().ToString());
            
        }
    }
}
