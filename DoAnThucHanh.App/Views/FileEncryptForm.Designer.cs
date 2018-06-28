namespace DoAnThucHanh.App.Views
{
    partial class FileEncryptForm
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
            this.keySizeLabel = new System.Windows.Forms.Label();
            this.algoLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.algoCb = new System.Windows.Forms.ComboBox();
            this.fileEncryptTxt = new System.Windows.Forms.TextBox();
            this.emailCb = new System.Windows.Forms.ComboBox();
            this.browseEncryptButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.paddingCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modeCb = new System.Windows.Forms.ComboBox();
            this.compressCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keySizeLabel
            // 
            this.keySizeLabel.AutoSize = true;
            this.keySizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keySizeLabel.Location = new System.Drawing.Point(65, 70);
            this.keySizeLabel.Name = "keySizeLabel";
            this.keySizeLabel.Size = new System.Drawing.Size(26, 13);
            this.keySizeLabel.TabIndex = 16;
            this.keySizeLabel.Text = "To:";
            // 
            // algoLabel
            // 
            this.algoLabel.AutoSize = true;
            this.algoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algoLabel.Location = new System.Drawing.Point(28, 97);
            this.algoLabel.Name = "algoLabel";
            this.algoLabel.Size = new System.Drawing.Size(63, 13);
            this.algoLabel.TabIndex = 15;
            this.algoLabel.Text = "Algorithm:";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.Location = new System.Drawing.Point(13, 17);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(78, 13);
            this.fileLabel.TabIndex = 14;
            this.fileLabel.Text = "File Encrypt:";
            // 
            // algoCb
            // 
            this.algoCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algoCb.FormattingEnabled = true;
            this.algoCb.Location = new System.Drawing.Point(97, 94);
            this.algoCb.Name = "algoCb";
            this.algoCb.Size = new System.Drawing.Size(110, 21);
            this.algoCb.TabIndex = 13;
            this.algoCb.SelectedValueChanged += new System.EventHandler(this.algoCb_SelectedValueChanged);
            // 
            // fileEncryptTxt
            // 
            this.fileEncryptTxt.Location = new System.Drawing.Point(97, 12);
            this.fileEncryptTxt.Name = "fileEncryptTxt";
            this.fileEncryptTxt.ReadOnly = true;
            this.fileEncryptTxt.Size = new System.Drawing.Size(339, 20);
            this.fileEncryptTxt.TabIndex = 11;
            // 
            // emailCb
            // 
            this.emailCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emailCb.FormattingEnabled = true;
            this.emailCb.Location = new System.Drawing.Point(97, 67);
            this.emailCb.Name = "emailCb";
            this.emailCb.Size = new System.Drawing.Size(396, 21);
            this.emailCb.TabIndex = 17;
            this.emailCb.SelectedValueChanged += new System.EventHandler(this.emailCb_SelectedValueChanged);
            // 
            // browseEncryptButton
            // 
            this.browseEncryptButton.Location = new System.Drawing.Point(442, 10);
            this.browseEncryptButton.Name = "browseEncryptButton";
            this.browseEncryptButton.Size = new System.Drawing.Size(51, 23);
            this.browseEncryptButton.TabIndex = 18;
            this.browseEncryptButton.Text = "Browse";
            this.browseEncryptButton.UseVisualStyleBackColor = true;
            this.browseEncryptButton.Click += new System.EventHandler(this.browseEncryptButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(442, 39);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(51, 23);
            this.saveFileButton.TabIndex = 21;
            this.saveFileButton.Text = "Browse";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Save Location:";
            // 
            // saveFileTxt
            // 
            this.saveFileTxt.Location = new System.Drawing.Point(97, 41);
            this.saveFileTxt.Name = "saveFileTxt";
            this.saveFileTxt.ReadOnly = true;
            this.saveFileTxt.Size = new System.Drawing.Size(339, 20);
            this.saveFileTxt.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Padding:";
            // 
            // paddingCb
            // 
            this.paddingCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paddingCb.FormattingEnabled = true;
            this.paddingCb.Location = new System.Drawing.Point(276, 94);
            this.paddingCb.Name = "paddingCb";
            this.paddingCb.Size = new System.Drawing.Size(83, 21);
            this.paddingCb.TabIndex = 22;
            this.paddingCb.SelectedValueChanged += new System.EventHandler(this.paddingCb_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mode:";
            // 
            // modeCb
            // 
            this.modeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeCb.FormattingEnabled = true;
            this.modeCb.Location = new System.Drawing.Point(413, 94);
            this.modeCb.Name = "modeCb";
            this.modeCb.Size = new System.Drawing.Size(80, 21);
            this.modeCb.TabIndex = 24;
            this.modeCb.SelectedValueChanged += new System.EventHandler(this.modeCb_SelectedValueChanged);
            // 
            // compressCheckBox
            // 
            this.compressCheckBox.AutoSize = true;
            this.compressCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compressCheckBox.Location = new System.Drawing.Point(97, 130);
            this.compressCheckBox.Name = "compressCheckBox";
            this.compressCheckBox.Size = new System.Drawing.Size(80, 17);
            this.compressCheckBox.TabIndex = 26;
            this.compressCheckBox.Text = "Compress";
            this.compressCheckBox.UseVisualStyleBackColor = true;
            this.compressCheckBox.CheckedChanged += new System.EventHandler(this.compressCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(305, 130);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 32);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.encryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptButton.Location = new System.Drawing.Point(402, 130);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(91, 32);
            this.encryptButton.TabIndex = 31;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = false;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // FileEncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(505, 174);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.compressCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modeCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paddingCb);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveFileTxt);
            this.Controls.Add(this.browseEncryptButton);
            this.Controls.Add(this.emailCb);
            this.Controls.Add(this.keySizeLabel);
            this.Controls.Add(this.algoLabel);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.algoCb);
            this.Controls.Add(this.fileEncryptTxt);
            this.Name = "FileEncryptForm";
            this.Text = "FileEncryptForm";
            this.Load += new System.EventHandler(this.FileEncryptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keySizeLabel;
        private System.Windows.Forms.Label algoLabel;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.ComboBox algoCb;
        private System.Windows.Forms.TextBox fileEncryptTxt;
        private System.Windows.Forms.ComboBox emailCb;
        private System.Windows.Forms.Button browseEncryptButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saveFileTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox paddingCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox modeCb;
        private System.Windows.Forms.CheckBox compressCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button encryptButton;
    }
}