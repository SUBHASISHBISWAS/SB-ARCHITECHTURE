using System;
using System.Collections.Generic;

namespace SOLIDPrincipal.OCP
{

    public class EmployeeDto
    {
        public string Name { get; set; }

        public string SeniorityLavel { get; set; }

        public double BillingRate { get; set; }

        public int WorkingHours { get; set; }

    }
    public class EmpoyeeDataAccessLayer
    {
        public IEnumerable<EmployeeDto> GetEmployee()
        {
            // ORM to Get Data
            return new List<EmployeeDto>
            {
                new EmployeeDto { Name="Subhasish",BillingRate=5, WorkingHours=8,SeniorityLavel="Developer"},
                new EmployeeDto { Name="Adrita", BillingRate=10,WorkingHours=8,SeniorityLavel="Manager"}
            };
        }

        public void Save(EmployeeDto employeeDto)
        {
            // Save the Employee
        }


    }

    // Abstation Removed due to Seperation Consideration  
    public interface IEmployee
    {
        string Name { get; set; }

        double BillingRate { get; set; }

        int WorkingHours { get; set; }

        double EmpoyeeSalaryCalculator();
        void HireNewEmployee();

    }

    public interface ILogger
    {
        void Log(string message);
    }

    // Logging (Cross cutting Concern) is Seperated from Domain Logic
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }



    public abstract class Employee : IEmployee
    {

        protected string Name { get; set; }

        protected double BillingRate { get; set; }

        protected int WorkingHours { get; set; }

        private EmpoyeeDataAccessLayer _empoyeeDataAccessLayer;

        private ILogger _logger;

        private double totalSalary = 0;

        private IEnumerable<IEmployee> _employeeList;

        public Employee(ILogger logger, IEnumerable<IEmployee> employees)
        {

            _logger = logger;
            _employeeList = employees;
            _empoyeeDataAccessLayer = new EmpoyeeDataAccessLayer();


        }

        public abstract double CalculateSalary();

        public double EmpoyeeSalaryCalculator()
        {

            foreach (var employee in _employeeList)
            {
                totalSalary += CalculateSalary();
                _logger.Log(string.Format("Employee Name :" + Name + ":" + "Salary" + totalSalary));
                _empoyeeDataAccessLayer.Save(new EmployeeDto
                {
                    Name= employee.Name,
                    BillingRate=employee.BillingRate,
                    WorkingHours=employee.WorkingHours
                });


            }
            return totalSalary;
        }

        // Not valid for all Employee 
        public void HireNewEmployee()
        {
            throw new NotImplementedException();
        }

    }

    public class Developer : Employee
    {
        
        public double BillingRate { private set; get; }
        double salary = 0;

        public Developer(ILogger logger, IEnumerable<IEmployee> employees)
            :base(logger,employees)
        {

        }
        public override double CalculateSalary()
        {
            return salary += (WorkingHours* BillingRate) * 5;
        }
    }

    public class Manager : Employee
    {
        public int WorkingHours { private set; get; }
        public double BillingRate { private set; get; }
        double salary = 0;

        public Manager(ILogger logger, IEnumerable<IEmployee> employees)
            : base(logger, employees)
        {

        }
        public override double CalculateSalary()
        {
            return salary += (WorkingHours * BillingRate) * 10;
        }
    }
}
