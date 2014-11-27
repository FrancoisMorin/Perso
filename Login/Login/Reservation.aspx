<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Reservation.aspx.vb" Inherits="Login.Reservation" %>

<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Réservation</h2>

    <h4>
        <asp:Label ID="TitreNomHotel" runat="server" />
    </h4>

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
                                <asp:Image ID="ImageTypeChambre" runat="server" ImageUrl='<%# String.Format("~\Images\TypeChambre\Chambre{0}.jpg", Eval("CodeTypeChambre"))%>' Width="200" Height="120" BorderStyle="None" />
                                <br />
                                <p>
                                    <h5 style="font-weight: bold;"><%# Eval("NomTypeChambre")%></h5>
                                    Prix: <%# Eval("PrixTypeChambre", "{0:c}")%>  / Nuit
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
                            <legend>Informations</legend>
                            <p>Vous êtes connecté en tant que <strong><%: User.Identity.GetUserName() %></strong>.</p>
                            <hr />
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
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNoCarteCredit"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Le champ de numéro de carte de crédit est obligatoire." />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="Label3" AssociatedControlID="cmbTypeCarte" CssClass="control-label">Date d'expiration (mm/aa)</asp:Label>
                                    <asp:TextBox runat="server" ID="txtDateExpiration" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDateExpiration"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Le champ de date d'expiration est obligatoire." />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="Label4" AssociatedControlID="txtNomDetenteurCarte" CssClass="control-label">Nom détenteur</asp:Label>
                                    <asp:TextBox runat="server" ID="txtNomDetenteurCarte" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNomDetenteurCarte"
                                        CssClass="text-danger" Display="dynamic" ErrorMessage="Le champ du nom du dédententeur est obligatoire." />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-10">
                                    <asp:Button ID="btnCalculer" runat="server" Text="Calculer" CssClass="btn btn-primary" />
                                </div>
                            </div>

                        </fieldset>
                    </div>

                    <asp:PlaceHolder ID="DetailReservation" runat="server" Visible="false">
                        <div class="col-md-8">

                            <div class="alert alert-info">

                                <fieldset class="form-horizontal">
                                    <legend>Détails de la réservation</legend>

                                    <div class="form-group">
                                        <div class="col-md-4">
                                            <asp:Label runat="server" ID="Label5" CssClass="control-label"><strong>Date debut :</strong> 25 novembre 2014</asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-4">
                                            <asp:Label runat="server" ID="Label6" CssClass="control-label"><strong>Date fin :</strong> 28 novembre 2014</asp:Label>
                                        </div>

                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-4">
                                            <asp:Label runat="server" ID="Label7" CssClass="control-label"><strong>Prix :</strong> 500.00$</asp:Label>
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
                                        <div class="col-lg-8">
                                            <asp:Label runat="server" ID="Label8" AssociatedControlID="btnConfirmer" CssClass="control-label"><strong>Voulez-vous confirmer cette réservation ?</strong></asp:Label>
                                            <asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" CssClass="form-control btn btn-primary" Width="50%" />
                                        </div>

                                    </div>
                                </fieldset>

                            </div>


                        </div>
                    </asp:PlaceHolder>

                </div>
            </section>


        </div>
    </div>
</asp:Content>
