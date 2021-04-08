using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class View_access : Entity_base
    {
        public View_access(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.ID_Person = (int?)dataReader["ID_Person"];
            this.ID_View = (int?)dataReader["ID_View"];
        }
        public View_access() { }
        public int? ID_Person { get; set; }
        public int? ID_View { get; set; }
    }
}
