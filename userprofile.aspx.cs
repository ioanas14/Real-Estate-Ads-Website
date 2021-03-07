using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ProiectBD
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session expired! Log in again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    if(!Page.IsPostBack)
                    {
                        getUserData();
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                         SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT * FROM [Anunturi] INNER JOIN [Salvate] ON [Anunturi].IDAnunt = [Salvate].IDAnunt " +
                             "INNER JOIN [Proprietati] ON [Anunturi].IDProprietate = [Proprietati].IDProprietate INNER JOIN [Categorii] ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                             "WHERE [Salvate].IDUtilizator = '" + Session["IDUtilizator"] + "'", con);

                        
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        SqlDataAdapter da1 = new SqlDataAdapter("SELECT COUNT(S.IDAnunt) AS NrSalvate, S.IDUtilizator FROM SALVATE S INNER JOIN Utilizatori U ON S.IDUtilizator = U.IDUtilizator AND U.IDUtilizator = '" + Session["IDUtilizator"] + "' GROUP BY S.IDUtilizator", con);

                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);

                        if (dt1.Rows.Count >= 1)
                        {
                            TextBox5.Text = dt1.Rows[0][0].ToString();         
                        }
                        else
                        {
                            TextBox5.Text = "0";
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        //Apasarea butonului "Actualizare"
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session expired! Log in again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserData();
            }
        }

        void updateUserData()
        {
            //variabila folosita pentru a verifica daca utilizatorul doreste sa modifice si parola
            string password = "";
            if(TextBox4.Text.Trim() == "")
            {
                password = TextBox3.Text.Trim();
            }
            else
            {
                password = TextBox4.Text.Trim();
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Utilizatori SET NumeUtilizator = @numeut, Parola = @parola WHERE NumeUtilizator = '" + Session["username"].ToString() + "'", con);

                cmd.Parameters.AddWithValue("@numeut", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@parola", password);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Datele au fost actualizate cu succes!');</script>");    
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        void getUserData()
        {
           try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator = '"+ Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
               

                if(dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0][2].ToString();
                    TextBox2.Text = dt.Rows[0][4].ToString();
                    TextBox3.Text = dt.Rows[0]["Parola"].ToString();    
                }
                else
                {
                    Response.Write("<script>alert('Utilizatorul nu exista in baza de date!'); </script>");
                }
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
    }
}