using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRecorder.models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string JobTitle { get; set; }
        public string Division { get; set; }
        public bool Status { get; set; }
        public Employee(int employeeId, string name, string idNumber, string jobTitle, string division, bool status) 
        {
            EmployeeId = employeeId;
            Name = name;
            IdNumber = idNumber;
            JobTitle = jobTitle;
            Division = division;
            Status = status;
        }
    }
}
