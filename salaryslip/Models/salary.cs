using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace salaryslip.Models
{
    public class salary
    {
        public int id { get; set; }
        public string name { get; set; }
        public string employerid { get; set; }
        public string title { get; set; }
        public string depart { get; set; }
        public string accno { get; set; }
        public int basicsalary { get; set; }
        public int mealallow { get; set; }
        public int transportallow { get; set; }
        public int medicalallow { get; set; }
        public int tax { get; set; }
        public int total { get; set; }




        public int no { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}