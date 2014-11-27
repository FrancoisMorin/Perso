Public Class ClasseGestion
    Dim BD As P2014_BD_GestionHotelEntities

    Public MaReservation As tblReservationChambre

    Dim ListeDetailsReservation As List(Of DetailsReservation)

    Dim ListeChambreDispo As List(Of VerificationDispo_Result)
    Dim ListeChambreReservation As List(Of tblChambreReservationChambre)

    Structure DetailsReservation
        Dim NombreChambre As Integer
        Dim TypeChambre As String
    End Structure

    Sub New()
        BD = New P2014_BD_GestionHotelEntities
        ListeDetailsReservation = New List(Of DetailsReservation)
        ListeChambreReservation = New List(Of tblChambreReservationChambre)
    End Sub

    Public Function RechercheHotel(ByRef _DateDebut As Date, ByRef _DateFin As Date, ByRef _NomVille As String) As List(Of tblHotel)
        Dim ListeHotel As New List(Of tblHotel)
        Dim ListeCodeHotel As New List(Of String)

        Dim NomVille As String = _NomVille

        ListeCodeHotel = (From tabChambre In BD.VerificationDispo(_DateDebut, _DateFin)
                       Select tabChambre.CodeHotel).Distinct.ToList

        For Each CodeHotel As String In ListeCodeHotel
            Dim NewHotel As New tblHotel

            If NomVille <> "" Then
                Try
                    NewHotel = (From tabHotel In BD.tblHotel
                                Join tabVille In BD.tblVille On tabHotel.CodeVille Equals tabVille.CodeVille
                                Where tabHotel.CodeHotel = CodeHotel And tabVille.NomVille.StartsWith(NomVille)
                                Select tabHotel).ToList.First

                    ListeHotel.Add(NewHotel)
                Catch ex As Exception

                End Try
            Else
                Try
                    NewHotel = (From tabHotel In BD.tblHotel
                                                        Join tabVille In BD.tblVille On tabHotel.CodeVille Equals tabVille.CodeVille
                                                       Where tabHotel.CodeHotel = CodeHotel
                                                       Select tabHotel).ToList.First

                    ListeHotel.Add(NewHotel)
                Catch ex As Exception

                End Try
            End If
        Next

        Return ListeHotel
    End Function

    Public Function AjoutDetailReservation(ByRef _CodeTypeChambre As String, ByRef _NbChambre As Integer) As Boolean

        'Recherche si le type de chambre a déjà été ajouté.
        'Si oui, ajuste le nombre de chambre.
        For Each Detail As DetailsReservation In ListeDetailsReservation
            If Detail.TypeChambre = _CodeTypeChambre Then
                Detail.NombreChambre = _NbChambre
                Return True
            End If
        Next

        'Le type de chambre n'a pas encore été ajouté, crée le dans la liste
        Dim NewDetail As DetailsReservation
        NewDetail.TypeChambre = _CodeTypeChambre
        NewDetail.NombreChambre = _NbChambre
        ListeDetailsReservation.Add(NewDetail)

        Return True
    End Function

    Public Function FaireReservationTypeChambre(ByRef _CodeHotel As String, ByRef _DateDebut As Date, ByRef _DateFin As Date) As Boolean

        Dim NbChambre As Integer = 0
        'Regarde si il y a eu au moins une chambre de choisi.
        For Each Detail As DetailsReservation In ListeDetailsReservation
            NbChambre += Detail.NombreChambre
        Next
        'Si aucune chambre n'a été selectionné, message d'erreur.
        If NbChambre = 0 Then
            BD.tblReservationChambre.Remove(MaReservation)
            BD.SaveChanges()
            Return False
        End If


        Dim CodeHotel As String = _CodeHotel

        'Prend la liste des chambres disponibles
        Dim res = From tabChambre In BD.VerificationDispo(_DateDebut, _DateFin)
                  Where tabChambre.CodeHotel = CodeHotel
                  Select tabChambre


        ListeChambreDispo = res.ToList

        Dim i As Integer = 0

        'Pour chaque type de chambre, cherche si y en
        For Each Detail As DetailsReservation In ListeDetailsReservation
            i = 0
            For Each Chambre As VerificationDispo_Result In ListeChambreDispo

                If i = Detail.NombreChambre Then
                    Exit For
                End If

                If Chambre.CodeTypeChambre = Detail.TypeChambre Then

                    Dim ChambreReservation As New tblChambreReservationChambre
                    ChambreReservation.NoSeqChambre = Chambre.NoSeqChambre
                    ChambreReservation.NoSeqReservChambre = MaReservation.NoSeqReservChambre
                    ChambreReservation.NbPersonne = "1"
                    ChambreReservation.NomLocataire = "Temp"
                    ChambreReservation.PrenomLocataire = "Temp"
                    ChambreReservation.DateDebutReservation = _DateDebut
                    ChambreReservation.DateFinReservation = _DateFin
                    ChambreReservation.StatutChambreReservChambre = "Temp"

                    ListeChambreReservation.Add(ChambreReservation)
                    i += 1
                End If
            Next
        Next

        'Compte le nombre de chambre que le client voulais
        Dim CompteurChambre As Integer
        For Each Detail As DetailsReservation In ListeDetailsReservation
            CompteurChambre += Detail.NombreChambre
        Next

        'Si le nombre de chambre de la liste de disponible est plus petit que le nombre qu'il voulait,
        'Ça veut dire qu'il n'y a pas asser de chambre dispo.
        If ListeChambreReservation.Count < CompteurChambre Then
            Return False
        End If

        Return True

    End Function

    Public Function CreerReservation(ByRef _MonUser As ApplicationUser, ByRef _TypeCarte As String, ByRef _NoCarteCredit As String, ByRef _DateExpiration As String, ByRef _NomDetenteur As String) As Boolean

        Try
            MaReservation = New tblReservationChambre
            MaReservation.TypeCarteCredit = _TypeCarte
            MaReservation.NoCarteCredit = _NoCarteCredit
            MaReservation.DateExpirationCarteCredit = _DateExpiration
            MaReservation.NomCarteCredit = _NomDetenteur
            MaReservation.NoSeqClient = _MonUser.Id
            MaReservation.ModePaiement = "Carte credit"
            MaReservation.StatutPaiement = "Non payé"
            MaReservation.StatutReservChambre = "En attente"

            BD.tblReservationChambre.Add(MaReservation)
            BD.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnregistrerChambresReservation() As Boolean

        Dim PrixReservation As Double = 0

        Try
            For Each Chambre As tblChambreReservationChambre In ListeChambreReservation

                PrixReservation += (From tabPrixChambre In BD.tblPrixTypeChambre
                                   Where tabPrixChambre.CodeTypeChambre = Chambre.NoSeqChambre And (Chambre.DateDebutReservation > tabPrixChambre.DateDebutPrix And Chambre.DateFinReservation < tabPrixChambre.DateFinPrix) And tabPrixChambre.CodeHotel = Chambre.tblChambre.CodeHotel
                                   Select tabPrixChambre).ToList.First.PrixTypeChambre

                BD.tblChambreReservationChambre.Add(Chambre)
                BD.SaveChanges()
            Next
            MaReservation.PrixReservChambre = PrixReservation
            Return True
        Catch ex As Exception
            Return False
        End Try


        Return True
    End Function

End Class
