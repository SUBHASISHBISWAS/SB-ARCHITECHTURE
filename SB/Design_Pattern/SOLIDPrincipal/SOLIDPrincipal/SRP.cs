using System;
using System.Collections.Generic;

namespace SOLIDPrincipal.SRP
{

    public class EmpoyeeDto
    {
        public string Name { get; set; }

        public string SeniorityLavel { get; set; }

        public double BillingRate { get; set; }

        public int WorkingHours { get; set; }

    }
    public class EmpoyeeDataAccessLayer
    {
        public IEnumerable<EmpoyeeDto> GetEmployee()
        {
            // ORM to Get Data
            return new List<EmpoyeeDto>
            {
                new EmpoyeeDto { Name="Subhasish",BillingRate=5, WorkingHours=8,SeniorityLavel="Developer"},
                new EmpoyeeDto { Name="Adrita", BillingRate=10,WorkingHours=8,SeniorityLavel="Manager"}
            };
        }

    }

    // Abstation Removed due to Seperation Consideration  
    public interface IEmployee
    {
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


   
    public class Employee : IEmployee
    {

        private EmpoyeeDataAccessLayer empoyeeDataAccessLayer;

        private ILogger _logger;

        private double totalSalary = 0;

        public Employee(ILogger logger)
        {

            _logger = logger;
            empoyeeDataAccessLayer = new EmpoyeeDataAccessLayer();

        }

        public double EmpoyeeSalaryCalculator()
        {

            var employees = empoyeeDataAccessLayer.GetEmployee();

            foreach (var employee in employees)
            {
                
                switch (employee.SeniorityLavel)
                {
                    case "Developer":
                        totalSalary += (employee.BillingRate * employee.WorkingHours) * 5;
                        break;
                    case "Manager":
                        totalSalary += (employee.BillingRate * employee.WorkingHours) * 10;
                        break;
                    default:
                        totalSalary += employee.BillingRate * employee.WorkingHours * 1;
                        break;
                }

                _logger.Log(string.Format("Employee Name :" + employee.Name + ":" + "Salary" + totalSalary));


            }
            return totalSalary;
        }

        // Not valid for all Employee 
        public void HireNewEmployee()
        {
            throw new NotImplementedException();
        }
        
    }
}
