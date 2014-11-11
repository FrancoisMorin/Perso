﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré à partir d'un modèle.
'
'     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
'     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class P2014_BD_GestionHotelEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=P2014_BD_GestionHotelEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property tblCategorieFourniture() As DbSet(Of tblCategorieFourniture)
    Public Overridable Property tblCommande() As DbSet(Of tblCommande)
    Public Overridable Property tblFournisseur() As DbSet(Of tblFournisseur)
    Public Overridable Property tblFourniture() As DbSet(Of tblFourniture)
    Public Overridable Property tblFournitureChambre() As DbSet(Of tblFournitureChambre)
    Public Overridable Property tblFournitureCommande() As DbSet(Of tblFournitureCommande)
    Public Overridable Property tblFournitureFournisseur() As DbSet(Of tblFournitureFournisseur)
    Public Overridable Property tblFournitureHotel() As DbSet(Of tblFournitureHotel)
    Public Overridable Property tblChiffreTravail() As DbSet(Of tblChiffreTravail)
    Public Overridable Property tblEmploye() As DbSet(Of tblEmploye)
    Public Overridable Property tblEntretienFournitureChambre() As DbSet(Of tblEntretienFournitureChambre)
    Public Overridable Property tblEntretienFournitureSalle() As DbSet(Of tblEntretienFournitureSalle)
    Public Overridable Property tblChambre() As DbSet(Of tblChambre)
    Public Overridable Property tblChambreReservationChambre() As DbSet(Of tblChambreReservationChambre)
    Public Overridable Property tblClient() As DbSet(Of tblClient)
    Public Overridable Property tblFacture() As DbSet(Of tblFacture)
    Public Overridable Property tblForfait() As DbSet(Of tblForfait)
    Public Overridable Property tblFournitureReservationSalle() As DbSet(Of tblFournitureReservationSalle)
    Public Overridable Property tblHotel() As DbSet(Of tblHotel)
    Public Overridable Property tblPays() As DbSet(Of tblPays)
    Public Overridable Property tblPrixTypeChambre() As DbSet(Of tblPrixTypeChambre)
    Public Overridable Property tblProvince() As DbSet(Of tblProvince)
    Public Overridable Property tblRabais() As DbSet(Of tblRabais)
    Public Overridable Property tblReservationChambre() As DbSet(Of tblReservationChambre)
    Public Overridable Property tblReservationSalle() As DbSet(Of tblReservationSalle)
    Public Overridable Property tblSalle() As DbSet(Of tblSalle)
    Public Overridable Property tblTypeChambre() As DbSet(Of tblTypeChambre)
    Public Overridable Property tblVille() As DbSet(Of tblVille)
    Public Overridable Property VueInventaire() As DbSet(Of VueInventaire)

    Public Overridable Function VerificationDispo(dateDebut As Nullable(Of Date), dateFin As Nullable(Of Date)) As ObjectResult(Of VerificationDispo_Result)
        Dim dateDebutParameter As ObjectParameter = If(dateDebut.HasValue, New ObjectParameter("DateDebut", dateDebut), New ObjectParameter("DateDebut", GetType(Date)))

        Dim dateFinParameter As ObjectParameter = If(dateFin.HasValue, New ObjectParameter("DateFin", dateFin), New ObjectParameter("DateFin", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of VerificationDispo_Result)("VerificationDispo", dateDebutParameter, dateFinParameter)
    End Function

End Class
