namespace StreamEncryption
{
    partial class StreamEncryption
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdChooseFile = new System.Windows.Forms.OpenFileDialog();
            this.lbSeanceKey = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lbEnter = new System.Windows.Forms.Label();
            this.btInputFile = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lbOutput = new System.Windows.Forms.Label();
            this.btOutputFile = new System.Windows.Forms.Button();
            this.tbSeanceKey = new System.Windows.Forms.TextBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lbKey = new System.Windows.Forms.Label();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tstrbtEncrypt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstrbtDecrypt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tstrbtClean = new System.Windows.Forms.ToolStripButton();
            this.lbSymbolsCount = new System.Windows.Forms.Label();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdChooseFile
            // 
            this.ofdChooseFile.Filter = "All files|*.*";
            this.ofdChooseFile.InitialDirectory = ".";
            this.ofdChooseFile.RestoreDirectory = true;
            // 
            // lbSeanceKey
            // 
            this.lbSeanceKey.AutoSize = true;
            this.lbSeanceKey.BackColor = System.Drawing.Color.Pink;
            this.lbSeanceKey.Location = new System.Drawing.Point(30, 283);
            this.lbSeanceKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSeanceKey.Name = "lbSeanceKey";
            this.lbSeanceKey.Size = new System.Drawing.Size(165, 17);
            this.lbSeanceKey.TabIndex = 1;
            this.lbSeanceKey.Text = "Сеансовый ключ(33 бита):";
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(16, 54);
            this.tbInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInput.Size = new System.Drawing.Size(350, 178);
            this.tbInput.TabIndex = 2;
            // 
            // lbEnter
            // 
            this.lbEnter.AutoSize = true;
            this.lbEnter.BackColor = System.Drawing.Color.Pink;
            this.lbEnter.Location = new System.Drawing.Point(13, 24);
            this.lbEnter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEnter.Name = "lbEnter";
            this.lbEnter.Size = new System.Drawing.Size(40, 17);
            this.lbEnter.TabIndex = 5;
            this.lbEnter.Text = "Ввод:";
            // 
            // btInputFile
            // 
            this.btInputFile.BackColor = System.Drawing.Color.Thistle;
            this.btInputFile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btInputFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btInputFile.Location = new System.Drawing.Point(60, 20);
            this.btInputFile.Name = "btInputFile";
            this.btInputFile.Size = new System.Drawing.Size(100, 25);
            this.btInputFile.TabIndex = 6;
            this.btInputFile.Text = "Файл";
            this.btInputFile.UseVisualStyleBackColor = false;
            this.btInputFile.Click += new System.EventHandler(this.btInputFile_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(16, 54);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(350, 178);
            this.tbOutput.TabIndex = 7;
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.BackColor = System.Drawing.Color.Pink;
            this.lbOutput.Location = new System.Drawing.Point(18, 24);
            this.lbOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(49, 17);
            this.lbOutput.TabIndex = 8;
            this.lbOutput.Text = "Вывод:";
            // 
            // btOutputFile
            // 
            this.btOutputFile.BackColor = System.Drawing.Color.Thistle;
            this.btOutputFile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btOutputFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btOutputFile.Location = new System.Drawing.Point(74, 20);
            this.btOutputFile.Name = "btOutputFile";
            this.btOutputFile.Size = new System.Drawing.Size(92, 25);
            this.btOutputFile.TabIndex = 9;
            this.btOutputFile.Text = "Файл";
            this.btOutputFile.UseVisualStyleBackColor = false;
            this.btOutputFile.Click += new System.EventHandler(this.btOutputFile_Click);
            // 
            // tbSeanceKey
            // 
            this.tbSeanceKey.Location = new System.Drawing.Point(33, 303);
            this.tbSeanceKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbSeanceKey.Multiline = true;
            this.tbSeanceKey.Name = "tbSeanceKey";
            this.tbSeanceKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSeanceKey.Size = new System.Drawing.Size(266, 47);
            this.tbSeanceKey.TabIndex = 10;
            this.tbSeanceKey.TextChanged += new System.EventHandler(this.tbSeanceKey_TextChanged);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(319, 303);
            this.tbKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbKey.Multiline = true;
            this.tbKey.Name = "tbKey";
            this.tbKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbKey.Size = new System.Drawing.Size(516, 73);
            this.tbKey.TabIndex = 13;
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.BackColor = System.Drawing.Color.Pink;
            this.lbKey.Location = new System.Drawing.Point(316, 283);
            this.lbKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(155, 17);
            this.lbKey.TabIndex = 14;
            this.lbKey.Text = "Сгенерированный ключ:";
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.tbInput);
            this.gbInput.Controls.Add(this.lbEnter);
            this.gbInput.Controls.Add(this.btInputFile);
            this.gbInput.Location = new System.Drawing.Point(33, 25);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(384, 246);
            this.gbInput.TabIndex = 19;
            this.gbInput.TabStop = false;
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.lbOutput);
            this.gbOutput.Controls.Add(this.btOutputFile);
            this.gbOutput.Controls.Add(this.tbOutput);
            this.gbOutput.Location = new System.Drawing.Point(451, 25);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(384, 246);
            this.gbOutput.TabIndex = 20;
            this.gbOutput.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrbtEncrypt,
            this.toolStripSeparator1,
            this.tstrbtDecrypt,
            this.toolStripSeparator2,
            this.tstrbtClean});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(867, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tstrbtEncrypt
            // 
            this.tstrbtEncrypt.BackColor = System.Drawing.Color.Thistle;
            this.tstrbtEncrypt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstrbtEncrypt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrbtEncrypt.Name = "tstrbtEncrypt";
            this.tstrbtEncrypt.Size = new System.Drawing.Size(75, 22);
            this.tstrbtEncrypt.Text = "Шифровать";
            this.tstrbtEncrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstrbtDecrypt
            // 
            this.tstrbtDecrypt.BackColor = System.Drawing.Color.Thistle;
            this.tstrbtDecrypt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstrbtDecrypt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrbtDecrypt.Name = "tstrbtDecrypt";
            this.tstrbtDecrypt.Size = new System.Drawing.Size(89, 22);
            this.tstrbtDecrypt.Text = "Дешифровать";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tstrbtClean
            // 
            this.tstrbtClean.BackColor = System.Drawing.Color.Thistle;
            this.tstrbtClean.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstrbtClean.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrbtClean.Name = "tstrbtClean";
            this.tstrbtClean.Size = new System.Drawing.Size(63, 22);
            this.tstrbtClean.Text = "Очистить";
            this.tstrbtClean.Click += new System.EventHandler(this.tstrbtClean_Click);
            // 
            // lbSymbolsCount
            // 
            this.lbSymbolsCount.AutoSize = true;
            this.lbSymbolsCount.Location = new System.Drawing.Point(30, 359);
            this.lbSymbolsCount.Name = "lbSymbolsCount";
            this.lbSymbolsCount.Size = new System.Drawing.Size(270, 17);
            this.lbSymbolsCount.TabIndex = 23;
            this.lbSymbolsCount.Text = "Количество двоичных символов регистра:0";
            
            // 
            // StreamEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleVioletRed;
            this.ClientSize = new System.Drawing.Size(867, 418);
            this.Controls.Add(this.lbSymbolsCount);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.tbSeanceKey);
            this.Controls.Add(this.lbSeanceKey);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StreamEncryption";
            this.Text = "StreamLFSR";
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdChooseFile;
        private System.Windows.Forms.Label lbSeanceKey;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lbEnter;
        private System.Windows.Forms.Button btInputFile;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Button btOutputFile;
        private System.Windows.Forms.TextBox tbSeanceKey;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tstrbtEncrypt;
        private System.Windows.Forms.ToolStripButton tstrbtDecrypt;
        private System.Windows.Forms.ToolStripButton tstrbtClean;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lbSymbolsCount;
    }
}

