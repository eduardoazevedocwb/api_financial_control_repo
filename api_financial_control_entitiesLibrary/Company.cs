using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Company : Entity_base
    {
        public Company(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.System_access = (bool)dataReader["System_access"];
            this.Document = (int?)dataReader["Document"];
            this.Municipal_document = (int?)dataReader["Municipal_document"];
            this.Contract_number = (int?)dataReader["Contract_number"];
            this.ID_Adrress = (int?)dataReader["ID_Adrress"];
            this.ID_Contact = (int?)dataReader["ID_Contact"];
        }
        public Company() { }
        public bool System_access { get; set; }
        public int? Document { get; set; }
        public int? Municipal_document { get; set; }
        public int? Contract_number { get; set; }
        public int? ID_Adrress { get; set; }
        public int? ID_Contact { get; set; }
    }
}
