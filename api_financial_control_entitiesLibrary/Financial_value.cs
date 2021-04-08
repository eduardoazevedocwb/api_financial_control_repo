using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Financial_value : Entity_base
    {
        public Financial_value(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.ID_Financial_structure = (int?)dataReader["ID_Financial_structure"];
            this.MyProperty = (int?)dataReader["MyProperty"];
            this.Simplified = (bool)dataReader["Simplified"];
            this.Document_type = (string)dataReader["Document_type"];
            this.Document = (int?)dataReader["Document"];
            this.Value = (double)dataReader["Value"];
            this.Doc_date = (DateTime)dataReader["Doc_date"];
            this.Doc_expiration = (DateTime)dataReader["Doc_expiration"];
            this.ID_Company = (int?)dataReader["ID_Company"];
            this.Value_type = (string)dataReader["Value_type"];
        }
        public Financial_value() { }
        public int? ID_Financial_structure { get; set; }
        public int? MyProperty { get; set; }
        public bool Simplified { get; set; }
        public string Document_type { get; set; }
        public int? Document { get; set; }
        public double Value { get; set; }
        public DateTime Doc_date { get; set; }
        public DateTime Doc_expiration { get; set; }
        public int? ID_Company { get; set; }
        public string Value_type { get; set; }
    }
}
