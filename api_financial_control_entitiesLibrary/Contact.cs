using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Contact : Entity_base
    {
        public Contact(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.Number = string.IsNullOrEmpty(dataReader["Number"].ToString()) ? 
                                null : (int?)dataReader["Number"];
            this.Email = (string)dataReader["Email"];
        }
        public Contact() { }
        public int? Number { get; set; }
        public string Email { get; set; }
    }
}
