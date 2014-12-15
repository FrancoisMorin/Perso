<%-- **************************************************************************************** 
Créée le : 10 novembre 2014
Par : François Morin
Date de dernière modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Félicitation" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PostReservation.aspx.vb" Inherits="Login.PostReservation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row"style="background-image: url('Images/banner-confetti.png'); background-repeat: repeat-x;">
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <div class="row">
        <h2><asp:Label ID="lblMessage" runat="server" Text="Ayyy"/></h2>
        <p>Nous vous souhaitons un excellent séjour !</p>
        <p>Contactez-nous par téléphone si vous souhaitez apporter des modifications à votre réservation.</p> 
    </div>

</asp:Content>
