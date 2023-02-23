using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRecorder.models
{
    public class Division
    {
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Employee Manager { get; set; }
    }
}
