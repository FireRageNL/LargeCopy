using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace LargeCopies.Models
{
    public class db
    {
        private readonly OracleConnection _conn = new OracleConnection();

        public db()
        {
            _conn.ConnectionString = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = fhictora01.fhict.local)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = fhictora))); User ID = dbi347373; PASSWORD = Testpassword1234";
        }

        public bool dbtest()
        {
            try
            {
                _conn.Open();
                OracleCommand cmd = new OracleCommand
                {
                    BindByName = true,
                    Connection = _conn,
                    CommandText = "SELECT COUNT(*) FROM ADRES"
                };
                OracleDataReader dr = cmd.ExecuteReader();
                int count = dr.GetInt32(0);
                if(count > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
            catch (OracleException e)
            {
                Console.WriteLine("Oracle error: " + e.Message);
                _conn.Close();
                return false;
            }
        }
    }
}