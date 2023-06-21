using System;
using BuilderPattern.Example2;

namespace BuilderPattern.Example3
{
    public interface IEmployeeBuilderM2
    {
        EmployeeM2 Build();
        void SetEmailAddress(string Email);
        void SetFullName(string fullName);
        void SetUsername(string Username);
    }

    public abstract class EmployeeBuilderM2 : IEmployeeBuilderM2
    {

        protected readonly EmployeeM2 Employee;

        public EmployeeBuilderM2()
        {
            Employee = new EmployeeM2();
        }

        public abstract void SetFullName(string fullName);

        public abstract void SetUsername(string Username);

        public abstract void SetEmailAddress(string Email);

        public EmployeeM2 Build() => Employee;

    }
}

