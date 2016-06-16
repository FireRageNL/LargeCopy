using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Oracle.ManagedDataAccess.Client;

namespace LargeCopies.Models
{
    class Themedb : db
    {
        public bool AddTheme(ThemaModel model)
        {
            try
            {
                conn.Open();
                if (!model.Theme.IsNullOrWhiteSpace())
                {
                    int themaid = 0;
                    cmd.CommandText = "SELECT ThemaID FROM THEMA WHERE Naam = :nme";
                    cmd.Parameters.Add("nme", model.Theme);
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        themaid = dr.GetInt32(0);
                    }
                    cmd.CommandText = "INSERT INTO THEMA(OMSCHRIJVING,CATEGORIE,NAAM) VALUES(:oms,:cat,:name)";
                    cmd.Parameters.Add("oms", model.Desc);
                    cmd.Parameters.Add("cat", themaid);
                    cmd.Parameters.Add("name", model.Name);                   
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "INSERT INTO THEMA(OMSCHRIJVING,NAAM) VALUES(:oms,:nme)";
                    cmd.Parameters.Add("oms", model.Desc);
                    cmd.Parameters.Add("nme", model.Name);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
            }
            return false;
        }
    }
}
