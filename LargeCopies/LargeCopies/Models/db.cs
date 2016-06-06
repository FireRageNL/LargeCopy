using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace LargeCopies.Models
{
    public class db
    {
        public OracleConnection conn;
        public OracleCommand cmd;

        protected db()
        {

            conn = new OracleConnection
            {
                ConnectionString =
                    "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = fhictora01.fhict.local)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = fhictora))); User ID = dbi347373; PASSWORD = Testpassword1234"
            };
            cmd = new OracleCommand
            {
                BindByName = true,
                Connection = conn,
            };
        }
    }
}