using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Login : Entity_base
    {
        public Login(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.ID_Person = (int?)dataReader["ID_Person"];
            this.ID_Secret_question = (int?)dataReader["ID_Secret_question"];
            this.Secret_Code = (string)dataReader["Secret_Code"];
            this.Secret_answer = (string)dataReader["Secret_answer"];
        }
        public Login() { }
        public int? ID_Person { get; set; }
        public string Secret_Code { get; set; }
        public int? ID_Secret_question { get; set; }
        public string Secret_answer { get; set; }
    }
}
