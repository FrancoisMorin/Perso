<%@ Page Title="S'inscrire" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.vb" Inherits="AppliTutoASPNET.Register" %>

<%@ Import Namespace="AppliTutoASPNET" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal2">
        <h4>Créer un compte.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <%--Champ Email--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">E-mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="Le champ d’adresse de messagerie est obligatoire." />
            </div>
        </div>

        <%--Champ Prenom--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPrenom" CssClass="col-md-2 control-label">Prénom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPrenom" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrenom"
                    CssClass="text-danger" ErrorMessage="Le champ de prénom est obligatoire." />
            </div>
        </div>

        <%--Champ Nom--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNom" CssClass="col-md-2 control-label">Nom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNom" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNom"
                    CssClass="text-danger" ErrorMessage="Le champ de nom est obligatoire." />
            </div>
        </div>

        <%--Champ numéro telephone--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNoTelephone" CssClass="col-md-2 control-label">Numéro de téléphone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNoTelephone" CssClass="form-control" TextMode="Phone"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNoTelephone"
                    CssClass="text-danger" ErrorMessage="Le numéro de téléphone est obligatoire." />
            </div>
        </div>

        <%--Champ numéro de cellulaire--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNoCellulaire" CssClass="col-md-2 control-label">Numéro de céllulaire</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNoCellulaire" CssClass="form-control" TextMode="Phone"/>
                <br />
            </div>
        </div>

        <%--Champ Adresse 1--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAdresse1" CssClass="col-md-2 control-label">Adresse 1</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAdresse1" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAdresse1"
                    CssClass="text-danger" ErrorMessage="Le champ d’adresse est obligatoire." />
            </div>
        </div>

        <%--Champ Adresse 2--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAdresse2" CssClass="col-md-2 control-label">Adresse 2</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAdresse2" CssClass="form-control"/>
                <br />
            </div>
        </div>

        <%--ComboBox Pays--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cmbPays" CssClass="col-md-2 control-label">Pays</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="cmbPays" AutoPostBack="true" CssClass="form-control"/>
                <br />
            </div>
        </div>

        <%--ComboBox Province--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cmbProvince" CssClass="col-md-2 control-label">Province</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="cmbProvince" AutoPostBack="true" CssClass="form-control"/>
                <br />
            </div>
        </div>

        <%--ComboBox Ville--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cmbVille" CssClass="col-md-2 control-label">Ville</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="cmbVille" AutoPostBack="true" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cmbVille"
                    CssClass="text-danger" ErrorMessage="Vous devez choisir une ville." />
                <br />
            </div>
        </div>

        <%--Champ code postal--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCodePostal" CssClass="col-md-2 control-label">Code postal</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCodePostal" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodePostal"
                    CssClass="text-danger" ErrorMessage="Le champ de code postal est obligatoire." />
            </div>
        </div>

        <%--Champ nom entreprise--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEntreprise" CssClass="col-md-2 control-label">Nom entreprise</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEntreprise" CssClass="form-control" />
                <br />
            </div>
        </div>

        <%--Champ Mot de passe--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Mot de passe</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Le champ mot de passe est requis." />
            </div>
        </div>

        <%--Champ validation mot de passe--%>
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

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="S'inscrire" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
