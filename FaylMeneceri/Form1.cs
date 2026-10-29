using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaylMeneceri
{
    public partial class Form1 : Form
    {
        private string _currentFolder = string.Empty;
        private string? _activeFilePath;
        private bool _isDirty;
        private bool _loadingText;
        private bool _suppressSelectionChanged;
        private bool _dragging;
        private Point _dragOrigin;
        private int _fileCount;

        public Form1()
        {
            InitializeComponent();
            HeaderPanel_Resize(this, EventArgs.Empty);

            // Visual Studio Designer-də fayl sisteminə müraciət etmirik.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            // Başlanğıcda layihə ilə gələn beş nümunə .txt faylını göstərir.
            // "Qovluq seç" vasitəsilə kompüterdə istənilən başqa qovluq açmaq olar.
            string sampleFolder = Path.Combine(AppContext.BaseDirectory, "NumuneFayllar");
            _currentFolder = Directory.Exists(sampleFolder)
                ? sampleFolder
                : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            LoadFileList();
        }

        private sealed class FileItem
        {
            public string FullPath { get; }
            public string Name => Path.GetFileName(FullPath);

            public FileItem(string fullPath) => FullPath = fullPath;

            public override string ToString() => Name;
        }

        private void LoadFileList(string? preferPath = null)
        {
            _suppressSelectionChanged = true;
            lstFayllar.BeginUpdate();
            try
            {
                lstFayllar.Items.Clear();
                string[] files = Directory.GetFiles(_currentFolder, "*.txt", SearchOption.TopDirectoryOnly);
                bool isSampleFolder = string.Equals(Path.GetFileName(_currentFolder.TrimEnd(
                    Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)),
                    "NumuneFayllar", StringComparison.OrdinalIgnoreCase);
                string[] sampleOrder = { "qeydler.txt", "hesabat.txt", "melumat.txt", "test.txt", "siyahi.txt" };

                files = isSampleFolder
                    ? files.OrderBy(p =>
                    {
                        int i = Array.FindIndex(sampleOrder, n =>
                            string.Equals(n, Path.GetFileName(p), StringComparison.OrdinalIgnoreCase));
                        return i < 0 ? int.MaxValue : i;
                    }).ThenBy(p => Path.GetFileName(p), StringComparer.CurrentCultureIgnoreCase).ToArray()
                    : files.OrderBy(p => Path.GetFileName(p), StringComparer.CurrentCultureIgnoreCase).ToArray();

                foreach (string path in files)
                    lstFayllar.Items.Add(new FileItem(path));

                _fileCount = files.Length;
                txtYol.Text = _currentFolder;
                txtYol.SelectionStart = 0;
                txtYol.SelectionLength = 0;

                int index = -1;
                if (!string.IsNullOrEmpty(preferPath))
                {
                    for (int i = 0; i < lstFayllar.Items.Count; i++)
                    {
                        if (lstFayllar.Items[i] is FileItem item &&
                            string.Equals(item.FullPath, preferPath, StringComparison.OrdinalIgnoreCase))
                        {
                            index = i;
                            break;
                        }
                    }
                }

                if (index < 0 && lstFayllar.Items.Count > 0)
                    index = 0;

                lstFayllar.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                _fileCount = 0;
                lstFayllar.Items.Clear();
                _activeFilePath = null;
                SetEditorText(string.Empty);
                lblMelumat.Text = "Fayllar göstərilə bilmədi";
                MessageBox.Show(this, "Qovluq oxunmadı:\n" + ex.Message,
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lstFayllar.EndUpdate();
                _suppressSelectionChanged = false;
            }

            if (lstFayllar.SelectedItem is FileItem selected)
                OpenFile(selected.FullPath);
            else
            {
                _activeFilePath = null;
                SetEditorText(string.Empty);
                lblMelumat.Text = "Fayl seçilməyib";
                txtMetn.Enabled = false;
                btnSaxla.Enabled = false;
                btnSil.Enabled = false;
                btnAc.Enabled = false;
            }

            UpdateStatus("Hazırdır");
        }

        private void OpenFile(string filePath)
        {
            try
            {
                // UTF-8 mətnini və BOM-lu UTF-8/UTF-16 fayllarını oxuyur.
                using var reader = new StreamReader(filePath, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
                string content = reader.ReadToEnd();

                _activeFilePath = filePath;
                SetEditorText(content);
                txtMetn.Enabled = true;
                btnSaxla.Enabled = true;
                btnAc.Enabled = true;
                btnSil.Enabled = true;
                UpdateFileInfo(filePath);
                UpdateStatus("Açıldı");
            }
            catch (Exception ex)
            {
                _activeFilePath = null;
                SetEditorText(string.Empty);
                txtMetn.Enabled = false;
                btnSaxla.Enabled = false;
                lblMelumat.Text = "Faylı oxumaq mümkün olmadı";
                UpdateStatus("Xəta");
                MessageBox.Show(this, "Fayl açıla bilmədi:\n" + ex.Message,
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEditorText(string text)
        {
            _loadingText = true;
            try
            {
                txtMetn.Text = text;
                txtMetn.SelectionStart = 0;
                txtMetn.SelectionLength = 0;
                _isDirty = false;
            }
            finally
            {
                _loadingText = false;
            }
        }

        private void UpdateFileInfo(string path)
        {
            try
            {
                var info = new FileInfo(path);
                string size = (info.Length / 1024.0).ToString("0.0", CultureInfo.CurrentCulture);
                lblMelumat.Text = $"Ad: {info.Name}     Ölçü: {size} KB     Yaranma tarixi: {info.CreationTime:dd.MM.yyyy}";
            }
            catch (Exception)
            {
                lblMelumat.Text = $"Ad: {Path.GetFileName(path)}";
            }
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"{message}  |  Fayl sayı: {_fileCount}";
        }

        private bool SaveCurrentFile()
        {
            if (string.IsNullOrEmpty(_activeFilePath))
            {
                MessageBox.Show(this, "Əvvəlcə bir mətn faylı seçin.",
                    "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                File.WriteAllText(_activeFilePath, txtMetn.Text, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
                _isDirty = false;
                UpdateFileInfo(_activeFilePath);
                UpdateStatus("Yadda saxlanıldı");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Faylı yadda saxlamaq mümkün olmadı:\n" + ex.Message,
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CanLoseChanges()
        {
            if (!_isDirty) return true;

            DialogResult answer = MessageBox.Show(this,
                "Mətndə saxlanılmamış dəyişikliklər var. Yadda saxlamaq istəyirsiniz?",
                "Saxlanılmamış dəyişikliklər",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            return answer switch
            {
                DialogResult.Yes => SaveCurrentFile(),
                DialogResult.No => true,
                _ => false
            };
        }

        private void BtnQovluq_Click(object? sender, EventArgs e)
        {
            if (!CanLoseChanges()) return;

            using var dialog = new FolderBrowserDialog
            {
                Description = "Mətn faylları olan qovluğu seçin",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = true,
                SelectedPath = Directory.Exists(_currentFolder) ? _currentFolder : string.Empty
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _currentFolder = dialog.SelectedPath;
                LoadFileList();
            }
        }

        private void BtnAc_Click(object? sender, EventArgs e)
        {
            if (lstFayllar.SelectedItem is not FileItem file) return;
            if (!CanLoseChanges()) return;
            OpenFile(file.FullPath);
            txtMetn.Focus();
        }

        private void BtnSaxla_Click(object? sender, EventArgs e) => SaveCurrentFile();

        private void BtnSil_Click(object? sender, EventArgs e)
        {
            if (lstFayllar.SelectedItem is not FileItem file) return;

            DialogResult answer = MessageBox.Show(this,
                $"'{file.Name}' faylını həmişəlik silmək istəyirsiniz?",
                "Faylı sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes) return;

            try
            {
                File.Delete(file.FullPath);
                _isDirty = false;
                LoadFileList();
                UpdateStatus("Fayl silindi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Fayl silinmədi:\n" + ex.Message,
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstFayllar_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_suppressSelectionChanged) return;
            if (lstFayllar.SelectedItem is not FileItem selected) return;

            if (!CanLoseChanges())
            {
                _suppressSelectionChanged = true;
                try
                {
                    int oldIndex = -1;
                    for (int i = 0; i < lstFayllar.Items.Count; i++)
                    {
                        if (lstFayllar.Items[i] is FileItem item &&
                            string.Equals(item.FullPath, _activeFilePath, StringComparison.OrdinalIgnoreCase))
                        {
                            oldIndex = i;
                            break;
                        }
                    }
                    lstFayllar.SelectedIndex = oldIndex;
                }
                finally
                {
                    _suppressSelectionChanged = false;
                }
                return;
            }

            OpenFile(selected.FullPath);
        }

        private void LstFayllar_DoubleClick(object? sender, EventArgs e) => BtnAc_Click(sender, e);

        private void TxtMetn_TextChanged(object? sender, EventArgs e)
        {
            if (_loadingText || _activeFilePath == null) return;
            _isDirty = true;
            UpdateStatus("Dəyişikliklər saxlanmayıb");
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.O)
            {
                BtnQovluq_Click(sender, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SaveCurrentFile();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                BtnAc_Click(sender, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (CanLoseChanges()) LoadFileList(_activeFilePath);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete && lstFayllar.Focused)
            {
                BtnSil_Click(sender, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!CanLoseChanges()) e.Cancel = true;
        }

        // Öz başlıq panelimizin pəncərə kimi hərəkət etməsi.
        private void HeaderPanel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || WindowState == FormWindowState.Maximized) return;
            _dragging = true;
            _dragOrigin = Cursor.Position;
            _dragOrigin.Offset(-Left, -Top);
        }

        private void HeaderPanel_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_dragging && e.Button == MouseButtons.Left)
            {
                Point cursor = Cursor.Position;
                Location = new Point(cursor.X - _dragOrigin.X, cursor.Y - _dragOrigin.Y);
            }
        }

        private void HeaderPanel_MouseUp(object? sender, MouseEventArgs e) => _dragging = false;

        private void HeaderPanel_Resize(object? sender, EventArgs e)
        {
            btnMinimize.Left = headerPanel.ClientSize.Width - 102;
            btnMaximize.Left = headerPanel.ClientSize.Width - 68;
            btnClose.Left = headerPanel.ClientSize.Width - 34;
        }

        private void BtnMinimize_Click(object? sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object? sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                btnMaximize.Text = "□";
            }
            else
            {
                MaximizedBounds = Screen.FromControl(this).WorkingArea;
                WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "❐";
            }
        }

        private void BtnClose_Click(object? sender, EventArgs e) => Close();

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(130, 130, 130));
            e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }
    }
}
