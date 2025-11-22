Public NotInheritable Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = "This program was designed and based off the original Sierra Launcher included with the " & _
        "Sierra Classic Collections.  The intention of this program was to bring a more functional launcher, equiped with  " & _
        "the ability to customize how each game is launched." & _
        ControlChars.NewLine & ControlChars.NewLine & _
        "© 1984-1995 Sierra Entertainment, Inc.  Gabriel Knight, King's Quest, Leisure Suit Larry, Police Quest, Quest for Glory, " & _
        "Roger Wilco, Sierra and the Sierra logo are registered trademarks or trademarks of Sierra Entertainment, Inc., in the U.S. and/or other countries.  " & _
        "Space Quest is a registered trademark of the Children’s Museum of Indianapolis, Inc., used under license. All rights reserved. " & _
        "All other trademarks and trade names are the properties of their respective owners." & _
        ControlChars.NewLine & ControlChars.NewLine & _
        "Activision, Gabriel Knight, Police Quest, King’s Quest, Quest for Glory, and other content are registered trademarks of Activision Publishing, Inc. " & _
        "Leisure Suit Larry is a registered trademark of The Codemasters Software Company Limited ('Codemasters'). All rights reserved. " & _
        "All other trademarks and trade names are the properties of their respective owners."
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class
