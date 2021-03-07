using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProiectBD
{
    public partial class adminmodificareproprietati : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //apasarea butonului "Cauta"
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAdByID();
        }

        //apasarea butonului "Actualizare"
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAdExists())
            {
                updateAd();
            }
            else
            {
                Response.Write("<script>alert('Anuntul nu exista in baza de date!'); </script>");
            }
        }

        //apasarea butonului "Stergere"
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAdExists())
            {
                deleteAd();
            }
            else
            {
                Response.Write("<script>alert('Anuntul nu exista in baza de date!'); </script>");
            }
        }

        void deleteAd()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se sterge anuntul
                SqlCommand cmd = new SqlCommand("DELETE FROM Anunturi WHERE IDAnunt = '" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Anunt sters!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
        void updateAd()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se actualizeaza anuntul
                SqlCommand cmd = new SqlCommand("UPDATE Anunturi SET Pret = @pret WHERE IDAnunt = '" + TextBox1.Text.Trim() + "'", con);


                cmd.Parameters.AddWithValue("@pret", TextBox4.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Anunt actualizat!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkIfAdExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista anuntul
                SqlCommand cmd = new SqlCommand("SELECT * FROM Anunturi WHERE IDAnunt = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                
                da.Fill(dt);

                
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        void getAdByID ()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista anuntul
                SqlCommand cmd = new SqlCommand("SELECT * FROM Anunturi WHERE IDAnunt = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);


                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][2].ToString();
                    TextBox3.Text = dt.Rows[0][1].ToString();
                    TextBox4.Text = dt.Rows[0][3].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Anuntul nu exista in baza de date!'); </script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
               
            }
        }
    }
}