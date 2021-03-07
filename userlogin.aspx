<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ProiectBD.userlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%--pagina de conectare ca utilizator--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('/imgs/back.jpg');">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <img width="150" src="imgs/userlogin.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h3>Log-in utilizator</h3>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                </div>

                                <label>Parola</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Log-in" OnClick="Button1_Click" />
                                </div>

                                <div class="form-group">
                                    <a href="usersignup.aspx">
                                        <input class="btn btn-info btn-block" id="Button2" type="button" value="Înregistrare utilizator" /></a>
                                </div>

                                <div class="form-group">
                                    <a href="ownersignup.aspx">
                                        <input class="btn btn-info btn-block" id="Button2" type="button" value="Înregistrare proprietar" /></a>
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
</asp:Content>
