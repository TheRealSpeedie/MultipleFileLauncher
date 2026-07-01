using MultipleFileLauncher.Models;

namespace MultipleFileLauncher
{
    public partial class Form1 : Form
    {
        private AppSettings _settings = new();
        private bool _loadingSettings;
        private TreeNode? _dragNode;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupIcons();
            treeView.AllowDrop = true;

            _loadingSettings = true;
            _settings = AppSettings.Load();
            RefreshTree();
            cmbWindowState.SelectedItem = WindowStateTexts.ToDisplay(_settings.LaunchWindowState);
            if (cmbWindowState.SelectedIndex < 0)
                cmbWindowState.SelectedIndex = 0;
            chkStartWithWindows.Checked = StartupManager.IsEnabled();
            _settings.StartWithWindows = chkStartWithWindows.Checked;
            _loadingSettings = false;
            UpdateDetailPanel(null);
        }

        private void SetupIcons()
        {
            imageList.Images.Add("folder", CreateFolderIcon());
            imageList.Images.Add("file", CreateFileIcon());
        }

        private static Bitmap CreateFolderIcon()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            using var brush = new SolidBrush(ThemeColors.Primary);
            g.FillRectangle(brush, 1, 4, 14, 10);
            g.FillRectangle(brush, 1, 2, 7, 3);
            return bmp;
        }

        private static Bitmap CreateFileIcon()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            using var brush = new SolidBrush(ThemeColors.TextMuted);
            g.FillRectangle(brush, 3, 1, 10, 14);
            using var fold = new SolidBrush(ThemeColors.AccentBright);
            g.FillPolygon(fold, [new Point(9, 1), new Point(13, 5), new Point(9, 5)]);
            return bmp;
        }

        private void RefreshTree(string? selectedId = null)
        {
            var expanded = CaptureExpandedNodeIds();
            var selected = selectedId ?? treeView.SelectedNode?.Tag as string;

            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            foreach (var item in _settings.RootItems)
                treeView.Nodes.Add(CreateNode(item));
            RestoreExpandedNodes(treeView.Nodes, expanded);
            treeView.EndUpdate();

            if (selected != null)
                SelectNodeById(selected);
        }

        private HashSet<string> CaptureExpandedNodeIds()
        {
            var expanded = new HashSet<string>();
            CollectExpandedNodeIds(treeView.Nodes, expanded);
            return expanded;
        }

        private static void CollectExpandedNodeIds(TreeNodeCollection nodes, HashSet<string> expanded)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded && node.Tag is string id)
                    expanded.Add(id);
                CollectExpandedNodeIds(node.Nodes, expanded);
            }
        }

        private static void RestoreExpandedNodes(TreeNodeCollection nodes, HashSet<string> expanded)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is string id && expanded.Contains(id))
                    node.Expand();
                RestoreExpandedNodes(node.Nodes, expanded);
            }
        }

        private static TreeNode CreateNode(LaunchItem item)
        {
            var node = new TreeNode(item.Name)
            {
                Tag = item.Id,
                ImageKey = item is LaunchFolder ? "folder" : "file",
                SelectedImageKey = item is LaunchFolder ? "folder" : "file"
            };

            if (item is LaunchFolder folder)
            {
                foreach (var child in folder.Children)
                    node.Nodes.Add(CreateNode(child));
            }

            return node;
        }

        private LaunchItem? GetSelectedItem()
        {
            if (treeView.SelectedNode?.Tag is not string id)
                return null;
            return _settings.FindById(id);
        }

        private void UpdateDetailPanel(LaunchItem? item)
        {
            if (item is LaunchFile file)
            {
                panelDetail.Visible = true;
                lblDetailHint.Visible = false;
                lblPath.Visible = true;
                txtPath.Visible = true;
                btnBrowse.Visible = true;
                chkEnabled.Visible = true;
                txtName.Text = file.Name;
                txtPath.Text = file.Path;
                chkEnabled.Checked = file.Enabled;
                return;
            }

            if (item is LaunchFolder folder)
            {
                panelDetail.Visible = true;
                lblDetailHint.Visible = false;
                lblPath.Visible = false;
                txtPath.Visible = false;
                btnBrowse.Visible = false;
                chkEnabled.Visible = false;
                txtName.Text = folder.Name;
                return;
            }

            panelDetail.Visible = false;
            lblDetailHint.Visible = true;
        }

        private void Persist()
        {
            _settings.Save();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var name = InputPrompt.Show(this, "Neuer Ordner", "Ordnername:", "Neuer Ordner");
            if (string.IsNullOrWhiteSpace(name))
                return;

            var folder = new LaunchFolder { Name = name.Trim() };
            var selected = GetSelectedItem();
            _settings.GetTargetContainer(selected).Add(folder);
            Persist();
            RefreshTree(folder.Id);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Dateien auswählen"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var selected = GetSelectedItem();
            var container = _settings.GetTargetContainer(selected);
            LaunchFile? lastAdded = null;

            foreach (var path in dialog.FileNames)
            {
                var file = new LaunchFile
                {
                    Name = Path.GetFileNameWithoutExtension(path),
                    Path = path
                };
                container.Add(file);
                lastAdded = file;
            }

            Persist();
            RefreshTree(lastAdded?.Id);
        }

        private void SelectNodeById(string id)
        {
            var node = FindNode(treeView.Nodes, id);
            if (node == null)
                return;

            ExpandAncestors(node);
            treeView.SelectedNode = node;
            node.EnsureVisible();
        }

        private static void ExpandAncestors(TreeNode node)
        {
            for (var parent = node.Parent; parent != null; parent = parent.Parent)
                parent.Expand();
        }

        private static TreeNode? FindNode(TreeNodeCollection nodes, string id)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is string nodeId && nodeId == id)
                    return node;

                var found = FindNode(node.Nodes, id);
                if (found != null)
                    return found;
            }

            return null;
        }

        private void btnLaunchAll_Click(object sender, EventArgs e)
        {
            FileLauncher.LaunchAll(_settings);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null)
                return;

            if (item is LaunchFolder folder && folder.Children.Count > 0)
            {
                var result = MessageBox.Show(
                    this,
                    $"Ordner \"{folder.Name}\" und alle enthaltenen Elemente löschen?",
                    "Löschen bestätigen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;
            }

            _settings.RemoveById(item.Id);
            Persist();
            RefreshTree();
            UpdateDetailPanel(null);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null)
                return;

            var name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(this, "Der Anzeigename darf nicht leer sein.", "Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            item.Name = name;

            if (item is LaunchFile file)
            {
                file.Path = txtPath.Text.Trim();
                file.Enabled = chkEnabled.Checked;
            }

            Persist();
            RefreshTree(item.Id);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (GetSelectedItem() is not LaunchFile)
                return;

            using var dialog = new OpenFileDialog { Title = "Datei auswählen" };
            if (!string.IsNullOrWhiteSpace(txtPath.Text))
                dialog.InitialDirectory = Path.GetDirectoryName(txtPath.Text);

            if (dialog.ShowDialog() == DialogResult.OK)
                txtPath.Text = dialog.FileName;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is not string id)
            {
                UpdateDetailPanel(null);
                return;
            }

            UpdateDetailPanel(_settings.FindById(id));
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is not string id)
                return;

            if (_settings.FindById(id) is LaunchFile file)
                FileLauncher.LaunchFile(file, _settings.LaunchWindowState);
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is TreeNode node)
            {
                _dragNode = node;
                DoDragDrop(node, DragDropEffects.Move);
            }
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data?.GetDataPresent(typeof(TreeNode)) == true ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(typeof(TreeNode)) != true)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            var target = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
            if (_dragNode == null || target == _dragNode || IsDescendant(_dragNode, target))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;
            target?.Expand();
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            if (_dragNode?.Tag is not string dragId || e.Data?.GetDataPresent(typeof(TreeNode)) != true)
                return;

            var target = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
            LaunchFolder? targetFolder = null;
            var targetIndex = 0;

            if (target == null)
            {
                targetFolder = null;
                targetIndex = _settings.RootItems.Count;
            }
            else if (target.Tag is string targetId)
            {
                var targetItem = _settings.FindById(targetId);
                if (targetItem is LaunchFolder folder)
                {
                    targetFolder = folder;
                    targetIndex = folder.Children.Count;
                }
                else
                {
                    var parent = _settings.FindParentFolder(targetId);
                    targetFolder = parent;
                    var list = parent?.Children ?? _settings.RootItems;
                    targetIndex = list.FindIndex(i => i.Id == targetId) + 1;
                }
            }

            if (targetFolder != null && _settings.FindById(dragId) is LaunchFolder dragFolder)
            {
                if (IsFolderOrDescendant(dragFolder, targetFolder))
                    return;
            }

            if (!_settings.MoveItem(dragId, targetFolder, targetIndex))
                return;

            Persist();
            RefreshTree(dragId);
            _dragNode = null;
        }

        private static bool IsDescendant(TreeNode parent, TreeNode? candidate)
        {
            if (candidate == null)
                return false;

            var node = candidate.Parent;
            while (node != null)
            {
                if (node == parent)
                    return true;
                node = node.Parent;
            }

            return false;
        }

        private static bool IsFolderOrDescendant(LaunchFolder source, LaunchFolder target)
        {
            if (source.Id == target.Id)
                return true;

            foreach (var child in source.Children)
            {
                if (child is LaunchFolder childFolder && IsFolderOrDescendant(childFolder, target))
                    return true;
            }

            return false;
        }

        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (_loadingSettings)
                return;

            if (chkStartWithWindows.Checked)
                StartupManager.Enable();
            else
                StartupManager.Disable();

            _settings.StartWithWindows = chkStartWithWindows.Checked;
            Persist();
        }

        private void cmbWindowState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingSettings || cmbWindowState.SelectedItem is not string state)
                return;

            _settings.LaunchWindowState = WindowStateTexts.ToStored(state);
            Persist();
        }
    }
}
