using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsDemo
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Employee()
        {

        }
        public Employee(string id,
                        string name,
                        string phone)
        {
            ID = id;
            Name = name;
            Phone = phone;
        }
    }
}