﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RechercheChambre.aspx.vb" Inherits="Login.RechercheChambre" %>

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
    </div>

    <asp:PlaceHolder runat="server" ID="ResultatRecherche" Visible="false">
        <asp:ListView ID="ListeChambres" runat="server" DataSourceID="HotelEDS">
            <LayoutTemplate>
                <div class="list-group">
                    <hr />
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    <hr />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <h2><%# Eval("NomHotel")%></h2>
            </ItemTemplate>
        </asp:ListView>
    </asp:PlaceHolder>


 
    <asp:EntityDataSource ID="HotelEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblHotel" Select="it.[NomHotel], it.[CodeHotel]" /> 

    <asp:EntityDataSource ID="ChambreEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblHotel" Select="it.[NomHotel], it.[CodeHotel]" /> 

</asp:Content>
