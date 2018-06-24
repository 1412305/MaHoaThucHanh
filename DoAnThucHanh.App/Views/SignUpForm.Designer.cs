namespace DoAnThucHanh.App.Views
{
    partial class SignUpForm
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
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.keySizeCb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(99, 55);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(134, 20);
            this.emailTxt.TabIndex = 0;
            this.emailTxt.TextChanged += new System.EventHandler(this.emailTxt_TextChanged);
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(99, 90);
            this.passTxt.Name = "passTxt";
            this.passTxt.Size = new System.Drawing.Size(134, 20);
            this.passTxt.TabIndex = 1;
            this.passTxt.TextChanged += new System.EventHandler(this.passTxt_TextChanged);
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(127, 132);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(75, 23);
            this.signUpButton.TabIndex = 2;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // keySizeCb
            // 
            this.keySizeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keySizeCb.FormattingEnabled = true;
            this.keySizeCb.Location = new System.Drawing.Point(333, 55);
            this.keySizeCb.Name = "keySizeCb";
            this.keySizeCb.Size = new System.Drawing.Size(121, 21);
            this.keySizeCb.TabIndex = 3;
            this.keySizeCb.SelectedValueChanged += new System.EventHandler(this.keySizeCb_SelectedValueChanged);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 315);
            this.Controls.Add(this.keySizeCb);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.passTxt);
            this.Controls.Add(this.emailTxt);
            this.Name = "SignUpForm";
            this.Text = "SignUp";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.TextBox passTxt;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.ComboBox keySizeCb;
    }
}