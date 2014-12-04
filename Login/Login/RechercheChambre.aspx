﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RechercheChambre.aspx.vb" Inherits="Login.RechercheChambre" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Rechercher un hôtel</h2>
    <br />

    <div class="panel panel-default">
        <div class="panel-heading">Informations du séjour</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-md-10 input-group">
                                    <asp:TextBox Enabled="false" ID="txtDateDebut" runat="server" CssClass="form-control" Width="99%" Text="Sélectionnez une date de début..." />
                                    <span class="input-group-btn" style="float: left;">
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
                                <div class="col-md-10 input-group">
                                    <asp:TextBox Enabled="false" ID="txtDateFin" runat="server" CssClass="form-control" Width="99%" Text="Sélectionnez une date de fin..." />
                                    <span class="input-group-btn" style="float: left;">
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

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtVilleRecherche" Text="Entrez un nom de ville"/>
                        <asp:TextBox runat="server" ID="txtVilleRecherche" CssClass="form-control" Text=""/>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnClear" OnClick="Clear" Text="Effacer" CssClass="btn btn-sm btn-warning" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Button ID="btnRecherche" runat="server" OnClick="RechercheHotel" Text="Filtrer" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <section id="result">
        <asp:PlaceHolder runat="server" ID="ResultatRecherche" Visible="true">
            <asp:ListView ID="ListeHotel" runat="server">
                <LayoutTemplate>
                    <div class="list-group">
                        <div class="well">
                            <a href="#" class="list-group-item active">Résultats de la recherche</a>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <a href="Reservation.aspx?ID=<%# Eval("CodeHotel") %>" class="list-group-item">
                        <span class="badge" style="margin-top: 25px;">Réserver dans cet hôtel</span>
                        <h3 class="list-group=item-heading"><%# Eval("NomHotel")%></h3>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# String.Format("~\Images\PhotoHotel\Hotel{0}.jpg", Eval("CodeHotel"))%>' Width="200" Height="120" BorderStyle="None" />
                        <br />
                        <p>
                            <strong>Nombre chambre : </strong><%# Eval("NbChambre")%>
                            <br />
                            <strong>Nombre étoiles : </strong><%# Eval("NbEtoiles")%>
                            <br />
                            <strong>Type Service : </strong><%# Eval("TypeService")%>
                            <br />
                        </p>
                    </a>
                </ItemTemplate>
            </asp:ListView>
        </asp:PlaceHolder>

        <asp:EntityDataSource ID="HotelEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblHotel" Select="it.[NomHotel], it.[CodeHotel]" />

        <asp:EntityDataSource ID="ChambreEDS" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="false" EntitySetName="tblHotel" Select="it.[NomHotel], it.[CodeHotel]" />

    </section>

</asp:Content>
