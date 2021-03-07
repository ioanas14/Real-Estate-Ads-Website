using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProiectBD
{
    public partial class adminmodifyowners : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //se apasa butonul "Cauta"
        protected void Button1_Click(object sender, EventArgs e)
        {
            getOwnerByID();
        }

        //se apasa butonul "Stergere proprietar"
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkIfOwnerExists())
            {
                deleteOwner();
            }
            else
            {
                Response.Write("<script>alert('Proprietarul nu exista in baza de date!'); </script>");
            }
        }

        void deleteOwner()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se sterge proprietarul
                SqlCommand cmd = new SqlCommand("DELETE FROM Proprietari WHERE IDProprietar = '" + TextBox1.Text.Trim() + "'", con);

                //se sterge contul de utilizator care corespunde proprietarului sters
                SqlCommand cmd1 = new SqlCommand("DELETE w FROM Utilizatori w INNER JOIN Proprietari p ON w.IDUtilizator = p.IDUtilizator WHERE p.IDProprietar = '" + TextBox1.Text.Trim() + "'", con);

                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                
                con.Close();
                Response.Write("<script>alert('Proprietar sters!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkIfOwnerExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista proprietarul
                SqlCommand cmd = new SqlCommand("SELECT * FROM Proprietari WHERE IDProprietar = '" + TextBox1.Text.Trim() + "'", con);
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
            cnp.Text = "";
        }

        void getOwnerByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista proprietarul
                SqlCommand cmd = new SqlCommand("SELECT * FROM Proprietari WHERE IDProprietar = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);


                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][2].ToString() + " " + dt.Rows[0][3].ToString();
                    cnp.Text = dt.Rows[0][4].ToString();            
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