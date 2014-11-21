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
                    <div class="col-md-3">
                        <asp:Image ID="ImageTypeChambre" runat="server" ImageUrl='<%# String.Format("~\Images\TypeChambre\Chambre{0}.jpg", Eval("CodeTypeChambre"))%>' Width="200" Height="120" BorderStyle="None" />
                        <br />
                        <p>
                            <h5 style="font-weight: bold;"><%# Eval("NomTypeChambre")%></h5>
                            Prix: <%# Eval("PrixTypeChambre", "{0:c}")%>  / Nuit
                        </p>
                        <div class="btn-group" style="padding-bottom:2%">
                            <asp:DropDownList CssClass="btn btn-default dropdown-toggle" SorteChambre='<%# Eval("CodeTypeChambre")%>' runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="1"></asp:ListItem>
                                <asp:ListItem Text="2"></asp:ListItem>
                                <asp:ListItem Text="3"></asp:ListItem>
                                <asp:ListItem Text="4"></asp:ListItem>
                                <asp:ListItem Text="5"></asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                        
                    </div>
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
                            <div class="col-lg-10 col-lg-offset-2">
                                <button class="btn btn-default">Cancel</button>
                                <button type="submit" class="btn btn-primary">Submit</button>
                            </div>
                        </div>

                    </fieldset>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
