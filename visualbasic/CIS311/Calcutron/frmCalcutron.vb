'________________________
' File Name: frmCalcutron
' Part of: Assignment 06
' Written By: Brett Previdi
' Written On: 2021 - 02 - 24
'________________________
' File Purpose: 
' This is the home file for the project and is also the startup form for the assignment. This is the parent for all
' instances of the child form. New instances can be created in the file tab, all instances can be set to a specific
' view mode in the window tab, and an about screen is available under help. The form will close completely from this 
' only if all instances of the child form are closed.
'________________________
' Program Purpose:
' Calcutron 3000 is a part of a large family of calulators created by Calcucorp INC which began all the way back in 
' 2021. The Calcutron 3000 Home will allow the user to create as many windows containing the Calcutron 3000 as they 
' please; each window of Calcutron 3000 will operate entirely on their own! The Calcutron 3000 Home will keep track
' of how many windows are open and allow the user to display them as they please within the Calcutron 3000 Home
' window. Operations included in the Calcutron 3000 include addition, subtraction, square root, sine, cosine, tangent,
' exponents, and more in both float AND integer mode!* As a number is entered on the display, it is stored to be used
' in operations that require a second number to be performed. For example, 2 is entered, then the addition sign, and 
' another 2, the Caclutron 3000 will remember the first 2 and perform the operation! 
'
' * Some functions may not be available in integer mode. Square Root function will not be available to negative numbers.
'________________________
' No Global Variables
'________________________
'--------------------------------------------------------------------------------------------------------------------
'________________________
' Sub Name: frmCalcutron_Load
' Written By: Brett Previdi
' Written On: 2021 - 02 - 24
'________________________
' Upon load, this subroutune simply open an initial calculator form so the user can get to calculating ASAP.
Public Class frmCalcutron
    Private Sub frmCalcutron_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mnuFile_New_Click(sender, e)
    End Sub
    '________________________
    ' Sub Name: mnuFile_New_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' When a new child form is created by using the NEW button or the shortcut, the child is created and 
    ' given a name before being displayed within the parent window.
    Private Sub mnuFile_New_Click(sender As Object, e As EventArgs) Handles mnuFile_New.Click
        Dim frmNewCalcChild As New frmCalcChild ' Create the new child.
        My.Application.intFormCount += 1 ' Increment the amount of children created total.
        frmNewCalcChild.Name &= " #" & Trim(CStr(My.Application.intFormCount)) ' Change the name of the new child to show which iteration it is.
        frmNewCalcChild.Text = frmNewCalcChild.Name ' Assign the name.
        frmNewCalcChild.MdiParent = Me ' Assign the parent of the new child to this form.
        frmNewCalcChild.Show() ' Show the new child.
    End Sub
    '________________________
    ' Sub Name: mnuFile_Exit_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Upon using the EXIT button or shortcut, the closing procedure is called.
    Private Sub mnuFile_Exit_Click(sender As Object, e As EventArgs) Handles mnuFile_Exit.Click
        Me.Close()
    End Sub
    '________________________
    ' Sub Name: mnuWindow_Cascade_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Using the CASCADE tab or shortcut will cascade the existing children windows.
    Private Sub mnuWindow_Cascade_Click(sender As Object, e As EventArgs) Handles mnuWindow_Cascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    '________________________
    ' Sub Name: mnuTile_Hori_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Using the HORIZONTAL TILE tab or shortcut will tile the existing children windows in a horizontal format.
    Private Sub mnuTile_Hori_Click(sender As Object, e As EventArgs) Handles mnuTile_Hori.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    '________________________
    ' Sub Name: mnuTile_Vertical_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Using the VERTICAL TILE tab or shortcut will tile the existing children windows in a vertical format.
    Private Sub mnuTile_Vertical_Click(sender As Object, e As EventArgs) Handles mnuTile_Vertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    '________________________
    ' Sub Name: mnuHelp_About_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Using the ABOUT tab or shortcut will display the about form within the file properties (feat. DJ Avishek)
    Private Sub mnuHelp_About_Click(sender As Object, e As EventArgs) Handles mnuHelp_About.Click
        frmAbout.ShowDialog()
    End Sub
    '________________________
    ' Sub Name: frmCalcutron_Closing
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' When the parent form is prompted to close either by the EXIT tab, shortcut, or exit button on the window itself,
    ' the amount of existing children is looked at to see if any need to be closed first. If the children do not meet
    ' the automatic closing procedure requirements defined in that form, then each child in those circumstances will
    ' prompt the user if they are sure they want to close. If any are left open after this, the parent will also remain
    ' open. Otherwise, it will close the application.
    Private Sub frmCalcutron_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        If Me.MdiChildren.Length > 0 Then ' Checking the amount of children that are open.
            MsgBox("Please close each calculator before closing the main window to ensure you do not lose any work.", vbExclamation) ' Prompt the user that the program cannot close since there are children watching.
            e.Cancel = True
        Else
            e.Cancel = False ' If there aren't any kids around, the parent can get down to business.
        End If
    End Sub
End Class
