using System;
using BuilderPattern.Example1;
using BuilderPattern.Example2;
using BuilderPattern.Example3;

namespace BuilderPattern // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Example 1 --");
            Example1();
            Console.WriteLine("-- Example 2 --");
            Example2();
            Console.WriteLine("-- Example 3 --");
            Example3();
        }

        public static void Example1()
        {
            EndpointBuilder endpointBuilder = new EndpointBuilder("www.google.com.tr/")
                .Append("product")
                .AppendParam("id", "xf4546gf")
                .Build();

            endpointBuilder.PrintUrl();
        }

        public static void Example2()
        {
            EmployeeBuilder employeeBuilder = new();
            var employee = employeeBuilder.SetFullName("Musa Küçük")
                            .SetEmailAddress("musakucuk@gmail.com")
                            .SetUsername("musakucuk99")
                            .Build();

            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Surname);   
        }

        public static void Example3()
        {
            // You can see the different domain of mail address after '@' character in this example.
            // Because it creates different instance from same implemantation 

            IEmployeeBuilderM2 employeeBuilderM2Internal = new InternalEmployeeBuilderM2();
            employeeBuilderM2Internal.SetEmailAddress("musakucuk@gmail.com");
            employeeBuilderM2Internal.SetFullName("Musa Kucuk");
            employeeBuilderM2Internal.SetUsername("musakucuk");

            var employee1 = employeeBuilderM2Internal.Build();
            Console.WriteLine($"Name: {employee1.Name}");
            Console.WriteLine($"Surname: {employee1.Surname}");
            Console.WriteLine($"Email: {employee1.Email}");
            Console.WriteLine($"Username: {employee1.Username}");

            // -----
            Console.WriteLine("---------------");

            IEmployeeBuilderM2 employeeBuilderM2External = new ExternalEmployeeBuilderM2();

            employeeBuilderM2External.SetEmailAddress("musakucuk@gmail.com");
            employeeBuilderM2External.SetFullName("Musa Kucuk");
            employeeBuilderM2External.SetUsername("musakucuk99");
            var employee2 = employeeBuilderM2External.Build();


            Console.WriteLine($"Name: {employee2.Name}");
            Console.WriteLine($"Surname: {employee2.Surname}");
            Console.WriteLine($"Email: {employee2.Email}");
            Console.WriteLine($"Username: {employee2.Username}");

        }
    }
}