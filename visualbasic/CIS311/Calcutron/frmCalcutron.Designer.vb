<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcutron
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mnuOptions = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_New = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFile_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow_Cascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindow_Tile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTile_Hori = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTile_Vertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuOptions
        '
        Me.mnuOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuWindow, Me.mnuHelp})
        Me.mnuOptions.Location = New System.Drawing.Point(0, 0)
        Me.mnuOptions.MdiWindowListItem = Me.mnuWindow
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(951, 24)
        Me.mnuOptions.TabIndex = 0
        Me.mnuOptions.Text = "File"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile_New, Me.ToolStripSeparator1, Me.mnuFile_Exit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "File"
        '
        'mnuFile_New
        '
        Me.mnuFile_New.Name = "mnuFile_New"
        Me.mnuFile_New.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuFile_New.Size = New System.Drawing.Size(180, 22)
        Me.mnuFile_New.Text = "New"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'mnuFile_Exit
        '
        Me.mnuFile_Exit.Name = "mnuFile_Exit"
        Me.mnuFile_Exit.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuFile_Exit.Size = New System.Drawing.Size(180, 22)
        Me.mnuFile_Exit.Text = "Exit"
        '
        'mnuWindow
        '
        Me.mnuWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindow_Cascade, Me.mnuWindow_Tile})
        Me.mnuWindow.Name = "mnuWindow"
        Me.mnuWindow.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.mnuWindow.Size = New System.Drawing.Size(63, 20)
        Me.mnuWindow.Text = "Window"
        '
        'mnuWindow_Cascade
        '
        Me.mnuWindow_Cascade.Name = "mnuWindow_Cascade"
        Me.mnuWindow_Cascade.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuWindow_Cascade.Size = New System.Drawing.Size(180, 22)
        Me.mnuWindow_Cascade.Text = "Cascade"
        '
        'mnuWindow_Tile
        '
        Me.mnuWindow_Tile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTile_Hori, Me.mnuTile_Vertical})
        Me.mnuWindow_Tile.Name = "mnuWindow_Tile"
        Me.mnuWindow_Tile.Size = New System.Drawing.Size(180, 22)
        Me.mnuWindow_Tile.Text = "Tile"
        '
        'mnuTile_Hori
        '
        Me.mnuTile_Hori.Name = "mnuTile_Hori"
        Me.mnuTile_Hori.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.mnuTile_Hori.Size = New System.Drawing.Size(180, 22)
        Me.mnuTile_Hori.Text = "Horizontal"
        '
        'mnuTile_Vertical
        '
        Me.mnuTile_Vertical.Name = "mnuTile_Vertical"
        Me.mnuTile_Vertical.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnuTile_Vertical.Size = New System.Drawing.Size(180, 22)
        Me.mnuTile_Vertical.Text = "Vertical"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelp_About})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "Help"
        '
        'mnuHelp_About
        '
        Me.mnuHelp_About.Name = "mnuHelp_About"
        Me.mnuHelp_About.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mnuHelp_About.Size = New System.Drawing.Size(180, 22)
        Me.mnuHelp_About.Text = "About"
        '
        'frmCalcutron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(951, 732)
        Me.Controls.Add(Me.mnuOptions)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuOptions
        Me.Name = "frmCalcutron"
        Me.Text = "Calcutron 3000 Home"
        Me.mnuOptions.ResumeLayout(False)
        Me.mnuOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuOptions As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuFile_New As ToolStripMenuItem
    Friend WithEvents mnuFile_Exit As ToolStripMenuItem
    Friend WithEvents mnuWindow As ToolStripMenuItem
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents mnuWindow_Tile As ToolStripMenuItem
    Friend WithEvents mnuWindow_Cascade As ToolStripMenuItem
    Friend WithEvents mnuHelp_About As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuTile_Vertical As ToolStripMenuItem
    Friend WithEvents mnuTile_Hori As ToolStripMenuItem
End Class
