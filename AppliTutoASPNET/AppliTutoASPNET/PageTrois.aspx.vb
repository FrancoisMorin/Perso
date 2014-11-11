Public Class PageTrois
    Inherits System.Web.UI.Page
    Dim MaClasse As MaClasse

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MaClasse = New MaClasse()
    End Sub

    'Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
    '    MaClasse.ReserverChambre(CType(Request.QueryString("id"), Integer))

    '    Dim chaine As String = "alert(""Réservation réussie!"");"

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ServerControlScript", chaine, True)
    'End Sub
End Class