namespace MultipleFileLauncher;

public static class InputPrompt
{
    public static string? Show(IWin32Window owner, string title, string prompt, string defaultValue = "")
    {
        using var form = new Form
        {
            Text = title,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent,
            MinimizeBox = false,
            MaximizeBox = false,
            ClientSize = new Size(380, 130),
            BackColor = ThemeColors.Background,
            Font = new Font("Segoe UI", 9.75F)
        };

        var label = new Label
        {
            Text = prompt,
            Location = new Point(20, 18),
            AutoSize = true,
            ForeColor = ThemeColors.Text,
            BackColor = Color.Transparent
        };

        var textBox = new TextBox
        {
            Text = defaultValue,
            Location = new Point(20, 44),
            Width = 340,
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Segoe UI", 10F),
            ForeColor = ThemeColors.Text
        };

        var ok = new Button
        {
            Text = "OK",
            DialogResult = DialogResult.OK,
            Location = new Point(194, 84),
            Size = new Size(80, 34),
            BackColor = ThemeColors.Primary,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        ok.FlatAppearance.BorderSize = 0;

        var cancel = new Button
        {
            Text = "Abbrechen",
            DialogResult = DialogResult.Cancel,
            Location = new Point(280, 84),
            Size = new Size(80, 34),
            BackColor = ThemeColors.Surface,
            ForeColor = ThemeColors.Primary,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        cancel.FlatAppearance.BorderColor = ThemeColors.Border;

        form.Controls.AddRange([label, textBox, ok, cancel]);
        form.AcceptButton = ok;
        form.CancelButton = cancel;

        return form.ShowDialog(owner) == DialogResult.OK ? textBox.Text.Trim() : null;
    }
}
