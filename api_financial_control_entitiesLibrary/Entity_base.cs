using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Entity_base
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public DateTime Registration_date { get; set; }
    }
}
