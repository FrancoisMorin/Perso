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

Partial Public Class tblCommande
    Public Property NoCommande As Integer
    Public Property DateCommande As Date
    Public Property StatutCommande As String
    Public Property PrixTotal As Nullable(Of Decimal)
    Public Property DateRecu As Nullable(Of Date)
    Public Property CodeFournisseur As String
    Public Property NoEmploye As Integer

    Public Overridable Property tblFournitureCommande As ICollection(Of tblFournitureCommande) = New HashSet(Of tblFournitureCommande)
    Public Overridable Property tblEmploye As tblEmploye
    Public Overridable Property tblFournisseur As tblFournisseur

End Class