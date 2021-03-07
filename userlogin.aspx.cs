using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProiectBD
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //apasarea butonului "Log-in"
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //se verifica daca exista utilizatorul in baza de date
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator = '" + TextBox1.Text.Trim() + "' " +
                    "AND Parola = '" + TextBox2.Text.Trim() + "'", con);

                //va executa query-ul si citeste rezultatele obtinute dupa executare
                SqlDataReader dr = cmd.ExecuteReader();

                //verificam daca exista o inregistrare care se potriveste
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Conectare reusita!');</script>");
                        //stocheaza numele utilizatorului care este conectat in momentul respectiv pe site
                        Session["username"] = dr.GetValue(2).ToString();

                        //stocheaza ID-ul utilizatorului care este conectat
                        Session["IDUtilizator"] = dr.GetValue(0).ToString();
                        
                        //daca in campul "Proprietar" se afla valoarea 1 - utilizatorul este proprietar
                        //altfel, este utilizator simplu
                        if (dr.GetValue(5).ToString() == "1")
                        {
                            Session["role"] = "owner";   
                        }
                        else
                        {
                            Session["role"] = "user";
                        }
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Utilizator inexistent!');</script>");
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
    }
}