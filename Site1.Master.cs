using System;

namespace ProiectBD
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //verificam ce tip de utilizator s-a conectat, pentru a afisa link-urile corespunzatoare
            try
            {
                if (string.IsNullOrEmpty((string)Session["role"]))
                {
                    loginButton.Visible = true; //butonul de "log-in" vizibil
                    inregproprButton.Visible = true; //butonul de "inregistrare proprietar" vizibil
                    inreguserButton.Visible = true; //butounl de "inregistrare utilizator" vizibil
                    logoutButton.Visible = false; //butonul de log-out invizibil
                    adaugarepropButton.Visible = false;
                    proprietatiButton.Visible = false;
                    adminloginButton.Visible = true;
                    modifanuntButton.Visible = false;
                    modifpropButton.Visible = false;
                    modifutilizButton.Visible = false;
                    hellouserButton.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    hellouserButton.Visible = true;
                    hellouserButton.Text = "Hello " + Session["username"].ToString();
                    proprietatiButton.Visible = true;
                    logoutButton.Visible = true;
                    adminloginButton.Visible = true;
                    modifanuntButton.Visible = false;
                    modifpropButton.Visible = false;
                    modifutilizButton.Visible = false;
                    inregproprButton.Visible = false;
                    inreguserButton.Visible = false;
                    loginButton.Visible = false;
                }
                else if (Session["role"].Equals("owner"))
                {
                    hellouserButton.Visible = true;
                    hellouserButton.Text = "Hello " + Session["username"].ToString();
                    proprietatiButton.Visible = true;
                    logoutButton.Visible = true;
                    adminloginButton.Visible = true;
                    modifanuntButton.Visible = false;
                    modifpropButton.Visible = false;
                    modifutilizButton.Visible = false;
                    inregproprButton.Visible = false;
                    inreguserButton.Visible = false;
                    loginButton.Visible = false;
                    adaugarepropButton.Visible = true;
                }
                else if (Session["role"].Equals("admin")) 
                {
                    hellouserButton.Visible = true;
                    hellouserButton.Text = "Hello " + Session["username"].ToString();
                    proprietatiButton.Visible = true;
                    logoutButton.Visible = true;
                    adminloginButton.Visible = false;
                    modifanuntButton.Visible = true;
                    modifpropButton.Visible = true;
                    modifutilizButton.Visible = true;
                    inregproprButton.Visible = false;
                    inreguserButton.Visible = false;
                    loginButton.Visible = false;
                    userStatButton.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
        //se apasa butonul "Admin Login"
        protected void adminloginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        //Se apasa butonul "Modificare proprietari"
        protected void modifpropButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmodifyowners.aspx");
        }

        //Se apasa butonul "Modificare anunturi"
        protected void modifanuntButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmodifyads.aspx");
        }

        //SE apasa butonul "Modificare Utilizatori"
        protected void modifutilizButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmodifyusers.aspx");
        }

        //Se apasa butonul "Adaugare proprietate"
        protected void adaugarepropButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("owneraddproperty.aspx");
        }

        //Se apaasa butonul "Logout"
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            loginButton.Visible = true; //butonul de "log-in" vizibil
            inregproprButton.Visible = true; //butonul de "inregistrare proprietar" vizibil
            inreguserButton.Visible = true; //butounl de "inregistrare utilizator" vizibil
            logoutButton.Visible = false; //butonul de log-out invizibil
            adaugarepropButton.Visible = false;
            proprietatiButton.Visible = false;
            adminloginButton.Visible = true;
            modifanuntButton.Visible = false;
            modifpropButton.Visible = false;
            modifutilizButton.Visible = false;
            hellouserButton.Visible = false;

            Response.Redirect("Homepage.aspx");
        }

        //Se apasa butonul "Inregistrare utilizator"
        protected void inreguserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        //Se apasa butonul "Proprietati"
        protected void proprietatiButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("userviewads.aspx");
        }

        //Se apasa butonul "Login"
        protected void loginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        //apasarea "Hello USER"
        protected void hellouserButton_Click(object sender, EventArgs e)
        {
            //AICI APARE PAGINA DE UTILIZATOR SIMPLU SAU DE PROPRIETAR
            if (Session["role"].Equals("user"))
                Response.Redirect("userprofile.aspx");
            else if(Session["role"].Equals("owner"))
                Response.Redirect("ownerprofile.aspx");
        }

        protected void inregproprButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ownersignup.aspx");
        }

        protected void userStatButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("userStatistics.aspx");
        }
    }
}