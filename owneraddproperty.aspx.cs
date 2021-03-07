using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ProiectBD
{
    public partial class owneraddproperty : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //apasarea butonului "Adaugare"
        protected void Button1_Click(object sender, EventArgs e)
        {
            addNewProperty();
        }

        void addNewProperty()
        {
            try
            {
                string filepath = "";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("imgs/" + filename));
                filepath = "~/imgs/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //introducerea datelor in tabelul "Proprietati"
                SqlCommand cmd = new SqlCommand("INSERT INTO Proprietati(IDCategorie, IDProprietar, NumarCamere,  NumeProprietate, Strada, Numarul, Orasul, Judetul, ImgLINK)" +
                    " VALUES((SELECT IDCategorie FROM Categorii WHERE NumeCategorie = @numecateg),  " +
                    "(SELECT IDProprietar FROM Proprietari WHERE IDUtilizator = '" + Session["IDUtilizator"] + "'), " +
                    "@nrcamere, @numepropr, @strada, @numarul, @orasul, @judetul, @imglink) ", con);

                //Introducerea anuntului in tabelul "Anunt" prin selectarea celei mai recente proprietati adaugate
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Anunturi(IDProprietate, Vanzare_Inchiriere, Pret) " +
                    "VALUES((SELECT MAX(IDProprietate) FROM Proprietati " +
                    " WHERE IDProprietar = (SELECT IDProprietar FROM Proprietari WHERE IDUtilizator = '" + Session["IDUtilizator"] + "'))," +
                    " @vanzare, @pret)", con);

                cmd1.Parameters.AddWithValue("@vanzare", list.SelectedItem.Text.Trim());
                cmd1.Parameters.AddWithValue("@pret", TextBox10.Text.Trim());

                cmd.Parameters.AddWithValue("@numecateg", DropDownList1.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@nrcamere", nrcamere.Text.Trim());
                cmd.Parameters.AddWithValue("@numepropr", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@strada", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@numarul", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@orasul", Oras.Text.Trim());
                cmd.Parameters.AddWithValue("@judetul", Judet.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@imglink", filepath);


                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                Response.Write("<script>alert('Proprietate adaugata cu succes!'); </script>");
                con.Close();
                
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }

        }
    }
}