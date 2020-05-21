using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace GHMS
{
    
    class connection
    {
        public OleDbConnection Connect()
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=orcl;User ID=yourId;Password=yourPass;Unicode=True");
            con.Open();
            return con;
        }
    }
}
