using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class System_structure : Entity_base
    {
        public string Category { get; set; }
        public string Items { get; set; }
        public string Description { get; set; }
    }
}
