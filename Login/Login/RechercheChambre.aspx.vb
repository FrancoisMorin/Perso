Imports System.Threading

Public Class RechercheChambre
    Inherits System.Web.UI.Page

    Dim DateDebutSelection As Date
    Dim DateFinSelection As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (IsPostBack) Then
            'ResultatRecherche.Visible = True

        End If

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

        ProgressBar.Visible = True

        Attend()

        Dim test As New ClasseGestion

        Dim Date1 As Date = "01/01/2014"
        Dim Date2 As Date = "02/01/2014"

        ListeHotel.DataSource = test.RechercheHotel(Date1, Date2)
        ListeHotel.DataBind()
        ProgressBar.Visible = False
        ResultatRecherche.Visible = True
    End Sub

    Sub Attend()
        Thread.Sleep(10000)
    End Sub


End Class