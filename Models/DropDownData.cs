using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMVC.Models
{
    public class DropDownData
    {
        public List<Employee_List> empList { get; set; }

        public class Employee_List
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
        }

    }
}