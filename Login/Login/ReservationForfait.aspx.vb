' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin
Public Class ReservationForfait
    Inherits System.Web.UI.Page

    Dim MaBD As New P2014_BD_GestionHotelEntities
    Dim PaysSelection As tblPays
    Dim ProvinceSelection As tblProvince
    Dim VilleSelection As tblVille

    Dim ForfaitSelection As tblForfait

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
        Dim MonCodeForfait As String = Request.QueryString("ID")

        If MonCodeForfait = "" Then
            Response.Redirect("~/Forfait.aspx")
        Else
            'Récupère le forfait avec le code passé dans l'URL
            Dim resForfait = From tabForfait In MaBD.tblForfait
                             Where tabForfait.CodeForfait = MonCodeForfait
                             Select tabForfait

            'Vérifie que le code est valide
            If resForfait.ToList IsNot Nothing Then
                Dim MonForfait As tblForfait
                MonForfait = resForfait.ToList.First

                'Affiche les informations du forfait
                ImageForfait.ImageUrl = "~/Images/SliderForfait/Forfait" + MonCodeForfait.ToLower + ".jpg"
                LabelNomForfait.Text = MonForfait.NomForfait
                LabelTypeChambre.Text = MonForfait.tblTypeChambre.NomTypeChambre
                LabelPrixForfait.Text = MonForfait.PrixForfait.ToString("0.00 $")
                LabelNbNuit.Text = MonForfait.NbNuit
                LabelDescription.Text = MonForfait.DescForfait

                ForfaitSelection = MonForfait
            Else
                Response.Redirect("~/Forfait.aspx")
            End If

        End If


        If (Not IsPostBack) Then
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim appUser = manager.FindById(User.Identity.GetUserId)

            If appUser Is Nothing Then
                MonPanelClient.Visible = True
            Else
                MonPanelClient.Visible = False
            End If

            'Rempli la combobox d'hôtel
            Dim resHotel = From tabHotel In MaBD.tblHotel
                           Select tabHotel

            cmbHotel.DataValueField = "CodeHotel"
            cmbHotel.DataTextField = "NomHotel"
            cmbHotel.DataSource = resHotel.ToList
            cmbHotel.DataBind()

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

            'Affichage de message d'erreur
            Dim Message = Request.QueryString("m")
            If Message IsNot Nothing Then
                ' Enlever la chaîne de requête de l'action
                MonMessage = If(Message = "EmptyFields", "Les champs d'informations de carte de crédit sont manquants.", If(Message = "NoDates", "Vous n'avez pas spécifié une date de début.", If(Message = "NoChambre", "Il n'y a pas asser de chambres disponible pour la plage de dates sélectionnée.", If(Message = "ErreurReserv", "Les informations de carte de crédit sont invalides.", If(Message = "NoSelect", "Vous n'avez pas sélectionné de chambre(s).", If(Message = "ErreurClient", "Les informations clients sont incomplètes ou invalides.", If(Message = "ErreurChambre", "Une erreur s'est produite lors de l'enregistrement des chambre.", [String].Empty)))))))
                If MonMessage <> "" Then
                    MessagePlaceHolder.Visible = True
                Else
                    MessagePlaceHolder.Visible = False
                End If
            End If
        End If
    End Sub

#Region "ControlsCalendrier"
    Private Sub CalendrierDebut_DayRender(sender As Object, e As DayRenderEventArgs) Handles CalendrierDebut.DayRender
        'Enlever les dates avant aujourd'hui
        If e.Day.Date.ToShortDateString() <= DateTime.Now.ToShortDateString Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If

        'Enlever les dates avant et après les dates limite du forfait
        If e.Day.Date.ToShortDateString() <= ForfaitSelection.DateDebut Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If

        If e.Day.Date.ToShortDateString() >= ForfaitSelection.DateFin Then
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
            e.Day.IsSelectable = False
        End If

        'Enlever les date dans + que 2 ans
        'Pas trop nécessaire ici vu que les date du forfait vont déjà être limité

        'Dim DateDans2Ans As Date = DateTime.Now
        'DateDans2Ans = DateDans2Ans.AddYears(2)

        'If e.Day.Date.ToShortDateString >= DateDans2Ans Then
        '    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEB")
        '    e.Day.IsSelectable = False
        'End If
    End Sub

    Private Sub CalendrierDebut_SelectionChanged(sender As Object, e As EventArgs) Handles CalendrierDebut.SelectionChanged
        If CalendrierDebut.SelectedDate >= CalendrierFin.SelectedDate Then
            CalendrierFin.SelectedDate = Nothing
            txtDateFin.Text = "Sélectionnez une date de fin..."
        End If

        txtDateDebut.Text = CalendrierDebut.SelectedDate.ToString("dd/MM/yyyy")
        CalendrierDebut.Visible = False

        'Faire sélectionner la date de fin dépendant du nombre de nuits du forfait.
        CalendrierFin.SelectedDate = CalendrierDebut.SelectedDate.AddDays(ForfaitSelection.NbNuit)
        txtDateFin.Text = CalendrierFin.SelectedDate.ToString("dd/MM/yyyy")

        btnExpandCalendarDebut.Text = "+"
    End Sub

    Private Sub CalendrierFin_SelectionChanged(sender As Object, e As EventArgs) Handles CalendrierFin.SelectionChanged

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
#End Region

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

#Region "ComboBoxVille"
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

    Sub ConfirmerReservation()

        Dim ClasseGes As ClasseGestion
        ClasseGes = Session("MaReservation")

        'Disable tous les controles, sauf les bouton Confirm/Cancel
        MonPanelClient.Enabled = False
        MessagePlaceHolder.Visible = False
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

        'Cacher les 4 premier caractères du No. de carte de crédit
        lblNoCarte.Text = Reserv.NoCarteCredit

        'Affc=iche le modal de confirmation
        Page.ClientScript.RegisterStartupScript(Me.GetType, "Show", "$(document).ready(function() {$('#myModal').modal('show');});", True)
    End Sub

    Sub Confirm()
        Dim ClasseGes As ClasseGestion
        'Si le client confirme, mail-to + redirect page de congratulation?
        ClasseGes = Session("MaReservation")
        Session("MaReservation") = Nothing
        Session("MesInfos") = Nothing

        Dim NoChambre As String
        NoChambre = ClasseGes.MaReservation.tblChambreReservationChambre.First.NoSeqChambre
        Dim Chambre = (From tabChambre In MaBD.tblChambre
                      Where tabChambre.NoSeqChambre = NoChambre
                      Select tabChambre).ToList.First

        Session("MonCodeHotel") = Chambre.CodeHotel

        Session("ReservationDone") = True
        Response.Redirect("~/PostReservation.aspx")
    End Sub

    Sub Annuler()
        Dim ClasseGes As ClasseGestion
        'Si le client refuse, supprime la réservation de la bd + redirect accueil
        ClasseGes = Session("MaReservation")

        Dim MaBD As New P2014_BD_GestionHotelEntities

        ClasseGes.AnnulerReservation()

        Session("MaReservation") = Nothing

        Response.Redirect("~/Default.aspx")
    End Sub

    Protected Sub btnCalculer_Click(sender As Object, e As EventArgs)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim appUser = manager.FindById(User.Identity.GetUserId)
        Dim ClasseGes As New ClasseGestion

        'Vérifie si la réservation se fait avec un compte client
        If appUser Is Nothing Then
            'Vérifie les champs du client et crée le client
            Dim NomClient As String = txtNom.Text
            Dim PrenomClient As String = txtPrenom.Text
            Dim NoTelephone As String = txtNoTelephone.Text
            Dim Email As String = txtEmail.Text
            Dim Adresse As String = txtAdresse.Text
            Dim CodeVille As String = cmbVille.SelectedValue.ToString()

            'Enregistre le client
            Dim MonResult As Boolean
            MonResult = ClasseGes.EnregistrerClient(NomClient, PrenomClient, NoTelephone, Email, Adresse, CodeVille)
            If Not MonResult Then
                Dim TempCodeForfait As String = Request.QueryString("ID")
                Response.Redirect("~/ReservationForfait?m=ErreurClient&ID=" + TempCodeForfait)
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
            Dim TempCodeForfait As String = Request.QueryString("ID")
            Response.Redirect("~/ReservationForfait?m=NoDates&ID=" + TempCodeForfait)
        End If

        'Valide si les champs ont été rempli
        'On peut pas utiliser les asp:Validator à cause des update panels.
        If NoCarte = "" Or DateExp = "" Or NomDetenteur = "" Then
            Dim TempCodeForfait As String = Request.QueryString("ID")
            Response.Redirect("~/ReservationForfait?m=EmptyFields&ID=" + TempCodeForfait)
        End If

        Dim CodeHotel As String = cmbHotel.SelectedValue

        'La réservation se fait avec seulement 1 chambre d'un type.
        'C'est donc beaucoup plus simple, mais on peut pas réutiliser les
        'fonctions de ClasseGes qui existent déjà :(

        'Créer tblReservationChambre
        Dim result As Boolean
        result = ClasseGes.CreerReservation(appUser, cmbTypeCarte.Text, txtNoCarteCredit.Text, txtDateExpiration.Text, txtNomDetenteurCarte.Text)
        If Not result Then
            Dim TempCodeForfait As String = Request.QueryString("ID")
            Response.Redirect("~/ReservationForfait?m=ErreurReserv&ID=" + TempCodeForfait)
        End If

        'Enregistre les chambres et liaison au forfait
        result = ClasseGes.EnregistrerChambresForfait(DateDebut, DateFin, CodeHotel, ForfaitSelection)
        If Not result Then
            Dim TempCodeForfait As String = Request.QueryString("ID")
            Response.Redirect("~/ReservationForfait?m=ErreurReserv&ID=" + TempCodeForfait)
        End If

        Session("MaReservation") = ClasseGes

        'Affiche le panel de confirmation
        'DetailReservation.Visible = True
        ConfirmerReservation()
    End Sub

End Class
