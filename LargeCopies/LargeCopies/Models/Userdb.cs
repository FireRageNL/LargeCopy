using System;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Oracle.ManagedDataAccess.Client;

namespace LargeCopies.Models
{
    public class Userdb : db
    {
        public bool Reguser(RegisterViewModel model)
        {
            int adresID;
            int userID;
            try
            {
                conn.Open();
                if (!model.NameConnector.IsNullOrWhiteSpace())
                {
                    cmd.CommandText =
                        "INSERT INTO GEBRUIKER(VOORNAAM,TUSSENVOEGSEL,ACHTERNAAM,EMAIL,WACHTWOORD,GESLACHT,TELEFOONNUMMER) VALUES(:vn,:tv,:an,:em,:ww,:gs,:tn)";
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
                        "INSERT INTO GEBRUIKER(VOORNAAM,ACHTERNAAM,EMAIL,WACHTWOORD,GESLACHT,TELEFOONNUMMER) VALUES(:vn,:an,:em,:ww,:gs,:tn)";
                    cmd.Parameters.Add("vn", model.FirstName);
                    cmd.Parameters.Add("an", model.LastName);
                    cmd.Parameters.Add("em", model.Email);
                    cmd.Parameters.Add("ww", model.Password);
                    cmd.Parameters.Add("gs", model.Sex);
                    cmd.Parameters.Add("tn", model.Telephone);
                }
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO ADRES(STRAAT,HUISNUMMER,POSTCODE,WOONPLAATS) VALUES(:st,:hn,:pc,:wp)";
                cmd.Parameters.Add("st", model.Street);
                cmd.Parameters.Add("hn", model.Number + "" + model.Addition);
                cmd.Parameters.Add("pc", model.Zipcode);
                cmd.Parameters.Add("wp", model.City);
                cmd.ExecuteNonQuery();
                adresID = GetAdresId(model);
                userID = GetUserID(model.Email);
                cmd.CommandText = "INSERT INTO GEBRUIKERADRES(ADRESID,GEBRUIKERID) VALUES(:ai,:ui)";
                cmd.Parameters.Add("ai", adresID);
                cmd.Parameters.Add("ui", userID);
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

        private int GetAdresId(RegisterViewModel model)
        {
            int ret = 0;
            try
            {
                cmd.CommandText =
                    "SELECT ADRESID FROM ADRES WHERE STRAAT = :st AND HUISNUMMER = :hn AND POSTCODE = :pc AND WOONPLAATs = :wp";
                cmd.Parameters.Add("st", model.Street);
                cmd.Parameters.Add("hn", model.Number + "" + model.Addition);
                cmd.Parameters.Add("pc", model.Zipcode);
                cmd.Parameters.Add("wp", model.City);

                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                ret = dr.GetInt32(0);
                return ret;
            }
            catch(OracleException e)
            {
                Console.WriteLine("Oh noes error: " + e.Message);
                conn.Close();
                return 0;
            }
        }

        private int GetUserID(string email)
        {
            int ret = 0;
            try
            {
                cmd.CommandText = "SELECT GEBRUIKERID FROM GEBRUIKER WHERE EMAIL = :em";
                cmd.Parameters.Add("em", email);
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                ret = dr.GetInt32(0);
                return ret;
            }
            catch (OracleException e)
            {
                Console.WriteLine("Oh noes error: " + e.Message);
                conn.Close();
                return 0;
            }
        }

        public int LoginUser(LoginViewModel model)
        {
            int ret = 0;
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT COUNT(*) FROM GEBRUIKER WHERE email = :em AND wachtwoord = :ww";
                cmd.Parameters.Add("em", model.Email);
                cmd.Parameters.Add("ww", model.Password);
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                ret = dr.GetInt32(0);
                if (ret == 1)
                {
                    ret = GetUserID(model.Email);
                    conn.Close();
                    return ret;
                }
                conn.Close();
                return 0;
            }
            
            catch (OracleException e)
            {
                Console.WriteLine("Oh noes error: " + e.Message);
                conn.Close();
                return 0;
            }
        }
    }
}