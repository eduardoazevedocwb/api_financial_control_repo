using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_financial_control_entitiesLibrary
{
    public class Address : Entity_base
    {
        public Address(SqlDataReader dataReader)
        {
            this.ID = (int?)dataReader["id"];
            this.Name = (string)dataReader["Name"];
            this.Active = (bool)dataReader["active"];
            this.Registration_date = (DateTime)dataReader["Registration_date"];
            this.Street = (string)dataReader["Street"];
            this.Number = (int?)dataReader["Number"];
            this.Neighborhood = (string)dataReader["Neighborhood"];
            this.City = (string)dataReader["City"];
            this.State = (string)dataReader["State"];
            this.Country = (string)dataReader["Country"];
            this.Code = (int?)dataReader["Code"];
        }
        public Address(){}
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? Code { get; set; }
    }
}
