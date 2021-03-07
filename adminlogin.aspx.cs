using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProiectBD
{
    public partial class adminlogin : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator = 'ioana' " +
                    "AND Parola = 'ioana'", con);

                //va executa query-ul si citeste rezultatele obtinute dupa executare
                SqlDataReader dr = cmd.ExecuteReader();

                //verificam daca exista o inregistrare care se potriveste
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Conectare reusita!');</script>");
                        Session["username"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Utilizator inexistent!');</script>");
                }
                Response.Redirect("homepage.aspx");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
    }
}