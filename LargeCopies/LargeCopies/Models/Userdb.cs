using System;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Oracle.ManagedDataAccess.Client;

namespace LargeCopies.Models
{
    public class Userdb : db
    {
        public bool Reguser(RegisterViewModel model)
        {
            try
            {
                conn.Open();
                if (!model.NameConnector.IsNullOrWhiteSpace())
                {
                    cmd.CommandText =
                        "INSERT INTO GEBRUIKER(VOORNAAM,TUSSENVOEGSEL,ACHTERNAAM,EMAIL,WACHTWOORD,GESLACHT,TELEFOONUMMER) VALUES(:vn,:tv,:an,:em,:ww,:gs,:tn)";
                    cmd.Parameters.Add("vn", model.FirstName);
                    cmd.Parameters.Add("tv", model.NameConnector);
                    cmd.Parameters.Add("an", model.LastName);
                    cmd.Parameters.Add("em", model.Email);
                    cmd.Parameters.Add("ww", model.Password);
                    cmd.Parameters.Add("gs", model.Sex);
                    cmd.Parameters.Add("tn", model.Telephone);
                }
                else
                {
                    cmd.CommandText =
                        "INSERT INTO GEBRUIKER(VOORNAAM,ACHTERNAAM,EMAIL,WACHTWOORD,GESLACHT,TELEFOONUMMER) VALUES(:vn,:an,:em,:ww,:gs,:tn)";
                    cmd.Parameters.Add("vn", model.FirstName);
                    cmd.Parameters.Add("an", model.LastName);
                    cmd.Parameters.Add("em", model.Email);
                    cmd.Parameters.Add("ww", model.Password);
                    cmd.Parameters.Add("gs", model.Sex);
                    cmd.Parameters.Add("tn", model.Telephone);
                }
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (OracleException e)
            {
                Console.WriteLine("Oh noes error: " + e.Message);
                conn.Close();
                return false;
            }
        }
    }
}