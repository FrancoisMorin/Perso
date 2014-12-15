' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class RechercheChambre
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Dim BD As New P2014_BD_GestionHotelEntities

            Dim res = From tabHotel In BD.tblHotel
                          Select tabHotel

            ListeHotel.DataSource = res.ToList
            ListeHotel.DataBind()

            ResultatRecherche.Visible = True
        End If

    End Sub

    Sub Clear()
        txtDateDebut.Text = "Sélectionnez une date de début..."
        txtDateFin.Text = "Sélectionnez une date de fin..."
        txtVilleRecherche.Text = ""
        CalendrierDebut.SelectedDate = Nothing
        CalendrierFin.SelectedDate = Nothing
        btnExpandCalendarFin.Enabled = False
        CalendrierDebut.Visible = False
        btnExpandCalendarDebut.Text = "+"
        CalendrierFin.Visible = False
        btnExpandCalendarFin.Text = "+"

        Dim BD As New P2014_BD_GestionHotelEntities

        Dim res = From tabHotel In BD.tblHotel
                      Select tabHotel

        ListeHotel.DataSource = res.ToList
        ListeHotel.DataBind()
    End Sub

    Sub RechercheHotel()
        Dim maClasse As New ClasseGestion
        Dim BD As New P2014_BD_GestionHotelEntities

        If txtVilleRecherche.Text <> "" Then
            Dim res = From tabHotel In BD.tblHotel
                      Join tabVille In BD.tblVille On tabHotel.CodeVille Equals tabVille.CodeVille
                      Where tabVille.NomVille.StartsWith(txtVilleRecherche.Text)
                      Select tabHotel

            ListeHotel.DataSource = res.ToList
            ListeHotel.DataBind()
        End If

        If (txtDateDebut.Text <> "Sélectionnez une date de début...") And (txtDateFin.Text <> "Sélectionnez une date de fin...") Then
            Dim Date1 As Date = CalendrierDebut.SelectedDate.ToShortDateString
            Dim Date2 As Date = CalendrierFin.SelectedDate.ToShortDateString

            ListeHotel.DataSource = maClasse.RechercheHotel(Date1, Date2, txtVilleRecherche.Text)
            ListeHotel.DataBind()
        End If

        If (txtVilleRecherche.Text = "") And (txtDateDebut.Text = "Sélectionnez une date de début...") And (txtDateFin.Text = "Sélectionnez une date de fin...") Then
            Dim res = From tabHotel In BD.tblHotel
                      Select tabHotel

            ListeHotel.DataSource = res.ToList
            ListeHotel.DataBind()
        End If


    End Sub

#Region "Calendrier"
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

#End Region

End Class
