using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelerikMVC.Models
{
    public class StepperExample
    {
        public class Form1
        {
            public int ID { get; set; }
            [Required(ErrorMessage ="Enter First Name!")]
            public string FName { get; set; }
            [Required(ErrorMessage = "Enter Last Name!")]
            public string LName { get; set; }
            [Required(ErrorMessage = "Enter Country!")]
            public string Country { get; set; }
            [Required(ErrorMessage = "Enter Mobile!")]
            public string Mobile { get; set; }
            [Required(ErrorMessage = "Enter Email!")]
            public string Email { get; set; }
        }

        public class Form2
        {
            public int ID { get; set; }
            [Required(ErrorMessage = "Enter First Name!")]
            public string FName { get; set; }
            [Required(ErrorMessage = "Enter Last Name!")]
            public string LName { get; set; }
            [Required(ErrorMessage = "Enter Country!")]
            public string Country { get; set; }
            [Required(ErrorMessage = "Enter Mobile!")]
            public string Mobile { get; set; }
            [Required(ErrorMessage = "Enter Email!")]
            public string Email { get; set; }
        }

        public class Form3
        {
            public int ID { get; set; }
            [Required(ErrorMessage = "Enter First Name!")]
            public string FName { get; set; }
            [Required(ErrorMessage = "Enter Last Name!")]
            public string LName { get; set; }
            [Required(ErrorMessage = "Enter Country!")]
            public string Country { get; set; }
            [Required(ErrorMessage = "Enter Mobile!")]
            public string Mobile { get; set; }
            [Required(ErrorMessage = "Enter Email!")]
            public string Email { get; set; }
        }


        public Form1 form1 { get; set; }
        public Form2 form2 { get; set; }
        public Form3 form3 { get; set; }
    }
}