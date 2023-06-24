using System;
using StrategyPattern.Example2;

namespace StrategyPattern // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Example1();
            Console.WriteLine("------------");
            Example2();
        }

        public static void Example1()
        {
            Character character = new Character();
            character.SetAttackStrategy(new AggresiveCombatStrategy());
            character.ApplyAttackStrategy();

            character.SetAttackStrategy(new DefensiveAttackStrategy());
            character.ApplyAttackStrategy();
        }

        public static void Example2()
        {
            var paymentOptions = new PaymentOptions()
            {
                Amount = 10000,
                CardHolderName = "Musa Kucuk",
                CardNumber = "1234 4567 8910 1112",
                CVV = "114",
                ExpirationDate = "05/24"
            };

            PaymentService paymentService = new PaymentService();

            Console.Write("Please select a bank to payment (1 - A Bank 2 - B Bank 3 - C Bank): ");
            var BankChoice = Console.ReadLine();

            IPayment payment = null;

            switch (BankChoice)
            {
                case "1":
                    payment = new ABankPayment();
                    break;
                case "2":
                    payment = new BBankPayment();
                    break;
                case "3":
                    payment = new CBankPayment();
                    break;
                default:
                    Console.WriteLine("This is not an option");
                    break;
            }

            paymentService.ChangePaymentService(payment);
            paymentService.ApplyPaymentService(paymentOptions);

        }

    }


}