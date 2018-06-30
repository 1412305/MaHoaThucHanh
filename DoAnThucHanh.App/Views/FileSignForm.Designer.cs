namespace DoAnThucHanh.App.Views
{
    partial class FileSignForm
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
            this.browseSignButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileSignTxt = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // browseSignButton
            // 
            this.browseSignButton.Location = new System.Drawing.Point(434, 10);
            this.browseSignButton.Name = "browseSignButton";
            this.browseSignButton.Size = new System.Drawing.Size(51, 23);
            this.browseSignButton.TabIndex = 21;
            this.browseSignButton.Text = "Browse";
            this.browseSignButton.UseVisualStyleBackColor = true;
            this.browseSignButton.Click += new System.EventHandler(this.browseSignButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.Location = new System.Drawing.Point(5, 15);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(60, 13);
            this.fileLabel.TabIndex = 20;
            this.fileLabel.Text = "File Sign:";
            // 
            // fileSignTxt
            // 
            this.fileSignTxt.Location = new System.Drawing.Point(89, 12);
            this.fileSignTxt.Name = "fileSignTxt";
            this.fileSignTxt.ReadOnly = true;
            this.fileSignTxt.Size = new System.Drawing.Size(339, 20);
            this.fileSignTxt.TabIndex = 19;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(297, 39);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 32);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // signButton
            // 
            this.signButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.signButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signButton.Location = new System.Drawing.Point(394, 39);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(91, 32);
            this.signButton.TabIndex = 33;
            this.signButton.Text = "Sign";
            this.signButton.UseVisualStyleBackColor = false;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // FileSignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 82);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.signButton);
            this.Controls.Add(this.browseSignButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileSignTxt);
            this.Name = "FileSignForm";
            this.Text = "File Sign";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseSignButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileSignTxt;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button signButton;
    }
}