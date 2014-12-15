<%-- **************************************************************************************** 
Créée le : 10 novembre 2014
Par : François Morin
Date de dernière modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Contact.aspx.vb" Inherits="Login.Contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-10">
            <h2>Cliquer sur un hôtel pour voir sa localisation et ses coordonnées</h2>
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-md-8">
            <asp:ListView ID="ListeHotel" runat="server">
                <LayoutTemplate>
                    <div class="list-group">
                        <asp:PlaceHolder ID="itemplaceholder" runat="server"/>
                    </div>               
                </LayoutTemplate>
                <ItemTemplate>
                    <a href="Localisation.aspx?ID=<%# Eval("CodeHotel")%>" class="list-group-item">
                        <span class="badge" style="margin-top: 10px;">&raquo;</span>
                        <h4><%# Eval("NomHotel")%></h4>                        
                    </a>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
