<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ProiectBD.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%--pagina profilului de utilizator--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="container-fluid">
        <div class="row">
            <%--afisarea informatiilor pt utilizator--%>
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col" style="text-align: center">
                                <img width="100" src="imgs/userlogin.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h3>Informatii utilizator</h3>
       
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

                                <label>E-mail</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <label>Parola curenta</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <label>Parola noua</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="rou">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Actualizare" OnClick="Button1_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>

                    
                </div>
            </div>

            <%--afisarea anunturilor salvate de catre utilizator--%>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <img width="100" src="imgs/views.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h3>Anunțuri salvate</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-5" style="text-align: center">
                                <h5>Număr anuțuri salvate: </h5>     
                            </div>
                            <div class="col-2"> 
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12" style="text-align: center">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"  BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">            
                                                        <div class="col-lg-8">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeProprietate") %>' Font-Bold="True" Font-Size="Larger" ForeColor="#660066"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <span><b>Adresa:</b></span>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Orasul") %>'></asp:Label>,
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Strada") %>'></asp:Label>, Nr.
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Numarul") %>'></asp:Label>,
                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Judetul") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                     <span><b>Categorie:</b></span>
                                                                     <asp:Label ID="Label6" runat="server" Text='<%# Eval("NumeCategorie") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                     <span><b>Status:</b></span>
                                                                     <asp:Label ID="Label8" runat="server" Text='<%# Eval("Vanzare_Inchiriere") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                     <span><b>Pret:</b></span>
                                                                     <asp:Label ID="Label7" runat="server" Text='<%# Eval("Pret") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-lg-4">
                                                            <asp:Image width="200" class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("ImgLINK") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                </asp:GridView>
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

</asp:Content>
