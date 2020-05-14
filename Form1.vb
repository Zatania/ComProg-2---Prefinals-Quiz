Imports System.IO
Public Class Form1
    Private saveTxt As New SaveFileDialog
    Private openTxt As New OpenFileDialog
    Private fontStyle As New FontDialog

    Private FileReader As StreamReader
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            openTxt.FileName = ""
            openTxt.Filter = "Text file only (*.txt)|*.txt"
            openTxt.Title = "Open"
            openTxt.Multiselect = False

            If (openTxt.ShowDialog = DialogResult.OK) Then
                Using reader As StreamReader = New StreamReader(openTxt.FileName)
                    RichTextBox1.Text = reader.ReadToEnd()

                    reader.Close()
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            saveTxt.FileName = ""
            saveTxt.Filter = "Text file only (*.txt)|*.txt"
            saveTxt.Title = "Save As"

            If (saveTxt.ShowDialog = DialogResult.OK) Then
                Using writer As StreamWriter = New StreamWriter(saveTxt.FileName)
                    writer.Write(RichTextBox1.Text)

                    writer.Close()
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        fontStyle.Font = New Font("Consolas", 11)

        fontStyle.ShowDialog()
        RichTextBox1.Font = fontStyle.Font
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Hide()
        About.Show()
    End Sub
End Class
