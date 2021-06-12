using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace tecnovision_backend.Controllers
{

    public class DBConnection
    {

        public static SqlConnection GetConnection() => new SqlConnection("Data Source=SEBASTIAN-PC;Initial Catalog=tecnovision;Integrated Security=True");

    }


}



