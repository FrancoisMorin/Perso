' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class ClasseGestion
    Dim BD As P2014_BD_GestionHotelEntities

    Public MaReservation As tblReservationChambre
    Public MonClient As tblClient

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
                ListeDetailsReservation.Remove(Detail)

                Dim NewDetail2 As New DetailsReservation
                NewDetail2.TypeChambre = _CodeTypeChambre
                NewDetail2.NombreChambre = _NbChambre
                ListeDetailsReservation.Add(NewDetail2)
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

                'Si on a réservé le nombre de chambres (du type de chambre) qu'on voulait, sors du for.
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
            BD.tblReservationChambre.Remove(MaReservation)
            BD.SaveChanges()
            Return False
        End If

        Return True

    End Function

    Public Function CreerReservation(ByRef _MonUser As ApplicationUser, ByRef _TypeCarte As String, ByRef _NoCarteCredit As String, ByRef _DateExpiration As String, ByRef _NomDetenteur As String) As Boolean

        Try
            MaReservation = New tblReservationChambre
            MaReservation.TypeCarteCredit = _TypeCarte

            'Valider le numéro de carte de crédit
            _NoCarteCredit.Trim(" ")
            Dim regex As Regex = New Regex("^\d{15,16}")
            Dim match As Match = regex.Match(_NoCarteCredit)
            If match.Success Then
                MaReservation.NoCarteCredit = _NoCarteCredit
            Else
                Return False
            End If

            'Valider date expiration
            Dim regex2 As Regex = New Regex("\b\d\d\d\d\b")
            Dim match2 As Match = regex2.Match(_DateExpiration)
            If match2.Success Then
                MaReservation.DateExpirationCarteCredit = _DateExpiration
            Else
                Return False
            End If

            MaReservation.NomCarteCredit = _NomDetenteur
            MaReservation.ModePaiement = "Carte credit"
            MaReservation.StatutPaiement = "Non payé"
            MaReservation.StatutReservChambre = "En attente"

            'Si le user n'est pas connecté, il faut utiliser le client qui vient d'être créée
            If _MonUser Is Nothing Then
                MaReservation.NoSeqClient = MonClient.NoSeqClient
            Else
                MaReservation.NoSeqClient = _MonUser.Id
            End If

            BD.tblReservationChambre.Add(MaReservation)
            BD.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnregistrerChambresReservation(ByRef _DateDebut As Date, ByRef _DateFin As Date) As Boolean

        Dim PrixReservation As Double = 0

        Try
            For Each Chambre As tblChambreReservationChambre In ListeChambreReservation

                Dim MaChambre As New tblChambre

                MaChambre = (From tabChambre In BD.tblChambre
                            Where tabChambre.NoSeqChambre = Chambre.NoSeqChambre).ToList.First

                Dim MonPrix = From tabPrixChambre In BD.tblPrixTypeChambre
                              Where tabPrixChambre.CodeTypeChambre = MaChambre.CodeTypeChambre And (Chambre.DateDebutReservation > tabPrixChambre.DateDebutPrix And Chambre.DateFinReservation < tabPrixChambre.DateFinPrix) And tabPrixChambre.CodeHotel = MaChambre.CodeHotel
                              Select tabPrixChambre.PrixTypeChambre

                PrixReservation = PrixReservation + MonPrix.ToList.First

                BD.tblChambreReservationChambre.Add(Chambre)
                BD.SaveChanges()
            Next

            'Maintenant qu'on a le prix total, multiplier par le nombre de nuits et l'ajouter à la réservation.
            Dim NbNuit As Integer = _DateFin.Subtract(_DateDebut).TotalDays
            MaReservation.PrixReservChambre = PrixReservation * NbNuit
            BD.SaveChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try


        Return True
    End Function

    Function EnregistrerClient(ByRef _Nom As String, ByRef _Prenom As String, ByRef _NoTelephone As String, ByRef _Email As String, ByRef _Adresse As String, ByRef _CodeVille As String) As Boolean
        If _Nom = "" Or _Prenom = "" Or _NoTelephone = "" Or _Email = "" Or _Adresse = "" Or _CodeVille = "" Then
            'Les infos de bases nécessaires n'ont pas toutes été remplies.
            Return False
        End If

        Try
            BD = New P2014_BD_GestionHotelEntities
            'Crée le client
            MonClient = New tblClient
            'Rempli les info nécessaire
            MonClient.NomClient = _Nom
            MonClient.PrenomClient = _Prenom

            _NoTelephone.TrimEnd(" ")
            _NoTelephone.TrimStart(" ")
            'Valider le No.Telephone
            Dim regex As Regex = New Regex("\b\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})\b")
            Dim match As Match = regex.Match(_NoTelephone)
            If match.Success Then
                MonClient.NoTelephone = _NoTelephone
            Else
                Return False
            End If

            _Email.Trim(" ")
            'Valider le email
            Dim regex2 As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            Dim match2 As Match = regex2.Match(_Email)
            If match2.Success Then
                MonClient.EmailClient = _Email
            Else
                Return False
            End If

            MonClient.AdresseClient = _Adresse.Trim(" ")
            MonClient.CodeVille = _CodeVille

            'On veut garder la réservation simple, donc les informations non-obligatoires seront vide.
            MonClient.NoCellulaire = ""
            MonClient.AdresseSecondaireClient = ""
            MonClient.MdpClient = ""
            MonClient.CodePostal = ""
            MonClient.NomEntreprise = ""

            BD.tblClient.Add(MonClient)
            BD.SaveChanges()
        Catch ex As Exception
            'Des champs ne sont pas valide
            Return False
        End Try

        Return True
    End Function

    Public Sub AnnulerReservation()
        'Supprimer les ChambresReservationChambre
        For Each ChambreReserv As tblChambreReservationChambre In ListeChambreReservation
            BD.tblChambreReservationChambre.Remove(ChambreReserv)
        Next
        'Supprimer la réservation
        BD.tblReservationChambre.Remove(MaReservation)
        BD.SaveChanges()
    End Sub

    Public Function EnregistrerChambresForfait(ByRef _DateDebut As Date, ByRef _DateFin As Date, ByRef _CodeHotel As String, ByRef _MonForfait As tblForfait) As Boolean
        Dim MonForfait As tblForfait = _MonForfait

        Dim Forfait = (From tabForfait In BD.tblForfait
                     Where tabForfait.CodeForfait = MonForfait.CodeForfait
                     Select tabForfait).ToList.First

        'Créer la liste de ChambreRéservationChambre

        Dim TypeChambre As String = MonForfait.CodeTypeChambre
        Dim CodeHotel As String = _CodeHotel

        'Prend la liste des chambres disponibles
        Dim res = From tabChambre In BD.VerificationDispo(_DateDebut, _DateFin)
                  Where tabChambre.CodeHotel = CodeHotel And tabChambre.CodeTypeChambre = TypeChambre
                  Select tabChambre

        ListeChambreDispo = res.ToList

        'Pour l'instant c'est dit que un forfait est une réservation 
        'd'UNE seule chambre avec des activité. On garde la possibilité
        'd'avoir plusieurs chambres dans un forfait plus tard.
        Dim NbChambre As Integer = 1
        Dim Compteur As Integer = 0

        For Each Chambre As VerificationDispo_Result In ListeChambreDispo

            If Compteur = NbChambre Then
                Exit For
            End If

            Dim ChambreReservation As New tblChambreReservationChambre
            ChambreReservation.NoSeqChambre = Chambre.NoSeqChambre
            ChambreReservation.NoSeqReservChambre = MaReservation.NoSeqReservChambre
            ChambreReservation.NbPersonne = "1"
            ChambreReservation.NomLocataire = "Temp"
            ChambreReservation.PrenomLocataire = "Temp"
            ChambreReservation.DateDebutReservation = _DateDebut
            ChambreReservation.DateFinReservation = _DateFin
            ChambreReservation.StatutChambreReservChambre = "Temp"
            ChambreReservation.tblForfait.Add(Forfait)

            ListeChambreReservation.Add(ChambreReservation)
            Compteur = Compteur + 1
        Next

        'Vérification du nombre de chambre disponible trouvé
        'Encore, pas trop important ici mais on garde pour plus tard.
        If ListeChambreReservation.Count < NbChambre Then
            BD.tblReservationChambre.Remove(MaReservation)
            BD.SaveChanges()
            Return False
        End If

        'Fixe le prix de la réservation
        MaReservation.PrixReservChambre = Forfait.PrixForfait

        'Entre les chambres dans la BD
        For Each Chambre As tblChambreReservationChambre In ListeChambreReservation
            BD.tblChambreReservationChambre.Add(Chambre)
        Next

        Try
            BD.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Sub Enregistrer()
        'Enregistre les ChambreReservationChambre dans la BD
        For Each MaChambre As tblChambreReservationChambre In ListeChambreReservation
            BD.tblChambreReservationChambre.Add(MaChambre)
            BD.SaveChanges()
        Next
    End Sub

End Class
