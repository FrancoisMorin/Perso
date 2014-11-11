Public Class ClasseDeGestion
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New()
        MaBD = New P2014_BD_GestionHotelEntities
    End Sub

    Public Function GetTypeChambre()
        Dim ListTypeChambre = From tabTypChamb In MaBD.tblTypeChambre
                              Select tabTypChamb

        Return ListTypeChambre
    End Function
End Class
