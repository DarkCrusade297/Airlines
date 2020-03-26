using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportDate { get; set; }
        public string WasGiven { get; set; }
        public string PhoneNumber { get; set; }
    }
}