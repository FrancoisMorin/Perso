Public Class ClasseGestion
    Dim BD As P2014_BD_GestionHotelEntities

    Sub New()
        BD = New P2014_BD_GestionHotelEntities
    End Sub

    Public Function RechercheHotel(ByRef _DateDebut As Date, ByRef _DateFin As Date) As List(Of tblHotel)
        Dim ListeHotel As New List(Of tblHotel)
        Dim ListeCodeHotel As New List(Of String)

        ListeCodeHotel = (From tabChambre In BD.VerificationDispo(_DateDebut, _DateFin)
                       Select tabChambre.CodeHotel).Distinct.ToList

        For Each CodeHotel As String In ListeCodeHotel
            Dim NewHotel As New tblHotel

            NewHotel = (From tabHotel In BD.tblHotel
                       Where tabHotel.CodeHotel = CodeHotel
                       Select tabHotel).ToList.First

            ListeHotel.Add(NewHotel)
        Next

        Return ListeHotel
    End Function



    'Public Function RechercheChambre(ByRef _CodeHotel As String, ByRef _DateDebut As Date, ByRef _DateFin As Date) As List(Of tblChambre)
    '    Dim ListeChambre As New List(Of tblChambre)

    '    ListeChambre = From tabChambre In BD.VerificationDispo(_DateDebut, _DateFin)

    '    For Each Chambre As tblChambre In ListeChambre

    '    Next


    '    Return ListeChambre
    'End Function


End Class
