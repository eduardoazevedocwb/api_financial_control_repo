using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    class Company : Entity_base
    {
        public bool System_access { get; set; }
        public string Name { get; set; }
        public int Document { get; set; }
        public int Municipal_document { get; set; }
        public int Contract_number { get; set; }
        public int ID_Adrress { get; set; }
        public int ID_Contact { get; set; }
    }
}
