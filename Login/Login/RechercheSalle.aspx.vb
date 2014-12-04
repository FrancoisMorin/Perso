Public Class RechercheSalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BD As New P2014_BD_GestionHotelEntities

        Dim res = From tabHotel In BD.tblHotel
                  Select tabHotel

        ListeHotels.DataSource = res.ToList
        ListeHotels.DataBind()



    End Sub

    Private Sub ListeHotels_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles ListeHotels.ItemDataBound
        'Dim u = CType(sender, ListView)
        'Dim code = u.Attributes("HotelSalle")

        'Dim I As Integer
        'I = 0
    End Sub
End Class