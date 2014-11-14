Public Class RechercheChambre
    Inherits System.Web.UI.Page
    Dim DateDebutSelection As Date
    Dim DateFinSelection As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub calDebut_DayRender(sender As Object, e As DayRenderEventArgs) Handles calDebut.DayRender
        If e.Day.Date < DateTime.Today Then
            e.Day.IsSelectable = False
            e.Cell.BackColor = Drawing.Color.LightGray
            e.Cell.ForeColor = Drawing.Color.Gray
        End If
    End Sub

    Private Sub calFin_DayRender(sender As Object, e As DayRenderEventArgs) Handles calFin.DayRender
        If e.Day.Date < DateTime.Today Then
            e.Day.IsSelectable = False
            e.Cell.BackColor = Drawing.Color.LightGray
            e.Cell.ForeColor = Drawing.Color.Gray
        End If
    End Sub

    Sub ClickStuff()
        ResultatRecherche.Visible = True

    End Sub

End Class