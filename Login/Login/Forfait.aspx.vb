' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class Forfait
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BD As New P2014_BD_GestionHotelEntities

        Dim res = From tabForfait In BD.tblForfait
                  Select tabForfait

        ListeForfait.DataSource = res.ToList
        ListeForfait.DataBind()

        If (Not IsPostBack) Then
            Dim CodeForfait As String = Request.QueryString("ID")

            'Prend le forfait placé dans l'URL si un forfait a été choisi
            If CodeForfait = "" Then
                Exit Sub
            Else
                Dim resForfait = From tabForfait In BD.tblForfait
                                 Where tabForfait.CodeForfait = CodeForfait
                                 Select tabForfait

                'Valide qu'un forfait a été trouvé
                If resForfait.ToList IsNot Nothing Then
                    ForfaitTrouve(resForfait.ToList.First)
                Else
                    ForfaitPasTrouve()
                End If
            End If
        End If
    End Sub

    Sub ForfaitTrouve(ByRef _Forfait As tblForfait)
        Dim BD As New P2014_BD_GestionHotelEntities
        Dim MonForfait As tblForfait = _Forfait
        'Affiche le panel d'informations du forfait et rentre les infos dedans
        InformationForfait.Visible = True
        AucunForfait.Visible = False
        btnReserver.HRef = "ReservationForfait.aspx?ID=" + MonForfait.CodeForfait

        'Si on n'est pas dans les dates de disponibilité du forfait,
        'le bouton de réservation est disabled
        If (DateTime.Now.ToShortDateString < MonForfait.DateDebut) Or (DateTime.Now.ToShortDateString > MonForfait.DateFin) Then
            btnReserver.Disabled = True
            btnReserver.Attributes.Add("class", "btn btn-success disabled")
        Else
            btnReserver.Disabled = False
            btnReserver.Attributes.Add("class", "btn btn-success")
        End If


        'Récupère le nom du type de chambre du forfait
        Dim NomTypeChambre As String
        Dim resNomTypeChambre = From tabTypeChambre In BD.tblTypeChambre
                                Where tabTypeChambre.CodeTypeChambre = MonForfait.CodeTypeChambre
                                Select tabTypeChambre

        NomTypeChambre = resNomTypeChambre.First.NomTypeChambre

        LabelNbNuit.Text = MonForfait.NbNuit
        LabelPrixForfait.Text = MonForfait.PrixForfait.ToString("0.00 $")
        LabelDateDebut.Text = MonForfait.DateDebut
        LabelDateFin.Text = MonForfait.DateFin
        LabelTypeChambre.Text = NomTypeChambre

        LabelTitre.Text = _Forfait.NomForfait
        LabelDescription.Text = _Forfait.DescForfait
    End Sub

    Sub ForfaitPasTrouve()
        InformationForfait.Visible = False
        AucunForfait.Visible = True
    End Sub

End Class
