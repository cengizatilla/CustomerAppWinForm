using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.UygulamaAlani.CustomerApp.Core.Context
{
    class DatabaseLogicLayer
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public DatabaseLogicLayer()
        {
            connection = new SqlConnection(ConnectionStringWizard());
        }

        string ConnectionStringWizard()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-LD30C6D\SQLEXPRESS";
            builder.InitialCatalog = "CustomerDb";
            builder.IntegratedSecurity = true;
            // Eğer farklı bir kullanıcı ile sql sistemine erişmek isterseniz aşağıdaki yolu kullanabilirsiniz.
            //builder.UserID = "kullanici adi";
            //builder.Password = "sifre";

            return builder.ConnectionString;
        }

        public void ConnectionOpenClose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
            else
                connection.Open();
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = connection;
            ConnectionOpenClose();
            int result = command.ExecuteNonQuery(); // Create - Update - Delete 
            ConnectionOpenClose();
            return result;

        }

        public SqlDataReader GetDataList(SqlCommand command)
        {
            command.Connection = connection;
            ConnectionOpenClose();
            return command.ExecuteReader();
        }

    }
}
