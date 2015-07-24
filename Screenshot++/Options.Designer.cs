namespace Screenshot__
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSavePath = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.lblSaveFormat = new System.Windows.Forms.Label();
            this.lblSavePrefix = new System.Windows.Forms.Label();
            this.txtSavePrefix = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAbout = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblQuality = new System.Windows.Forms.Label();
            this.trackQuality = new System.Windows.Forms.TrackBar();
            this.lblQualityMin = new System.Windows.Forms.Label();
            this.lblQualityMax = new System.Windows.Forms.Label();
            this.lblQualityCurrent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(13, 13);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(57, 13);
            this.lblSavePath.TabIndex = 0;
            this.lblSavePath.Text = "Save Path";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavePath.Location = new System.Drawing.Point(16, 30);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(377, 20);
            this.txtSavePath.TabIndex = 1;
            // 
            // cmbFormat
            // 
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(16, 69);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(121, 21);
            this.cmbFormat.TabIndex = 2;
            this.cmbFormat.SelectedIndexChanged += new System.EventHandler(this.cmbFormat_SelectedIndexChanged);
            // 
            // lblSaveFormat
            // 
            this.lblSaveFormat.AutoSize = true;
            this.lblSaveFormat.Location = new System.Drawing.Point(13, 53);
            this.lblSaveFormat.Name = "lblSaveFormat";
            this.lblSaveFormat.Size = new System.Drawing.Size(67, 13);
            this.lblSaveFormat.TabIndex = 3;
            this.lblSaveFormat.Text = "Save Format";
            // 
            // lblSavePrefix
            // 
            this.lblSavePrefix.AutoSize = true;
            this.lblSavePrefix.Location = new System.Drawing.Point(144, 53);
            this.lblSavePrefix.Name = "lblSavePrefix";
            this.lblSavePrefix.Size = new System.Drawing.Size(61, 13);
            this.lblSavePrefix.TabIndex = 4;
            this.lblSavePrefix.Text = "Save Prefix";
            // 
            // txtSavePrefix
            // 
            this.txtSavePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavePrefix.Location = new System.Drawing.Point(147, 69);
            this.txtSavePrefix.Name = "txtSavePrefix";
            this.txtSavePrefix.Size = new System.Drawing.Size(328, 20);
            this.txtSavePrefix.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(398, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(317, 223);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(67, 228);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(73, 13);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "Screenshot++";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(398, 30);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbLogo.Location = new System.Drawing.Point(16, 193);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(48, 48);
            this.pbLogo.TabIndex = 11;
            this.pbLogo.TabStop = false;
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(16, 97);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(39, 13);
            this.lblQuality.TabIndex = 12;
            this.lblQuality.Text = "Quality";
            // 
            // trackQuality
            // 
            this.trackQuality.Location = new System.Drawing.Point(19, 114);
            this.trackQuality.Maximum = 100;
            this.trackQuality.Name = "trackQuality";
            this.trackQuality.Size = new System.Drawing.Size(118, 45);
            this.trackQuality.SmallChange = 5;
            this.trackQuality.TabIndex = 13;
            this.trackQuality.Value = 75;
            this.trackQuality.ValueChanged += new System.EventHandler(this.trackQuality_ValueChanged);
            // 
            // lblQualityMin
            // 
            this.lblQualityMin.AutoSize = true;
            this.lblQualityMin.Location = new System.Drawing.Point(16, 146);
            this.lblQualityMin.Name = "lblQualityMin";
            this.lblQualityMin.Size = new System.Drawing.Size(13, 13);
            this.lblQualityMin.TabIndex = 14;
            this.lblQualityMin.Text = "0";
            // 
            // lblQualityMax
            // 
            this.lblQualityMax.AutoSize = true;
            this.lblQualityMax.Location = new System.Drawing.Point(112, 146);
            this.lblQualityMax.Name = "lblQualityMax";
            this.lblQualityMax.Size = new System.Drawing.Size(25, 13);
            this.lblQualityMax.TabIndex = 15;
            this.lblQualityMax.Text = "100";
            // 
            // lblQualityCurrent
            // 
            this.lblQualityCurrent.AutoSize = true;
            this.lblQualityCurrent.Location = new System.Drawing.Point(67, 146);
            this.lblQualityCurrent.Name = "lblQualityCurrent";
            this.lblQualityCurrent.Size = new System.Drawing.Size(19, 13);
            this.lblQualityCurrent.TabIndex = 16;
            this.lblQualityCurrent.Text = "50";
            // 
            // Options
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(487, 258);
            this.Controls.Add(this.lblQualityCurrent);
            this.Controls.Add(this.lblQualityMax);
            this.Controls.Add(this.lblQualityMin);
            this.Controls.Add(this.trackQuality);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSavePrefix);
            this.Controls.Add(this.lblSavePrefix);
            this.Controls.Add(this.lblSaveFormat);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.lblSavePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label lblSaveFormat;
        private System.Windows.Forms.Label lblSavePrefix;
        private System.Windows.Forms.TextBox txtSavePrefix;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.TrackBar trackQuality;
        private System.Windows.Forms.Label lblQualityMin;
        private System.Windows.Forms.Label lblQualityMax;
        private System.Windows.Forms.Label lblQualityCurrent;
    }
}