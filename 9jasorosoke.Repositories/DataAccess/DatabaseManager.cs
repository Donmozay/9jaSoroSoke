using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace _9jasorosoke.Repositories.DataAccess
{
    public class DatabaseManager
    {
        public async Task<IDbConnection> DatabaseConnection()
        {

            return new SqlConnection(ConnectionString.MyConnectionString);

        }
    }
}
