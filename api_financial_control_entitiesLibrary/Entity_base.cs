using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace api_financial_control_entitiesLibrary
{
    [DataContract]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class Entity_base
    {
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool? Active { get; set; }
        [DataMember]
        public DateTime? Registration_date { get; set; }

        public object GetDataObjectByEntityName(string entityName, SqlDataReader dataReader) {
            var obj = new object();

            switch (entityName)
            {
                case "Address":
                    obj = new Address(dataReader);
                    break;
                case "Application":
                    obj = new Application(dataReader);
                    break;
                case "Company":
                    obj = new Company(dataReader);
                    break;
                case "Contact":
                    obj = new Contact(dataReader);
                    break;
                case "Cost_center":
                    obj = new Cost_center(dataReader);
                    break;
                case "Department":
                    obj = new Department(dataReader);
                    break;
                case "Financial_structure":
                    obj = new Financial_structure(dataReader);
                    break;
                case "Financial_structure_access":
                    obj = new Financial_structure_access(dataReader);
                    break;
                case "Financial_value":
                    obj = new Financial_value(dataReader);
                    break;
                case "Login":
                    obj = new Login(dataReader);
                    break;
                case "Person":
                    obj = new Person(dataReader);
                    break;
                case "Secret_question":
                    obj = new Secret_question(dataReader);
                    break;
                case "System_structure":
                    obj = new System_structure(dataReader);
                    break;
                case "View":
                    obj = new View(dataReader);
                    break;
                case "View_access":
                    obj = new View_access(dataReader);
                    break;
            }
            return obj;
        }
    }
}
