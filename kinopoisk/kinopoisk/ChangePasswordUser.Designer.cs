namespace kinopoisk
{
    partial class ChangePasswordUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordUser));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pForChangePassword = new System.Windows.Forms.Panel();
            this.lPassword2 = new System.Windows.Forms.Label();
            this.tbRepeatPass = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.bSaveNewPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pForChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kinopoisk.Properties.Resources.logoOrange;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 50);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pForChangePassword
            // 
            this.pForChangePassword.Controls.Add(this.lPassword2);
            this.pForChangePassword.Controls.Add(this.tbRepeatPass);
            this.pForChangePassword.Controls.Add(this.lPassword);
            this.pForChangePassword.Controls.Add(this.tbPass);
            this.pForChangePassword.Location = new System.Drawing.Point(24, 91);
            this.pForChangePassword.Name = "pForChangePassword";
            this.pForChangePassword.Size = new System.Drawing.Size(278, 125);
            this.pForChangePassword.TabIndex = 17;
            // 
            // lPassword2
            // 
            this.lPassword2.AutoSize = true;
            this.lPassword2.Location = new System.Drawing.Point(12, 46);
            this.lPassword2.Name = "lPassword2";
            this.lPassword2.Size = new System.Drawing.Size(100, 13);
            this.lPassword2.TabIndex = 10;
            this.lPassword2.Text = "Повторите пароль";
            // 
            // tbRepeatPass
            // 
            this.tbRepeatPass.Location = new System.Drawing.Point(15, 62);
            this.tbRepeatPass.Name = "tbRepeatPass";
            this.tbRepeatPass.Size = new System.Drawing.Size(223, 20);
            this.tbRepeatPass.TabIndex = 9;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(12, 7);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(247, 13);
            this.lPassword.TabIndex = 8;
            this.lPassword.Text = "Введите пароль(минимум 6 символов, A-Z, 0-9)";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(15, 23);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(223, 20);
            this.tbPass.TabIndex = 7;
            // 
            // bSaveNewPassword
            // 
            this.bSaveNewPassword.Location = new System.Drawing.Point(39, 243);
            this.bSaveNewPassword.Name = "bSaveNewPassword";
            this.bSaveNewPassword.Size = new System.Drawing.Size(223, 23);
            this.bSaveNewPassword.TabIndex = 18;
            this.bSaveNewPassword.Text = "Сохранить новый пароль";
            this.bSaveNewPassword.UseVisualStyleBackColor = true;
            this.bSaveNewPassword.Click += new System.EventHandler(this.bSaveNewPassword_Click_1);
            // 
            // ChangePasswordUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 307);
            this.Controls.Add(this.bSaveNewPassword);
            this.Controls.Add(this.pForChangePassword);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePasswordUser";
            this.Text = "Кинопоиск";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pForChangePassword.ResumeLayout(false);
            this.pForChangePassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pForChangePassword;
        private System.Windows.Forms.Label lPassword2;
        private System.Windows.Forms.TextBox tbRepeatPass;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button bSaveNewPassword;
    }
}