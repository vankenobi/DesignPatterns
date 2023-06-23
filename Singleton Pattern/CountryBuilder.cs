using System;
namespace Singleton_Pattern
{
    public class CountryBuilder
    {
        private static CountryBuilder instance = null;

        // create an instance if not exist
        public static CountryBuilder Instance => instance ?? (instance = new CountryBuilder());
        private new List<Country> Countries { get; set; }

        private CountryBuilder()
        {
            Task.Delay(2000).GetAwaiter().GetResult();
            
            Countries = new List<Country>() {
                    new (){ Id = 1,Name = "Turkiye",Population = 82000000 },
                    new (){ Id = 2,Name = "USA",Population = 331000000 },
                    new (){ Id = 3,Name = "Azerbajian",Population = 10000000}
            };

        }

        public async Task<IList<Country>> GetCountries() => Countries;

    }
}


