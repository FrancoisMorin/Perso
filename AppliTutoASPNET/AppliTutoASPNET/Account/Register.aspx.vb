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
    Dim Classe As MaClasse
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
        Classe = New MaClasse()

        Dim Nom As String = txtNom.Text
        Dim Prenom As String = txtPrenom.Text
        Dim NoTelephone As String = txtNoTelephone.Text
        Dim NoCellulaire As String = txtNoCellulaire.Text
        Dim Adresse1 As String = txtAdresse1.Text
        Dim Adresse2 As String = txtAdresse2.Text
        Dim Email As String = txtEmail.Text
        Dim CodePostal As String = txtCodePostal.Text
        Dim NomEntreprise As String = txtEntreprise.Text
        Dim CodeVille As String = cmbVille.SelectedValue

        If Classe.EnregistrerClient(CodeVille, CodePostal, Email, NoTelephone, Adresse1, Nom, Prenom, NoCellulaire, Adresse2, NomEntreprise) Then
            'Message client créé avec succès
            Response.Write("<script>alert('Yayy');</script>")

            Dim userName As String = txtEmail.Text
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim user = New ApplicationUser() With {.UserName = userName, .Email = userName}
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

        Else
            'Message erreur de création
            Response.Write("<script>alert('Nayy');</script>")
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
End Class

