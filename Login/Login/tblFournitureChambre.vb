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

Partial Public Class tblFournitureChambre
    Public Property NoSeqChambre As Integer
    Public Property CodeFourniture As String
    Public Property QuantiteChambre As Short

    Public Overridable Property tblFourniture As tblFourniture
    Public Overridable Property tblChambre As tblChambre
    Public Overridable Property tblEntretienFournitureChambre As ICollection(Of tblEntretienFournitureChambre) = New HashSet(Of tblEntretienFournitureChambre)

End Class
