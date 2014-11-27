Public Class RechercheChambre
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (IsPostBack) Then
            'ResultatRecherche.Visible = True

        End If

    End Sub

    Sub Clear()
        txtDateDebut.Text = "Sélectionnez une date de début..."
        txtDateFin.Text = "Sélectionnez une date de fin..."
        txtVilleRecherche.Text = ""
        ResultatRecherche.Visible = False
        CalendrierDebut.SelectedDate = Nothing
        CalendrierFin.SelectedDate = Nothing
        btnExpandCalendarFin.Enabled = False
        CalendrierDebut.Visible = False
        btnExpandCalendarDebut.Text = "+"
        CalendrierFin.Visible = False
        btnExpandCalendarFin.Text = "+"
    End Sub


    Sub RechercheHotel()
        Dim maClasse As New ClasseGestion

        If txtDateDebut.Text <> "Sélectionnez une date de début..." Then
            Dim Date1 As Date = CalendrierDebut.SelectedDate.ToShortDateString

            If txtDateFin.Text <> "Sélectionnez une date de fin..." Then
                Dim Date2 As Date = CalendrierFin.SelectedDate.ToShortDateString

                ListeHotel.DataSource = maClasse.RechercheHotel(Date1, Date2, txtVilleRecherche.Text)
                ListeHotel.DataBind()

                ResultatRecherche.Visible = True
            Else
                ResultatRecherche.Visible = False
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "AlertBox", "alert('Vous devez entrer une date de début et une date de fin pour effectuer la recherche.');", True)
            End If
        Else
            ResultatRecherche.Visible = False
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "AlertBox", "alert('Vous devez entrer une date de début et une date de fin pour effectuer la recherche.');", True)
        End If

    End Sub

    Private Sub CalendrierDebut_DayRender(sender As Object, e As DayRenderEventArgs) Handles CalendrierDebut.DayRender
        If e.Day.Date.ToShortDateString() <= DateTime.Now.ToShortDateString Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If
    End Sub

    Private Sub CalendrierFin_DayRender(sender As Object, e As DayRenderEventArgs) Handles CalendrierFin.DayRender
        If e.Day.Date.ToShortDateString() <= CalendrierDebut.SelectedDate.ToShortDateString Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If
    End Sub

    Private Sub CalendrierDebut_SelectionChanged(sender As Object, e As EventArgs) Handles CalendrierDebut.SelectionChanged
        If CalendrierDebut.SelectedDate >= CalendrierFin.SelectedDate Then
            CalendrierFin.SelectedDate = Nothing
            txtDateFin.Text = "Sélectionnez une date de fin..."
        End If

        txtDateDebut.Text = CalendrierDebut.SelectedDate.ToString("dd/MM/yyyy")
        CalendrierDebut.Visible = False

        btnExpandCalendarFin.Enabled = True
        btnExpandCalendarFin.CssClass = "btn btn-success"

        btnExpandCalendarDebut.Text = "+"
    End Sub

    Private Sub CalendrierFin_SelectionChanged(sender As Object, e As EventArgs) Handles CalendrierFin.SelectionChanged
        txtDateFin.Text = CalendrierFin.SelectedDate.ToString("dd/MM/yyyy")

        CalendrierFin.Visible = False
        btnExpandCalendarFin.Text = "+"
    End Sub

    Private Sub btnExpandCalendarDebut_Click(sender As Object, e As EventArgs) Handles btnExpandCalendarDebut.Click
        If (CalendrierDebut.Visible = False) Then
            CalendrierDebut.Visible = True
            btnExpandCalendarDebut.Text = "-"
        Else
            CalendrierDebut.Visible = False
            btnExpandCalendarDebut.Text = "+"
        End If
    End Sub

    Private Sub btnExpandCalendarFin_Click(sender As Object, e As EventArgs) Handles btnExpandCalendarFin.Click
        If (CalendrierFin.Visible = False) Then
            CalendrierFin.Visible = True
            btnExpandCalendarFin.Text = "-"
        Else
            CalendrierFin.Visible = False
            btnExpandCalendarFin.Text = "+"
        End If
    End Sub

End Class