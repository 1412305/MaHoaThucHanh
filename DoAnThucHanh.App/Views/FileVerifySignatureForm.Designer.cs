namespace DoAnThucHanh.App.Views
{
    partial class FileVerifySignatureForm
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
            this.fileSignatureButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSignatureTxt = new System.Windows.Forms.TextBox();
            this.browseVerifyButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileVerifyTxt = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.verifyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileSignatureButton
            // 
            this.fileSignatureButton.Location = new System.Drawing.Point(451, 39);
            this.fileSignatureButton.Name = "fileSignatureButton";
            this.fileSignatureButton.Size = new System.Drawing.Size(51, 23);
            this.fileSignatureButton.TabIndex = 27;
            this.fileSignatureButton.Text = "Browse";
            this.fileSignatureButton.UseVisualStyleBackColor = true;
            this.fileSignatureButton.Click += new System.EventHandler(this.fileSignatureButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "File Signature:";
            // 
            // fileSignatureTxt
            // 
            this.fileSignatureTxt.Location = new System.Drawing.Point(106, 41);
            this.fileSignatureTxt.Name = "fileSignatureTxt";
            this.fileSignatureTxt.ReadOnly = true;
            this.fileSignatureTxt.Size = new System.Drawing.Size(339, 20);
            this.fileSignatureTxt.TabIndex = 25;
            // 
            // browseVerifyButton
            // 
            this.browseVerifyButton.Location = new System.Drawing.Point(451, 10);
            this.browseVerifyButton.Name = "browseVerifyButton";
            this.browseVerifyButton.Size = new System.Drawing.Size(51, 23);
            this.browseVerifyButton.TabIndex = 24;
            this.browseVerifyButton.Text = "Browse";
            this.browseVerifyButton.UseVisualStyleBackColor = true;
            this.browseVerifyButton.Click += new System.EventHandler(this.browseVerifyButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.Location = new System.Drawing.Point(29, 15);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(67, 13);
            this.fileLabel.TabIndex = 23;
            this.fileLabel.Text = "File Verify:";
            // 
            // fileVerifyTxt
            // 
            this.fileVerifyTxt.Location = new System.Drawing.Point(106, 12);
            this.fileVerifyTxt.Name = "fileVerifyTxt";
            this.fileVerifyTxt.ReadOnly = true;
            this.fileVerifyTxt.Size = new System.Drawing.Size(339, 20);
            this.fileVerifyTxt.TabIndex = 22;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(314, 77);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 32);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.verifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyButton.Location = new System.Drawing.Point(411, 77);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(91, 32);
            this.verifyButton.TabIndex = 33;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // FileVerifySignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 122);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.fileSignatureButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileSignatureTxt);
            this.Controls.Add(this.browseVerifyButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileVerifyTxt);
            this.Name = "FileVerifySignatureForm";
            this.Text = "FileVerifySignature";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileSignatureButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileSignatureTxt;
        private System.Windows.Forms.Button browseVerifyButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileVerifyTxt;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button verifyButton;
    }
}