using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace bazadanych
{
    class Connection
    {
        public SqlConnection con = new(@"Data Source=DESKTOP-TNPIKUD\BAZA;Initial Catalog=NewDB;Integrated Security=True");
    }
}
