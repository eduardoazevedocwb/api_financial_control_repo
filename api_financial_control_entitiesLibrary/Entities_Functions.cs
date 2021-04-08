using api_financial_control_entitiesLibrary;
using System;

namespace api_financial_control
{
    public class Entities_Functions
    {
        public static string GetInsertString(Object obj)
        {
            var values = "";

            if (obj.GetType() == typeof(Person))
            {
                Person person = (Person)obj;
                values = ConcatValues(new object[] {
                person.ID,
                person.Name,
                person.Active,
                person.Registration_date,
                person.Document_type,
                person.Document,
                person.Birth,
                person.ID_Company,
                person.ID_PersonUp,
                person.ID_Contact,
                person.ID_Address
                });
            }
            else if (obj.GetType() == typeof(Address))
            {
                Address address = (Address)obj;
                values = ConcatValues(new object[] {
                address.ID,
                address.Name,
                address.Active,
                address.Registration_date,
                address.Street,
                address.Number,
                address.Neighborhood,
                address.City,
                address.State,
                address.Country,
                address.Code
                });
            }
            else if (obj.GetType() == typeof(Application))
            {
                Application application = (Application)obj;
                values = ConcatValues(new object[] {
                application.ID,
                application.Name,
                application.Active,
                application.Registration_date,
                application.ID_Cost_center
                });
            } else if (obj.GetType() == typeof(Company))
            {
                Company company = (Company)obj;
                values = ConcatValues(new object[] {
                company.ID,
                company.Name,
                company.Active,
                company.Registration_date,
                company.System_access,
                company.Document,
                company.Municipal_document,
                company.Contract_number,
                company.ID_Adrress,
                company.ID_Contact
                });
            } else if (obj.GetType() == typeof(Contact))
            {
                Contact contact = (Contact)obj;
                values = ConcatValues(new object[] {
                contact.ID,
                contact.Name,
                contact.Active,
                contact.Registration_date,
                contact.Number,
                contact.Email
                });
            } else if (obj.GetType() == typeof(Cost_center))
            {
                Cost_center cost_center = (Cost_center)obj;
                values = ConcatValues(new object[] {
                cost_center.ID,
                cost_center.Name,
                cost_center.Active,
                cost_center.Registration_date,
                cost_center.ID_Department
                });
            } else if (obj.GetType() == typeof(Department))
            {
                Department department = (Department)obj;
                values = ConcatValues(new object[] {
                department.ID,
                department.Name,
                department.Active,
                department.Registration_date
                });
            } else if (obj.GetType() == typeof(Financial_structure_access))
            {
                Financial_structure_access financial_structure_access = (Financial_structure_access)obj;
                values = ConcatValues(new object[] {
                financial_structure_access.ID,
                financial_structure_access.Name,
                financial_structure_access.Active,
                financial_structure_access.Registration_date,
                financial_structure_access.ID_Person,
                financial_structure_access.ID_Financial_structure
                });
            } else if (obj.GetType() == typeof(Financial_structure))
            {
                Financial_structure financial_structure = (Financial_structure)obj;
                values = ConcatValues(new object[] {
                financial_structure.ID,
                financial_structure.Name,
                financial_structure.Active,
                financial_structure.Registration_date,
                financial_structure.ID_Department,
                financial_structure.ID_Cost_center,
                financial_structure.ID_Application
                });
            } else if (obj.GetType() == typeof(Financial_value))
            {
                Financial_value financial_value = (Financial_value)obj;
                values = ConcatValues(new object[] {
                financial_value.ID,
                financial_value.Name,
                financial_value.Active,
                financial_value.Registration_date,
                financial_value.ID_Financial_structure,
                financial_value.MyProperty,
                financial_value.Simplified,
                financial_value.Document_type,
                financial_value.Document,
                financial_value.Value,
                financial_value.Doc_date,
                financial_value.Doc_expiration,
                financial_value.ID_Company,
                financial_value.Value_type
                });
            }else if (obj.GetType() == typeof(Login))
            {
                Login login = (Login)obj;
                values = ConcatValues(new object[] {
                login.ID,
                login.Name,
                login.Active,
                login.Registration_date,
                login.ID_Person,
                login.ID_Secret_question,
                login.Secret_Code,
                login.Secret_answer
                });
            }
            else if (obj.GetType() == typeof(Secret_question))
            {
                Secret_question secret_question = (Secret_question)obj;
                values = ConcatValues(new object[] {
                secret_question.ID,
                secret_question.Name,
                secret_question.Active,
                secret_question.Registration_date,
                secret_question.Description
            });
            } else if (obj.GetType() == typeof(System_structure))
            {
                System_structure system_structure = (System_structure)obj;
                values = ConcatValues(new object[] {
                system_structure.ID,
                system_structure.Name,
                system_structure.Active,
                system_structure.Registration_date,
                system_structure.Category,
                system_structure.Items,
                system_structure.Description
                });
            } else if (obj.GetType() == typeof(View_access))
            {
                View_access view_access = (View_access)obj;
                values = ConcatValues(new object[] {
                view_access.ID,
                view_access.Name,
                view_access.Active,
                view_access.Registration_date,
                view_access.ID_Person,
                view_access.ID_View
                });
            }else if (obj.GetType() == typeof(View))
            {
                View view = (View)obj;
                values = ConcatValues(new object[] {
                view.ID,
                view.Name,
                view.Active,
                view.Registration_date,
                view.Description
                });
            }

            return values;
        }
        private static string ConcatValues(object[] values)
        {
            var concat = ""; var value = "";
            foreach (var item in values)
            {
                if (!string.IsNullOrEmpty(item.ToString()))
                {
                    if (item.ToString().Trim() == "True")
                        value = "1";
                    else if (item.ToString().Trim() == "False")
                        value = "0";
                    else
                        value = item.ToString().Trim();
                }
                else
                {
                    value = "NULL";
                }

                if (string.IsNullOrEmpty(concat))
                    concat += "'" + value + "'";
                else
                    concat += ",'" + value + "'";

            }
            return concat;
        }
    }
}