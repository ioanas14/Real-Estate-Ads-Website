<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userviewads.aspx.cs" Inherits="ProiectBD.WebForm2" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <font face = "Times New Roman">
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
                            <div class="col-2">
                                <label>Sortare</label>
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Preț crescător" Value="p1"/>
                                    <asp:ListItem Text="Preț descrescător" Value="p2"/>
                                </asp:DropDownList>
                            </div>
                            
                            
                            <div class="col-2">
                                <label>Filtrare pret</label>
                                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="200-300€" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="300+ €" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-2">
                                <label>Vanzare / inchiriere</label>
                                <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Vanzare" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inchiriere" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Sortează" OnClick="Button1_Click"/>
                        </div>

                        <div class="row">
                            <div class="col">
                                  
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" onrowcommand="GridView1_RowCommand" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                         <asp:ButtonField ButtonType="Button" CommandName="Save" Text="Salveaza" ControlStyle-BackColor="#006699" ControlStyle-CssClass="btn-info" />
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

                                       

                                         <asp:BoundField DataField="IDAnunt" SortExpression="id" />

                                       

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
        </font>
</asp:Content>
