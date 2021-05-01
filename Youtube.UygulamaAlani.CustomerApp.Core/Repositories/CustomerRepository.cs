using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.UygulamaAlani.CustomerApp.Core.Context;
using Youtube.UygulamaAlani.CustomerApp.Core.Entities;

namespace Youtube.UygulamaAlani.CustomerApp.Core.Repositories
{
    public class CustomerRepository
    {
        DatabaseLogicLayer databaseLogicLayer;
        SqlCommand command;
        SqlDataReader reader;

        public CustomerRepository()
        {
            databaseLogicLayer = new DatabaseLogicLayer();
        }

        public int AddNewDataItem(Customer customer)
        {
            command = new SqlCommand("AddNewCustomer");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = customer.FirstName;
            command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = customer.LastName;
            command.Parameters.Add("@TelephoneNumber", System.Data.SqlDbType.NVarChar).Value = customer.TelephoneNumber;
            command.Parameters.Add("@EmailAddress", System.Data.SqlDbType.NVarChar).Value = customer.EmailAddress;
            command.Parameters.Add("@CreateDate", System.Data.SqlDbType.DateTime).Value = customer.CreateDate;
            return databaseLogicLayer.ExecuteNonQuery(command);
        }

        public int UpdateDataItem(Customer customer)
        {
            command = new SqlCommand("UpdateCustomer");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = customer.Id;
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = customer.FirstName;
            command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = customer.LastName;
            command.Parameters.Add("@TelephoneNumber", System.Data.SqlDbType.NVarChar).Value = customer.TelephoneNumber;
            command.Parameters.Add("@EmailAddress", System.Data.SqlDbType.NVarChar).Value = customer.EmailAddress;
            return databaseLogicLayer.ExecuteNonQuery(command);
        }

        public int DeleteDataItem(int Id)
        {
            command = new SqlCommand("DeleteCustomer");
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
            return databaseLogicLayer.ExecuteNonQuery(command);
        }

        public List<Customer> GetDataList()
        {
            List<Customer> dataItemList = new List<Customer>();

            command = new SqlCommand("Select * from Customer");
            reader = databaseLogicLayer.GetDataList(command);
            while (reader.Read())
            {
                Customer item = new Customer();
                item.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                item.FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                item.LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                item.TelephoneNumber = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                item.EmailAddress = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                item.CreateDate = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                dataItemList.Add(item);
            }
            reader.Close();
            databaseLogicLayer.ConnectionOpenClose();

            return dataItemList;
        }

        public Customer GetDataById(int Id)
        {
            Customer dataItem = new Customer();

            command = new SqlCommand("select * from Customer where Id = @Id");
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
            reader = databaseLogicLayer.GetDataList(command);
            while (reader.Read())
            {
                dataItem.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                dataItem.FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                dataItem.LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                dataItem.TelephoneNumber = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                dataItem.EmailAddress = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            }
            reader.Close();
            databaseLogicLayer.ConnectionOpenClose();

            return dataItem;
        }

    }
}
