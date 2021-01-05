using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Financial_value : Entity_base
    {
        public int ID_Financial_structure { get; set; }
        public int MyProperty { get; set; }
        public bool Simplified { get; set; }
        public string Document_type { get; set; }
        public int Document { get; set; }
        public double Value { get; set; }
        public DateTime Doc_date { get; set; }
        public DateTime Doc_expiration { get; set; }
        public int ID_Company { get; set; }
        public string Value_type { get; set; }
    }
}
