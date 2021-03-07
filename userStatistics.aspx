<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userStatistics.aspx.cs" Inherits="ProiectBD.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <font face = "Times New Roman">
      <div class="card">
         <div class="card-body>
            <div class="row">
            <div class="col">
               <center>
                  <h4>Listă utilizatori</h4>
               </center>
            </div>

         </div>
         <div class="row">
            <div class="col-2">
               <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                  <asp:ListItem Text="" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Utilizatori care sunt proprietari si au un numar minim de proprietat" Value="v1"/>
                  <asp:ListItem Text="Proprietarii cu cele mai multe proprietati postate" Value="v2"/>
                  <asp:ListItem Text="Proprietarii care au o medie de pret >= 500" Value="v3"/>
                  <asp:ListItem Text="Proprietăți salvate de către cel puțin 3 utilizatori" Value="v4"/>
               </asp:DropDownList>

            </div>
             

             <div class="col-2">
               <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                  <asp:ListItem Text="Nr proprietati " Value="0"></asp:ListItem>
                  <asp:ListItem Text="2" Value="2"/>
                  <asp:ListItem Text="5" Value="5"/>
                   <asp:ListItem Text="10" Value="10"/>
               </asp:DropDownList>

            </div>

             <div class="col-2">
                 <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Sortează" OnClick="Button1_Click"/>
             </div>
            
         </div>

         <div class="row">
            <div class="col">
            </div>
         </div>

         <div class="row">
          
            <div class="col">

               <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False">
                  <Columns>
                     <asp:BoundField DataField="IDUtilizator" HeaderText="IDUtilizator" InsertVisible="False" ReadOnly="True" SortExpression="IDUtilizator" Visible="false" />
                     <asp:BoundField DataField="NumeUtilizator" HeaderText="NumeUtilizator" SortExpression="NumeUtilizator" />
                     <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                     <asp:BoundField DataField="Proprietar" HeaderText="Proprietar" SortExpression="Proprietar" />
                     <asp:BoundField DataField="NrProprietati" HeaderText="NrProprietati" SortExpression="NrProprietati" Visible ="false"/>
                     <asp:BoundField DataField="Nume" HeaderText="Nume" SortExpression="Nume" Visible ="false"/>
                     <asp:BoundField DataField="Prenume" HeaderText="Prenume" SortExpression="Prenume" Visible ="false"/>
                     <asp:BoundField DataField="MediePret" HeaderText="MediePret" SortExpression="MediePret" Visible ="false"/>
                     <asp:BoundField DataField="NumeProprietate" HeaderText="MediePret" SortExpression="MediePret" Visible ="false"/>
                     <asp:BoundField DataField="Pret" HeaderText="Pret" SortExpression="Pret" Visible ="false"/>
                     <asp:BoundField DataField="NrSalvari" HeaderText="NrSalvari" SortExpression="NrSalvari" Visible ="false"/>
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