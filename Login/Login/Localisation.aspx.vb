' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class Localisation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim CodeHotel As String = Request.QueryString("ID")

        If CodeHotel IsNot Nothing Then
            Dim BD As New P2014_BD_GestionHotelEntities

            Dim res = From tabHotel In BD.tblHotel
                      Where tabHotel.CodeHotel = CodeHotel
                      Select tabHotel

            Dim CodeVille As String = res.First.CodeVille

            Dim resVille = From tabVille In BD.tblVille
                           Where tabVille.CodeVille = CodeVille
                           Select tabVille

            lblAdresse.Text = res.First.AdresseHotel
            lblTelephone.Text = res.First.NoTelephoneHotel
            lblNoReservation.Text = res.First.NoTelReservation
            lblNoTelecopieur.Text = res.First.NoTelecopieurHotel
            lblCodePostal.Text = res.First.CodePostal
            lblHeure1.Text = res.First.HeureLimiteArrive
            lblHeure2.Text = res.First.HeureLimiteDepart

            Dim NomVille As String = resVille.First.NomVille

            MyMap.Attributes("src") = "https://www.google.com/maps/embed/v1/place?key=AIzaSyClJcaaScvorWUw5YMSlohxqFdV_d7vM_s&q=" + NomVille

        Else
            Response.Redirect("~/Default.aspx")
        End If

    End Sub

End Class
