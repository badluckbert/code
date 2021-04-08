Public Class clsEmpPayroll
    '---------------------------
    ' File Name: clsEmpPayroll
    ' Project: Assignment 09
    ' Written By: Brett Previdi
    ' Written On: 2021 - 04 - 05
    ' Version 1.0.0.0
    '---------------------------
    ' File Purpose:
    ' This file contains the class that holds employee information. 
    ' A constructor assigns the 4 variables and their values from the main application.
    ' A method for calculating total worked hours for an employee is also provided.
    '---------------------------
    ' Program Purpose:
    ' This program creates a list of employees built using a class holding an employee's
    ' name, ID, hourly rate, and hours worked per day of the week. The information is passed
    ' to a new or existing Excel sheet where their name, ID, and payrate is displayed in order.
    ' Each employee's total hours worked are passed from clas method, and thier weekly pay is 
    ' calculated in Excel. The average, minimum, maximum, and totals for each of the pay related
    ' variables are calculated and displayed below the employee list in Excel.
    '---------------------------
    ' Global Variable Dictionary
    Property strEmployeeName As String 'Holds the employee's name.
    Property intEmployeeID As Integer 'Holds the employee's ID number.
    Property sngHourlyRate As Single 'Holds the employee's hourly rate.
    Property sngHoursWorked As Single() 'Holds an array of hours worked in one week.
    '---------------------------
    Public Sub New(ByVal newName As String, ByVal newID As Integer, ByVal newRate As Single, ByVal newWorked As Single())
        '---------------------------
        ' Subroutine Name: New(ByVal newName As String, ByVal newID As Integer, ByVal newRate As Single, ByVal newWorked As Single())
        ' Written By: Brett Previdi
        ' Written On: 2021 - 04 - 05
        '---------------------------
        ' Subroutine Purpose:
        ' This serves as the contstructor for objects of the clsEmpPayroll class when
        ' variables are passed to it. The values passed from the caller are assigned to 
        ' their respective object variables.
        '---------------------------
        ' Local Variable Library
        ' newName as String 'The passed string containing an employee name from where the object is created to be assigned to the new object.
        ' newID as Integer 'The passed integer containing an eompoyee ID number from where the object is created to be assigned to the new object.
        ' newRate as Single 'The passed single containing an employee's hourly rate from where the object is created to be assigned to the new object.
        ' newWorked as Single() 'The passed array of singles containing all the hours worked by an employee for a week, or 7 days, to be assigned to the new employee object.
        '---------------------------
        strEmployeeName = newName 'Set the name.
        intEmployeeID = newID 'Set the ID.
        sngHourlyRate = newRate 'Set the hourly rate.
        sngHoursWorked = newWorked 'Set the hours worked.
    End Sub
    Public Function totalHours()
        '---------------------------
        ' Subroutine Name: totalHours
        ' Written By: Brett Previdi
        ' Written On: 2021 - 04 - 05
        '---------------------------
        ' Subroutine Purpose:
        ' When called, this function combines the hours an employee worked in a week
        ' and returns the sum. This is done by adding all of the array variables
        ' to a single variable to return.
        '---------------------------
        ' Local Variable Dictionary
        ' sngHours as Single 'Holds the sum of the hours worked in a week
        '---------------------------
        Dim sngHours As Single = 0
        For Each day In sngHoursWorked
            sngHours += day
        Next
        Return sngHours
    End Function
End Class