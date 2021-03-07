<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="owneraddproperty.aspx.cs" Inherits="ProiectBD.owneraddproperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Adaugare proprietate</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/addproperty.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                       
                  <div class="row">
                     <div class="col-md-8">
                        <label>Nume proprietate</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pret</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Strada</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Numarul</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>

                   <div class="row">
                       <div class="col-md-6">
                           <label>Orasul</label>
                           <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Oras" runat="server"></asp:TextBox>
                        </div>
                       </div>

                       <div class="col-md-6">
                           <label>Judetul</label>
                           <div class="form-group">
                              <asp:DropDownList class="form-control" ID="Judet" runat="server">
                               <asp:ListItem Text="Alba" Value="Alba"/>
                               <asp:ListItem Text="Arad" Value="Arad"/>
                               <asp:ListItem Text="Arges" Value="Arges" />
                               <asp:ListItem Text="Bacau" Value="Bacau" />
                               <asp:ListItem Text="Bihor" Value="Bihor" />
                               <asp:ListItem Text="Bistrita-Nasaud" Value="BN" />
                               <asp:ListItem Text="Botosani" Value="BT" />
                               <asp:ListItem Text="Brasov" Value="Brasov" />
                               <asp:ListItem Text="Braila" Value="Braila" />
                               <asp:ListItem Text="Bucuresti" Value="Bucuresti" />
                               <asp:ListItem Text="Buzau" Value="Buzau" />
                               <asp:ListItem Text="Caras-Severin" Value="Caras-Severin" />
                               <asp:ListItem Text="Calarasi" Value="Calarasi" />
                               <asp:ListItem Text="Cluj" Value="Cluj" />
                               <asp:ListItem Text="Constanta" Value="Constanta" />
                               <asp:ListItem Text="Covasna" Value="Covasna" />
                               <asp:ListItem Text="Dambovita" Value="Dambovita" />
                               <asp:ListItem Text="Dolj" Value="Dolj" />
                               <asp:ListItem Text="Galati" Value="Galati" />
                               <asp:ListItem Text="Giurgiu" Value="Giurgiu" />
                               <asp:ListItem Text="Gorj" Value="Gorj" />
                               <asp:ListItem Text="Harghita" Value="Harghita" />
                               <asp:ListItem Text="Hunedoara" Value="Hunedoara" />
                               <asp:ListItem Text="Ialomita" Value="Ialomita" />
                               <asp:ListItem Text="Iasi" Value="Iasi" />
                               <asp:ListItem Text="Ilfov" Value="Ilfov" />
                               <asp:ListItem Text="Maramures" Value="Maramures" />
                               <asp:ListItem Text="Mehedinti" Value="Mehedinti" />
                               <asp:ListItem Text="Mures" Value="Mures" />
                               <asp:ListItem Text="Neamt" Value="Neamt" />
                               <asp:ListItem Text="Olt" Value="Olt" />
                               <asp:ListItem Text="Prahova" Value="Prahova" />
                               <asp:ListItem Text="Satu Mare" Value="SM" />
                               <asp:ListItem Text="Salaj" Value="Salaj" />
                               <asp:ListItem Text="Sibiu" Value="Sibiu" />
                               <asp:ListItem Text="Suceava" Value="Suceava" />
                               <asp:ListItem Text="Teleorman" Value="Teleorman" />
                               <asp:ListItem Text="Timis" Value="Timis" />
                               <asp:ListItem Text="Tulcea" Value="Tulcea" />
                               <asp:ListItem Text="Vaslui" Value="Vaslui" />
                               <asp:ListItem Text="Valcea" Value="Valcea" />
                               <asp:ListItem Text="Vrancea" Value="Vrancea" />
                            </asp:DropDownList>
                           </div>
                       </div>

                   </div>
                  <div class="row">
                     <div class="col-5">
                        <label>Numar Camere</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="nrcamere" runat="server" TextMode="Number" Rows="2"></asp:TextBox>
                        </div>
                     </div>

                      <div class="col-7">
                        <label>Categorie proprietate</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                               <asp:ListItem Text="Casa" Value="Casa"/>
                               <asp:ListItem Text="Garsoniera" Value="Garsoniera"/>
                               <asp:ListItem Text="Apartament 2 camere" Value="ap2" />
                               <asp:ListItem Text="Apartament 3 camere" Value="ap3" />
                               <asp:ListItem Text="Apartament 4 camere" Value="ap4" />                              
                            </asp:DropDownList>
                        </div>
                     </div>
                  </div>
                   <center>
                   <div class="row">
                       <h5>Doriti sa vindeti sau sa inchiriati proprietatea?</h5>
                       <div class="form-group">
                           <asp:RadioButtonList ID="list" runat="server" RepeatDirection="Horizontal"  TextAlign="Right" Style="list-style=center" align="center">
                               <asp:ListItem Text="Vanzare" Value="v" Selected="False"></asp:ListItem>
                               <asp:ListItem Text="Inchiriere" Value="i" Selected="False"></asp:ListItem>
                           </asp:RadioButtonList>
                       </div>
                   </div>
                    </center>
                  <div class="row">
                     <div class="col-6">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Adaugare" OnClick="Button1_Click" />
                     </div>                                          
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
       
      </div>
   </div>
</asp:Content>

