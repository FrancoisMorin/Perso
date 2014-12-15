' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports System
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin

Partial Public Class Register
    Inherits Page
    Dim MaBD As New P2014_BD_GestionHotelEntities
    Dim PaysSelection As tblPays
    Dim ProvinceSelection As tblProvince
    Dim VilleSelection As tblVille

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (Not IsPostBack) Then

            'Remplir les combobox. Par défaut sur canada, quebec, montreal
            VilleSelection = (From tabVille In MaBD.tblVille
                             Where tabVille.CodeVille = "MRL"
                             Select tabVille).ToList.First

            ProvinceSelection = (From tabProvince In MaBD.tblProvince
                                Where tabProvince.CodeProvince = VilleSelection.CodeProvince
                                Select tabProvince).ToList.First

            PaysSelection = (From tabPays In MaBD.tblPays
                            Where tabPays.CodePays = ProvinceSelection.CodePays
                            Select tabPays).ToList.First

            cmbPays.DataSource = (From tabPays In MaBD.tblPays
                                      Select tabPays).ToList

            cmbPays.DataValueField = "CodePays"
            cmbPays.DataTextField = "NomPays"
            cmbPays.DataBind()

            cmbProvince.DataValueField = "CodeProvince"
            cmbProvince.DataTextField = "NomProvince"
            cmbProvince.DataBind()

            cmbVille.DataValueField = "CodeVille"
            cmbVille.DataTextField = "NomVille"
            cmbVille.DataBind()

            cmbPays.SelectedValue = PaysSelection.CodePays
            FiltrerPays()
            FiltrerProvinces()
            FiltrerVilles()
        End If
    End Sub

    Protected Sub CreateUser_Click(sender As Object, e As EventArgs)
        Dim userName As String = Email.Text
        Dim NomClient As String = txtNom.Text
        Dim PrenomClient As String = txtPrenom.Text
        Dim NoTelephone As String = txtNoTelephone.Text
        Dim NoCellulaire As String = txtNoCellulaire.Text
        Dim Adresse1 As String = txtAdresse1.Text
        Dim Adresse2 As String = txtAdresse2.Text
        Dim CodePostal As String = txtCodePostal.Text
        Dim NomEntreprise As String = txtNomEntreprise.Text
        Dim CodeVille As String = cmbVille.SelectedValue.ToString()

        Dim res = From tabClient In MaBD.tblClient
                  Where tabClient.EmailClient = userName
                  Select tabClient

        If res.ToList.Count <> 0 Then
            ErrorMessage.Text = "Cette adresse de messagerie est déjà utilisée."
            Exit Sub
        End If

        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim user = New ApplicationUser() With {.UserName = userName, .Email = userName, .NomClient = NomClient, .PrenomClient = PrenomClient, .NoTelephone = NoTelephone, .NoCellulaire = NoCellulaire, .AdresseClient = Adresse1, .AdresseSecondaireClient = Adresse2, .CodePostal = CodePostal, .NomEntreprise = NomEntreprise, .CodeVille = CodeVille}
        'Dim result = manager.CreateAsync(user)
        'Dim result = manager.Create(user, Password.Text)
        Dim result = manager.Create(user, Password.Text)
        If result.Succeeded Then
            ' Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
            ' Dim code = manager.GenerateEmailConfirmationToken(user.Id)
            ' Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)
            ' manager.SendEmail(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=""" & callbackUrl & """>ici</a>.")


            'IdentityHelper.SignIn(manager, user, False)
            'IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)

            'On peut pas connecter le user direct après la création de son compte
            'parce que ça fait une erreur sur son ID qui a un format invalide.
            Response.Redirect("~/Account/Login.aspx")
        Else
            ErrorMessage.Text = result.Errors.FirstOrDefault()
        End If
    End Sub

    Sub FiltrerPays()
        PaysSelection = (From tabPays In MaBD.tblPays
                       Where tabPays.CodePays = cmbPays.SelectedValue
                       Select tabPays).ToList.First

        FiltrerProvinces()
    End Sub

    Sub FiltrerProvinces()
        Dim resProvinces = From tabProvince In MaBD.tblProvince
                           Where tabProvince.CodePays = PaysSelection.CodePays
                           Select tabProvince

        ProvinceSelection = resProvinces.ToList.First
        cmbProvince.DataSource = resProvinces.ToList
        cmbProvince.DataBind()
        cmbProvince.SelectedValue = resProvinces.ToList.First.CodeProvince
        FiltrerVilles()
    End Sub

    Sub FiltrerVilles()
        If cmbProvince.SelectedValue Is Nothing Then
            Dim resVille = From tabVille In MaBD.tblVille
                           Where tabVille.CodeProvince = ProvinceSelection.CodeProvince
                           Select tabVille

            cmbVille.DataSource = resVille.ToList
            cmbProvince.DataBind()
            VilleSelection = resVille.ToList.First
            cmbVille.SelectedValue = resVille.ToList.First.CodeVille
        Else
            ProvinceSelection = (From tabProvince In MaBD.tblProvince
                                Where tabProvince.CodeProvince = cmbProvince.SelectedValue
                                Select tabProvince).ToList.First

            Dim resVille = From tabVille In MaBD.tblVille
                           Where tabVille.CodeProvince = ProvinceSelection.CodeProvince
                           Select tabVille

            cmbVille.DataSource = resVille.ToList
            cmbVille.DataBind()
            VilleSelection = resVille.ToList.First
            cmbVille.SelectedValue = resVille.ToList.First.CodeVille
        End If

    End Sub

    Private Sub cmbPays_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPays.SelectedIndexChanged
        FiltrerPays()
    End Sub

    Private Sub cmbProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProvince.SelectedIndexChanged
        FiltrerVilles()
    End Sub

    Private Sub cmbVille_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVille.SelectedIndexChanged
        VilleSelection = (From tabVille In MaBD.tblVille
                         Where tabVille.CodeVille = cmbVille.SelectedValue
                         Select tabVille).ToList.First
    End Sub

    Private Sub Page_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If User.Identity.IsAuthenticated Then
            'Le user est connecté, redirect à l'accueil
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class

