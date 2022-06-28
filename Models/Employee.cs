using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMVC.Models
{
    public class Employee
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public bool Discontinued { get; set; }


        public List<Employee> GetEmpList()
        {
            var data = Enumerable.Range(1, 359000)
                .Select(index => new Employee
                {
                    ProductID = index,
                    ProductName = "Product #" + index,
                    UnitPrice = index * 10,
                    Discontinued = false
                }).ToList();

            return data;
        }
    }
}