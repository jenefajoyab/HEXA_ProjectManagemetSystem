using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProjectManagement.Util
{
    public class DBConnUtil
    {
        private static SqlConnection connection;
        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection(PropertyUtil.GetPropertyString());
            return connection;
        }
    }
}
