namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnDownload = new Button();
            txtMangaId = new TextBox();
            txtProgress = new TextBox();
            cmbLanguage = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.Transparent;
            btnDownload.Location = new Point(383, 50);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(111, 46);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // txtMangaId
            // 
            txtMangaId.Location = new Point(120, 38);
            txtMangaId.Name = "txtMangaId";
            txtMangaId.Size = new Size(232, 23);
            txtMangaId.TabIndex = 1;
            txtMangaId.TextChanged += textBox1_TextChanged;
            // 
            // txtProgress
            // 
            txtProgress.Location = new Point(12, 132);
            txtProgress.Multiline = true;
            txtProgress.Name = "txtProgress";
            txtProgress.Size = new Size(499, 187);
            txtProgress.TabIndex = 2;
            txtProgress.TextChanged += txtProgress_TextChanged;
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(120, 71);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(49, 23);
            cmbLanguage.TabIndex = 3;
            cmbLanguage.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 1, true);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 4;
            label1.Text = "Mangadex ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 5;
            label2.Text = "Language";
            label2.Click += label2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 110);
            progressBar1.Maximum = 0;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(499, 16);
            progressBar1.TabIndex = 6;
            progressBar1.Click += progressBar1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(524, 23);
            panel1.TabIndex = 7;
            panel1.DragDrop += panel1_DragDrop;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(499, -2);
            label4.Name = "label4";
            label4.Size = new Size(25, 28);
            label4.TabIndex = 1;
            label4.Text = "X";
            label4.TextAlign = ContentAlignment.TopCenter;
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.ForeColor = Color.Red;
            label3.ImageAlign = ContentAlignment.TopCenter;
            label3.Location = new Point(467, -5);
            label3.Name = "label3";
            label3.Size = new Size(26, 32);
            label3.TabIndex = 0;
            label3.Text = "–";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.FromArgb(255, 128, 0);
            label5.Location = new Point(1, 322);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 9;
            label5.Text = "v1.699.69";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(526, 334);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbLanguage);
            Controls.Add(txtProgress);
            Controls.Add(txtMangaId);
            Controls.Add(btnDownload);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "MangaDL";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDownload;
        private TextBox txtMangaId;
        private TextBox txtProgress;
        private ComboBox cmbLanguage;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private Panel panel1;
        private Label label3;
        private Label label4;
        private CheckBox checkBox1;
        private Label label5;
    }
}
