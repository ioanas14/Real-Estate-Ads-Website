<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="ProiectBD.signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%--pagina de inregistrare--%>

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
                                <h3>Înregistrare utilizator</h3>
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
                                    <asp:TextBox CssClass="form-control" ID="usernameBox" runat="server"></asp:TextBox>
                                </div>

                                <label>E-mail</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="mailBox" runat="server"></asp:TextBox>
                               </div>
                                    <div class="row">
                                        <div class="col-md">
                                            <label>Parola</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="passBox" runat="server" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                       
                                    </div>
                                
                                                                                        

                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button class="btn btn-success btn-block btn-lg" ID="inregButton" runat="server" Text="Inregistrare" OnClick="inregButton_Click" />
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
