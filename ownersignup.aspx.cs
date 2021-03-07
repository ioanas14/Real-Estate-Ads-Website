using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ProiectBD
{
    public partial class ownersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //apasarea butonului "Inregistrare"
        protected void inregistrButton_Click(object sender, EventArgs e)
        {
            if (checkOwnerExists())
            {
                Response.Write("<script>alert('Deja exista un utilizator cu acest nume!'); </script>");
            }
            else
            {
                signUpNewOwner();
                Response.Redirect("userlogin.aspx");
            }
        }

        bool checkOwnerExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //se verifica daca exista utilizatorul in baza de date cu acelasi nume de utilizator
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator = '" + userBox.Text.Trim() + "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);

                DataTable dt1 = new DataTable();
                //datele primite din baza de date se vor retine in acest tabel pentru a verifica daca exista utilizatori sau nu
                da1.Fill(dt1);

                // se verifica daca exista cel putin o inregistrare (un utilizator cu acelasi NumeUtilizator)
                if (dt1.Rows.Count >= 1)
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

        void signUpNewOwner()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO [Utilizatori](NumeUtilizator, Parola, Email, Proprietar)" +
                                                 "VALUES(@NumeUtilizator, @Parola, @Email, 1)", con);

                cmd.Parameters.AddWithValue("@NumeUtilizator", userBox.Text.Trim());
                cmd.Parameters.AddWithValue("@Parola", passwordBox.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", emailBox.Text.Trim());
                cmd.ExecuteNonQuery();

                //INSERARE IN TABELUL DE PROPRIETARI CU INTRODUCEREA CHEII STRAINE "IDUtilizator"
                SqlCommand cmd1 = new SqlCommand("INSERT INTO [Proprietari](IDUtilizator, Nume, Prenume, CNP) " +
                    "VALUES ((SELECT IDUtilizator FROM Utilizatori WHERE NumeUtilizator='" + userBox.Text.Trim() + "'), @Nume, @Prenume, @CNP)", con);

                cmd1.Parameters.AddWithValue("@Nume", name1Box.Text.Trim());
                cmd1.Parameters.AddWithValue("@Prenume", name2Box.Text.Trim());
                cmd1.Parameters.AddWithValue("@CNP", cnpBox.Text.Trim());
                cmd1.Parameters.AddWithValue("@IDUtilizator", DBNull.Value);
                cmd1.ExecuteNonQuery();

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