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

Partial Public Class tblTypeChambre
    Public Property CodeTypeChambre As String
    Public Property NomTypeChambre As String
    Public Property DescTypeChambre As String

    Public Overridable Property tblChambre As ICollection(Of tblChambre) = New HashSet(Of tblChambre)
    Public Overridable Property tblForfait As ICollection(Of tblForfait) = New HashSet(Of tblForfait)
    Public Overridable Property tblPrixTypeChambre As ICollection(Of tblPrixTypeChambre) = New HashSet(Of tblPrixTypeChambre)

End Class
