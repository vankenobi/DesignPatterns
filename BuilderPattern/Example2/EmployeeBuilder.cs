using System;
namespace BuilderPattern.Example2
{
	public class EmployeeBuilder
	{
		// You can edit and build an employee object with this class.

		private readonly Employee employee;

		public EmployeeBuilder()
		{
			employee = new Employee(); 
		}

		public EmployeeBuilder SetFullName(string fullName)
		{
			var splittedFullName = fullName.Split(' ');
			employee.Name = splittedFullName[0];
			employee.Surname = splittedFullName[1];
			return this;
		}

		public EmployeeBuilder SetUsername(string Username)
		{
			employee.Username = Username;
			return this;
		}

		public EmployeeBuilder SetEmailAddress(string Email)
		{
			employee.Email = Email;
			return this;
		}

		public Employee Build()
		{
			return employee;
		}
	}
}

