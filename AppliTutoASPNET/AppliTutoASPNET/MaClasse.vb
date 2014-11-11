Public Class MaClasse
    Dim MaBD As P2014_BD_GestionHotelEntities

    Dim VilleSelection As tblVille
    Dim ProvinceSelection As tblProvince
    Dim PaysSelection As tblPays

    Sub New()
        MaBD = New P2014_BD_GestionHotelEntities
    End Sub

    Public Function RetourneInfoChambre(ByRef _NoSeqChambre As Integer)
        Dim NoSeqChambre As Integer = _NoSeqChambre
        Dim Chambre As tblChambre

        Chambre = (From tabChambre In MaBD.tblChambre
                  Where tabChambre.NoSeqChambre = NoSeqChambre
                  Select tabChambre).ToList.First

        Return Chambre
    End Function

    Public Function EnregistrerClient(ByRef _CodeVille As String, ByRef _CodePostal As String, ByRef _Email As String, ByRef _NoTelephone As String, ByRef _Adresse1 As String, ByRef _Nom As String, ByRef _Prenom As String, Optional ByRef _NoCellulaire As String = Nothing, Optional ByRef _Adresse2 As String = Nothing, Optional ByRef _NomEntreprise As String = Nothing)
        Dim Nom As String = _Nom
        Dim Prenom As String = _Prenom
        Dim NoTelephone As String = _NoTelephone
        Dim NoCellulaire As String = _NoCellulaire
        Dim Adresse1 As String = _Adresse1
        Dim Adresse2 As String = _Adresse2
        Dim Email As String = _Email
        Dim CodePostal As String = _CodePostal
        Dim NomEntreprise As String = _NomEntreprise

        Try
            Dim res = (From tabClient In MaBD.tblClient
                  Where tabClient.NomClient = Nom And tabClient.PrenomClient = Prenom And tabClient.CodePostal = CodePostal And tabClient.EmailClient = Email
                  Select tabClient).ToList.First

            'Le client existe déjà.
            Return False
        Catch ex As Exception

            Dim Client As New tblClient
            Client.NomClient = _Nom
            Client.PrenomClient = _Prenom
            Client.NoTelephone = _NoTelephone
            Client.NoCellulaire = _NoCellulaire
            Client.AdresseClient = _Adresse1
            Client.AdresseSecondaireClient = _Adresse2
            Client.EmailClient = _Email
            Client.NomEntreprise = _NomEntreprise
            Client.CodeVille = _CodeVille

            MaBD.tblClient.Add(Client)
            MaBD.SaveChanges()

            'Le client a été créé
            Return True
        End Try
    End Function

    Public Sub ReserverChambre(ByRef _NoSeqChambre As Integer)
        Dim Reserv As New tblReservationChambre
        Dim ChambreReserv As New tblChambreReservationChambre

        Try
            Reserv.StatutReservChambre = "En cours"
            Reserv.PrixReservChambre = 100.0
            Reserv.ModePaiement = "Argent"
            Reserv.StatutPaiement = "Non payé"
            Reserv.NoCarteCredit = "172038276357289"
            Reserv.DateExpirationCarteCredit = "0101"
            Reserv.TypeCarteCredit = "Mastercard"
            Reserv.NomCarteCredit = "RESERVTEST"
            Reserv.NoSeqClient = 1000

            MaBD.tblReservationChambre.Add(Reserv)
            MaBD.SaveChanges()

            Try
                ChambreReserv.NoSeqChambre = _NoSeqChambre
                ChambreReserv.NoSeqReservChambre = Reserv.NoSeqReservChambre
                ChambreReserv.NbPersonne = 1
                ChambreReserv.NomLocataire = "Nicolas"
                ChambreReserv.PrenomLocataire = "Larouche"
                ChambreReserv.DateDebutReservation = "01/01/2014"
                ChambreReserv.DateFinReservation = "01/01/2014"
                ChambreReserv.StatutChambreReservChambre = "Occupé"

                MaBD.tblChambreReservationChambre.Add(ChambreReserv)
                MaBD.SaveChanges()
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub


End Class
