<%@ Page Title="S'inscrire" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.vb" Inherits="Login.Register" %>

<%@ Import Namespace="Login" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Créer un compte.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Messagerie</asp:Label>
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Le champ d’adresse de messagerie est obligatoire." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Mot de passe</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Le champ mot de passe est requis." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmer le mot de passe </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Le champ confirmer le mot de passe est requis." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Le mot de passe et le mot de passe de confirmation ne correspondent pas." />
            </div>
        </div>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNom" CssClass="col-md-2 control-label">Nom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNom" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNom"
                    CssClass="text-danger" ErrorMessage="Le champ de nom est obligatoire." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPrenom" CssClass="col-md-2 control-label">Prenom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPrenom" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrenom"
                    CssClass="text-danger" ErrorMessage="Le champ de prénom est obligatoire." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNoTelephone" CssClass="col-md-2 control-label">Numéro de téléphone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNoTelephone" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNoTelephone"
                    CssClass="text-danger" ErrorMessage="Le champ de numéro de téléphone est obligatoire." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNoCellulaire" CssClass="col-md-2 control-label">Numéro de cellulaire</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNoCellulaire" CssClass="form-control" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAdresse1" CssClass="col-md-2 control-label">Adresse 1</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAdresse1" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAdresse1"
                    CssClass="text-danger" ErrorMessage="Le champ d'adresse est obligatoire." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAdresse2" CssClass="col-md-2 control-label">Adresse 2</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAdresse2" CssClass="form-control" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCodePostal" CssClass="col-md-2 control-label">Code postal</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCodePostal" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodePostal"
                    CssClass="text-danger" ErrorMessage="Le champ de code postal est obligatoire." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNomEntreprise" CssClass="col-md-2 control-label">Nom entreprise</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNomEntreprise" CssClass="form-control" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="S'inscrire" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
