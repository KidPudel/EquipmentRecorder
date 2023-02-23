using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRecorder.models
{
    public class EquipmentAssignment
    {
        public int InventoryNumber { get; set; }
        public string EquipmentName { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string Division { get; set; }
        public DateTime? DateAssigned { get; set; }

        public EquipmentAssignment(int inventoryNumber, string equipmentName, string employeeName, int employeeID, string division, DateTime? dateAssigned) 
        {
            InventoryNumber = inventoryNumber;
            EquipmentName = equipmentName;
            EmployeeName = employeeName;
            EmployeeID = employeeID;
            Division = division;
            DateAssigned = dateAssigned;
        }
    }
}
