using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Creational
{
    internal class PrototypeDesignPattern
    {
        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }

            public Employee GetClone()
            {
                return (Employee)MemberwiseClone();
            }
        }
    }
}
