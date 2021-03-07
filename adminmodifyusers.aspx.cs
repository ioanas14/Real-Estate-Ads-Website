using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProiectBD
{
    public partial class modifyowners : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //apasarea butonului "Stergere utilizator"
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkIfUserExists()) {
                
                int txt1 = int.Parse(TextBox1.Text);
                if (txt1 == 24)
                {
                    Response.Write("<script>alert('Nu se poate modifica administratorul!'); </script>");
                }
                else
                {
                    deleteUser();
                }
            }
            else
            {
                Response.Write("<script>alert('Utilizatorul nu exista in baza de date!'); </script>");
            }
            
        }

        //apasarea butonului "Cauta"
        protected void Button1_Click(object sender, EventArgs e)
        {
            getUserByID();
        }
       

        //functie care verifica daca exista utilizatorul
        bool checkIfUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE IDUtilizator = '" + TextBox1.Text.Trim() + "'", con);

               
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

        //functie pentru stergerea unui utilizator
        void deleteUser ()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se sterge utilizatorul
                SqlCommand cmd = new SqlCommand("DELETE FROM Utilizatori WHERE IDUtilizator = '" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Utilizator sters!');</script>");
                clearForm();
                GridView1.DataBind();



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            email.Text = "";
        }

        void getUserByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista proprietarul
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE IDUtilizator = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);


                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][2].ToString();
                    email.Text = dt.Rows[0][4].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Utilizatorul nu exista in baza de date!'); </script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

    }
}