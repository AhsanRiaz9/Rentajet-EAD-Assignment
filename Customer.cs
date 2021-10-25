using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF18M009_Rentajet
{
    public class Customer
    {
        public string name { get; set; }
        public string contact { get; set; }
        public string typeOfCharterTransaction { get; set; }
        public Customer(string name,string contact, string typeOfCharterTransaction)
        {
            this.name = name;
            this.contact = contact;
            this.typeOfCharterTransaction=typeOfCharterTransaction;
        }
    }
}
