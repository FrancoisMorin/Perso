<%-- **************************************************************************************** 
Créée le : 10 novembre 2014
Par : François Morin
Date de dernière modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Nos Salles" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RechercheSalle.aspx.vb" Inherits="Login.RechercheSalle" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script src="Scripts/lightbox.min.js"></script>
    <link href="Content/lightbox.css" rel="stylesheet" />

    <div class="row">
        <div class="well">
            <h2>Nos salles</h2>
            <p><strong>Consultez nos salles en ligne pour commencer la planification de vos évènements. Contactez nous par téléphone pour effectuer une réservation.</strong></p>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-default">
            <div class="panel-heading">Recherche de salle</div>
            <div class="panel-body">
                <div class="row">

                    <div class="col-md-5">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtHotelRecherche" Text="Entrez un nom d'hôtel" />
                            <div class="col-md-8 input-group">
                                <asp:TextBox runat="server" ID="txtHotelRecherche" CssClass="form-control" Width="80%" Text="" />
                                <span class="input-group-btn" style="float: left;">
                                    <asp:Button runat="server" ID="btnRechercheHotel" Text="Recherche" CssClass="btn btn-success" />
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-5">
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="txtVilleRecherche" Text="Entrez un nom de ville" />
                            <div class="col-md-8 input-group">
                                <asp:TextBox runat="server" ID="txtVilleRecherche" CssClass="form-control" Width="80%" Text="" />
                                <span class="input-group-btn" style="float: left;">
                                    <asp:Button runat="server" ID="btnRechercheVille" Text="Recherche" CssClass="btn btn-success" />
                                </span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-1">
                        <div class="form-group">
                            <asp:Button ID="btnClear" CssClass="btn btn-warning btn-sm" runat="server" Text="Effacer" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:PlaceHolder runat="server" ID="ResultatRecherche" Visible="true">
            <div class="well">
                <asp:ListView ID="ListeHotels" runat="server">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    <ItemTemplate>

                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"><%# Eval("NomHotel")%></h3>
                            </div>
                            <div class="panel-body">
                                <asp:ListView ID="ListeSalle" runat="server" DataSource='<%# Eval("tblSalle")%>'>
                                    <LayoutTemplate>
                                        <div class="panel panel-default">
                                            <div class="panel-body">
                                                <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                                            </div>
                                        </div>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-md-4" style="overflow:hidden;">
                                                <a href="<%# String.Format("Images/Salles/Salle{0}.jpg", Eval("CodeSalle"))%>" data-lightbox="Salle" data-title='<%# Eval("NomSalle")%>'>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# String.Format("~\Images\Salles\Salle{0}.jpg", Eval("CodeSalle"))%>' CssClass="clickimage" Width="300" Height="220" BorderStyle="None" />
                                                </a>
                                            </div>

                                            <div class="col-md-5">
                                                <h3 class="backgradient"><%# Eval("NomSalle") %></h3>
                                                <p><%# Eval("DetailSalle")%></p>
                                                <div class="col-md-8">
                                                    <ul>
                                                        <li><strong>Type de salle : </strong><%# Eval("TypeSalle")%></li>
                                                        <li><strong>Nombre de places assis : </strong><%# Eval("NbPlacesAssis")%></li>
                                                        <li><strong>Nombre de places debout : </strong><%# Eval("NbPlacesDebout")%></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </asp:PlaceHolder>
    </div>

</asp:Content>
