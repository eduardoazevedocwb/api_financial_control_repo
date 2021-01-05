using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    class Contact : Entity_base
    {
        public int Number { get; set; }
        public string Email { get; set; }
    }
}
