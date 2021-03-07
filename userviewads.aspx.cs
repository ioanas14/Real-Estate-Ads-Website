using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProiectBD
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //se ordoneaza proprietatile in ordine crescatoare dupa pret
            if (DropDownList1.Text.Trim() == "p1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate ORDER BY [Anunturi].Pret ASC", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            //se ordoneaza proprietatile in ordine descrescatoare dupa pret
            else if (DropDownList1.Text.Trim() == "p2")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate ORDER BY [Anunturi].Pret DESC", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            //filtrarea in functie de pret
            if (DropDownList2.Text.Trim() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Pret >= 200 AND [Anunturi].Pret <= 300", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (DropDownList2.Text.Trim() == "2")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Pret >= 300", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            

            if(DropDownList1.Text.Trim() == "p1" && DropDownList2.Text.Trim() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Pret >= 200 AND [Anunturi].Pret <= 300" +
                    "ORDER BY [Anunturi].Pret ASC", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            if (DropDownList1.Text.Trim() == "p1" && DropDownList2.Text.Trim() == "2")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Pret >= 300" +
                    "ORDER BY [Anunturi].Pret ASC", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            if (DropDownList1.Text.Trim() == "p2" && DropDownList2.Text.Trim() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Pret >= 200 AND [Anunturi].Pret <= 300" +
                    "ORDER BY [Anunturi].Pret DESC", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            if (DropDownList1.Text.Trim() == "p2" && DropDownList2.Text.Trim() == "2")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                    "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Pret >= 300" +
                    "ORDER BY [Anunturi].Pret DESC", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            //se selecteaza doar proprietatile care sunt de vanzare
            if(DropDownList3.Text.Trim() == "1")
            {
                if(DropDownList1.Text.Trim() == "0" && DropDownList2.Text.Trim() == "0")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'vanzare'", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                if (DropDownList1.Text.Trim() == "0" && DropDownList2.Text.Trim() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'vanzare'" +
                     "AND [Anunturi].Pret >= 200 AND [Anunturi].Pret <=300", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                if (DropDownList1.Text.Trim() == "0" && DropDownList2.Text.Trim() == "2")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'vanzare'" +
                     "AND [Anunturi].Pret >= 300", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                //proprietatile care sunt de vanzare, ordonate crescator dupa pret
                if (DropDownList1.Text.Trim() == "p1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'vanzare'" +
                     "ORDER BY [Anunturi].Pret ASC", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                //proprietatile care sunt de vanzare, ordonate descrescator dupa pret
                if (DropDownList1.Text.Trim() == "p2")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'vanzare'" +
                     "ORDER BY [Anunturi].Pret DESC", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

            //se selecteaza doar proprietatile care sunt pentru inchiriat
            if (DropDownList3.Text.Trim() == "2")
            {
                if (DropDownList1.Text.Trim() == "0" && DropDownList2.Text.Trim() == "0")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                //proprietati pt inchiriat, filtrate dupa pret
                if (DropDownList1.Text.Trim() == "0" && DropDownList2.Text.Trim() == "1")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                     "AND [Anunturi].Pret >= 200 AND [Anunturi].Pret <=300", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                if (DropDownList1.Text.Trim() == "0" && DropDownList2.Text.Trim() == "2")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                     "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                     "AND [Anunturi].Pret >= 300", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da1.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                //proprietatile care sunt de inchiriat, ordonate crescator dupa pret
                if (DropDownList1.Text.Trim() == "p1")
                {
                    if (DropDownList2.Text.Trim() == "0")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                         "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                         "ORDER BY [Anunturi].Pret ASC", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }

                    if (DropDownList2.Text.Trim() == "1")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                         "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                         "AND [Anunturi].Pret >= 200 AND [Anunturi].Pret <= 300 ORDER BY [Anunturi].Pret ASC", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }

                    if (DropDownList2.Text.Trim() == "2")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                         "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                         "AND [Anunturi].Pret >= 300 ORDER BY [Anunturi].Pret ASC", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }

                //proprietatile care sunt de inchiriat, ordonate descrescator dupa pret
                if (DropDownList1.Text.Trim() == "p2")
                {
                    if (DropDownList2.Text.Trim() == "0")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                         "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                         "ORDER BY [Anunturi].Pret DESC", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }

                    if (DropDownList2.Text.Trim() == "1")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                         "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                         "AND [Anunturi].Pret >= 200 AND [Anunturi].Pret <= 300 ORDER BY [Anunturi].Pret DESC", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }

                    if (DropDownList2.Text.Trim() == "2")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM[Proprietati] INNER JOIN Categorii ON [Proprietati].IDCategorie = [Categorii].IDCategorie " +
                         "INNER JOIN [Anunturi] ON [Proprietati].IDProprietate = [Anunturi].IDProprietate WHERE [Anunturi].Vanzare_Inchiriere = 'Inchiriere'" +
                         "AND [Anunturi].Pret >= 300 ORDER BY [Anunturi].Pret DESC", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }

        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Save")
            {
                int index = Convert.ToInt32(e.CommandArgument);
               
                GridViewRow row = GridView1.Rows[index];

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Salvate(IDUtilizator, IDAnunt) VALUES (@idutiliz, @idanunt)", con);

                cmd.Parameters.AddWithValue("@idutiliz", Session["IDUtilizator"]);
                cmd.Parameters.AddWithValue("@idanunt", row.Cells[2].Text);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        
    }
}