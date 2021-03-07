<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ownersignup.aspx.cs" Inherits="ProiectBD.ownersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('/imgs/back.jpg');">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col" style="text-align: center">
                                <img width="100" src="imgs/userlogin.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h3>Înregistrare proprietar</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <hr />
                            </div>
                        </div>

                        <div class="row">

                            <div class="col" style="text-align: center">
                                <label>Nume utilizator</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="userBox" runat="server"></asp:TextBox>
                                </div>

                                <label>E-mail</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="emailBox" runat="server"></asp:TextBox>
                                </div>

                                <div class="row">
                                    <div class="col-md">
                                         <label>Parola</label>
                                           <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="passwordBox" runat="server" TextMode="Password"></asp:TextBox>
                                           </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Nume</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="name1Box" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Prenume</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="name2Box" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                              
                                 <div class="row">
                                    <div class="col-md">
                                        <label>CNP</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="cnpBox" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-success btn-block btn-lg" ID="inregistrButton" runat="server" Text="Inregistrare" OnClick="inregistrButton_Click" />
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>

                    <a href="Homepage.aspx"><- Înapoi la pagina principală</a>
                    <br>
                    <br />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
