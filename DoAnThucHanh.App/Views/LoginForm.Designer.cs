namespace DoAnThucHanh.App.Views
{
    partial class LoginForm
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
            this.passLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.Location = new System.Drawing.Point(7, 65);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(76, 13);
            this.passLabel.TabIndex = 28;
            this.passLabel.Text = "Passphrase:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(42, 33);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(41, 13);
            this.emailLabel.TabIndex = 27;
            this.emailLabel.Text = "Email:";
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(85, 62);
            this.passTxt.Name = "passTxt";
            this.passTxt.PasswordChar = '*';
            this.passTxt.Size = new System.Drawing.Size(200, 20);
            this.passTxt.TabIndex = 26;
            this.passTxt.TextChanged += new System.EventHandler(this.passTxt_TextChanged);
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(85, 30);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(200, 20);
            this.emailTxt.TabIndex = 25;
            this.emailTxt.TextChanged += new System.EventHandler(this.emailTxt_TextChanged);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(130, 96);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(91, 32);
            this.loginButton.TabIndex = 29;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(309, 140);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.passTxt);
            this.Controls.Add(this.emailTxt);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox passTxt;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.Button loginButton;
    }
}