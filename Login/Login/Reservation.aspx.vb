Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin
Public Class Reservation
    Inherits System.Web.UI.Page

    Dim ClasseGes As ClasseGestion

    Private _MonMessage As String
    Protected Property MonMessage() As String
        Get
            Return _MonMessage
        End Get
        Set(ByVal value As String)
            _MonMessage = value
        End Set
    End Property

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
            MessagePlaceHolder.Visible = False
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

            ' Afficher le message de réussite
            Dim Message = Request.QueryString("m")
            If Message IsNot Nothing Then
                ' Enlever la chaîne de requête de l'action
                MonMessage = If(Message = "EmptyFields", "Certain champs sont manquant.", If(Message = "NoDates", "Vous n'avez pas spécifié une date de début ou une date de fin.", If(Message = "NoChambre", "Il n'y a pas asser de chambres disponible pour la plage de dates sélectionnée.", If(Message = "ErreurReserv", "Une erreur s'est produite dans la réservation.", If(Message = "NoSelect", "Vous n'avez pas sélectionné de chambre(s).", If(Message = "ErreurChambre", "Une erreur s'est produite lors de l'enregistrement des chambre.", [String].Empty))))))
                If MonMessage <> "" Then
                    MessagePlaceHolder.Visible = True
                Else
                    MessagePlaceHolder.Visible = False
                End If
            End If
        Else
            ClasseGes = New ClasseGestion
        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim u = CType(sender, DropDownList)
        Dim code = u.Attributes("SorteChambre")

        'Si la variable a déjà été créée, récupère là.
        If Session("MesReservations") IsNot Nothing Then
            ClasseGes = Session("MesReservations")
        End If

        ClasseGes.AjoutDetailReservation(code, u.Text)
        Session("MesReservations") = ClasseGes
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

    Private Sub btnCalculer_Click(sender As Object, e As EventArgs) Handles btnCalculer.Click

        Dim txtDebut As String = txtDateDebut.Text
        Dim txtFin As String = txtDateFin.Text
        Dim TypeCarte As String = cmbTypeCarte.SelectedValue.ToString
        Dim NoCarte As String = txtNoCarteCredit.Text
        Dim DateExp As String = txtDateExpiration.Text
        Dim NomDetenteur As String = txtNomDetenteurCarte.Text

        Dim DateDebut As String = ""
        Dim DateFin As String = ""

        'Vérifie si les dates ont été selectionné.
        If txtDebut <> "Sélectionnez une date de début..." And txtDateFin.Text <> "Sélectionnez une date de fin..." Then
            DateDebut = CalendrierDebut.SelectedDate.ToString("yyyy-MM-dd")
            DateFin = CalendrierFin.SelectedDate.ToString("yyyy-MM-dd")
        Else
            'Les dates n'ont pas été selectionné.
            Dim TempCodeHotel As String = Request.QueryString("ID")
            Response.Redirect("~/Reservation?m=NoDates&ID=" + TempCodeHotel)
        End If

        'Valide si les champs ont été rempli
        'On peut pas utiliser les asp:Validator à cause des update panels.
        If NoCarte = "" Or DateExp = "" Or NomDetenteur = "" Then
            Dim TempCodeHotel As String = Request.QueryString("ID")
            Response.Redirect("~/Reservation?m=EmptyFields&ID=" + TempCodeHotel)
        Else

        End If

        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim appUser = manager.FindById(User.Identity.GetUserId)
        Dim CodeHotel As String = Request.QueryString("ID")

        'Récupère la variable de session
        ClasseGes = Session("MesReservations")

        'Si ClasseGes est a Nothing, aucune chambre n'a été selectionné.
        If ClasseGes Is Nothing Then
            Dim TempCodeHotel As String = Request.QueryString("ID")
            Response.Redirect("~/Reservation?m=NoSelect&ID=" + TempCodeHotel)
        End If

        'Créer tblReservationChambre
        Dim result As Boolean
        result = ClasseGes.CreerReservation(appUser, cmbTypeCarte.Text, txtNoCarteCredit.Text, txtDateExpiration.Text, txtNomDetenteurCarte.Text)
        If Not result Then
            Dim TempCodeHotel As String = Request.QueryString("ID")
            Response.Redirect("~/Reservation?m=ErreurReserv&ID=" + TempCodeHotel)
        End If

        'Créer les tbChambresRéservationChambre
        result = ClasseGes.FaireReservationTypeChambre(CodeHotel, DateDebut, DateFin)
        If Not result Then
            Dim TempCodeHotel As String = Request.QueryString("ID")
            Response.Redirect("~/Reservation?m=NoChambre&ID=" + TempCodeHotel)
        End If

        'Fou tout ça dans la bd
        result = ClasseGes.EnregistrerChambresReservation(DateDebut, DateFin)
        If Not result Then
            Dim TempCodeHotel As String = Request.QueryString("ID")
            Response.Redirect("~/Reservation?m=ErreurChambre&ID=" + TempCodeHotel)
        End If

        Session("MesReservation") = ClasseGes

        'Affiche le panel de confirmation
        DetailReservation.Visible = True
        ConfirmerReservation()
    End Sub

    Sub ConfirmerReservation()
        'Récupère la classe
        ClasseGes = Session("MesReservation")

        'Disable tous les controles, sauf les bouton Confirm/Cancel
        MessagePlaceHolder.Visible = False
        ListeTypeChambre.Enabled = False
        cmbTypeCarte.Enabled = False
        btnExpandCalendarDebut.Enabled = False
        btnExpandCalendarFin.Enabled = False
        txtNoCarteCredit.Enabled = False
        txtDateExpiration.Enabled = False
        txtNomDetenteurCarte.Enabled = False
        btnCalculer.Enabled = False

        'Afficher les info de la réservation.
        Dim Reserv As New tblReservationChambre
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim appUser = manager.FindById(User.Identity.GetUserId)
        Reserv = ClasseGes.MaReservation

        lblDateDebut.Text = Reserv.tblChambreReservationChambre.First.DateDebutReservation.ToShortDateString
        lblDateFin.Text = Reserv.tblChambreReservationChambre.First.DateFinReservation.ToShortDateString
        lblNomReserv.Text = appUser.PrenomClient + " " + appUser.NomClient
        Dim Prix As Double = Reserv.PrixReservChambre
        lblPrixTotal.Text = Math.Round(Prix).ToString + " $"
        lblTypeCarte.Text = Reserv.TypeCarteCredit
        lblNoCarte.Text = Reserv.NoCarteCredit

        'Si le client confirme, mail-to + redirect page de congratulation?
        'Si le client refuse, supprime la réservation de la bd + redirect accueil?
    End Sub

End Class