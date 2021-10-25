using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF18M009_Rentajet
{
    class Employee
    {
        public string role { get; set; }
        public double salary { get; set; }
        public Employee(string r, double sal)
        {
            role = r;
            salary = sal;
        }
        public double personalCost()
        {
            return this.salary * 1.2;
        }
    }
}
