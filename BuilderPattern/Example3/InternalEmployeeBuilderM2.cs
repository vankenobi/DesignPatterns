using System;
namespace BuilderPattern.Example3
{
	public class InternalEmployeeBuilderM2 : EmployeeBuilderM2
	{
		public InternalEmployeeBuilderM2()
		{
		}

        public override void SetEmailAddress(string Email)
        {
            var splittedEmail = Email.Split('@');
            Employee.Email = splittedEmail[0] + "@internal.com";
        }

        public override void SetFullName(string fullName)
        {
            var splittedFullName = fullName.Split(' ');
            Employee.Name = splittedFullName[0];
            Employee.Surname = splittedFullName[1];
        }

        public override void SetUsername(string username)
        {
            Employee.Username = username;
        }

    }
}

