using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Financial_structure : Entity_base
    {
        public int ID_Department { get; set; }
        public int ID_Cost_center { get; set; }
        public int ID_Application { get; set; }
    }
}
