' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class RechercheSalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Dim BD As New P2014_BD_GestionHotelEntities

            Dim res = From tabHotel In BD.tblHotel
                      Select tabHotel

            ListeHotels.DataSource = res.ToList
            ListeHotels.DataBind()
        End If
    End Sub

    Private Sub btnRechercheHotel_Click(sender As Object, e As EventArgs) Handles btnRechercheHotel.Click
        Dim BD As New P2014_BD_GestionHotelEntities

        Dim res = From tabHotel In BD.tblHotel
                  Where tabHotel.NomHotel.StartsWith(txtHotelRecherche.Text)
                  Select tabHotel

        ListeHotels.DataSource = res.ToList
        ListeHotels.DataBind()
    End Sub

    Private Sub btnRechercheVille_Click(sender As Object, e As EventArgs) Handles btnRechercheVille.Click
        Dim BD As New P2014_BD_GestionHotelEntities

        Dim res = From tabHotel In BD.tblHotel
                  Where tabHotel.tblVille.NomVille.StartsWith(txtVilleRecherche.Text)
                  Select tabHotel

        ListeHotels.DataSource = res.ToList
        ListeHotels.DataBind()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtHotelRecherche.Text = ""
        txtVilleRecherche.Text = ""

        Dim BD As New P2014_BD_GestionHotelEntities

        Dim res = From tabHotel In BD.tblHotel
                  Select tabHotel

        ListeHotels.DataSource = res.ToList
        ListeHotels.DataBind()
    End Sub
End Class
