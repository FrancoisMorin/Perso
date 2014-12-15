' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports System
Imports System.Threading.Tasks
Imports System.Security.Claims

' Vous pouvez ajouter des données de profil pour l’utilisateur en ajoutant des propriétés à votre classe d’utilisateur. Pour plus d’informations, consultez http://go.microsoft.com/fwlink/?LinkID=317594.
Public Class ApplicationUser
    Inherits IdentityUser

#Region "Property Client"
    Private _NomClient As String
    Public Property NomClient() As String
        Get
            Return _NomClient
        End Get
        Set(ByVal value As String)
            _NomClient = value
        End Set
    End Property

    Private _PrenomClient As String
    Public Property PrenomClient() As String
        Get
            Return _PrenomClient
        End Get
        Set(ByVal value As String)
            _PrenomClient = value
        End Set
    End Property

    Private _NoTelephone As String
    Public Property NoTelephone() As String
        Get
            Return _NoTelephone
        End Get
        Set(ByVal value As String)
            _NoTelephone = value
        End Set
    End Property

    Private _NoCellulaire As String
    Public Property NoCellulaire() As String
        Get
            Return _NoCellulaire
        End Get
        Set(ByVal value As String)
            _NoCellulaire = value
        End Set
    End Property

    Private _AdresseClient As String
    Public Property AdresseClient() As String
        Get
            Return _AdresseClient
        End Get
        Set(ByVal value As String)
            _AdresseClient = value
        End Set
    End Property

    Private _AdresseSecondaireClient As String
    Public Property AdresseSecondaireClient() As String
        Get
            Return _AdresseSecondaireClient
        End Get
        Set(ByVal value As String)
            _AdresseSecondaireClient = value
        End Set
    End Property

    Private _CodePostal As String
    Public Property CodePostal() As String
        Get
            Return _CodePostal
        End Get
        Set(ByVal value As String)
            _CodePostal = value
        End Set
    End Property

    Private _NomEntreprise As String
    Public Property NomEntreprise() As String
        Get
            Return _NomEntreprise
        End Get
        Set(ByVal value As String)
            _NomEntreprise = value
        End Set
    End Property

    Private _CodeVille As String
    Public Property CodeVille() As String
        Get
            Return _CodeVille
        End Get
        Set(ByVal value As String)
            _CodeVille = value
        End Set
    End Property
#End Region

    Public Function GenerateUserIdentityAsync(manager As ApplicationUserManager) As Task(Of ClaimsIdentity)
        Return Task.FromResult(GenerateUserIdentity(manager))
    End Function

    Public Function GenerateUserIdentity(manager As ApplicationUserManager) As ClaimsIdentity
        ' Notez que l'authenticationType doit correspondre à celui défini dans CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = manager.CreateIdentity(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Ajouter des revendications utilisateur personnalisées ici
        Return userIdentity
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)

    Private _MaBD As P2014_BD_GestionHotelEntities
    Public Property MaBD() As P2014_BD_GestionHotelEntities
        Get
            Return _MaBD
        End Get
        Set(ByVal value As P2014_BD_GestionHotelEntities)
            _MaBD = value
        End Set
    End Property


    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)

        MaBD = New P2014_BD_GestionHotelEntities
    End Sub
    
    Public Shared Function Create As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function    
End Class

#Region "Helpers"
Public Class IdentityHelper
    'Utilisé pour XSRF lors de la liaison de logins externes
    Public Const XsrfKey As String = "xsrfKey"

    Public Shared Sub SignIn(manager As ApplicationUserManager, user As ApplicationUser, isPersistent As Boolean)
        Dim authenticationManager As IAuthenticationManager = HttpContext.Current.GetOwinContext().Authentication
        authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie)
        Dim identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie)
        authenticationManager.SignIn(New AuthenticationProperties() With {.IsPersistent = isPersistent}, identity)
    End Sub

    Public Const ProviderNameKey As String = "providerName"
    Public Shared Function GetProviderNameFromRequest(request As HttpRequest) As String
        Return request.QueryString(ProviderNameKey)
    End Function

    Public Const CodeKey As String = "code"
    Public Shared Function GetCodeFromRequest(request As HttpRequest) As String
        Return request.QueryString(CodeKey)
    End Function

    Public Const UserIdKey As String = "userId"
    Public Shared Function GetUserIdFromRequest(request As HttpRequest) As String
        Return HttpUtility.UrlDecode(request.QueryString(UserIdKey))
    End Function

    Public Shared Function GetResetPasswordRedirectUrl(code As String) As String
        Return "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code)
    End Function

    Public Shared Function GetUserConfirmationRedirectUrl(code As String, userId As String) As String
        Return "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId)
    End Function

    Private Shared Function IsLocalUrl(url As String) As Boolean
        Return Not String.IsNullOrEmpty(url) AndAlso ((url(0) = "/"c AndAlso (url.Length = 1 OrElse (url(1) <> "/"c AndAlso url(1) <> "\"c))) OrElse (url.Length > 1 AndAlso url(0) = "~"c AndAlso url(1) = "/"c))
    End Function

    Public Shared Sub RedirectToReturnUrl(returnUrl As String, response As HttpResponse)
        If Not [String].IsNullOrEmpty(returnUrl) AndAlso IsLocalUrl(returnUrl) Then
            response.Redirect(returnUrl)
        Else
            response.Redirect("~/")
        End If
    End Sub
End Class
#End Region
