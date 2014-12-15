' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class Contact
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BD As New P2014_BD_GestionHotelEntities

        Dim res = From tabHotel In BD.tblHotel
                  Select tabHotel

        ListeHotel.DataSource = res.ToList
        ListeHotel.DataBind()
    End Sub

End Class
