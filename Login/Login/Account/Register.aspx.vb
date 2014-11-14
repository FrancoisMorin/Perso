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

        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim user = New ApplicationUser() With {.UserName = userName, .Email = userName, .NomClient = NomClient, .PrenomClient = PrenomClient, .NoTelephone = NoTelephone, .NoCellulaire = NoCellulaire, .AdresseClient = Adresse1, .AdresseSecondaireClient = Adresse2, .CodePostal = CodePostal, .NomEntreprise = NomEntreprise}
        'Dim result = manager.CreateAsync(user)
        'Dim result = manager.Create(user, Password.Text)
        Dim result = manager.Create(user, Password.Text)
        If result.Succeeded Then
            IdentityHelper.SignIn(manager, user, isPersistent:=False)

            ' Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
            ' Dim code = manager.GenerateEmailConfirmationToken(user.Id)
            ' Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)
            ' manager.SendEmail(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=""" & callbackUrl & """>ici</a>.")

            IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
        Else
            ErrorMessage.Text = result.Errors.FirstOrDefault()
        End If
    End Sub
End Class

