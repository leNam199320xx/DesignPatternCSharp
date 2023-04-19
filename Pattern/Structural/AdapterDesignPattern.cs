using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Structural
{
    internal class AdapterDesignPattern
    {
        public class EmployeeAdapter : ITarget
        {
            ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem();

            public void ProcessCompanySalary(string[,] employeesArray)
            {
                string Id = null;
                string Name = null;
                string Designation = null;
                string Salary = null;
                List<Employee> listEmployee = new List<Employee>();
                for (int i = 0; i < employeesArray.GetLength(0); i++)
                {
                    for (int j = 0; j < employeesArray.GetLength(1); j++)
                    {
                        if (j == 0)
                        {
                            Id = employeesArray[i, j];
                        }
                        else if (j == 1)
                        {
                            Name = employeesArray[i, j];
                        }
                        else if (j == 2)
                        {
                            Designation = employeesArray[i, j];
                        }
                        else
                        {
                            Salary = employeesArray[i, j];
                        }
                    }
                    listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Designation, Convert.ToDecimal(Salary)));
                }
                Console.WriteLine("Adapter chuyen doi mang Employee thanh danh sach Employee");
                Console.WriteLine("Sau do uy quyen cho he thong ThirdPartyBillingSystem de xu ly tien luong cua nhan vien\n");
                thirdPartyBillingSystem.ProcessSalary(listEmployee);
            }
        }
        public interface ITarget
        {
            void ProcessCompanySalary(string[,] employeesArray);
        }
        public class ThirdPartyBillingSystem
        {
            public void ProcessSalary(List<Employee> listEmployee)
            {
                foreach (Employee employee in listEmployee)
                {
                    Console.WriteLine("Rs." + employee.Salary + " muc luong duoc ghi cho tai khoan cua " + employee.Name);
                }
            }
        }
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
            public decimal Salary { get; set; }
            public Employee(int id, string name, string designation, decimal salary)
            {
                ID = id;
                Name = name;
                Designation = designation;
                Salary = salary;
            }
        }
    }
}
