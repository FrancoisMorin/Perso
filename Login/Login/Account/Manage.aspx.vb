' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin

Partial Public Class Manage
    Inherits System.Web.UI.Page
    Protected Property SuccessMessage() As String
        Get
            Return m_SuccessMessage
        End Get
        Private Set(value As String)
            m_SuccessMessage = value
        End Set
    End Property
    Private m_SuccessMessage As String

    Protected Property CanRemoveExternalLogins() As Boolean
        Get
            Return m_CanRemoveExternalLogins
        End Get
        Private Set(value As Boolean)
            m_CanRemoveExternalLogins = value
        End Set
    End Property
    Private m_CanRemoveExternalLogins As Boolean

    Private Function HasPassword(manager As ApplicationUserManager) As Boolean
        Dim appUser = manager.FindById(User.Identity.GetUserId())
        Return (appUser IsNot Nothing AndAlso appUser.PasswordHash IsNot Nothing)
    End Function

    Protected Sub Page_Load() Handles Me.Load

        
        If Not IsPostBack Then
            ' Déterminer les sections à afficher
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            If HasPassword(manager) Then
                changePasswordHolder.Visible = True
            Else
                setPassword.Visible = True
                changePasswordHolder.Visible = False
            End If
            CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1

            'Afficher info client
            Dim usr = manager.FindById(User.Identity.GetUserId())

            txtNom.Text = usr.NomClient
            txtPrenom.Text = usr.PrenomClient
            txtNoTelephone.Text = usr.NoTelephone
            txtCellulaire.Text = usr.NoCellulaire
            txtAdresse1.Text = usr.AdresseClient
            txtAdresse2.Text = usr.AdresseSecondaireClient
            txtEmail.Text = usr.UserName

            ' Afficher le message de réussite
            Dim message = Request.QueryString("m")
            If message IsNot Nothing Then
                ' Enlever la chaîne de requête de l'action
                Form.Action = ResolveUrl("~/Account/Manage")
                SuccessMessage = If(message = "ChangePwdSuccess", "Votre mot de passe a été modifié.", If(message = "ModifFail", "Cette adresse de mssagerie est déjà utilisée.", If(message = "SetPwdSuccess", "Votre mot de passe a été défini.", If(message = "RemoveLoginSuccess", "Le compte a été supprimé.", [String].Empty))))
                SuccessMessagePlaceHolder.Visible = Not [String].IsNullOrEmpty(SuccessMessage)
            End If
        End If
    End Sub

    Protected Sub ChangePassword_Click(sender As Object, e As EventArgs)
        If IsValid Then
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim result As IdentityResult = manager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text)
            If result.Succeeded Then
                Dim userInfo = manager.FindById(User.Identity.GetUserId())
                IdentityHelper.SignIn(manager, userInfo, isPersistent:=False)
                Response.Redirect("~/Account/Manage?m=ChangePwdSuccess")
            Else
                AddErrors(result)
            End If
        End If
    End Sub

    Protected Sub SetPassword_Click(sender As Object, e As EventArgs)
        If IsValid Then
            ' Créer les informations de connexion locale et associer le compte local à l'utilisateur
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim result As IdentityResult = manager.AddPassword(User.Identity.GetUserId(), password.Text)
            If result.Succeeded Then
                Response.Redirect("~/Account/Manage?m=SetPwdSuccess")
            Else
                AddErrors(result)
            End If
        End If
    End Sub

    Public Function GetLogins() As IEnumerable(Of UserLoginInfo)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim accounts = manager.GetLogins(User.Identity.GetUserId())
        CanRemoveExternalLogins = accounts.Count() > 1 Or HasPassword(manager)
        Return accounts
    End Function

    Public Sub RemoveLogin(loginProvider As String, providerKey As String)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim result = manager.RemoveLogin(User.Identity.GetUserId(), New UserLoginInfo(loginProvider, providerKey))
        Dim msg As String = String.Empty
        If result.Succeeded Then
            Dim userInfo = manager.FindById(User.Identity.GetUserId())
            IdentityHelper.SignIn(manager, userInfo, isPersistent:=False)
            msg = "?m=RemoveLoginSuccess"
        End If
        Response.Redirect("~/Account/Manage" & msg)
    End Sub

    Private Sub AddErrors(result As IdentityResult)
        For Each [error] As String In result.Errors
            ModelState.AddModelError("", [error])
        Next
    End Sub

    Private Sub btnModifInfos_Click(sender As Object, e As EventArgs) Handles btnModifInfos.Click
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim usr = manager.FindById(User.Identity.GetUserId())

        usr.NomClient = txtNom.Text
        usr.PrenomClient = txtPrenom.Text
        usr.NoTelephone = txtNoTelephone.Text
        usr.NoCellulaire = txtCellulaire.Text
        usr.AdresseClient = txtAdresse1.Text
        usr.AdresseSecondaireClient = txtAdresse2.Text

        'Si le gars veut changer son email, faut vérifier si l'email existe déjà parce que on veut garder l'email client unique.
        If usr.UserName <> txtEmail.Text Then
            Dim BD As New P2014_BD_GestionHotelEntities
            Dim res = From tabClient In BD.tblClient
                      Where tabClient.EmailClient = txtEmail.Text
                      Select tabClient

            If res.Count > 0 Then
                Response.Redirect("~/Account/Manage?m=ModifFail")
            Else
                usr.UserName = txtEmail.Text
            End If
        End If

        Dim result As IdentityResult = manager.UpdateAsync(usr).Result
        If result.Succeeded Then
            Response.Redirect("~/Account/Manage?m=ModifSucces")
        Else
            AddErrors(result)
        End If
    End Sub
End Class
