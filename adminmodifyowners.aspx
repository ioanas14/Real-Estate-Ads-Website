<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmodifyowners.aspx.cs" Inherits="ProiectBD.adminmodifyowners" %>
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
                                        <h4>Informatii proprietar</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100" src="imgs/owner.png" />
                                       
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
                                <label>ID Proprietar</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Cauta" OnClick="Button1_Click"/>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Nume Proprietar</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nume proprietar"  ReadOnly="true"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>CNP</label>
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="cnp" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="Button5" class="btn btn-md btn-block btn-danger" runat="server" Text="Stergere proprietar" OnClick="Button5_Click" />
                            </div>
                        </div>


                    </div>
                </div>

                <a href="homepage.aspx"><-Inapoi la pagina principala</a><br>
                <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Lista proprietari</h4>
                                    </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProiectDBConnectionString2 %>" SelectCommand="SELECT * FROM [Proprietari]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IDProprietar" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="IDProprietar" HeaderText="IDProprietar" InsertVisible="False" ReadOnly="True" SortExpression="IDProprietar" />
                                        <asp:BoundField DataField="IDUtilizator" HeaderText="IDUtilizator" SortExpression="IDUtilizator" />
                                        <asp:BoundField DataField="Nume" HeaderText="Nume" SortExpression="Nume" />
                                        <asp:BoundField DataField="Prenume" HeaderText="Prenume" SortExpression="Prenume" />
                                        <asp:BoundField DataField="CNP" HeaderText="CNP" SortExpression="CNP" />
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
