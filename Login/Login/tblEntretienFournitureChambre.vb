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

Partial Public Class tblEntretienFournitureChambre
    Public Property NoSeqEntretienChambre As Integer
    Public Property EtatFourniture As String
    Public Property CommentaireFourniture As String
    Public Property DateDemande As Date
    Public Property DateEffectue As Nullable(Of Date)
    Public Property StatutEntretien As String
    Public Property CodeFourniture As String
    Public Property NoSeqChambre As Integer
    Public Property NoEmploye As Integer

    Public Overridable Property tblFournitureChambre As tblFournitureChambre
    Public Overridable Property tblEmploye As tblEmploye

End Class
