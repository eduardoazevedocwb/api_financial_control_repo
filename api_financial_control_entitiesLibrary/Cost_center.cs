using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    class Cost_center : Entity_base
    {
        public string Name { get; set; }
        public int ID_Department { get; set; }
    }
}
