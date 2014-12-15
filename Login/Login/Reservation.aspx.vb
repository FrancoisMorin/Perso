' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin
Public Class Reservation
    Inherits System.Web.UI.Page

    Dim ClasseGes As ClasseGestion

    Dim MaBD As New P2014_BD_GestionHotelEntities
    Dim PaysSelection As tblPays
    Dim ProvinceSelection As tblProvince
    Dim VilleSelection As tblVille

    Private _MonMessage As String
    Protected Property MonMessage() As String
        Get
            Return _MonMessage
        End Get
        Set(ByVal value As String)
            _MonMessage = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim appUser = manager.FindById(User.Identity.GetUserId)

            If appUser Is Nothing Then
                MonPanelClient.Visible = True
            Else
                MonPanelClient.Visible = False
            End If


            'Remplir les combobox. Par défaut sur canada, quebec, montreal
            VilleSelection = (From tabVille In MaBD.tblVille
                             Where tabVille.CodeVille = "MRL"
                             Select tabVille).ToList.First

            ProvinceSelection = (From tabProvince In MaBD.tblProvince
                                Where tabProvince.CodeProvince = VilleSelection.CodeProvince
                                Select tabProvince).ToList.First

            PaysSelection = (From tabPays In MaBD.tblPays
                            Where tabPays.CodePays = ProvinceSelection.CodePays
                            Select tabPays).ToList.First

            cmbPays.DataSource = (From tabPays In MaBD.tblPays
                                      Select tabPays).ToList

            cmbPays.DataValueField = "CodePays"
            cmbPays.DataTextField = "NomPays"
            cmbPays.DataBind()

            cmbProvince.DataValueField = "CodeProvince"
            cmbProvince.DataTextField = "NomProvince"
            cmbProvince.DataBind()

            cmbVille.DataValueField = "CodeVille"
            cmbVille.DataTextField = "NomVille"
            cmbVille.DataBind()

            cmbPays.SelectedValue = PaysSelection.CodePays
            FiltrerPays()
            FiltrerProvinces()
            FiltrerVilles()

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
                MonMessage = If(Message = "EmptyFields", "Certain champs sont manquant.", If(Message = "NoDates", "Vous n'avez pas spécifié une date de début ou une date de fin.", If(Message = "NoChambre", "Il n'y a pas asser de chambres disponible pour la plage de dates sélectionnée.", If(Message = "ErreurReserv", "Une erreur s'est produite dans la réservation.", If(Message = "NoSelect", "Vous n'avez pas sélectionné de chambre(s).", If(Message = "ErreurClient", "Les informations clients sont incomplètes ou invalides.", If(Message = "ErreurChambre", "Une erreur s'est produite lors de l'enregistrement des chambre.", [String].Empty)))))))
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
        If Session("MesReservation") IsNot Nothing Then
            ClasseGes = Session("MesReservation")
        End If

        ClasseGes.AjoutDetailReservation(code, u.Text)
        Session("MesReservation") = ClasseGes
    End Sub

#Region "Event_Combobox_Ville"
    Protected Sub cmbPays_SelectedIndexChanged(sender As Object, e As EventArgs)
        FiltrerPays()
    End Sub

    Protected Sub cmbProvince_SelectedIndexChanged(sender As Object, e As EventArgs)
        FiltrerVilles()
    End Sub

    Protected Sub cmbVille_SelectedIndexChanged(sender As Object, e As EventArgs)
        VilleSelection = (From tabVille In MaBD.tblVille
                         Where tabVille.CodeVille = cmbVille.SelectedValue
                         Select tabVille).ToList.First
    End Sub
#End Region

#Region "ControlsCalendrier"
    Private Sub CalendrierDebut_DayRender(sender As Object, e As DayRenderEventArgs) Handles CalendrierDebut.DayRender
        If e.Day.Date.ToShortDateString() <= DateTime.Now.ToShortDateString Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If

        Dim DateDans2Ans As Date = DateTime.Now
        DateDans2Ans = DateDans2Ans.AddYears(2)

        If e.Day.Date.ToShortDateString >= DateDans2Ans Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If
    End Sub

    Private Sub CalendrierFin_DayRender(sender As Object, e As DayRenderEventArgs) Handles CalendrierFin.DayRender
        If e.Day.Date.ToShortDateString() <= CalendrierDebut.SelectedDate.ToShortDateString Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If

        Dim DateDans2Ans As Date = DateTime.Now
        DateDans2Ans = DateDans2Ans.AddYears(2)

        If e.Day.Date.ToShortDateString >= DateDans2Ans Then
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

    Private Sub btnCalculer_Click(sender As Object, e As EventArgs) Handles btnCalculer.Click
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim appUser = manager.FindById(User.Identity.GetUserId)
        'Récupère la variable de session
        ClasseGes = Session("MesReservation")

        'Si la variable est vide dès le départ, les combobox de chambre n'ont pas été changé
        If ClasseGes Is Nothing Then
            Dim TempCodeHotel As String = Request.QueryString("ID")
            Response.Redirect("~/Reservation?m=NoSelect&ID=" + TempCodeHotel)
        End If

        'Vérifie si la réservation se fait avec un compte client
        If appUser Is Nothing Then
            'Vérifie les champs du client et crée le client
            Dim NomClient As String = txtNom.Text
            Dim PrenomClient As String = txtPrenom.Text
            Dim NoTelephone As String = txtNoTelephone.Text
            Dim Email As String = txtEmail.Text
            Dim Adresse As String = txtAdresse.Text
            Dim CodeVille As String = cmbVille.SelectedValue.ToString()

            Dim MonResult As Boolean
            MonResult = ClasseGes.EnregistrerClient(NomClient, PrenomClient, NoTelephone, Email, Adresse, CodeVille)
            If Not MonResult Then
                Dim TempCodeHotel As String = Request.QueryString("ID")
                Response.Redirect("~/Reservation?m=ErreurClient&ID=" + TempCodeHotel)
            End If
        End If

        'Récupere les infos de la réservation
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
        End If

        Dim CodeHotel As String = Request.QueryString("ID")

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
        ConfirmerReservation()
    End Sub

    Sub ConfirmerReservation()
        'Récupère la classe
        ClasseGes = Session("MesReservation")

        'Disable tous les controles, sauf les bouton Confirm/Cancel
        MonPanelClient.Enabled = False
        MessagePlaceHolder.Visible = False
        ListeTypeChambre.Enabled = False
        cmbTypeCarte.Enabled = False
        btnExpandCalendarDebut.Enabled = False
        btnExpandCalendarFin.Enabled = False
        txtNoCarteCredit.Enabled = False
        txtDateExpiration.Enabled = False
        txtNomDetenteurCarte.Enabled = False
        btnCalculer.Enabled = False

        'Rempli les controles du modal
        'Afficher les info de la réservation.
        Dim Reserv As New tblReservationChambre
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim appUser = manager.FindById(User.Identity.GetUserId)
        Reserv = ClasseGes.MaReservation

        lblDateDebut.Text = Reserv.tblChambreReservationChambre.First.DateDebutReservation.ToShortDateString
        lblDateFin.Text = Reserv.tblChambreReservationChambre.First.DateFinReservation.ToShortDateString

        If appUser Is Nothing Then
            lblNomReserv.Text = ClasseGes.MonClient.PrenomClient + " " + ClasseGes.MonClient.NomClient
        Else
            lblNomReserv.Text = appUser.PrenomClient + " " + appUser.NomClient
        End If

        Dim Prix As Double = Reserv.PrixReservChambre
        lblPrixTotal.Text = Math.Round(Prix).ToString + " $"
        lblTypeCarte.Text = Reserv.TypeCarteCredit
        lblNoCarte.Text = Reserv.NoCarteCredit


        'Affc=iche le modal de confirmation
        Page.ClientScript.RegisterStartupScript(Me.GetType, "Show", "$(document).ready(function() {$('#myModal').modal('show');});", True)
    End Sub

    Sub Confirm()
        'Si le client confirme, mail-to + redirect page de congratulation?
        ClasseGes = Session("MesReservation")

        Session("MonCodeHotel") = ClasseGes.MaReservation.tblChambreReservationChambre.First.tblChambre.CodeHotel

        Response.Redirect("~/PostReservation.aspx")
    End Sub

    Sub Annuler()
        'Si le client refuse, supprime la réservation de la bd + redirect accueil
        ClasseGes = Session("MesReservation")

        Dim MaBD As New P2014_BD_GestionHotelEntities

        ClasseGes.AnnulerReservation()

        Session("MesReservation") = Nothing

        Response.Redirect("~/Default.aspx")
    End Sub

    Protected Sub btnAnnuler_Click(sender As Object, e As EventArgs)
        Annuler()
    End Sub

    Protected Sub btnConfirmer_Click(sender As Object, e As EventArgs)
        Confirm()
    End Sub

#Region "ProceduresVille"
    Sub FiltrerPays()
        PaysSelection = (From tabPays In MaBD.tblPays
                       Where tabPays.CodePays = cmbPays.SelectedValue
                       Select tabPays).ToList.First

        FiltrerProvinces()
    End Sub

    Sub FiltrerProvinces()
        Dim resProvinces = From tabProvince In MaBD.tblProvince
                           Where tabProvince.CodePays = PaysSelection.CodePays
                           Select tabProvince

        ProvinceSelection = resProvinces.ToList.First
        cmbProvince.DataSource = resProvinces.ToList
        cmbProvince.DataBind()
        cmbProvince.SelectedValue = resProvinces.ToList.First.CodeProvince
        FiltrerVilles()
    End Sub

    Sub FiltrerVilles()
        If cmbProvince.SelectedValue Is Nothing Then
            Dim resVille = From tabVille In MaBD.tblVille
                           Where tabVille.CodeProvince = ProvinceSelection.CodeProvince
                           Select tabVille

            cmbVille.DataSource = resVille.ToList
            cmbProvince.DataBind()
            VilleSelection = resVille.ToList.First
            cmbVille.SelectedValue = resVille.ToList.First.CodeVille
        Else
            ProvinceSelection = (From tabProvince In MaBD.tblProvince
                                Where tabProvince.CodeProvince = cmbProvince.SelectedValue
                                Select tabProvince).ToList.First

            Dim resVille = From tabVille In MaBD.tblVille
                           Where tabVille.CodeProvince = ProvinceSelection.CodeProvince
                           Select tabVille

            cmbVille.DataSource = resVille.ToList
            cmbVille.DataBind()
            VilleSelection = resVille.ToList.First
            cmbVille.SelectedValue = resVille.ToList.First.CodeVille
        End If

    End Sub
#End Region

End Class
