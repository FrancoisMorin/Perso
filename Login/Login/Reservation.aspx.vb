Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin
Public Class Reservation
    Inherits System.Web.UI.Page

    Dim ClasseGes As ClasseGestion

    Private Sub Reservation_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If User.Identity.IsAuthenticated Then
            'Le user est connecté, passe à la réservation
        Else
            Response.Redirect("~/Account/Login.aspx")
            'bo tit poput javascrip
            'Redirect vers login / inscription
        End If
    End Sub

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
        Else
            ClasseGes = New ClasseGestion
        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim u = CType(sender, DropDownList)
        Dim code = u.Attributes("SorteChambre")

        ClasseGes.AjoutDetailReservation(code, u.Text)
        u.Enabled = False
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

    Private Sub btnCalculer_Click(sender As Object, e As EventArgs) Handles btnCalculer.Click
        DetailReservation.Visible = True

        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim appUser = manager.FindById(User.Identity.GetUserId)

        Dim DateDebut As String = CalendrierDebut.SelectedDate.ToString("yyyy-MM-dd")
        Dim Datefin As String = CalendrierFin.SelectedDate.ToString("yyyy-MM-dd")

        Dim CodeHotel As String = Request.QueryString("ID")

        ClasseGes.CreerReservation(appUser, cmbTypeCarte.Text, txtNoCarteCredit.Text, txtDateExpiration.Text, txtNomDetenteurCarte.Text)
        ClasseGes.FaireReservationTypeChambre(CodeHotel, DateDebut, Datefin)
        ClasseGes.EnregistrerChambresReservation()

    End Sub
End Class