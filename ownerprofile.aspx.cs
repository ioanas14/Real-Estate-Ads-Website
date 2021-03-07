using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ProiectBD
{
    public partial class ownerprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
     
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session expired! Log in again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getOwnerData();
                    }
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Proprietati P INNER JOIN Proprietari PR ON PR.IDUtilizator = '"+ Session["IDUtilizator"] +"' WHERE P.IDProprietar = PR.IDProprietar", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            catch (Exception ex)
            {

            }
        }

        //apasarea butonului "Actualizare informatii"
        protected void Button1_Click1(object sender, EventArgs e)
        {
            updateOwnerData();
        }

        //apasarea butonului "Cauta"
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPropertyByID();
        }

        //apasarea butonului "Actualizare proprietate"
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPropertyExists())
            {
                updateProperty();
            }
            else
            {
                Response.Write("<script>alert('Proprietatea nu exista in baza de date!'); </script>");
            }
        }

        void getPropertyByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista anuntul
                SqlCommand cmd = new SqlCommand("SELECT * FROM Proprietati WHERE IDProprietate = '" + TextBox8.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);


                if (dt.Rows.Count >= 1)
                {
                    TextBox9.Text =  dt.Rows[0][4].ToString();
                    TextBox11.Text = dt.Rows[0][3].ToString();
                    TextBox12.Text = dt.Rows[0][5].ToString();
                    TextBox13.Text = dt.Rows[0][6].ToString();
                    TextBox14.Text = dt.Rows[0][7].ToString();
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
        bool checkIfPropertyExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista proprietatea
                SqlCommand cmd = new SqlCommand("SELECT * FROM Proprietati WHERE IDProprietate = '" + TextBox8.Text.Trim() + "'", con);
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

        //actualizarea informatiilor despre o proprietate
        void updateProperty()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se actualizeaza informatiile despre proprietate
                SqlCommand cmd = new SqlCommand("UPDATE Proprietati SET NumarCamere = @nrc,  NumeProprietate = @nume," +
                    " Strada = @strada, Numarul = @numar, Orasul = @oras WHERE IDProprietate = '" + TextBox8.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@nume", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@nrc", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@strada", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@numar", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@oras", TextBox14.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Proprietate actualizata!');</script>");
                // clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        void updateOwnerData()
        {
            string password = "";
            if (TextBox4.Text.Trim() == "")
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
               
                SqlCommand cmd = new SqlCommand("UPDATE Proprietari SET Nume = @nume, Prenume = @prenume, CNP = @cnp WHERE IDUtilizator = (SELECT IDUtilizator FROM Utilizatori WHERE NumeUtilizator = '" + Session["username"].ToString() + "');", con);

                SqlCommand cmd1 = new SqlCommand("UPDATE Utilizatori SET NumeUtilizator = @numeut, Parola = @parola WHERE IDUtilizator = (SELECT IDUtilizator FROM Utilizatori WHERE NumeUtilizator = '" + Session["username"].ToString() + "');", con);

                cmd1.Parameters.AddWithValue("@numeut", TextBox1.Text.Trim());
                cmd1.Parameters.AddWithValue("@parola", password);
                cmd.Parameters.AddWithValue("@nume", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@prenume", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@cnp", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Datele au fost actualizate cu succes!');</script>");
            }

            catch (Exception ex)
            {

            }
        }

        void getOwnerData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator = '" + Session["username"].ToString() + "';", con);
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Proprietari " +
                    "WHERE IDUtilizator = (SELECT IDUtilizator FROM Utilizatori WHERE NumeUtilizator = '" + Session["username"].ToString() + "');", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);


                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                da.Fill(dt);
                da1.Fill(dt1);


                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0][2].ToString();
                    TextBox2.Text = dt.Rows[0][4].ToString();
                    TextBox3.Text = dt.Rows[0]["Parola"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Utilizatorul nu exista in baza de date!'); </script>");
                }

                if (dt1.Rows.Count >= 1)
                {
                    TextBox5.Text = dt1.Rows[0][2].ToString();
                    TextBox6.Text = dt1.Rows[0][3].ToString();
                    TextBox7.Text = dt1.Rows[0][4].ToString();
                }
                    
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

     

    }
}