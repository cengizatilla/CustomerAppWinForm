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
    public class SystemUserRepository
    {
        DatabaseLogicLayer databaseLogicLayer;
        SqlCommand command;
        SqlDataReader reader;

        public SystemUserRepository()
        {
            databaseLogicLayer = new DatabaseLogicLayer();
        }

        public SystemUser CheckSystemUser(SystemUser systemUser)
        {
            SystemUser dataItem = new SystemUser();

            command = new SqlCommand("select * from SystemUser where UserName = @UserName and Pass = @Pass");
            command.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar).Value = systemUser.UserName;
            command.Parameters.Add("@Pass", System.Data.SqlDbType.NVarChar).Value = systemUser.Pass;
            reader = databaseLogicLayer.GetDataList(command);
            while (reader.Read())
            {
                dataItem.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                dataItem.UserName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                dataItem.Pass = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            }
            reader.Close();
            databaseLogicLayer.ConnectionOpenClose();
            return dataItem;
        }
    }
}
