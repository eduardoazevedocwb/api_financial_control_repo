using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Financial_structure : Entity_base
    {
        public Financial_structure(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.ID_Department = (int?)dataReader["ID_Department"];
            this.ID_Cost_center = (int?)dataReader["ID_Cost_center"];
            this.ID_Application = (int?)dataReader["ID_Application"];
        }
        public Financial_structure() { }
        public int? ID_Department { get; set; }
        public int? ID_Cost_center { get; set; }
        public int? ID_Application { get; set; }
    }
}
