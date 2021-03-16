using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pampara.DataAccess.Model
{
   public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }
    }
}
