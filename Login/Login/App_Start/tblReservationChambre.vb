'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré à partir d'un modèle.
'
'     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
'     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class tblReservationChambre
    Public Property NoSeqReservChambre As Integer
    Public Property StatutReservChambre As String
    Public Property PrixReservChambre As Nullable(Of Decimal)
    Public Property ModePaiement As String
    Public Property StatutPaiement As String
    Public Property NoCarteCredit As String
    Public Property DateExpirationCarteCredit As String
    Public Property TypeCarteCredit As String
    Public Property NomCarteCredit As String
    Public Property NoSeqClient As Integer
    Public Property NoSeqRabais As Nullable(Of Integer)

    Public Overridable Property tblChambreReservationChambre As ICollection(Of tblChambreReservationChambre) = New HashSet(Of tblChambreReservationChambre)
    Public Overridable Property tblClient As tblClient
    Public Overridable Property tblFacture As ICollection(Of tblFacture) = New HashSet(Of tblFacture)
    Public Overridable Property tblRabais As tblRabais

End Class
