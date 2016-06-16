using System.Collections.Generic;
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
                    cmd.CommandText = "SELECT ThemaID FROM THEMA WHERE Naam = :name";
                    cmd.Parameters.Add("name", model.Themes3);
                    OracleDataReader dr1 = cmd.ExecuteReader();
                    dr1.Read();
                    theme3 = dr1.HasRows ? dr1.GetInt32(0) : 0;
                }
                cmd.CommandText = "SELECT ThemaID FROM THEMA WHERE Naam = :nm";
                cmd.Parameters.Add("nm", model.Themes);
                OracleDataReader dr2 = cmd.ExecuteReader();
                dr2.Read();
                theme1 = dr2.HasRows ? dr2.GetInt32(0) : 0;

                cmd.CommandText = "INSERT INTO PRODUCT(Kleur,Prijs,Omschrijving,Naam) VALUES(:kl,:pr,:descr,:naam)";
                cmd.Parameters.Add("kl", model.Color);
                cmd.Parameters.Add("pr", model.Price);
                cmd.Parameters.Add("descr", model.Description);
                cmd.Parameters.Add("naam", model.Productname);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT ProductID FROM PRODUCT WHERE NAAM = :naam AND OMSCHRIJVING = :descr";
                cmd.Parameters.Add("descr", model.Description);
                cmd.Parameters.Add("naam", model.Productname);
                OracleDataReader dr3 = cmd.ExecuteReader();
                dr3.Read();
                int productid = dr3.HasRows ? dr3.GetInt32(0) : 0;
                cmd.CommandText = "INSERT INTO ProductThema(ProductID,ThemaID) VALUES(:prid,:tid)";
                cmd.Parameters.Add("prid", productid);
                cmd.Parameters.Add("tid", theme1);
                cmd.ExecuteNonQuery();
                if (theme2 == 0) return true;
                cmd.CommandText = "INSERT INTO ProductThema(ProductID,ThemaID) VALUES(:prid,:thid)";
                cmd.Parameters.Add("prid", productid);
                cmd.Parameters.Add("thid", theme2);
                cmd.ExecuteNonQuery();
                if (theme3 == 0) return true;
                cmd.CommandText = "INSERT INTO ProductThema(ProductID,ThemaID) VALUES(:prid,:ti)";
                cmd.Parameters.Add("prid", productid);
                cmd.Parameters.Add("ti", theme3);
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

        public List<ProductModel> FetchProducts(string theme)
        {
            List<ProductModel> ret = new List<ProductModel>();
            try
            {
                conn.Open();
                cmd.CommandText =
                    "SELECT product.productid, product.naam, product.omschrijving,kleur,prijs FROM product, productthema, thema WHERE product.productid = productthema.productid AND productthema.themaid = thema.themaid AND thema.naam = :thm";
                cmd.Parameters.Add("thm", theme);
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int pid = dr.GetInt32(0);
                    string name = dr.GetString(1);
                    string desc = dr.GetString(2);
                    string color = dr.GetString(3);
                    decimal price = dr.GetDecimal(4);

                    cmd.CommandText = "SELECT themaid FROM productthema WHERE productid = :pid";
                    cmd.Parameters.Add("pid", pid);
                    OracleDataReader dr2 = cmd.ExecuteReader();
                    string theme1 = null;
                    string theme2 = null;
                    string theme3 = null;
                    while (dr2.Read())
                    {
                        int themeid = dr2.GetInt32(0);
                        cmd.CommandText = "SELECT naam FROM THEMA WHERE themaid = :tid";
                        cmd.Parameters.Add("tid", themeid);
                        OracleDataReader dr3 = cmd.ExecuteReader();
                        dr3.Read();
                        if (!dr3.HasRows) continue;
                        if (theme1 == null)
                        {
                            theme1 = dr3.GetString(0);
                        }
                        else if (theme2 == null)
                        {
                            theme2 = dr3.GetString(0);
                        }
                        else if (theme3 == null)
                        {
                            theme3 = dr3.GetString(0);
                        }
                    }
                    ProductModel add = new ProductModel
                    {
                        Productname = name,
                        Description = desc,
                        Color = color,
                        Price = price,
                        Themes = theme1,
                        Themes2 = theme2,
                        Themes3 = theme3,
                        ProductID= pid
                    };
                    ret.Add(add);
                }
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
            return ret;
        }

        public ProductModel GetProductDetails(int pid)
        {
            ProductModel details = new ProductModel();
            try
            {
                conn.Open();
                cmd.CommandText =
                    "SELECT naam, omschrijving,kleur,prijs FROM product WHERE productid = :pid";
                cmd.Parameters.Add("pid", pid);
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    string name = dr.GetString(0);
                    string desc = dr.GetString(1);
                    string color = dr.GetString(2);
                    decimal price = dr.GetDecimal(3);
                    cmd.CommandText = "SELECT themaid FROM productthema WHERE productid = :pid";
                    cmd.Parameters.Add("pid", pid);
                    OracleDataReader dr2 = cmd.ExecuteReader();
                    string theme1 = null;
                    string theme2 = null;
                    string theme3 = null;
                    while (dr2.Read())
                    {
                        int themeid = dr2.GetInt32(0);
                        cmd.CommandText = $"SELECT naam FROM THEMA WHERE themaid = {themeid}";
                        cmd.Parameters.Add("tid", themeid);
                        OracleDataReader dr3 = cmd.ExecuteReader();
                        while (dr3.Read())
                        {
                            if (theme1 == null)
                            {
                                theme1 = dr3.GetString(0);
                            }
                            else if (theme2 == null)
                            {
                                theme2 = dr3.GetString(0);
                            }
                            else if (theme3 == null)
                            {
                                theme3 = dr3.GetString(0);
                            }
                        }
                    }
                    details.Productname = name;
                    details.Color = color;
                    details.Description = desc;
                    details.Price = price;
                    details.Themes = theme1;
                    details.Themes2 = theme2;
                    details.Themes3 = theme3;
                }
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
            return details;
        }
    }
}