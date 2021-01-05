using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Login : Entity_base
    {
        public int ID_Person { get; set; }
        public string Secret_Code { get; set; }
        public int ID_Secret_question { get; set; }
        public string Secret_answer { get; set; }
    }
}
