namespace DoAnThucHanh.App.Views
{
    partial class UserUpdateForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.phoneTxt = new System.Windows.Forms.TextBox();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.birthTxt = new System.Windows.Forms.DateTimePicker();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Phone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Birth:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Name:";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.Location = new System.Drawing.Point(25, 57);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(76, 13);
            this.passLabel.TabIndex = 24;
            this.passLabel.Text = "Passphrase:";
            // 
            // phoneTxt
            // 
            this.phoneTxt.Location = new System.Drawing.Point(103, 178);
            this.phoneTxt.Name = "phoneTxt";
            this.phoneTxt.Size = new System.Drawing.Size(200, 20);
            this.phoneTxt.TabIndex = 23;
            this.phoneTxt.TextChanged += new System.EventHandler(this.phoneTxt_TextChanged);
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(103, 149);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(200, 20);
            this.addressTxt.TabIndex = 22;
            this.addressTxt.TextChanged += new System.EventHandler(this.addressTxt_TextChanged);
            // 
            // birthTxt
            // 
            this.birthTxt.Location = new System.Drawing.Point(103, 120);
            this.birthTxt.Name = "birthTxt";
            this.birthTxt.Size = new System.Drawing.Size(200, 20);
            this.birthTxt.TabIndex = 21;
            this.birthTxt.ValueChanged += new System.EventHandler(this.birthTxt_ValueChanged);
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(103, 88);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(200, 20);
            this.nameTxt.TabIndex = 20;
            this.nameTxt.TextChanged += new System.EventHandler(this.nameTxt_TextChanged);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(60, 25);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(41, 13);
            this.emailLabel.TabIndex = 19;
            this.emailLabel.Text = "Email:";
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(212, 223);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(91, 32);
            this.updateButton.TabIndex = 17;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(103, 54);
            this.passTxt.Name = "passTxt";
            this.passTxt.PasswordChar = '*';
            this.passTxt.Size = new System.Drawing.Size(200, 20);
            this.passTxt.TabIndex = 16;
            this.passTxt.TextChanged += new System.EventHandler(this.passTxt_TextChanged);
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(103, 22);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.ReadOnly = true;
            this.emailTxt.Size = new System.Drawing.Size(200, 20);
            this.emailTxt.TabIndex = 15;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Silver;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(115, 223);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 32);
            this.cancelButton.TabIndex = 30;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // UserUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(351, 283);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.phoneTxt);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.birthTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.passTxt);
            this.Controls.Add(this.emailTxt);
            this.Name = "UserUpdateForm";
            this.Text = "UserUpdateForm";
            this.Load += new System.EventHandler(this.UserUpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox phoneTxt;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.DateTimePicker birthTxt;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox passTxt;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.Button cancelButton;
    }
}