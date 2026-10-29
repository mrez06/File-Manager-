using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FaylMeneceri
{
    partial class Form1
    {
        private IContainer? components = null;

        private Panel headerPanel = null!;
        private Label lblTitle = null!;
        private Button btnMinimize = null!;
        private Button btnMaximize = null!;
        private Button btnClose = null!;

        private Button btnQovluq = null!;
        private Button btnAc = null!;
        private Button btnSaxla = null!;
        private Button btnSil = null!;
        private TextBox txtYol = null!;
        private ListBox lstFayllar = null!;
        private TextBox txtMetn = null!;
        private Label lblFayllarHeading = null!;
        private Label lblMetnHeading = null!;
        private Panel pnlMelumat = null!;
        private Label lblMelumat = null!;
        private StatusStrip statusStrip1 = null!;
        private ToolStripStatusLabel lblStatus = null!;

        // Şəkildə qırmızı rənglə verilən Control adları.
        private Label lblTagQovluq = null!;
        private Label lblTagAc = null!;
        private Label lblTagSaxla = null!;
        private Label lblTagSil = null!;
        private Label lblTagYol = null!;
        private Label lblTagFayllar = null!;
        private Label lblTagMetn = null!;
        private Label lblTagMelumat = null!;
        private ToolStripStatusLabel lblTagStatus = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            headerPanel = new Panel();
            lblTitle = new Label();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            btnQovluq = new Button();
            btnAc = new Button();
            btnSaxla = new Button();
            btnSil = new Button();
            txtYol = new TextBox();
            lstFayllar = new ListBox();
            txtMetn = new TextBox();
            lblFayllarHeading = new Label();
            lblMetnHeading = new Label();
            pnlMelumat = new Panel();
            lblMelumat = new Label();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblTagStatus = new ToolStripStatusLabel();
            lblTagQovluq = new Label();
            lblTagAc = new Label();
            lblTagSaxla = new Label();
            lblTagSil = new Label();
            lblTagYol = new Label();
            lblTagFayllar = new Label();
            lblTagMetn = new Label();
            lblTagMelumat = new Label();

            lblTagQovluq.Name = "lblTagQovluq";
            lblTagQovluq.Text = "btnQovluq";
            lblTagQovluq.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagQovluq.Font = new Font("Segoe UI", 8.5F);
            lblTagQovluq.AutoEllipsis = true;
            lblTagQovluq.Location = new Point(17, 89);
            lblTagQovluq.Size = new Size(130, 20);
            lblTagQovluq.BackColor = Color.Transparent;
            lblTagAc.Name = "lblTagAc";
            lblTagAc.Text = "btnAc";
            lblTagAc.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagAc.Font = new Font("Segoe UI", 8.5F);
            lblTagAc.AutoEllipsis = true;
            lblTagAc.Location = new Point(163, 89);
            lblTagAc.Size = new Size(130, 20);
            lblTagAc.BackColor = Color.Transparent;
            lblTagSaxla.Name = "lblTagSaxla";
            lblTagSaxla.Text = "btnSaxla";
            lblTagSaxla.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagSaxla.Font = new Font("Segoe UI", 8.5F);
            lblTagSaxla.AutoEllipsis = true;
            lblTagSaxla.Location = new Point(310, 89);
            lblTagSaxla.Size = new Size(130, 20);
            lblTagSaxla.BackColor = Color.Transparent;
            lblTagSil.Name = "lblTagSil";
            lblTagSil.Text = "btnSil";
            lblTagSil.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagSil.Font = new Font("Segoe UI", 8.5F);
            lblTagSil.AutoEllipsis = true;
            lblTagSil.Location = new Point(457, 89);
            lblTagSil.Size = new Size(130, 20);
            lblTagSil.BackColor = Color.Transparent;
            lblTagYol.Name = "lblTagYol";
            lblTagYol.Text = "txtYol (ReadOnly)";
            lblTagYol.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagYol.Font = new Font("Segoe UI", 8.5F);
            lblTagYol.AutoEllipsis = true;
            lblTagYol.Location = new Point(604, 89);
            lblTagYol.Size = new Size(259, 20);
            lblTagYol.BackColor = Color.Transparent;
            lblTagFayllar.Name = "lblTagFayllar";
            lblTagFayllar.Text = "lstFayllar (ListBox)";
            lblTagFayllar.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagFayllar.Font = new Font("Segoe UI", 8.5F);
            lblTagFayllar.AutoEllipsis = true;
            lblTagFayllar.Location = new Point(17, 495);
            lblTagFayllar.Size = new Size(245, 20);
            lblTagFayllar.BackColor = Color.Transparent;
            lblTagMetn.Name = "lblTagMetn";
            lblTagMetn.Text = "txtMetn (Multiline, ScrollBars = Vertical)";
            lblTagMetn.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagMetn.Font = new Font("Segoe UI", 8.5F);
            lblTagMetn.AutoEllipsis = true;
            lblTagMetn.Location = new Point(284, 495);
            lblTagMetn.Size = new Size(470, 20);
            lblTagMetn.BackColor = Color.Transparent;
            lblTagMelumat.Name = "lblTagMelumat";
            lblTagMelumat.Text = "lblMelumat (Label)";
            lblTagMelumat.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagMelumat.Font = new Font("Segoe UI", 8.5F);
            lblTagMelumat.AutoEllipsis = true;
            lblTagMelumat.Location = new Point(9, 23);
            lblTagMelumat.Size = new Size(250, 20);
            lblTagMelumat.BackColor = Color.Transparent;

            SuspendLayout();

            // Başlıq paneli (şəkildəki mavi başlıq)
            headerPanel.BackColor = Color.FromArgb(47, 107, 218);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 32;
            headerPanel.Name = "headerPanel";
            headerPanel.MouseDown += HeaderPanel_MouseDown;
            headerPanel.MouseMove += HeaderPanel_MouseMove;
            headerPanel.MouseUp += HeaderPanel_MouseUp;
            headerPanel.DoubleClick += BtnMaximize_Click;

            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Fayl Meneceri";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 4);
            lblTitle.Size = new Size(260, 24);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.MouseDown += HeaderPanel_MouseDown;
            lblTitle.MouseMove += HeaderPanel_MouseMove;
            lblTitle.MouseUp += HeaderPanel_MouseUp;
            lblTitle.DoubleClick += BtnMaximize_Click;

            btnMinimize.Name = "btnMinimize";
            btnMinimize.Text = "−";
            btnMinimize.Size = new Size(34, 32);
            btnMinimize.Location = new Point(ClientSize.Width - 102, 0);
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.ForeColor = Color.White;
            btnMinimize.BackColor = Color.FromArgb(47, 107, 218);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 87, 187);
            btnMinimize.TabStop = false;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.Font = new Font("Segoe UI", 12F);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Text = "□";
            btnMaximize.Size = new Size(34, 32);
            btnMaximize.Location = new Point(ClientSize.Width - 68, 0);
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.ForeColor = Color.White;
            btnMaximize.BackColor = Color.FromArgb(47, 107, 218);
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 87, 187);
            btnMaximize.TabStop = false;
            btnMaximize.Cursor = Cursors.Hand;
            btnMaximize.Font = new Font("Segoe UI", 12F);
            btnClose.Name = "btnClose";
            btnClose.Text = "×";
            btnClose.Size = new Size(34, 32);
            btnClose.Location = new Point(ClientSize.Width - 34, 0);
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(47, 107, 218);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(205, 47, 47);
            btnClose.TabStop = false;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 12F);
            btnMinimize.Click += BtnMinimize_Click;
            btnMaximize.Click += BtnMaximize_Click;
            btnClose.Click += BtnClose_Click;

            // Sağ tərəfə yapışan başlıq düymələri
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(btnMinimize);
            headerPanel.Controls.Add(btnMaximize);
            headerPanel.Controls.Add(btnClose);
            headerPanel.Resize += HeaderPanel_Resize;

            btnQovluq.Name = "btnQovluq";
            btnQovluq.Text = "Qovluq seç";
            btnQovluq.Location = new Point(17, 52);
            btnQovluq.Size = new Size(130, 35);
            btnQovluq.BackColor = Color.FromArgb(223, 223, 223);
            btnQovluq.FlatStyle = FlatStyle.Flat;
            btnQovluq.FlatAppearance.BorderColor = Color.FromArgb(149, 149, 149);
            btnQovluq.FlatAppearance.BorderSize = 1;
            btnQovluq.UseVisualStyleBackColor = false;
            btnQovluq.Font = new Font("Segoe UI", 9.5F);
            btnQovluq.Cursor = Cursors.Hand;
            btnAc.Name = "btnAc";
            btnAc.Text = "Aç";
            btnAc.Location = new Point(163, 52);
            btnAc.Size = new Size(130, 35);
            btnAc.BackColor = Color.FromArgb(223, 223, 223);
            btnAc.FlatStyle = FlatStyle.Flat;
            btnAc.FlatAppearance.BorderColor = Color.FromArgb(149, 149, 149);
            btnAc.FlatAppearance.BorderSize = 1;
            btnAc.UseVisualStyleBackColor = false;
            btnAc.Font = new Font("Segoe UI", 9.5F);
            btnAc.Cursor = Cursors.Hand;
            btnSaxla.Name = "btnSaxla";
            btnSaxla.Text = "Yadda saxla";
            btnSaxla.Location = new Point(310, 52);
            btnSaxla.Size = new Size(130, 35);
            btnSaxla.BackColor = Color.FromArgb(223, 223, 223);
            btnSaxla.FlatStyle = FlatStyle.Flat;
            btnSaxla.FlatAppearance.BorderColor = Color.FromArgb(149, 149, 149);
            btnSaxla.FlatAppearance.BorderSize = 1;
            btnSaxla.UseVisualStyleBackColor = false;
            btnSaxla.Font = new Font("Segoe UI", 9.5F);
            btnSaxla.Cursor = Cursors.Hand;
            btnSil.Name = "btnSil";
            btnSil.Text = "Sil";
            btnSil.Location = new Point(457, 52);
            btnSil.Size = new Size(130, 35);
            btnSil.BackColor = Color.FromArgb(223, 223, 223);
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.FlatAppearance.BorderColor = Color.FromArgb(149, 149, 149);
            btnSil.FlatAppearance.BorderSize = 1;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Font = new Font("Segoe UI", 9.5F);
            btnSil.Cursor = Cursors.Hand;
            btnQovluq.Click += BtnQovluq_Click;
            btnAc.Click += BtnAc_Click;
            btnSaxla.Click += BtnSaxla_Click;
            btnSil.Click += BtnSil_Click;

            txtYol.Name = "txtYol";
            txtYol.Location = new Point(604, 58);
            txtYol.Size = new Size(259, 25);
            txtYol.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtYol.ReadOnly = true;
            txtYol.BackColor = Color.White;
            txtYol.ForeColor = Color.Gray;
            txtYol.BorderStyle = BorderStyle.FixedSingle;
            txtYol.Font = new Font("Segoe UI", 9.5F);
            txtYol.TabStop = false;

            lblFayllarHeading.Name = "lblFayllarHeading";
            lblFayllarHeading.Text = "Fayllar";
            lblFayllarHeading.Location = new Point(25, 111);
            lblFayllarHeading.Size = new Size(190, 20);
            lblFayllarHeading.Font = new Font("Segoe UI", 9.5F);

            lblMetnHeading.Name = "lblMetnHeading";
            lblMetnHeading.Text = "Mətn";
            lblMetnHeading.Location = new Point(284, 111);
            lblMetnHeading.Size = new Size(100, 20);
            lblMetnHeading.Font = new Font("Segoe UI", 9.5F);

            lstFayllar.Name = "lstFayllar";
            lstFayllar.FormattingEnabled = true;
            lstFayllar.IntegralHeight = false;
            lstFayllar.Location = new Point(17, 134);
            lstFayllar.Size = new Size(242, 360);
            lstFayllar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstFayllar.Font = new Font("Segoe UI", 9.5F);
            lstFayllar.BorderStyle = BorderStyle.FixedSingle;
            lstFayllar.SelectedIndexChanged += LstFayllar_SelectedIndexChanged;
            lstFayllar.DoubleClick += LstFayllar_DoubleClick;

            txtMetn.Name = "txtMetn";
            txtMetn.Location = new Point(284, 134);
            txtMetn.Size = new Size(579, 360);
            txtMetn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMetn.Font = new Font("Segoe UI", 9.5F);
            txtMetn.BackColor = Color.White;
            txtMetn.BorderStyle = BorderStyle.FixedSingle;
            txtMetn.Multiline = true;
            txtMetn.ScrollBars = ScrollBars.Vertical;
            txtMetn.AcceptsTab = true;
            txtMetn.TextChanged += TxtMetn_TextChanged;

            lblTagFayllar.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            lblTagMetn.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            lblTagYol.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            pnlMelumat.Name = "pnlMelumat";
            pnlMelumat.Location = new Point(17, 526);
            pnlMelumat.Size = new Size(846, 44);
            pnlMelumat.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlMelumat.BackColor = Color.FromArgb(247, 247, 247);
            pnlMelumat.BorderStyle = BorderStyle.FixedSingle;

            lblMelumat.Name = "lblMelumat";
            lblMelumat.Text = "Fayl seçilməyib";
            lblMelumat.Location = new Point(9, 7);
            lblMelumat.Size = new Size(822, 20);
            lblMelumat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMelumat.Font = new Font("Segoe UI", 9.5F);
            lblMelumat.AutoEllipsis = true;
            pnlMelumat.Controls.Add(lblMelumat);
            pnlMelumat.Controls.Add(lblTagMelumat);

            statusStrip1.Name = "statusStrip1";
            statusStrip1.Dock = DockStyle.Bottom;
            statusStrip1.SizingGrip = false;
            statusStrip1.AutoSize = false;
            statusStrip1.Height = 30;
            statusStrip1.BackColor = Color.FromArgb(226, 226, 226);
            statusStrip1.Padding = new Padding(7, 0, 9, 0);
            statusStrip1.Font = new Font("Segoe UI", 9.5F);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Hazırdır  |  Fayl sayı: 0";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.AutoSize = true;
            lblTagStatus.Name = "lblTagStatus";
            lblTagStatus.Text = "statusStrip1 → lblStatus";
            lblTagStatus.ForeColor = Color.FromArgb(225, 74, 61);
            lblTagStatus.Spring = true;
            lblTagStatus.TextAlign = ContentAlignment.MiddleCenter;
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, lblTagStatus });

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 614);
            MinimumSize = new Size(750, 480);
            BackColor = Color.FromArgb(227, 227, 227);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fayl Meneceri";
            Name = "Form1";
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            FormClosing += Form1_FormClosing;
            Paint += Form1_Paint;

            Controls.Add(headerPanel);
            Controls.Add(btnQovluq);
            Controls.Add(btnAc);
            Controls.Add(btnSaxla);
            Controls.Add(btnSil);
            Controls.Add(txtYol);
            Controls.Add(lblTagQovluq);
            Controls.Add(lblTagAc);
            Controls.Add(lblTagSaxla);
            Controls.Add(lblTagSil);
            Controls.Add(lblTagYol);
            Controls.Add(lblFayllarHeading);
            Controls.Add(lblMetnHeading);
            Controls.Add(lstFayllar);
            Controls.Add(txtMetn);
            Controls.Add(lblTagFayllar);
            Controls.Add(lblTagMetn);
            Controls.Add(pnlMelumat);
            Controls.Add(statusStrip1);

            ResumeLayout(false);
            PerformLayout();
        }

    }
}
