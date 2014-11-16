<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RechercheChambre.aspx.vb" Inherits="Login.RechercheChambre" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Recherche</h2>

    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server" AssociatedControlID="calDebut" CssClass="col-md-2 control-label">Date début</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="calDebut" runat="server" SelectionMode="Day"/>
            </div>
        </div>

        <div class="col-md-4">
            <asp:Label runat="server" AssociatedControlID="calFin" CssClass="col-md-2 control-label">Date fin</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="calFin" runat="server" SelectionMode="Day"/>
            </div>
        </div>
    </div>

    <br />

    <section id="result">
        <div class="form-horizontal" style="width: 60%">

            <div class="form-group">

                <asp:Label runat="server" AssociatedControlID="cmbHotel" CssClass="col-md-2 control-label">Choisissez un hôtel</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="cmbHotel" runat="server" DataSourceID="HotelEDS" DataTextField="NomHotel" AutoPostBack="true" CssClass="form-control">
                        <asp:ListItem>Tous</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button ID="btnRecherche" runat="server" OnClick="ClickStuff" Text="Recherche" CssClass="btn btn-default" />
                </div>

            </div>
            
            <asp:PlaceHolder runat="server" ID="ProgressBar" Visible="false">
                <div class="progress progress-striped active">
                    <div id="MaProgressBar" class="progress-bar" style="width: 100%;"></div>
                </div>
            </asp:PlaceHolder>

        </div>

        <hr />

        <asp:PlaceHolder runat="server" ID="ResultatRecherche" Visible="false">
            <asp:ListView ID="ListeHotel" runat="server">
                <LayoutTemplate>
                    <div class="well">
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </div>
                </LayoutTemplate>
                <ItemTemplate>

                    <div class="panel panel-primary">
                        <div class="pannel-heading">
                            <h3 class="panel-title">Ayy lmao</h3>
                        </div>
                        <div class="panel-body">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# String.Format("~\Images\PhotoHotel\Hotel{0}.jpg", Eval("CodeHotel"))%>' Width="200" Height="120" BorderStyle="None" />
                            <br />
                            <p>
                                Nombre chambre : <%# Eval("NbChambre")%> <br />
                                Nombre étoiles : <%# Eval("NbEtoiles")%> <br />
                                Type Service : <%# Eval("TypeService")%> <br />
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </asp:PlaceHolder>

        <asp:EntityDataSource ID="HotelEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblHotel" Select="it.[NomHotel], it.[CodeHotel]" />

        <asp:EntityDataSource ID="ChambreEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblHotel" Select="it.[NomHotel], it.[CodeHotel]" />

    </section>
    
</asp:Content>
