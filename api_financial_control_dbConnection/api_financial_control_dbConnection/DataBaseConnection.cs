using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using api_financial_control_entitiesLibrary;

namespace DataBaseConnection
{
    public class DataBaseConnection
    {
        private SqlConnection connection;
        private SqlCommand query;
        private Entity_base entityBase;

        private void On()
        {
            if(connection == null)
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Financial_Control;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                query = new SqlCommand();
                query.Connection = connection;
                if(connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                if (entityBase == null)
                    entityBase = new Entity_base();
            }
            catch (Exception ex){
                throw;
            }
        }
        private void Off()
        {
            try
            {
                query = null;
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
            catch {
                throw;
            }
        }

        public object GetById(string entityName, int? id)
        {
            On();

            object obj = null;

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    query.CommandText = string.Concat("Select * from ", entityName, " where id=", id);
                    SqlDataReader result = query.ExecuteReader();

                    if(result.HasRows)
                        obj = new object();

                    while (result.Read()) {
                        obj = entityBase.GetDataObjectByEntityName(entityName, result);
                    }
                }
                catch {
                    throw;
                }
                finally
                {
                    Off();
                }
            }
            return obj;
        }
        public object GetByName(string entityName, string name)
        {
            On();

            var obj = new object();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    query.CommandText = string.Concat("Select * from ", entityName, " where name=", name);
                    SqlDataReader result = query.ExecuteReader();

                    while (result.Read())
                        obj = entityBase.GetDataObjectByEntityName(entityName, result);
                }
                catch {
                    throw;
                }
                finally
                {
                    Off();
                }
            }
            return obj;

        }
        public List<object> Get(string entityName)
        {
            On();

            var obj = new List<object>();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    query.CommandText = string.Concat("Select * from ", entityName);
                    SqlDataReader result = query.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                            obj.Add(entityBase?.GetDataObjectByEntityName(entityName, result));
                    }
                }
                catch (Exception ex){
                    throw;
                }
                finally
                {
                    Off();
                }
            }
            return obj;

        }
        public string SetItem(string entityName, int? id, string valuesConcat)
        {
            var message = "";
            var containsId = false;

            //analyse if contains values and if id already exists
            if (valuesConcat.Length > 0)
            {
                if (id > 0)
                    containsId = ContainsId(entityName, id);
                else
                    containsId = false;
            }
            else
            {
                message = "Error: the value to persist is empty";
                return message;
            }

            On();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    //update
                    if (containsId)
                    {
                        query.CommandText = string.Concat("update ", entityName, " set active='false' where id=",id);
                        var done = query.ExecuteNonQuery();
                        if (done > 0)
                            message = "New register update successfully";
                        query.Dispose();
                    }

                    //insert new
                    query.CommandText = string.Concat("Insert into ", entityName, " values(", valuesConcat, ")");
                    var result = query.ExecuteNonQuery();
                    if (result > 0)
                        message = "New register persisted successfully";
                    query.Dispose();
                }
                catch (Exception ex)
                {
                    message = string.Concat("Error: ",ex.Message);
                }
                finally
                {
                    Off();
                }
            }
            return message;

        }
        public bool ContainsId (string entityName, int? id)
        {
            On();

            var contains = false;

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    query.CommandText = string.Concat("Select id from ", entityName, " where id=", id);
                    SqlDataReader result = query.ExecuteReader();

                    if(result.HasRows)
                        contains = true;
                }
                catch {
                    throw;
                }
                finally
                {
                    Off();
                }
            }
            return contains;

        }
        public bool ContainsName (string entityName, string name)
        {
            On();

            var contains = false;

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    query.CommandText = string.Concat("Select name from ", entityName, " where name like '%", name,"%'");
                    SqlDataReader result = query.ExecuteReader();

                    if (result.HasRows)
                        contains = true;
                }
                catch {
                    throw;
                }
                finally
                {
                    Off();
                }
            }
            return contains;

        }
        public string Inative (string entityName, int? id)
        {
            var message = "";
            var containsId = false;

            //analyse if contains values and if id already exists
            containsId = ContainsId(entityName, id);

            On();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    //update
                    if (containsId)
                    {
                        query.CommandText = string.Concat("update ", entityName, " set active='false' where id=", id);
                        var done = query.ExecuteNonQuery();
                        if (done > 0)
                            message = "New register update successfully";
                        query.Dispose();
                    }
                    else
                    {
                        message = "Do not contains item to update";
                    }
                }
                catch (Exception ex)
                {
                    message = string.Concat("Error: ", ex.Message);
                }
                finally
                {
                    Off();
                }
            }
            return message;
        }
    }
}