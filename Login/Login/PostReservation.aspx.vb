' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class PostReservation
    Inherits System.Web.UI.Page
    Dim CodeHotel As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            CodeHotel = Session("MonCodeHotel")

            If CodeHotel = "" Then
                Response.Redirect("~/Default.aspx")
            End If

            Session("MonCodeHotel") = ""

            Dim MaBD As New P2014_BD_GestionHotelEntities

            Dim MonHotel = (From tabHotel In MaBD.tblHotel
                           Where tabHotel.CodeHotel = CodeHotel
                           Select tabHotel).ToList.First

            lblMessage.Text = "Votre réservation a été correctement enregistrée pour l'hotel " + MonHotel.NomHotel
        Catch ex As Exception
            Response.Redirect("~/Default.aspx")
        End Try
    End Sub

    Private Sub PostReservation_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        
    End Sub
End Class
