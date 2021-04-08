using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class System_structure : Entity_base
    {
        public System_structure(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.Category = (string)dataReader["Category"];
            this.Items = (string)dataReader["Items"];
            this.Description = (string)dataReader["Description"];
        }
        public System_structure() { }
        public string Category { get; set; }
        public string Items { get; set; }
        public string Description { get; set; }
    }
}
