<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ownerprofile.aspx.cs" Inherits="ProiectBD.ownerprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <%--afisarea informatiilor pt proprietar--%>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col" style="text-align: center">
                                <img width="100" src="imgs/owner.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h3>Informatii proprietar</h3>
                   
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

                                    <div class="row">

                                        <div class="col-md-4">
                                            <label>Nume</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" ></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <label>Prenume</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" ></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <label>CNP</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" ></asp:TextBox>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Actualizare informatii" OnClick="Button1_Click1" />
                                            </div>
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

                <div class="card">
                    <div class="row">
                            <div class="col" style="text-align: center">
                                <h3>Modificare proprietate</h3>
                            </div>
                        </div>
                    </div>
                <div class="row">
                            <div class="col" style="text-align: center">
                                <hr />
                            </div>
                        </div>
                   <div class="row">
                            <div class="col-md-4">
                                <label>ID Proprietate</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Cauta" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Nume Proprietate</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Nume proprietate"></asp:TextBox>
                                </div>
                            </div>
                     </div>

                   <div class="row">
                       

                       <div class="col-md-4">
                           <label>Numar camere</label>
                           <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Numar camere"></asp:TextBox>
                           </div>
                       </div>

                       <div class="col-md-8">
                           <label>Strada</label>
                           <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Strada"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                <div class="row">
                       <div class="col-md-6">
                           <label>Numar</label>
                           <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Numar"></asp:TextBox>
                            </div>
                       </div>

                       <div class="col-md-6">
                           <label>Oras</label>
                           <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Oras"></asp:TextBox>
                           </div>
                       </div>

                       
                   </div>

                <div class="row">
                   <div class="col">
                        <div class="form-group">
                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button3" runat="server" Text="Actualizare proprietate" OnClick="Button3_Click" />
                        </div>
                   </div>
                </div>

                 </div>

            <%--afisarea proprietatilor postate de catre proprietar--%>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <img width="100" src="imgs/views.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <h3>Proprietatile dumneavoastra</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col" style="text-align: center">
                                <hr />
                            </div>
                        </div>
                        
                        <div class="row">
                                 <div class="col">
                                     <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False">
                                          <Columns>
                                             <asp:BoundField DataField="IDProprietate" HeaderText="IDProprietate" InsertVisible="False" ReadOnly="True" SortExpression="IDProprietate" />
                                             <asp:BoundField DataField="NumeProprietate" HeaderText="NumeProprietate" SortExpression="NumeProprietate" />
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
