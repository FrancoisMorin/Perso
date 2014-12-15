<%-- **************************************************************************************** 
Créée le : 10 novembre 2014
Par : François Morin
Date de dernière modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Forfaits" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Forfait.aspx.vb" Inherits="Login.Forfait" %>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="UpperSlider">
    <div class="row">
        <div class="col-md-8">
            <h2>Nos forfaits</h2>
            <p>Naviguez parmis nos forfaits pour connaitre nos offres.</p>
        </div>
        <hr />
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="slidercontent" runat="server">
    <script src="//code.jquery.com/jquery-latest.min.js"></script>
    <script src="Scripts/unslider.js"></script>

    <script>
        $(function () {
            if (window.chrome) {
                $('.banner li').css('background-size', '100% 100%');
            }
            $('.banner').unslider({

                speed: 500,
                delay: 5000,
                complete: function () { },
                keys: true,
                dots: true,
                fluid: true
            });
        });
    </script>

    <div class="container body-content">
        <div class="row">
            <div class="banner">
                <ul>
                    <asp:ListView ID="ListeForfait" runat="server">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li style="background-image: url('<%# String.Format("Images/SliderForfait/Forfait{0}.jpg", Eval("CodeForfait"))%>');">
                                <div class="backgrounddivh1" style="padding-bottom: 1%;">
                                    <div class="row">
                                        <div class="row">
                                            <h1><%# Eval("NomForfait")%></h1>
                                        </div>
                                        <div class="row">
                                            <a href="Forfait.aspx?ID=<%# Eval("CodeForfait") %>" class="btn">Détails &raquo;</a>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                </ul>
            </div>
        </div>
    </div>
    <br />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:PlaceHolder runat="server" ID="InformationForfait" Visible="false">
        <div class="well">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <asp:Label ID="LabelTitre" runat="server" Text="NomForfait" /></h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <fieldset><legend>Informations</legend></fieldset>
                            <div class="col-md-6">
                                <ul>
                                    <li><strong>Type de chambre : </strong>
                                        <asp:Label ID="LabelTypeChambre" runat="server" Text="TypeChambre" /></li>
                                    <li><strong>Nombre de nuit(s) : </strong>
                                        <asp:Label ID="LabelNbNuit" runat="server" Text="NbNuit" /></li>
                                    <li><strong>Prix : </strong>
                                        <asp:Label ID="LabelPrixForfait" runat="server" Text="PrixForfait" /></li>
                                </ul>
                            </div>
                            <div class="col-md-4">
                                <ul>
                                    <li><strong>Disponibilité de l'offre  </strong></li>
                                    <li><strong>Du : </strong>
                                        <asp:Label ID="LabelDateDebut" runat="server" Text="DateDebut" /></li>
                                    <li><strong>Au : </strong>
                                        <asp:Label ID="LabelDateFin" runat="server" Text="DateFin" /></li>
                                </ul>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <fieldset><legend>Description</legend></fieldset>
                            <div class="col-md-8">
                                <asp:Label ID="LabelDescription" runat="server" Font-Bold="true" Text="DescForfait" />
                            </div>

                            <div class="col-md-4">
                                <a runat="server" id="btnReserver" href="#" style="padding-left: 2%;" class="btn btn-success">Réserver &raquo;</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>



    <asp:PlaceHolder runat="server" ID="AucunForfait" Visible="true">
        <div class="alert alert-info">
            <p>Choissisez un forfait pour afficher les informations</p>
        </div>
    </asp:PlaceHolder>

</asp:Content>
