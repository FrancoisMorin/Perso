' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports Microsoft.AspNet.Identity
Imports System.Threading.Tasks

Public Class MonStore(Of TUser As ApplicationUser)
    Implements IUserStore(Of ApplicationUser), IUserPasswordStore(Of ApplicationUser), IUserLoginStore(Of ApplicationUser)

    Private _applicationDbContext As ApplicationDbContext
    Private BD As P2014_BD_GestionHotelEntities

    Sub New(applicationDbContext As ApplicationDbContext)
        ' TODO: Complete member initialization 
        _applicationDbContext = applicationDbContext
        BD = _applicationDbContext.MaBD
    End Sub

#Region "User"

    Public Function CreateAsync(user As ApplicationUser) As Task Implements IUserStore(Of ApplicationUser, String).CreateAsync

        Dim Client As New tblClient

        Dim fuckyou As String = user.CodePostal

        Client.NomClient = user.NomClient
        Client.PrenomClient = user.PrenomClient
        Client.NoTelephone = user.NoTelephone
        Client.NoCellulaire = user.NoCellulaire
        Client.AdresseClient = user.AdresseClient
        Client.AdresseSecondaireClient = user.AdresseSecondaireClient
        Client.CodePostal = fuckyou.Replace(" ", "")
        Client.CodeVille = user.CodeVille
        Client.EmailClient = user.Email
        Client.MdpClient = user.PasswordHash
        BD.tblClient.Add(Client)

        BD.SaveChanges()

            Return Task.FromResult(True)
    End Function

    Public Function DeleteAsync(user As ApplicationUser) As Task Implements IUserStore(Of ApplicationUser, String).DeleteAsync

    End Function

    Public Function FindByIdAsync(userId As String) As Task(Of ApplicationUser) Implements IUserStore(Of ApplicationUser, String).FindByIdAsync
        Dim user As ApplicationUser = Nothing

        Dim res = From el In BD.tblClient Where el.NoSeqClient = userId Select el

        If res.Count > 0 Then
            user = New ApplicationUser
            user.Id = res.First.NoSeqClient
            user.UserName = res.First.EmailClient
            user.PasswordHash = res.First.MdpClient
            user.NomClient = res.First.NomClient
            user.PrenomClient = res.First.PrenomClient
            user.NoTelephone = res.First.NoTelephone
            user.NoCellulaire = res.First.NoCellulaire
            user.AdresseClient = res.First.AdresseClient
            user.AdresseSecondaireClient = res.First.AdresseSecondaireClient
            user.CodePostal = res.First.CodePostal
            user.NomEntreprise = res.First.NomEntreprise
            user.CodeVille = res.First.CodeVille
        End If

        Return Task.FromResult(user)
    End Function

    Public Function FindByNameAsync(userName As String) As Task(Of ApplicationUser) Implements IUserStore(Of ApplicationUser, String).FindByNameAsync
        Dim user As ApplicationUser = Nothing

        'Dim res = From el In BD.tblClient Select el
        Dim res = From el In BD.tblClient Where el.EmailClient = userName Select el

        If res.Count > 0 Then
            user = New ApplicationUser
            user.Id = res.First.NoSeqClient
            user.UserName = res.First.EmailClient
            user.PasswordHash = res.First.MdpClient
            user.NomClient = res.First.NomClient
            user.PrenomClient = res.First.PrenomClient
            user.NoTelephone = res.First.NoTelephone
            user.NoCellulaire = res.First.NoCellulaire
            user.AdresseClient = res.First.AdresseClient
            user.AdresseSecondaireClient = res.First.AdresseSecondaireClient
            user.CodePostal = res.First.CodePostal
            user.NomEntreprise = res.First.NomEntreprise
            user.CodeVille = res.First.CodeVille
        End If

        Return Task.FromResult(user)
    End Function

    Public Function UpdateAsync(user As ApplicationUser) As Task Implements IUserStore(Of ApplicationUser, String).UpdateAsync
        
        Dim res = From tabClient In BD.tblClient
                  Where tabClient.NoSeqClient = user.Id
                  Select tabClient

        If res.Count > 0 Then
            res.ToList.First.MdpClient = user.PasswordHash

            res.ToList.First.NomClient = user.NomClient
            res.ToList.First.PrenomClient = user.PrenomClient
            res.ToList.First.NoTelephone = user.NoTelephone
            res.ToList.First.NoCellulaire = user.NoCellulaire
            res.ToList.First.AdresseClient = user.AdresseClient
            res.ToList.First.AdresseSecondaireClient = user.AdresseSecondaireClient
            res.ToList.First.EmailClient = user.UserName

            BD.SaveChanges()
        End If

        Return Task.FromResult(user)
    End Function
#End Region

#Region "Login"
    Public Function AddLoginAsync(user As ApplicationUser, login As UserLoginInfo) As Task Implements IUserLoginStore(Of ApplicationUser, String).AddLoginAsync

    End Function

    Public Function FindAsync(login As UserLoginInfo) As Task(Of ApplicationUser) Implements IUserLoginStore(Of ApplicationUser, String).FindAsync

    End Function

    Public Function GetLoginsAsync(user As ApplicationUser) As Task(Of IList(Of UserLoginInfo)) Implements IUserLoginStore(Of ApplicationUser, String).GetLoginsAsync
        Dim l As New List(Of UserLoginInfo)

        l.Add(New UserLoginInfo("Nouvotel", "123"))

        Return Task.FromResult(DirectCast(l, IList(Of UserLoginInfo)))
    End Function

    Public Function RemoveLoginAsync(user As ApplicationUser, login As UserLoginInfo) As Task Implements IUserLoginStore(Of ApplicationUser, String).RemoveLoginAsync

    End Function
#End Region

#Region "Password"
    Public Function GetPasswordHashAsync(user As ApplicationUser) As Task(Of String) Implements IUserPasswordStore(Of ApplicationUser, String).GetPasswordHashAsync
        Return Task.FromResult(user.PasswordHash)
    End Function

    Public Function HasPasswordAsync(user As ApplicationUser) As Task(Of Boolean) Implements IUserPasswordStore(Of ApplicationUser, String).HasPasswordAsync
        If user.PasswordHash Is Nothing Then
            Return Task.FromResult(False)
        Else
            Return Task.FromResult(True)
        End If
    End Function

    Public Function SetPasswordHashAsync(user As ApplicationUser, passwordHash As String) As Task Implements IUserPasswordStore(Of ApplicationUser, String).SetPasswordHashAsync
        user.PasswordHash = passwordHash

        Dim res = From tabClient In BD.tblClient
                  Where tabClient.NoSeqClient = user.Id
                  Select tabClient

        If res.ToList.Count > 0 Then
            res.ToList.First.MdpClient = passwordHash
            BD.SaveChanges()
            Return Task.FromResult(True)
        End If

        Return Task.FromResult(False)
    End Function
#End Region


#Region "IDisposable Support"
    Private disposedValue As Boolean ' Pour détecter les appels redondants

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: supprimez l'état managé (objets managés).
            End If

            ' TODO: libérez les ressources non managées (objets non managés) et substituez la méthode Finalize() ci-dessous.
            ' TODO: définissez les champs volumineux à null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: substituez Finalize() uniquement si Dispose(ByVal disposing As Boolean) ci-dessus comporte du code permettant de libérer des ressources non managées.
    'Protected Overrides Sub Finalize()
    '    ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Ce code a été ajouté par Visual Basic pour permettre l'implémentation correcte du modèle pouvant être supprimé.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(disposing As Boolean) ci-dessus.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class
