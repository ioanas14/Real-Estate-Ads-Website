<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="ProiectBD.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<%--pagina principala--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <section>
        <img width=1800 height=200 src="imgs/header.jpg" class="img-fluid" />
    </section>
    </div>
    
    
    <section>
        <div class="container">
            <div class="row" style="text-align:center">
                <div class="col-12">
                    
                    <h2>Ce vă oferim?</h2>
                        
                </div>
            </div>

            <div class="row">
                <div class="col-md-4" style="text-align:center">
                    <img width="150" src="imgs/addproperty.png"/>
                    <h4>Abilitatea de a adăuga proprietăți noi</h4>
                    <p class="text-justify">
                        Înregistrați-vă drept proprietar pe site-ul nostru și veți avea abilitatea de a adăuga proprietățile dumneavoastră
                        spre închiriere/vanzare
                    </p>
                </div>

                <div class="col-md-4" style="text-align:center">
                    <img width="150" src="imgs/rent.jpg"/>
                    <h4>Posibilitatea de a închiria proprietăți</h4>
                    <p class="text-justify">
                        Dacă sunteți în căutare de o nouă locuință pentru închiriere, pe site-ul nostru
                        veți găsi o multitudine de proprietăți disponibile
                    </p>
                </div>

                <div class="col-md-4" style="text-align:center">
                    <img width="150" src="imgs/buy.png"/>
                    <h4>Posibilitatea de a cumpăra proprietăți</h4>
                    <p class="text-justify">
                        Dacă sunteti în căutarea unei locuințe noi pe care doriți să o cumpărați, 
                        pe site-ul nostru veți găsi o multitudine de proprietăți disponibile
                    </p>
                </div>
            </div>
        </div>
    </section>

    <div class="container-fluid">
        <section>
            <img width=1800 height=200 src="imgs/header2.png" class="img-fluid" />
        </section>
    </div>
    

    <section>
        <div class="container">
            <div class="row" style="text-align:center">
                <div class="col-12">
                    <h2>Procesul nostru</h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6" style="text-align:center">
                    <img width="150" src="imgs/user.png"/>
                    <h4>Înregistrarea ca utilizator simplu</h4>
                    <p class="text-justify">
                        Înregistrați-vă drept utilizator simplu și veti putea vizualiza toate proprietățile disponibile
                    </p>
                </div>

                <div class="col-md-6" style="text-align:center">
                    <img width="150" src="imgs/owner.png"/>
                    <h4>Înregistrarea ca proprietar</h4>
                    <p class="text-justify">
                        Înregistrați-vă drept proprietar și veți putea adăuga proprietățile dumneavoastră
                    </p>
                </div>

            </div>
        </div>
    </section>
       
</asp:Content>
