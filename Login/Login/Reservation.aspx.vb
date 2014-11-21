Public Class Reservation
    Inherits System.Web.UI.Page
    Dim Maliste As List(Of PrixTypeChambreHotel_Result)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then

            Try
                Dim CodeHotel As String = Request.QueryString("ID")

                Dim BD As New P2014_BD_GestionHotelEntities

                Dim MonNomHotel As String

                Dim res = (From tabHotel In BD.tblHotel
                               Where tabHotel.CodeHotel = CodeHotel
                               Select tabHotel).ToList.First

                MonNomHotel = res.NomHotel
                TitreNomHotel.Text = MonNomHotel

                Dim res2 = From tabTypeChambre In BD.PrixTypeChambreHotel(CodeHotel)
                          Select tabTypeChambre


                ListeTypeChambre.DataSource = res2
                ListeTypeChambre.DataBind()
            Catch ex As Exception
                Response.Redirect("~/RechercheChambre.aspx")
            End Try
        End If
    End Sub

    Sub ClickStuff(ByVal sender As Object, ByVal e As System.EventArgs)
        

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim u = CType(sender, DropDownList)
        Dim code = u.Attributes("SorteChambre")
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
            txtDateFin.Text = "Sélectionnez un date de fin..."
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