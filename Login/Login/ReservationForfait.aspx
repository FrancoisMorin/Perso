<%-- **************************************************************************************** 
Créée le : 10 novembre 2014
Par : François Morin
Date de dernière modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Réservation forfait" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReservationForfait.aspx.vb" Inherits="Login.ReservationForfait" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Réservation avec forfait</h2>
    <asp:PlaceHolder runat="server" ID="MessagePlaceHolder" Visible="false">
        <div class="alert alert-danger">
            <p><strong><%: MonMessage%></strong></p>
        </div>
    </asp:PlaceHolder>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Confirmer la réservation</h4>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <asp:Label runat="server" ID="MonLabel1" CssClass="control-label"><strong>Date d'arrivé : </strong>
                            <asp:Label ID="lblDateDebut" runat="server" CssClass="control-label" /></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" ID="MonLabel2" CssClass="control-label"><strong>Date de départ : </strong>
                            <asp:Label runat="server" ID="lblDateFin" CssClass="control-label" /></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" ID="MonLabel3" CssClass="control-label"><strong>Réservation au nom de : </strong>
                            <asp:Label runat="server" ID="lblNomReserv" CssClass="control-label" /></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" ID="MonLabel4" CssClass="control-label"><strong>Prix total : </strong>
                            <asp:Label runat="server" ID="lblPrixTotal" CssClass="control-label" /></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" ID="MonLabel5" CssClass="control-label"><strong>Type carte : </strong>
                            <asp:Label runat="server" ID="lblTypeCarte" CssClass="control-label" /></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" ID="MonLabel6" CssClass="control-label"><strong>Numéro carte de crédit : </strong>
                            <asp:Label runat="server" ID="lblNoCarte" CssClass="control-label" /></asp:Label>
                    </div>

                    <div class="form-group">
                        <p>
                            <strong>Un email vous sera envoyé avec toutes les informations de votre réservation.</strong>
                        </p>
                    </div>

                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="Annuler" CssClass="btn btn-default monbtnspecial" />
                        <asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" OnClick="Confirm" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">Détails forfait</div>
                <div class="panel-body">

                    <h3><asp:Label ID="LabelNomForfait" runat="server" Text="NomForfait" /></h3>

                    <div class="row">
                        <div class="col-md-7">
                            <asp:Image ID="ImageForfait" runat="server" Width="99%" Height="99%" />
                        </div>

                        <div class="col-md-4">
                            <fieldset><legend>Informations</legend></fieldset>
                            <div class="col-md-8">
                                <ul>
                                    <li><strong>Type de chambre : </strong>
                                        <asp:Label ID="LabelTypeChambre" runat="server" Text="TypeChambre" /></li>
                                    <li><strong>Prix forfait : </strong>
                                        <asp:Label ID="LabelPrixForfait" runat="server" Text="PrixForfait" /></li>
                                    <li><strong>Nombre de nuit(s) : </strong>
                                        <asp:Label ID="LabelNbNuit" runat="server" Text="NbNuit" /></li>
                                    <li>
                                        <asp:Label ID="LabelDescription" runat="server" CssClass="control-label" /></li>
                                </ul>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="MonPanelClient" runat="server" Visible="false">
        <asp:PlaceHolder runat="server" ID="MonPlaceHolder" Visible="true">
            <div class="panel panel-default">
                <div class="panel-heading">Coordonnées client</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-8">
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

    <asp:PlaceHolder ID="InforReserv" runat="server" Visible="true">
        <div class="panel panel-default">
            <div class="panel-heading">Détails du séjour</div>
            <div class="panel-body">
                <div class="well well-sm">
                    <fieldset><legend>Informations</legend></fieldset>
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
                        <div class="col-md-3" style="padding-left: 5px;">
                            <asp:DropDownList ID="cmbHotel" runat="server" CssClass="btn btn-default dropdown-toggle" />
                        </div>
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
                                        <asp:Label runat="server" ID="Label3" AssociatedControlID="cmbTypeCarte" CssClass="control-label">Date d'expiration (MMAA)</asp:Label>
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
                                        <asp:Button ID="btnCalculer" runat="server" OnClick="btnCalculer_Click" Text="Soumettre" CssClass="btn btn-primary"/>
                                    </div>
                                </div>

                            </fieldset>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </asp:PlaceHolder>

</asp:Content>
