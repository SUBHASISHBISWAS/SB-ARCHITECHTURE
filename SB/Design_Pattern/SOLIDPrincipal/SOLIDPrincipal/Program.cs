using System;
using System.Collections.Generic;

namespace SOLIDPrincipal
{

    public class EmpoyeeDto
    {
        public string Name { get; set; }

        public  string SeniorityLavel { get; set; }

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

    // Come up with this abstraction @requirement analysis or at the time of development after
    public interface IEmployee
    {
        double EmpoyeeSalaryCalculator();
        void HireNewEmployee();
        void Log(string message);
    }

    // Intial Abstraction and Encapsulation
    public class Employee :IEmployee
    {

        // 1.Reason for Change
        // This Persistance Layer will Chnage Over Time 
        private EmpoyeeDataAccessLayer empoyeeDataAccessLayer;
        
        double totalSalary = 0;

        public Employee()
        {
            // No validation 
            empoyeeDataAccessLayer = new EmpoyeeDataAccessLayer();
        }

        public double EmpoyeeSalaryCalculator()
        {
            
            var employees = empoyeeDataAccessLayer.GetEmployee();

            foreach (var employee in employees)
            {
                // 2.Reason for Change
                //This Business Logic Change Over Time 
                switch (employee.SeniorityLavel)
                {
                    case "Developer":
                        totalSalary += (employee.BillingRate * employee.WorkingHours)*5;
                        break;
                    case "Manager":
                        totalSalary += (employee.BillingRate * employee.WorkingHours) *10;
                        break;
                    default:
                        totalSalary += employee.BillingRate * employee.WorkingHours*1;
                        break;
                }

                Log(string.Format("Employee Name :" + employee.Name + ":" + "Salary" + totalSalary));
                
                
            }
            return totalSalary;
        }

        // Not valid for all Employee 
        public void HireNewEmployee()
        {
            throw new NotImplementedException();
        }

        // 3.Reason for Change
        // Logging (Cross cutting Concern and not Domain or Business Logic): 
        public void Log( string message)
        {
            Console.WriteLine(message);
        }
    }

   

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
