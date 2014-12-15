' ------------------------------------------------------------------------------------------- 
' Créée le : 10 novembre 2014
' Par : François Morin
' Date de dernière modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

'------------------------------------------------------------------------------
' <généré automatiquement>
'     Ce code a été généré par un outil.
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </généré automatiquement>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Reservation

    '''<summary>
    '''Contrôle TitreNomHotel.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents TitreNomHotel As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle MessagePlaceHolder.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MessagePlaceHolder As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contrôle ListeTypeChambre.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ListeTypeChambre As Global.System.Web.UI.WebControls.ListView

    '''<summary>
    '''Contrôle MonPanelClient.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonPanelClient As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contrôle MonPlaceHolder.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonPlaceHolder As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contrôle Label5.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label5 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtNom.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle Label6.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label6 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtPrenom.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtPrenom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle Label7.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label7 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtNoTelephone.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNoTelephone As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle Label8.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label8 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtEmail.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtEmail As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle Label9.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label9 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtAdresse.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtAdresse As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle cmbPays.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbPays As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contrôle cmbProvince.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbProvince As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contrôle cmbVille.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbVille As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contrôle UpdatePanel1.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents UpdatePanel1 As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Contrôle txtDateDebut.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtDateDebut As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle btnExpandCalendarDebut.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnExpandCalendarDebut As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle CalendrierDebut.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents CalendrierDebut As Global.System.Web.UI.WebControls.Calendar

    '''<summary>
    '''Contrôle UpdatePanel2.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents UpdatePanel2 As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Contrôle txtDateFin.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtDateFin As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle btnExpandCalendarFin.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnExpandCalendarFin As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle CalendrierFin.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents CalendrierFin As Global.System.Web.UI.WebControls.Calendar

    '''<summary>
    '''Contrôle Label1.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle cmbTypeCarte.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbTypeCarte As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contrôle Label2.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtNoCarteCredit.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNoCarteCredit As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle Label3.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label3 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtDateExpiration.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtDateExpiration As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle Label4.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label4 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtNomDetenteurCarte.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNomDetenteurCarte As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle btnCalculer.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnCalculer As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle Label10.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label10 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle lblDateDebut.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblDateDebut As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle Label12.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label12 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle lblDateFin.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblDateFin As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle Label14.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label14 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle lblNomReserv.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblNomReserv As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle Label16.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label16 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle lblPrixTotal.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblPrixTotal As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle Label18.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label18 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle lblTypeCarte.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblTypeCarte As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle Label20.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label20 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle lblNoCarte.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblNoCarte As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle Button1.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Button1 As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle Button2.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Button2 As Global.System.Web.UI.WebControls.Button
End Class
