' ------------------------------------------------------------------------------------------- 
' Cr��e le : 10 novembre 2014
' Par : Fran�ois Morin
' Date de derni�re modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

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

Partial Public Class tblFacture
    Public Property NoSeqFacture As Integer
    Public Property MontantFacture As Nullable(Of Decimal)
    Public Property TypeFacture As String
    Public Property NoSeqReservChambre As Integer
    Public Property NoEmploye As Integer

    Public Overridable Property tblReservationChambre As tblReservationChambre

End Class
