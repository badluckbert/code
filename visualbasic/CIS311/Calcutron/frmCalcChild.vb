Public Class frmCalcChild
    '________________________
    ' File Name: frmCalcChild
    ' Part of: Assignment 06
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' File Purpose: 
    ' This file contains the form for the child of the parent MDI frmCalcutron. All functions and variables related 
    ' to this child form are contained within this form. Every instance of this will be independent of other children
    ' as is the nature of MDI forms. If the form is modified or not in a state of "default", the form will ask the user
    ' if they are sure they want to close the form.
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
    ' Global Variable Dictionary
    Public sngStored As Single = 0 ' Stores the first number entered in float operations to be used for execution.
    Public lngStored As Long = 0 ' Stores the first number entered in integer operations to be used for execution.
    Public strOperator As String = Nothing ' Stores the currently entered operator sign so the operation can be executed once the second number is entered.
    Public blnOperation As Boolean = False ' Flag for if an operation was executed so the display can be reset for new numbers upon entering a new number.
    '________________________
    '---------------------------------------------------------------------
    '________________________
    ' Sub Name: btnNumericClick
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This sub is called whena any of the numeric numbers 0-9 are pressed to append their specific values to the display. 
    ' It does so by passing the text of the button as the new value to append, so individual button click subs are not 
    ' needed. It checks if the display is the default or if an operation recently occured to clear it before appending 
    ' to remove the redundant 0. 
    Private Sub btnNumericClick(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim btnObject As Button = sender ' Send the button that was clicked as an object so the number for that button can be pulled.
        If txtDisplay.Text = "0" Or blnOperation = True Then ' If the display is the default of 0 or an operation recently occured, 
            If checkMode() Then ' check for the current operating mode and store the old number before clearing the display.
                sngStored = txtDisplay.Text
            Else
                lngStored = txtDisplay.Text
            End If
            txtDisplay.Text = btnObject.Text ' clear the display so the new number does not display at 0123 for example.
            blnOperation = False ' Lower the operation flag since it is no longer the most recent event.
        Else
            txtDisplay.Text = txtDisplay.Text + btnObject.Text ' Append the number in the specific button pressed to the end of the displayed number.
        End If
    End Sub
    '________________________
    ' Sub Name: btnClearAll_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Upon clicking the C button, this sub will reset the calculator variables and display. All stored variables are set to 0,
    ' the operator variable is set to nothing, and the display shows 0.
    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        sngStored = 0
        lngStored = 0
        strOperator = Nothing
        txtDisplay.Text = 0
    End Sub
    '________________________
    ' Sub Name: btnClearEntry_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Upon clicking CE, the currently displayed variable is set to 0. Other operations and the stored variables remain.
    Private Sub btnClearEntry_Click(sender As Object, e As EventArgs) Handles btnClearEntry.Click
        txtDisplay.Text = 0
    End Sub
    '________________________
    ' Function Name: checkMode
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This function is called commonly throughout this application to determine the status of the mode the calculator is set in based on the radio buttons.
    ' This is important as the math for integers and singles converted into integers may be different. This will help prevent that discrepency.
    Private Function checkMode()
        If radFloat.Checked Then ' Checks if float is enabled and returns true, otherwise integer is the false value.
            Return True
        Else
            Return False
        End If
    End Function
    '________________________
    ' Sub Name: checkRad
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' When the two modes for the calculator are switched between, the calculator resets. If integer is selected, the buttons that are not compatible with
    ' integers will be disabled to prevent use. If float is chosen, those buttons are enabled. The Clear All sub is called to reset variables and the display.
    Private Sub checkRad(sender As Object, e As EventArgs) Handles radInt.CheckedChanged, radFloat.CheckedChanged
        If checkMode() Then ' Calls the previous function to check which button was chosen to determine whether to enable or disable.
            btnSqrt.Enabled = True
            btnSin.Enabled = True
            btnCos.Enabled = True
            btnTan.Enabled = True
            btnDecimal.Enabled = True
        Else
            btnSqrt.Enabled = False
            btnSin.Enabled = False
            btnCos.Enabled = False
            btnTan.Enabled = False
            btnDecimal.Enabled = False
        End If
        btnClearAll_Click(sender, e) ' Call Clear All using the sending operation as the reason or parameters for calling it. 
    End Sub
    '________________________
    ' Sub Name: btnPosNeg_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This sub will change the currently displayed number into a positive from a negative or a negative into a positive. 
    ' This is done by simply multiplying by -1.
    Private Sub btnPosNeg_Click(sender As Object, e As EventArgs) Handles btnPosNeg.Click
        txtDisplay.Text *= -1
    End Sub
    '________________________
    ' Sub Name: btnDecimal_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This sub adds a decimal where desired if the displayed value does not already have one, and the calculator must be in float
    ' mode for this to be used since no integers deserve the happiness of owning a decimal.
    Private Sub btnDecimal_Click(sender As Object, e As EventArgs) Handles btnDecimal.Click
        If Not txtDisplay.Text.Contains(".") Then ' Continue if decimals are not displayed at the time.
            txtDisplay.Text = txtDisplay.Text + "." ' Add that little ol' dot.
        End If
    End Sub
    '________________________
    ' Sub Name: btnSquare_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' Although this was not required by the assignment, the higher ups wanted me to include this button to simplify the process of
    ' the square function. The currently displayed number is multiplied by itself and displayed. The operation flag is raised since
    ' math was involved.
    Private Sub btnSquare_Click(sender As Object, e As EventArgs) Handles btnSquare.Click
        txtDisplay.Text *= txtDisplay.Text ' The square-ing.
        blnOperation = True
    End Sub
    '________________________
    ' Sub Name: btnSqrt_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This is for SquareRoot on float mode only. It will not do the operation on a negative number. Performs the function on the currently displayed number.
    Private Sub btnSqrt_Click(sender As Object, e As EventArgs) Handles btnSqrt.Click
        If Not txtDisplay.Text.Contains("-") Then ' Checking for Negative Nancy the Numerator 
            txtDisplay.Text = Math.Sqrt(txtDisplay.Text) ' If they are absolutely POSITIVE they want to continue, the function will perform.
            blnOperation = True
        End If
    End Sub
    '________________________
    ' Sub Name: btnSin_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This is for SINE function on the currently displayed number in float mode only.
    Private Sub btnSin_Click(sender As Object, e As EventArgs) Handles btnSin.Click
        txtDisplay.Text = Math.Sin(txtDisplay.Text)
        blnOperation = True
    End Sub
    '________________________
    ' Sub Name: btnCos_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This is for COSINE function on the currently displayed number in float mode only.
    Private Sub btnCos_Click(sender As Object, e As EventArgs) Handles btnCos.Click
        txtDisplay.Text = Math.Cos(txtDisplay.Text)
        blnOperation = True
    End Sub
    '________________________
    ' Sub Name: btnTan_Click
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This is for TAN function on the currently displayed number in float mode only.
    Private Sub btnTan_Click(sender As Object, e As EventArgs) Handles btnTan.Click
        txtDisplay.Text = Math.Tan(txtDisplay.Text)
        blnOperation = True
    End Sub
    '________________________
    ' Sub Name: btnFunctionClick
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This subroutine performs when a two variable function such as addition is called via button. Like the NumericClick subroutine, it passes the text of the button as the operator.
    ' The math for these functions only happens after the two variables have been entered. If only one variable has been entered, the operator variable will still be nothing and will not
    ' perform any operations. Once the select case statement passes, the operator pressed to activate this sub will become the operator variable to be performed with the next call. 
    ' If equals is pressed, it simply performs the previous operator and does not assign a new one. Numbers entered before the call are used and the results are stored.
    Private Sub btnFunctionClick(sender As Object, e As EventArgs) Handles btnAdd.Click, btnSub.Click, btnMultiply.Click, btnDivide.Click, btnMod.Click, btnExp.Click, btnEquals.Click
        Dim btnObject As Button = sender ' Pass the button clicked as an object so the text can be used as the operator variable after any operations happen.  
        Select Case strOperator ' The operator variable is used to determine which operation should happen based on the previously two entered numbers.
            Case "+" ' For example with addition...
                If checkMode() = True Then ' The current mode is checked so the correct math format is used. 
                    txtDisplay.Text = sngStored + txtDisplay.Text
                Else ' The same is typed out for integer values so the math isn't confused.
                    txtDisplay.Text = lngStored + txtDisplay.Text
                End If
            Case "-" ' The same operations occur for all operands. In this case, subtraction. 
                If checkMode() = True Then
                    txtDisplay.Text = sngStored - txtDisplay.Text
                Else
                    txtDisplay.Text = lngStored - txtDisplay.Text
                End If
            Case "*" ' Multiplication
                If checkMode() = True Then
                    txtDisplay.Text = sngStored * txtDisplay.Text
                Else
                    txtDisplay.Text = lngStored * txtDisplay.Text
                End If
            Case "/" ' Division
                If checkMode() = True Then
                    txtDisplay.Text = sngStored / txtDisplay.Text
                Else
                    txtDisplay.Text = lngStored / txtDisplay.Text
                End If ' If divide by 0 occurs, most calculators naturally display their natural errors. VB will do so in this case.
            Case "%" ' Mod
                If checkMode() = True Then
                    txtDisplay.Text = sngStored Mod txtDisplay.Text
                Else
                    txtDisplay.Text = lngStored Mod txtDisplay.Text
                End If
            Case "^" ' Exponents
                If checkMode() = True Then
                    txtDisplay.Text = Math.Pow(sngStored, txtDisplay.Text)
                Else
                    txtDisplay.Text = Math.Pow(lngStored, txtDisplay.Text)
                End If
        End Select
        If checkMode() Then ' The new results are saved as the stored variables to be used in future operations based on the mode.
            sngStored = txtDisplay.Text
        Else
            lngStored = txtDisplay.Text
        End If
        blnOperation = True ' Raise the operation flag to say an operation occured.
        strOperator = btnObject.Text ' The passed button will make its text the new operator variable for the next time an operator is pressed.
    End Sub
    '________________________
    ' Sub Name: frmCalcChild_FormClosing
    ' Written By: Brett Previdi
    ' Written On: 2021 - 02 - 24
    '________________________
    ' This is called when closing the form and it is not in the default state of displaying 0 and having nothing in the operator variable. The user will be prompted if they
    ' are sure they want to exit the instance of the child form. This is happen if the parent form tries to close for every child not in the default state.
    Private Sub frmCalcChild_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not txtDisplay.Text = "0" Or Not strOperator = Nothing Then ' If the display is not defaulted or some operation occured,
            Dim answer As String = MsgBox("Are you sure you want to cancel the current operation for this Calcutron instance?" + vbCrLf +
                                           "You will not be able to save this.", vbQuestion + vbYesNo, "Before You Exit") ' Prompt the user if they are sure they want to continue.
            If answer = vbNo Then ' If no, then cancel this sub.
                Me.Refresh()
            Else
                Me.Dispose()
            End If
        Else
            Me.Dispose() ' Otherwise, continue.
        End If
    End Sub
End Class
