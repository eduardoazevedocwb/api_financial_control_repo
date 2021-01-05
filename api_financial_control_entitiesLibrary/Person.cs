using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Person : Entity_base
    {
        public string Name { get; set; }
        public string Document_type { get; set; }
        public int Document { get; set; }
        public DateTime Birth { get; set; }
        public int ID_Company { get; set; }
        public int ID_PersonUp { get; set; }
        public int ID_Contact { get; set; }
        public int ID_Address { get; set; }
    }
}
