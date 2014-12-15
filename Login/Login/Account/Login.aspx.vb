' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports System.Web
Imports System.Web.UI
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin

Partial Public Class Login
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register"
        ' Activez ceci une fois que vous avez activé la confirmation du compte pour la fonctionnalité de réinitialisation du mot de passe
        ' ForgotPasswordHyperLink.NavigateUrl = "Forgot"
        'OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")
        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not [String].IsNullOrEmpty(returnUrl) Then
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
        End If
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs)
        If IsValid Then
            ' Valider le mot de passe de l'utilisateur
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim user As ApplicationUser = manager.Find(Email.Text, Password.Text)
            If user IsNot Nothing Then
                IdentityHelper.SignIn(manager, user, False)
                IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
            Else
                FailureText.Text = "Nom d'utilisateur ou mot de passe incorrect."
                ErrorMessage.Visible = True
            End If
        End If
    End Sub

    Private Sub Page_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If User.Identity.IsAuthenticated Then
            'Le user est connecté, redirect à l'accueil
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class
