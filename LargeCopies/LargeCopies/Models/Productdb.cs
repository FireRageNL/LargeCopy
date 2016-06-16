using Microsoft.Ajax.Utilities;
using Oracle.ManagedDataAccess.Client;

namespace LargeCopies.Models
{
    public class Productdb : db
    {
        public bool AddProduct(ProductModel model)
        {
            try
            {
                int theme1 = 0;
                int theme2 = 0;
                int theme3 = 0;
                conn.Open();
                if (!model.Themes2.IsNullOrWhiteSpace())
                {
                    cmd.CommandText = "SELECT ThemaID FROM THEMA WHERE Naam = :nme";
                    cmd.Parameters.Add("nme", model.Themes2);
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    theme2 = dr.HasRows ? dr.GetInt32(0) : 0;
                }
                if (!model.Themes3.IsNullOrWhiteSpace())
                {
                    cmd.CommandText = "SELECT ThemaID FROM THEMA WHERE Naam = :nme";
                    cmd.Parameters.Add("nme", model.Themes3);
                    OracleDataReader dr1 = cmd.ExecuteReader();
                    dr1.Read();
                    theme3 = dr1.HasRows ? dr1.GetInt32(0) : 0;
                }
                cmd.CommandText = "SELECT ThemaID FROM THEMA WHERE Naam = :nme";
                cmd.Parameters.Add("nme", model.Themes);
                OracleDataReader dr2 = cmd.ExecuteReader();
                dr2.Read();
                theme1 = dr2.HasRows ? dr2.GetInt32(0) : 0;

                cmd.CommandText = "INSERT INTO PRODUCT(Kleur,Prijs,Omschrijving,Naam) VALUES(:kl,:pr,:desc,:nm)";
                cmd.Parameters.Add("kl", model.Color);
                cmd.Parameters.Add("pr", model.Price);
                cmd.Parameters.Add("desc", model.Description);
                cmd.Parameters.Add("nm", model.Productname);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT ProductID FROM PRODUCT WHERE NAAM = :nm AND OMSCHRIJVING = :desc";
                cmd.Parameters.Add("desc", model.Description);
                cmd.Parameters.Add("nm", model.Productname);
                OracleDataReader dr3 = cmd.ExecuteReader();
                dr3.Read();
                int productid = dr3.HasRows ? dr3.GetInt32(0) : 0;
                cmd.CommandText = "INSERT INTO ProductThema(ProductID,ThemaID) VALUES(:prid,:tid)";
                cmd.Parameters.Add("prid", productid);
                cmd.Parameters.Add("tid", theme1);
                cmd.ExecuteNonQuery();
                if (theme2 == 0) return true;
                cmd.CommandText = "INSERT INTO ProductThema(ProductID,ThemaID) VALUES(:prid,:tid)";
                cmd.Parameters.Add("prid", productid);
                cmd.Parameters.Add("tid", theme2);
                cmd.ExecuteNonQuery();
                if (theme3 == 0) return true;
                cmd.CommandText = "INSERT INTO ProductThema(ProductID,ThemaID) VALUES(:prid,:tid)";
                cmd.Parameters.Add("prid", productid);
                cmd.Parameters.Add("tid", theme3);
                cmd.ExecuteNonQuery();
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