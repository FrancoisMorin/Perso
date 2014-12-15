<%-- **************************************************************************************** 
Créée le : 10 novembre 2014
Par : François Morin
Date de dernière modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="Login.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h1>À propos de Nouvhôtel</h1>
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>Nouvhôtel : l’histoire d’une réussite dans l’industrie canadienne de la gestion hôtelière</h2>
        </div>
        
        <br />

        <div class="col-md-5">
            <asp:Image ID="Image3" runat="server" ImageUrl="~\Images\About\HotelAbout.jpg" Width="425" Height="235" BorderStyle="None" />
        </div>

        <div class="col-md-7">
            <blockquote class="pull-left">
                Lors de sa fondation à Richmond, en Colombie-Britannique, en 1962, Nouvhôtel ne comptait à son actif qu’un seul hôtel-motel de 62 chambres. Aujourd’hui, c’est la plus importante société de gestion d’hôtels de première classe au Canada.
                Notre entreprise se targue maintenant d’un portefeuille de plus de 40 hôtels urbains, aéroportuaires et de villégiature et est considérée comme étant la marque de choix par les propriétaires et clients avertis, un employeur exemplaire pour plus de 6 000 personnes et 
                une société vivement consciente de ses responsabilités sociales, d'un océan à l'autre.
            </blockquote>
        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <h2>Une tradition de leadership et de vision</h2>
        </div>
        
        <br />

        <div class="col-md-7">
            <blockquote class="pull-left">
                Le leadership et la vision sont des traits qui marquent l’histoire de la société. Après être devenue la principale entreprise hôtelière de la Colombie-Britannique en 1970, Nouvhôtel a entrepris un ambitieux projet d’expansion vers l’est du pays.
                En 1975, elle a inauguré le Nouvhôtel Chelsea au centre-ville de Toronto. Comptant 1 590 chambres, cet hôtel est non seulement le plus vaste de Nouvhôtel, mais aussi de l’ensemble du Canada. Delta a ajouté des hôtels à son portefeuille pendant les années 80, notamment au Canada
                Atlantique et au Québec. Malgré un changement de main en 1987, le rythme rapide des projets d’expansion et de revitalisation s’est maintenu tout au long des années 90.
            </blockquote>
        </div>

        <div class="col-md-5">
            <asp:Image ID="Image2" runat="server" ImageUrl="~\Images\About\HotelFire.jpg" Width="425" Height="235" BorderStyle="None" />
        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <h2>Au-delà des salaires et des avantages sociaux</h2>
        </div>
        
        <br />

        <div class="col-md-5">
            <asp:Image ID="Image1" runat="server" ImageUrl="~\Images\About\HotelPerson.jpg" Width="425" Height="235" BorderStyle="None" />
        </div>

        <div class="col-md-7">
            <blockquote class="pull-left">
                Reconnue pour les garanties progressives qu’elle fait à ses employés, Nouvhôtel continue d’afficher l’un des taux de roulement les plus faibles de l’industrie hôtelière. Nous offrons également un programme d’assistance aux employés et
                aux familles, ainsi que d’innombrables possibilités de carrière. Le prestigieux Institut national de la qualité (INQ) a aussi conféré deux Prix Canada pour l’excellence à Nouvhôtel, soit l’un dans la catégorie Qualité (2000) et l’autre dans la catégorie Milieu
                de travail sain (2004). C’était la première fois de l’histoire de l’INQ qu’une entreprise hôtelière méritait ces honneurs. Comparable au Malcolm Baldridge National Quality Award des États-Unis, le prix de l’INQ est le plus important à être remis aux organismes 
                canadiens qui excellent dans les domaines du leadership, du rendement, de la planification et des activités axées sur les clients, les employés et les fournisseurs.
            </blockquote>
        </div>
    </div>

</asp:Content>
