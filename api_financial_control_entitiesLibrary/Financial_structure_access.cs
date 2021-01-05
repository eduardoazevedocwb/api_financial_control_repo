using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    class Financial_structure_access : Entity_base
    {
        public int ID_Person { get; set; }
        public int ID_Financial_structure { get; set; }
    }
}
