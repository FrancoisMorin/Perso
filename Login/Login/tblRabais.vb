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

Partial Public Class tblRabais
    Public Property NoSeqRabais As Integer
    Public Property DescRabais As String
    Public Property DateDebutRabais As Date
    Public Property DateFinRabais As Date
    Public Property PourcentageRabais As Short

    Public Overridable Property tblReservationChambre As ICollection(Of tblReservationChambre) = New HashSet(Of tblReservationChambre)

End Class
