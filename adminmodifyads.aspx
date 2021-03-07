<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmodifyads.aspx.cs" Inherits="ProiectBD.adminmodificareproprietati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
           $('.table').prepend($('<thead></thead>').append($(this).find('tr:first'))).dataTable();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Informatii anunt</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100" src="imgs/ads.png" />
                                       
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>ID Anunt</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Cauta" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <%--daca este de vanzare sau inchiriere--%>
                            <div class="col-md-8">
                                <label>Status anunt</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Vanzare/inchiriere" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>ID Proprietate</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"  ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Pret</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" ></asp:TextBox>
                                </div>
                            </div>


                        </div>

                        <div class="row">
         
                            <div class="col-6">
                                <asp:Button ID="Button3" class="btn btn-md btn-block btn-warning" runat="server" Text="Actualizare" OnClick="Button3_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="Button4" class="btn btn-md btn-block btn-danger" runat="server" Text="Stergere" OnClick="Button4_Click" />
                            </div>
                        </div>


                    </div>
                </div>

                <a href="homepage.aspx"><- Inapoi la pagina principala</a><br>
                <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body>
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Lista anunturi</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProiectDBConnectionString %>" SelectCommand="SELECT * FROM [Anunturi]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IDAnunt" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="IDAnunt" HeaderText="IDAnunt" InsertVisible="False" ReadOnly="True" SortExpression="IDAnunt" />
                                        <asp:BoundField DataField="IDProprietate" HeaderText="IDProprietate" SortExpression="IDProprietate" />
                                        <asp:BoundField DataField="Vanzare_Inchiriere" HeaderText="Vanzare_Inchiriere" SortExpression="Vanzare_Inchiriere" />
                                        <asp:BoundField DataField="Pret" HeaderText="Pret" SortExpression="Pret" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
