namespace DoAnThucHanh.App.Views
{
    partial class FileDecryptForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileTxt = new System.Windows.Forms.TextBox();
            this.browseDecryptButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileDecryptTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(313, 80);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 32);
            this.cancelButton.TabIndex = 49;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.decryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptButton.Location = new System.Drawing.Point(410, 81);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(91, 32);
            this.decryptButton.TabIndex = 48;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = false;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(447, 52);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(51, 23);
            this.saveFileButton.TabIndex = 42;
            this.saveFileButton.Text = "Browse";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Save Location:";
            // 
            // saveFileTxt
            // 
            this.saveFileTxt.Location = new System.Drawing.Point(102, 54);
            this.saveFileTxt.Name = "saveFileTxt";
            this.saveFileTxt.ReadOnly = true;
            this.saveFileTxt.Size = new System.Drawing.Size(339, 20);
            this.saveFileTxt.TabIndex = 40;
            // 
            // browseDecryptButton
            // 
            this.browseDecryptButton.Location = new System.Drawing.Point(447, 23);
            this.browseDecryptButton.Name = "browseDecryptButton";
            this.browseDecryptButton.Size = new System.Drawing.Size(51, 23);
            this.browseDecryptButton.TabIndex = 39;
            this.browseDecryptButton.Text = "Browse";
            this.browseDecryptButton.UseVisualStyleBackColor = true;
            this.browseDecryptButton.Click += new System.EventHandler(this.browseDecryptButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.Location = new System.Drawing.Point(18, 30);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(79, 13);
            this.fileLabel.TabIndex = 35;
            this.fileLabel.Text = "File Decrypt:";
            // 
            // fileDecryptTxt
            // 
            this.fileDecryptTxt.Location = new System.Drawing.Point(102, 25);
            this.fileDecryptTxt.Name = "fileDecryptTxt";
            this.fileDecryptTxt.ReadOnly = true;
            this.fileDecryptTxt.Size = new System.Drawing.Size(339, 20);
            this.fileDecryptTxt.TabIndex = 33;
            // 
            // FileDecryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 126);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveFileTxt);
            this.Controls.Add(this.browseDecryptButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileDecryptTxt);
            this.Name = "FileDecryptForm";
            this.Text = "FileDecryptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saveFileTxt;
        private System.Windows.Forms.Button browseDecryptButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileDecryptTxt;
    }
}