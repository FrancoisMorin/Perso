Public Class PostReservation
    Inherits System.Web.UI.Page
    Dim CodeHotel As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            CodeHotel = Session("MonCodeHotel")

            Dim MaBD As New P2014_BD_GestionHotelEntities

            Dim NomHotel = From tabHotel In MaBD.tblHotel
                           Where tabHotel.CodeHotel = CodeHotel
                           Select tabHotel.CodeHotel

        Catch ex As Exception
            Response.Redirect("~/Default.aspx")
        End Try
    End Sub

    Private Sub PostReservation_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        
    End Sub
End Class