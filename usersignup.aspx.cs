using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProiectBD
{
    public partial class signup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //se apasa butonul "Inregistrare"
        protected void inregButton_Click(object sender, EventArgs e)
        {

            //verificam daca utilizatorul exista sau nu; daca nu exista, il inregistram
            if (checkUserExists())
            {
                Response.Write("<script>alert('Deja exista un utilizator cu acest nume!'); </script>");
            }
            else
            {
                signUpNewUser();
                Response.Redirect("userlogin.aspx");
            }

        }

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista utilizatorul in baza de date cu acelasi nume de utilizator
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator = '" + usernameBox.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //un tabel in cod
                DataTable dt = new DataTable();
                //datele primite din baza de date se vor retine in acest tabel pentru a verifica daca exista utilizatori sau nu
                da.Fill(dt);

                // se verifica daca exista cel putin o inregistrare (un utilizator cu acelasi NumeUtilizator)
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


        void signUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("INSERT INTO Utilizatori(NumeUtilizator, Parola, Email, Proprietar)" +
                                                 "VALUES(@NumeUtilizator, @Parola, @Email, 0)", con);

                cmd.Parameters.AddWithValue("@NumeUtilizator", usernameBox.Text.Trim());
                cmd.Parameters.AddWithValue("@Parola", passBox.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", mailBox.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Inregistrare reusita!'); </script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
    }
}