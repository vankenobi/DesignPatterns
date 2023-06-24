using System;
namespace ObserverPattern
{
	public class Amazon
	{
		
		private Dictionary<IObserver,Product> observers = new();

		public void Register(IObserver observer,Product product)
		{
			observers.TryAdd(observer, product);
		}
		
		public void UnRegister(IObserver observer)
		{
			observers.Remove(observer);
		}

		public void NotifyAll()
		{
			foreach (var kv in observers)
			{
				kv.Key.StockUpdate(kv.Value);
			}
		}

		public void NotifyForProductName(string productName)
		{
			foreach (var kv in observers)
			{
				if (kv.Value.Name == productName)
				{
					kv.Key.StockUpdate(kv.Value);
				}
			}
		}
	}

	public interface IObserver
	{
		void StockUpdate(Product product);
	}

	
	public class MusaObserver : IObserver
	{
		public string FullName { get; set; }

		public MusaObserver(string fullName)
		{
			FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
		}

        public void StockUpdate(Product product)
        {
			Console.WriteLine($"{FullName}, {product.Name} in stock !! ");
        }
    }

    public class JackObserver : IObserver
    {
        public string FullName { get; set; }

        public JackObserver(string fullName)
        {
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        }

        public void StockUpdate(Product product)
        {
            Console.WriteLine($"{FullName}, {product.Name} in stock !! ");
        }
    }


    public class Product
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public Product(string name, decimal price)
		{
			Name = name;
			Price = price;	
		}
	}
}

