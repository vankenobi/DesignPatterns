using System;
namespace StrategyPattern.Example2
{
	public class PaymentService
	{
        private IPayment _payment;

		public PaymentService()
		{
		}

        public PaymentService(IPayment payment)
        {
            _payment = payment;
        }

        public void ChangePaymentService(IPayment payment)
        {
            _payment = payment;
            Console.WriteLine($"Payment service changed as {_payment.GetType().Name}");
        }

        public void ApplyPaymentService(PaymentOptions paymentOptions)
        {
            _payment.Pay(paymentOptions);
        }
        
		
	}

	public interface IPayment
	{
		void Pay(PaymentOptions paymentOptions);
	}

    public class ABankPayment : IPayment
    {
        public void Pay(PaymentOptions paymentOptions)
        {
			Console.WriteLine("A bank payment gotted.");
        }
    }

    public class BBankPayment : IPayment
    {
        public void Pay(PaymentOptions paymentOptions)
        {
            Console.WriteLine("B bank payment gotted.");
        }
    }

    public class CBankPayment : IPayment
    {
        public void Pay(PaymentOptions paymentOptions)
        {
            Console.WriteLine("C bank payment gotted.");
        }
    }

    // Model
    public class PaymentOptions
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public decimal Amount { get; set; }
    }
    
}

