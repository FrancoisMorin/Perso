﻿<%@ Page Title="Réservation" Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Reservation.aspx.vb" Inherits="Login.Reservation" %>

<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Réservation</h2>

    <h4>
        <asp:Label ID="TitreNomHotel" runat="server" />
    </h4>

    <asp:PlaceHolder runat="server" ID="MessagePlaceHolder" Visible="false">
        <div class="alert alert-danger">
            <p class="text-danger"><strong><%: MonMessage%></strong></p>
        </div>
    </asp:PlaceHolder>

    <div class="panel panel-default">
        <div class="panel-heading">Choisissez votre/vos type(s) de chambre</div>
        <div class="panel-body">

            <asp:ListView runat="server" ID="ListeTypeChambre">
                <LayoutTemplate>
                    <div class="row">
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                    </div>

                </LayoutTemplate>
                <ItemTemplate>
                    <asp:UpdatePanel ID="MonUpdatePanel" runat="server">
                        <ContentTemplate>
                            <div class="col-md-3">
                                <asp:Image ID="ImageTypeChambre" runat="server" ImageUrl='<%# String.Format("~\Images\TypeChambre\{0}\Chambre{0}.jpg", Eval("CodeTypeChambre"))%>' Width="200" Height="120" BorderStyle="None" />
                                <br />
                                <p>
                                    <h5 style="font-weight: bold;"><%# Eval("NomTypeChambre")%></h5>
                                    <strong>Prix moyen: </strong><%# Eval("PrixTypeChambre", "{0:c}")%>  / Nuit
                                    <br />
                                    <strong>Nombre de chambre(s) :</strong>
                                </p>
                                <div class="btn-group" style="padding-bottom: 2%">
                                    <asp:DropDownList CssClass="btn btn-default dropdown-toggle" SorteChambre='<%# Eval("CodeTypeChambre")%>' runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="false">
                                        <asp:ListItem Text="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="1"></asp:ListItem>
                                        <asp:ListItem Text="2"></asp:ListItem>
                                        <asp:ListItem Text="3"></asp:ListItem>
                                        <asp:ListItem Text="4"></asp:ListItem>
                                        <asp:ListItem Text="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>


    <asp:Panel ID="MonPanelClient" runat="server" Visible="false">
        <asp:PlaceHolder runat="server" ID="MonPlaceHolder" Visible="true">
            <div class="panel panel-default">
                <div class="panel-heading">Coordonnées client</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-7">
                            <div class="alert alert-info">
                                <p><strong>Astuce : </strong>Créez un compte en ligne pour effectuer vos réservations encore plus rapidement !</p>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-9">
                        <fieldset class="form-horizontal">
                            <legend>Informations</legend>
                        </fieldset>
                    </div>

                    <div class="row">
                        <div class="col-md-5">
                            <div class="form-horizontal">
                                <%-- Champ Nom --%>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label5" AssociatedControlID="txtNom" CssClass="col-md-3 control-label">Nom</asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtNom" CssClass="form-control" />
                                    </div>
                                </div>

                                <%--Champ Prenom --%>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label6" AssociatedControlID="txtPrenom" CssClass="col-md-3 control-label">Prénom</asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtPrenom" CssClass="form-control" />
                                    </div>
                                </div>

                                <%-- Champ NoTelephone --%>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label7" AssociatedControlID="txtNoTelephone" CssClass="col-md-3 control-label">Numéro de téléphone</asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtNoTelephone" CssClass="form-control" />
                                    </div>
                                </div>

                                <%-- Champ Email --%>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label8" AssociatedControlID="txtEmail" CssClass="col-md-3 control-label">Email</asp:Label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-5">
                            <div class="form-horizontal">
                                <%-- Champ Adresse --%>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label9" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Adresse</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="txtAdresse" CssClass="form-control" />
                                    </div>
                                </div>

                                <%--ComboBox Pays--%>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="cmbVille" CssClass="col-md-2 control-label">Pays</asp:Label>
                                    <div class="col-md-3">
                                        <asp:DropDownList runat="server" ID="cmbPays" OnSelectedIndexChanged="cmbPays_SelectedIndexChanged" AutoPostBack="true" CssClass="btn btn-default dropdown-toggle" />
                                    </div>
                                </div>

                                <%--ComboBox Province--%>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="cmbProvince" CssClass="col-md-2 control-label">Province</asp:Label>
                                    <div class="col-md-3">
                                        <asp:DropDownList runat="server" ID="cmbProvince" OnSelectedIndexChanged="cmbProvince_SelectedIndexChanged" AutoPostBack="true" CssClass="btn btn-default dropdown-toggle" />
                                    </div>
                                </div>

                                <%--ComboBox Ville--%>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="cmbVille" CssClass="col-md-2 control-label">Ville</asp:Label>
                                    <div class="col-md-3">
                                        <asp:DropDownList runat="server" ID="cmbVille" OnSelectedIndexChanged="cmbVille_SelectedIndexChanged" AutoPostBack="true" CssClass="btn btn-default dropdown-toggle" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
    </asp:Panel>

    <div class="panel panel-default">
        <div class="panel-heading">Détails du séjour</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="btn-group btn-group-justified">
                                        <asp:TextBox Enabled="false" ID="txtDateDebut" runat="server" CssClass="form-control" Text="Sélectionnez une date de début..." />
                                        <asp:Button ID="btnExpandCalendarDebut" CssClass="btn btn-success" runat="server" Text="+" Width="30px" />
                                    </span>
                                </div>

                                <asp:Calendar ID="CalendrierDebut" runat="server" DayNameFormat="FirstLetter" Font-Names="Arial" Font-Size="11px" NextMonthText="»" PrevMonthText="«" SelectionMode="Day" CssClass="myCalendar" BorderStyle="None" CellPadding="1" Visible="False">
                                    <OtherMonthDayStyle ForeColor="Gray" />
                                    <DayStyle CssClass="myCalendarDay" />
                                    <SelectedDayStyle Font-Bold="True" Font-Size="12px" BackColor="#75baf7" />
                                    <SelectorStyle CssClass="myCalendarSelector" />
                                    <NextPrevStyle CssClass="myCalendarNextPrev" />
                                    <TitleStyle CssClass="myCalendarTitle" />
                                </asp:Calendar>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-4">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="btn-group btn-group-justified">
                                        <asp:TextBox Enabled="false" ID="txtDateFin" runat="server" CssClass="form-control" Text="Sélectionnez une date de fin..." />
                                        <asp:Button ID="btnExpandCalendarFin" Enabled="false" CssClass="btn btn-success disabled" runat="server" Text="+" Width="30px" />
                                    </span>
                                </div>

                                <asp:Calendar ID="CalendrierFin" runat="server" DayNameFormat="FirstLetter" Font-Names="Arial" Font-Size="11px" NextMonthText="»" PrevMonthText="«" SelectionMode="Day" CssClass="myCalendar" BorderStyle="None" CellPadding="1" Visible="False">
                                    <OtherMonthDayStyle ForeColor="Gray" />
                                    <DayStyle CssClass="myCalendarDay" />
                                    <SelectedDayStyle Font-Bold="True" Font-Size="12px" BackColor="#75baf7" />
                                    <SelectorStyle CssClass="myCalendarSelector" />
                                    <NextPrevStyle CssClass="myCalendarNextPrev" />
                                    <TitleStyle CssClass="myCalendarTitle" />
                                </asp:Calendar>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <section id="info">
                <div class="row">
                    <div class="col-md-4">
                        <fieldset class="form-horizontal">
                            <legend>Informations de carte de crédit</legend>

                            <div class="form-group">
                                <asp:Label runat="server" ID="Label1" AssociatedControlID="cmbTypeCarte" CssClass="col-md-4">Type de carte</asp:Label>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="cmbTypeCarte" runat="server" CssClass="btn btn-default dropdown-toggle">
                                        <asp:ListItem Text="Visa" />
                                        <asp:ListItem Text="MasterCard" />
                                        <asp:ListItem Text="American Express" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="Label2" AssociatedControlID="cmbTypeCarte" CssClass="control-label">Numéro carte de crédit</asp:Label>
                                    <asp:TextBox runat="server" ID="txtNoCarteCredit" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="Label3" AssociatedControlID="cmbTypeCarte" CssClass="control-label">Date d'expiration (mm/aa)</asp:Label>
                                    <asp:TextBox runat="server" ID="txtDateExpiration" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="Label4" AssociatedControlID="txtNomDetenteurCarte" CssClass="control-label">Nom détenteur</asp:Label>
                                    <asp:TextBox runat="server" ID="txtNomDetenteurCarte" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-10">
                                    <asp:Button ID="btnCalculer" runat="server" Text="Soumettre" CssClass="btn btn-primary" />
                                </div>
                            </div>

                        </fieldset>
                    </div>

                    <asp:PlaceHolder ID="DetailReservation" runat="server" Visible="false">
                        <div class="col-md-8">
                            <div class="alert alert-info form-horizontal">
                                <fieldset>
                                    <legend>Détails de la réservation</legend>
                                </fieldset>
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" ID="MonLabel1" CssClass="control-label"><strong>Date d'arrivé : </strong>
                                            <asp:Label ID="lblDateDebut" runat="server" CssClass="control-label" /></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" ID="MonLabel2" CssClass="control-label"><strong>Date de départ : </strong>
                                            <asp:Label runat="server" ID="lblDateFin" CssClass="control-label" /></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" ID="MonLabel3" CssClass="control-label"><strong>Réservation au nom de : </strong>
                                            <asp:Label runat="server" ID="lblNomReserv" CssClass="control-label" /></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" ID="MonLabel4" CssClass="control-label"><strong>Prix total : </strong>
                                            <asp:Label runat="server" ID="lblPrixTotal" CssClass="control-label" /></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" ID="MonLabel5" CssClass="control-label"><strong>Type carte : </strong>
                                            <asp:Label runat="server" ID="lblTypeCarte" CssClass="control-label" /></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" ID="MonLabel6" CssClass="control-label"><strong>Numéro carte de crédit : </strong>
                                            <asp:Label runat="server" ID="lblNoCarte" CssClass="control-label" /></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-10">
                                        <p>
                                            <strong>Un email vous sera envoyé avec toutes les informations de votre réservation.</strong>
                                        </p>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Button ID="btnAnnuler" runat="server" OnClick="btnAnnuler_Click" Text="Annuler" CssClass="btn btn-default monbtnspecial" />
                                        <asp:Button ID="btnConfirmer" runat="server" OnClick="btnConfirmer_Click" Text="Confirmer" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
