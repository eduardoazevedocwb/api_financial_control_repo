using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Person : Entity_base
    {
        public Person(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime?)dataReader["Registration_date"];
            this.Document_type = (string)dataReader["Document_type"];
            this.Document = (string)dataReader["Document"];
            this.Birth = (DateTime)dataReader["Birth"];
            this.ID_Company = (int?)dataReader["ID_Company"];
            this.ID_PersonUp = (int?)dataReader["ID_PersonUp"];
            this.ID_Contact = (int?)dataReader["ID_Contact"];
            this.ID_Address = (int?)dataReader["ID_Address"];
        }
        public Person() { }
        public string Document_type { get; set; }
        public string Document { get; set; }
        public DateTime Birth { get; set; }
        public int? ID_Company { get; set; }
        public int? ID_PersonUp { get; set; }
        public int? ID_Contact { get; set; }
        public int? ID_Address { get; set; }
    }
}
