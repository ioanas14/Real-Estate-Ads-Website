using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProiectBD
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Utilizatori WHERE IDUtilizator <> 24", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            //GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //se afiseaza utilizatorii care sunt proprietari si care au minim x anunturi postate
            if (DropDownList1.Text.Trim() == "v1" && DropDownList2.Text.Trim() != "0")
            {
                SqlCommand cmd = new SqlCommand("SELECT U.IDUtilizator, U.NumeUtilizator, U.Email, U.Proprietar, P.Nume, P.Prenume FROM Utilizatori U INNER JOIN Proprietari P " +
                    "ON U.IDUtilizator = P.IDUtilizator GROUP BY U.IDUtilizator, U.NumeUtilizator, U.Email, U.Proprietar, P.IDProprietar, P.Nume, P.Prenume " +
                    "HAVING(SELECT COUNT(P1.IDProprietate) FROM Proprietati P1 WHERE P1.IDProprietar = P.IDProprietar) > '"+ DropDownList2.Text.Trim() +"'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Columns[1].Visible = true;
                GridView1.Columns[2].Visible = true;
                GridView1.Columns[3].Visible = true;
                GridView1.Columns[4].Visible = false;
                GridView1.Columns[5].Visible = false;
                GridView1.Columns[6].Visible = false;
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;

            }

            //se afiseaza utilizatorii care sunt proprietari si au postat cele mai multe proprietati
            if (DropDownList1.Text.Trim() == "v2")
            {
                SqlCommand cmd = new SqlCommand("SELECT U.IDUtilizator, U.NumeUtilizator, U.Email, U.Proprietar, COUNT(P2.IDProprietate) AS NrProprietati FROM Utilizatori U " +
                    "INNER JOIN Proprietari P1 ON U.IDUtilizator = P1.IDUtilizator INNER JOIN Proprietati P2 ON P1.IDProprietar = P2.IDProprietar " +
                    "GROUP BY U.IDUtilizator, U.NumeUtilizator, U.Email, U.Proprietar " +
                    "HAVING COUNT(P2.IDProprietate) = (SELECT MAX(nrprop) FROM(SELECT COUNT(P1.IDProprietate) AS nrprop FROM Proprietati P1 " +
                    "INNER JOIN Proprietari P2 ON P1.IDProprietar = P2.IDProprietar GROUP BY P1.IDProprietar) as NrProprietati) ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.Columns[2].Visible = true;
                GridView1.Columns[4].Visible = true;
                GridView1.Columns[3].Visible = false;
                GridView1.Columns[5].Visible = false;
                GridView1.Columns[6].Visible = false;
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            //afisarea proprietarilor cu o medie de pret a proprietatilor mai mare decat 500
            if (DropDownList1.Text.Trim() == "v3")
            {
                SqlCommand cmd = new SqlCommand("SELECT U.IDUtilizator, P.Nume, P.Prenume, P.IDProprietar, AVG(A.Pret) AS MediePret " +
                    "FROM Proprietari P INNER JOIN Utilizatori U ON P.IDUtilizator = U.IDUtilizator " +
                    "INNER JOIN Proprietati P1 ON P.IDProprietar = P1.IDProprietar " +
                    "INNER JOIN Anunturi A ON A.IDProprietate = P1.IDProprietate " +
                    "GROUP BY P.Nume, P.Prenume, P.IDProprietar, U.IDUtilizator HAVING (SELECT AVG(A.Pret)) >= 500", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.Columns[4].Visible = false;
                GridView1.Columns[3].Visible = false;
                GridView1.Columns[1].Visible = false;
                GridView1.Columns[2].Visible = false;
                GridView1.Columns[5].Visible = true;
                GridView1.Columns[6].Visible = true;
                GridView1.Columns[7].Visible = true;
                GridView1.Columns[8].Visible = false;
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            //afisarea anunturilor care au fost salvate de catre cel putin 3 utilizatori
            if (DropDownList1.Text.Trim() == "v4")
            {
                SqlCommand cmd = new SqlCommand("SELECT A.Pret, P.NumeProprietate, S.IDAnunt, COUNT(S.IDAnunt) AS NrSalvari FROM Proprietati P  " +
                    "INNER JOIN Anunturi A ON A.IDProprietate = P.IDProprietate " +
                    "INNER JOIN Salvate S ON S.IDAnunt = A.IDAnunt " +
                    "GROUP BY A.Pret, S.IDAnunt, P.NumeProprietate HAVING(SELECT COUNT(S.IDAnunt)) > 3", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.Columns[4].Visible = false;
                GridView1.Columns[3].Visible = false;
                GridView1.Columns[1].Visible = false;
                GridView1.Columns[2].Visible = false;
                GridView1.Columns[5].Visible = false;
                GridView1.Columns[6].Visible = false;
                GridView1.Columns[8].Visible = true;
                GridView1.Columns[9].Visible = true;
                GridView1.Columns[10].Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }




        }
    }
}