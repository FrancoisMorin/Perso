<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PageSecondaire.aspx.vb" Inherits="AppliTutoASPNET.PageSecondaire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        Choisissez un type chambre:<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="TypeChambreEDS" DataTextField="CodeTypeChambre" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        Chambres:<br />
        <asp:ListView runat="server" DataSourceID="ChambresEDS">
            <LayoutTemplate>
                <table>
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </tr>
                </table>
            </LayoutTemplate>

                <ItemTemplate>
                    <tb>
                        <h2><a href="/PageTrois.aspx?id=<%# Eval("NoSeqChambre")%>"> <%# Eval("NoSeqChambre")%> </a></h2>
                                <asp:Image  ID="Image1" runat="server" ImageUrl='<%# String.Format("~\Images\Chambre{0}.jpg", Eval("CodeTypeChambre"))%>' Width="75" Height="75" BorderStyle="None" />
                                <p>
                                    <%# Eval("DescChambre")%><br />
                                    <%# Eval("TypeLit")%>
                                </p>
                    </tb>    

                </ItemTemplate>

            </asp:ListView>
    
        <asp:EntityDataSource ID="TypeChambreEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblTypeChambre" Select="it.[CodeTypeChambre]" />

        <asp:EntityDataSource ID="ChambresEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblChambre" Where="it.[CodeTypeChambre] == @CodeTypeChambre AND it.[CodeHotel] == 'NGN'" Select="it.[NoSeqChambre], it.[DescChambre], it.[TypeLit], it.[CodeTypeChambre]">
            <WhereParameters>
                <asp:ControlParameter Name="CodeTypeChambre" ControlID="DropDownList1" Type="String" DefaultValue="NULL" />
            </WhereParameters>
        </asp:EntityDataSource>
    </div>

</asp:Content>

