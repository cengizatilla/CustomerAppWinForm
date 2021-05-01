using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.UygulamaAlani.CustomerApp.Core.Context;

namespace Youtube.UygulamaAlani.CustomerApp.Core.Repositories
{
    public class BaseRepository
    {
        DatabaseLogicLayer databaseLogicLayer;
        SqlCommand command;
        SqlDataReader reader;

        public BaseRepository()
        {
            databaseLogicLayer = new DatabaseLogicLayer();
        }
    }
}
