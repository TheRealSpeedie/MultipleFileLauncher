namespace MultipleFileLauncher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelAccent = new Panel();
            panelToolbar = new Panel();
            btnDelete = new Button();
            btnLaunchAll = new Button();
            btnAddFile = new Button();
            btnAddFolder = new Button();
            splitMain = new SplitContainer();
            panelSidebar = new Panel();
            treeView = new TreeView();
            imageList = new ImageList(components);
            panelLibraryHeader = new Panel();
            lblLibrary = new Label();
            panelDetailOuter = new Panel();
            panelDetail = new Panel();
            btnApply = new Button();
            chkEnabled = new CheckBox();
            btnBrowse = new Button();
            txtPath = new TextBox();
            lblPath = new Label();
            txtName = new TextBox();
            lblName = new Label();
            lblDetailsTitle = new Label();
            lblDetailHint = new Label();
            panelSettings = new Panel();
            cmbWindowState = new ComboBox();
            lblWindowState = new Label();
            chkStartWithWindows = new CheckBox();
            lblSettingsTitle = new Label();
            panelHeader.SuspendLayout();
            panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            panelSidebar.SuspendLayout();
            panelLibraryHeader.SuspendLayout();
            panelDetailOuter.SuspendLayout();
            panelDetail.SuspendLayout();
            panelSettings.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(27, 67, 50);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 0, 20, 0);
            panelHeader.Size = new Size(960, 64);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(116, 198, 157);
            lblSubtitle.Location = new Point(22, 40);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(361, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Dateien organisieren, starten und mit Windows automatisch öffnen";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(166, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Datei-Launcher";
            // 
            // panelAccent
            // 
            panelAccent.BackColor = Color.FromArgb(64, 145, 108);
            panelAccent.Dock = DockStyle.Top;
            panelAccent.Location = new Point(0, 64);
            panelAccent.Name = "panelAccent";
            panelAccent.Size = new Size(960, 3);
            panelAccent.TabIndex = 1;
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.FromArgb(200, 225, 200);
            panelToolbar.Controls.Add(btnDelete);
            panelToolbar.Controls.Add(btnLaunchAll);
            panelToolbar.Controls.Add(btnAddFile);
            panelToolbar.Controls.Add(btnAddFolder);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 67);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Padding = new Padding(16, 10, 16, 10);
            panelToolbar.Size = new Size(960, 60);
            panelToolbar.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 254, 247);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(200, 140, 140);
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 240, 240);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 245, 245);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.75F);
            btnDelete.ForeColor = Color.FromArgb(139, 58, 58);
            btnDelete.Location = new Point(408, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Löschen";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLaunchAll
            // 
            btnLaunchAll.BackColor = Color.FromArgb(64, 145, 108);
            btnLaunchAll.Cursor = Cursors.Hand;
            btnLaunchAll.FlatAppearance.BorderSize = 0;
            btnLaunchAll.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 145, 108);
            btnLaunchAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(116, 198, 157);
            btnLaunchAll.FlatStyle = FlatStyle.Flat;
            btnLaunchAll.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnLaunchAll.ForeColor = Color.White;
            btnLaunchAll.Location = new Point(266, 10);
            btnLaunchAll.Name = "btnLaunchAll";
            btnLaunchAll.Size = new Size(130, 40);
            btnLaunchAll.TabIndex = 2;
            btnLaunchAll.Text = "Alle starten";
            btnLaunchAll.UseVisualStyleBackColor = false;
            btnLaunchAll.Click += btnLaunchAll_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.BackColor = Color.FromArgb(27, 67, 50);
            btnAddFile.Cursor = Cursors.Hand;
            btnAddFile.FlatAppearance.BorderSize = 0;
            btnAddFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(27, 67, 50);
            btnAddFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 106, 79);
            btnAddFile.FlatStyle = FlatStyle.Flat;
            btnAddFile.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAddFile.ForeColor = Color.White;
            btnAddFile.Location = new Point(146, 10);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(108, 40);
            btnAddFile.TabIndex = 1;
            btnAddFile.Text = "+  Datei";
            btnAddFile.UseVisualStyleBackColor = false;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // btnAddFolder
            // 
            btnAddFolder.BackColor = Color.FromArgb(27, 67, 50);
            btnAddFolder.Cursor = Cursors.Hand;
            btnAddFolder.FlatAppearance.BorderSize = 0;
            btnAddFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(27, 67, 50);
            btnAddFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 106, 79);
            btnAddFolder.FlatStyle = FlatStyle.Flat;
            btnAddFolder.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAddFolder.ForeColor = Color.White;
            btnAddFolder.Location = new Point(16, 10);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(118, 40);
            btnAddFolder.TabIndex = 0;
            btnAddFolder.Text = "+  Ordner";
            btnAddFolder.UseVisualStyleBackColor = false;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // splitMain
            // 
            splitMain.BackColor = Color.FromArgb(255, 251, 230);
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 127);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.BackColor = Color.FromArgb(220, 237, 220);
            splitMain.Panel1.Controls.Add(panelSidebar);
            splitMain.Panel1MinSize = 240;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.BackColor = Color.FromArgb(255, 251, 230);
            splitMain.Panel2.Controls.Add(panelDetailOuter);
            splitMain.Panel2MinSize = 320;
            splitMain.Size = new Size(960, 393);
            splitMain.SplitterDistance = 320;
            splitMain.SplitterWidth = 6;
            splitMain.TabIndex = 3;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(220, 237, 220);
            panelSidebar.Controls.Add(treeView);
            panelSidebar.Controls.Add(panelLibraryHeader);
            panelSidebar.Dock = DockStyle.Fill;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Padding = new Padding(12, 8, 12, 12);
            panelSidebar.Size = new Size(320, 393);
            panelSidebar.TabIndex = 0;
            // 
            // treeView
            // 
            treeView.BackColor = Color.FromArgb(255, 254, 247);
            treeView.BorderStyle = BorderStyle.FixedSingle;
            treeView.Dock = DockStyle.Fill;
            treeView.Font = new Font("Segoe UI", 10F);
            treeView.ForeColor = Color.FromArgb(27, 67, 50);
            treeView.FullRowSelect = true;
            treeView.HideSelection = false;
            treeView.ImageIndex = 0;
            treeView.ImageList = imageList;
            treeView.Indent = 22;
            treeView.ItemHeight = 26;
            treeView.Location = new Point(12, 40);
            treeView.Name = "treeView";
            treeView.SelectedImageIndex = 0;
            treeView.Size = new Size(296, 341);
            treeView.TabIndex = 1;
            treeView.ItemDrag += treeView_ItemDrag;
            treeView.AfterSelect += treeView_AfterSelect;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            treeView.DragDrop += treeView_DragDrop;
            treeView.DragEnter += treeView_DragEnter;
            treeView.DragOver += treeView_DragOver;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // panelLibraryHeader
            // 
            panelLibraryHeader.BackColor = Color.FromArgb(27, 67, 50);
            panelLibraryHeader.Controls.Add(lblLibrary);
            panelLibraryHeader.Dock = DockStyle.Top;
            panelLibraryHeader.Location = new Point(12, 8);
            panelLibraryHeader.Name = "panelLibraryHeader";
            panelLibraryHeader.Padding = new Padding(10, 6, 10, 6);
            panelLibraryHeader.Size = new Size(296, 32);
            panelLibraryHeader.TabIndex = 0;
            // 
            // lblLibrary
            // 
            lblLibrary.AutoSize = true;
            lblLibrary.BackColor = Color.Transparent;
            lblLibrary.Dock = DockStyle.Fill;
            lblLibrary.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblLibrary.ForeColor = Color.White;
            lblLibrary.Location = new Point(10, 6);
            lblLibrary.Name = "lblLibrary";
            lblLibrary.Size = new Size(79, 17);
            lblLibrary.TabIndex = 0;
            lblLibrary.Text = "BIBLIOTHEK";
            lblLibrary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelDetailOuter
            // 
            panelDetailOuter.BackColor = Color.FromArgb(255, 251, 230);
            panelDetailOuter.Controls.Add(panelDetail);
            panelDetailOuter.Controls.Add(lblDetailHint);
            panelDetailOuter.Dock = DockStyle.Fill;
            panelDetailOuter.Location = new Point(0, 0);
            panelDetailOuter.Name = "panelDetailOuter";
            panelDetailOuter.Padding = new Padding(20, 16, 20, 16);
            panelDetailOuter.Size = new Size(634, 393);
            panelDetailOuter.TabIndex = 0;
            // 
            // panelDetail
            // 
            panelDetail.BackColor = Color.FromArgb(255, 254, 247);
            panelDetail.BorderStyle = BorderStyle.FixedSingle;
            panelDetail.Controls.Add(btnApply);
            panelDetail.Controls.Add(chkEnabled);
            panelDetail.Controls.Add(btnBrowse);
            panelDetail.Controls.Add(txtPath);
            panelDetail.Controls.Add(lblPath);
            panelDetail.Controls.Add(txtName);
            panelDetail.Controls.Add(lblName);
            panelDetail.Controls.Add(lblDetailsTitle);
            panelDetail.Dock = DockStyle.Top;
            panelDetail.Location = new Point(20, 16);
            panelDetail.Name = "panelDetail";
            panelDetail.Padding = new Padding(20);
            panelDetail.Size = new Size(594, 248);
            panelDetail.TabIndex = 0;
            panelDetail.Visible = false;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.FromArgb(27, 67, 50);
            btnApply.Cursor = Cursors.Hand;
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 106, 79);
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.Location = new Point(20, 200);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(200, 40);
            btnApply.TabIndex = 7;
            btnApply.Text = "Änderungen übernehmen";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.BackColor = Color.Transparent;
            chkEnabled.Font = new Font("Segoe UI", 9.75F);
            chkEnabled.ForeColor = Color.FromArgb(27, 67, 50);
            chkEnabled.Location = new Point(20, 172);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(173, 21);
            chkEnabled.TabIndex = 6;
            chkEnabled.Text = "Beim Starten einbeziehen";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowse.BackColor = Color.FromArgb(220, 237, 220);
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(180, 200, 180);
            btnBrowse.FlatAppearance.MouseOverBackColor = Color.FromArgb(116, 198, 157);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 9.75F);
            btnBrowse.ForeColor = Color.FromArgb(27, 67, 50);
            btnBrowse.Location = new Point(472, 131);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(100, 27);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "Durchsuchen…";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.BackColor = Color.White;
            txtPath.BorderStyle = BorderStyle.FixedSingle;
            txtPath.Font = new Font("Segoe UI", 10F);
            txtPath.ForeColor = Color.FromArgb(27, 67, 50);
            txtPath.Location = new Point(20, 132);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(440, 25);
            txtPath.TabIndex = 4;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.BackColor = Color.Transparent;
            lblPath.Font = new Font("Segoe UI", 9.75F);
            lblPath.ForeColor = Color.FromArgb(92, 107, 92);
            lblPath.Location = new Point(20, 112);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(65, 17);
            lblPath.TabIndex = 3;
            lblPath.Text = "Dateipfad";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.BackColor = Color.White;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.ForeColor = Color.FromArgb(27, 67, 50);
            txtName.Location = new Point(20, 76);
            txtName.Name = "txtName";
            txtName.Size = new Size(552, 25);
            txtName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 9.75F);
            lblName.ForeColor = Color.FromArgb(27, 67, 50);
            lblName.Location = new Point(20, 56);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 17);
            lblName.TabIndex = 1;
            lblName.Text = "Anzeigename";
            // 
            // lblDetailsTitle
            // 
            lblDetailsTitle.AutoSize = true;
            lblDetailsTitle.BackColor = Color.Transparent;
            lblDetailsTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.FromArgb(27, 67, 50);
            lblDetailsTitle.Location = new Point(20, 20);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(64, 20);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "DETAILS";
            // 
            // lblDetailHint
            // 
            lblDetailHint.AutoSize = true;
            lblDetailHint.BackColor = Color.Transparent;
            lblDetailHint.Font = new Font("Segoe UI", 10.5F);
            lblDetailHint.ForeColor = Color.FromArgb(92, 107, 92);
            lblDetailHint.Location = new Point(20, 16);
            lblDetailHint.MaximumSize = new Size(560, 0);
            lblDetailHint.Name = "lblDetailHint";
            lblDetailHint.Size = new Size(518, 19);
            lblDetailHint.TabIndex = 1;
            lblDetailHint.Text = "Wähle eine Datei oder einen Ordner in der Bibliothek aus, um Details zu bearbeiten.";
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.FromArgb(200, 225, 200);
            panelSettings.Controls.Add(cmbWindowState);
            panelSettings.Controls.Add(lblWindowState);
            panelSettings.Controls.Add(chkStartWithWindows);
            panelSettings.Controls.Add(lblSettingsTitle);
            panelSettings.Dock = DockStyle.Bottom;
            panelSettings.Location = new Point(0, 520);
            panelSettings.Name = "panelSettings";
            panelSettings.Padding = new Padding(20, 10, 20, 10);
            panelSettings.Size = new Size(960, 56);
            panelSettings.TabIndex = 4;
            // 
            // cmbWindowState
            // 
            cmbWindowState.BackColor = Color.White;
            cmbWindowState.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWindowState.FlatStyle = FlatStyle.Flat;
            cmbWindowState.Font = new Font("Segoe UI", 9.75F);
            cmbWindowState.ForeColor = Color.FromArgb(27, 67, 50);
            cmbWindowState.FormattingEnabled = true;
            cmbWindowState.Items.AddRange(new object[] { "Minimiert", "Maximiert", "Normal" });
            cmbWindowState.Location = new Point(381, 15);
            cmbWindowState.Name = "cmbWindowState";
            cmbWindowState.Size = new Size(140, 25);
            cmbWindowState.TabIndex = 3;
            cmbWindowState.SelectedIndexChanged += cmbWindowState_SelectedIndexChanged;
            // 
            // lblWindowState
            // 
            lblWindowState.AutoSize = true;
            lblWindowState.BackColor = Color.Transparent;
            lblWindowState.Font = new Font("Segoe UI", 9.75F);
            lblWindowState.ForeColor = Color.FromArgb(92, 107, 92);
            lblWindowState.Location = new Point(290, 18);
            lblWindowState.Name = "lblWindowState";
            lblWindowState.Size = new Size(116, 17);
            lblWindowState.TabIndex = 2;
            lblWindowState.Text = "Dateien öffnen als:";
            // 
            // chkStartWithWindows
            // 
            chkStartWithWindows.AutoSize = true;
            chkStartWithWindows.BackColor = Color.Transparent;
            chkStartWithWindows.Font = new Font("Segoe UI", 9.75F);
            chkStartWithWindows.ForeColor = Color.FromArgb(27, 67, 50);
            chkStartWithWindows.Location = new Point(129, 16);
            chkStartWithWindows.Name = "chkStartWithWindows";
            chkStartWithWindows.Size = new Size(147, 21);
            chkStartWithWindows.TabIndex = 1;
            chkStartWithWindows.Text = "Mit Windows starten";
            chkStartWithWindows.UseVisualStyleBackColor = true;
            chkStartWithWindows.CheckedChanged += chkStartWithWindows_CheckedChanged;
            // 
            // lblSettingsTitle
            // 
            lblSettingsTitle.AutoSize = true;
            lblSettingsTitle.BackColor = Color.Transparent;
            lblSettingsTitle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblSettingsTitle.ForeColor = Color.FromArgb(27, 67, 50);
            lblSettingsTitle.Location = new Point(20, 18);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.Size = new Size(107, 17);
            lblSettingsTitle.TabIndex = 0;
            lblSettingsTitle.Text = "EINSTELLUNGEN";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(255, 251, 230);
            ClientSize = new Size(960, 576);
            Controls.Add(splitMain);
            Controls.Add(panelSettings);
            Controls.Add(panelToolbar);
            Controls.Add(panelAccent);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9.75F);
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datei-Launcher";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            panelSidebar.ResumeLayout(false);
            panelLibraryHeader.ResumeLayout(false);
            panelLibraryHeader.PerformLayout();
            panelDetailOuter.ResumeLayout(false);
            panelDetailOuter.PerformLayout();
            panelDetail.ResumeLayout(false);
            panelDetail.PerformLayout();
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelAccent;
        private Panel panelToolbar;
        private Button btnAddFolder;
        private Button btnAddFile;
        private Button btnLaunchAll;
        private Button btnDelete;
        private SplitContainer splitMain;
        private Panel panelSidebar;
        private Panel panelLibraryHeader;
        private Label lblLibrary;
        private TreeView treeView;
        private Panel panelDetailOuter;
        private Panel panelDetail;
        private Label lblDetailsTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblPath;
        private TextBox txtPath;
        private Button btnBrowse;
        private CheckBox chkEnabled;
        private Button btnApply;
        private Label lblDetailHint;
        private Panel panelSettings;
        private Label lblSettingsTitle;
        private CheckBox chkStartWithWindows;
        private Label lblWindowState;
        private ComboBox cmbWindowState;
        private ImageList imageList;
    }
}
