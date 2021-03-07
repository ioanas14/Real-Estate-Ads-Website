<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmodifyusers.aspx.cs" Inherits="ProiectBD.modifyowners" %>

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
                                        <h4>Informatii utilizator</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100" src="imgs/user.png" />
                                       
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
                                <label>ID Utilizator</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Cauta" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Nume utilizator</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nume utilizator" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>E-mail</label>
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="email" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <hr />


                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="Button5" class="btn btn-lg btn-block btn-danger" runat="server" Text="Stergere utilizator" OnClick="Button5_Click" />
                            </div>
                        </div>


                    </div>
                </div>

                <a href="homepage.aspx"><- Inapoi la pagina principala</a><br>
                <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Lista utilizatori</h4>
                                    </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProiectDBConnectionString %>" SelectCommand="SELECT * FROM [Utilizatori] WHERE IDUtilizator <> 24"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IDUtilizator" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="IDUtilizator" HeaderText="IDUtilizator" InsertVisible="False" ReadOnly="True" SortExpression="IDUtilizator" />                       
                                        <asp:BoundField DataField="NumeUtilizator" HeaderText="NumeUtilizator" SortExpression="NumeUtilizator" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        <asp:BoundField DataField="Proprietar" HeaderText="Proprietar" SortExpression="Proprietar" />
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
