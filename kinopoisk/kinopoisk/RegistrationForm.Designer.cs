namespace kinopoisk
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lLogin = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.tbRepeatPass = new System.Windows.Forms.TextBox();
            this.lPassword2 = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lGender = new System.Windows.Forms.Label();
            this.dtpUserBirthday = new System.Windows.Forms.DateTimePicker();
            this.lUserBirthday = new System.Windows.Forms.Label();
            this.lUserBirthplace = new System.Windows.Forms.Label();
            this.bRegistrate = new System.Windows.Forms.Button();
            this.cbUserBirthplace = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::kinopoisk.Properties.Resources.logoOrange;
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 62);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(24, 112);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(223, 20);
            this.tbLogin.TabIndex = 1;
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(21, 96);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(128, 13);
            this.lLogin.TabIndex = 2;
            this.lLogin.Text = "Введите логин( A-Z, 0-9)";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(24, 160);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(223, 20);
            this.tbPass.TabIndex = 3;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(21, 144);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(247, 13);
            this.lPassword.TabIndex = 4;
            this.lPassword.Text = "Введите пароль(минимум 6 символов, A-Z, 0-9)";
            // 
            // tbRepeatPass
            // 
            this.tbRepeatPass.Location = new System.Drawing.Point(24, 199);
            this.tbRepeatPass.Name = "tbRepeatPass";
            this.tbRepeatPass.Size = new System.Drawing.Size(223, 20);
            this.tbRepeatPass.TabIndex = 5;
            // 
            // lPassword2
            // 
            this.lPassword2.AutoSize = true;
            this.lPassword2.Location = new System.Drawing.Point(21, 183);
            this.lPassword2.Name = "lPassword2";
            this.lPassword2.Size = new System.Drawing.Size(100, 13);
            this.lPassword2.TabIndex = 6;
            this.lPassword2.Text = "Повторите пароль";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(21, 222);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(79, 13);
            this.lEmail.TabIndex = 7;
            this.lEmail.Text = "Введите e-mail";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(24, 238);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(223, 20);
            this.tbEmail.TabIndex = 8;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(24, 279);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 9;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(115, 279);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 10;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // lGender
            // 
            this.lGender.AutoSize = true;
            this.lGender.Location = new System.Drawing.Point(21, 263);
            this.lGender.Name = "lGender";
            this.lGender.Size = new System.Drawing.Size(78, 13);
            this.lGender.TabIndex = 11;
            this.lGender.Text = "Выберите пол";
            // 
            // dtpUserBirthday
            // 
            this.dtpUserBirthday.Location = new System.Drawing.Point(24, 315);
            this.dtpUserBirthday.Name = "dtpUserBirthday";
            this.dtpUserBirthday.Size = new System.Drawing.Size(223, 20);
            this.dtpUserBirthday.TabIndex = 12;
            this.dtpUserBirthday.Value = new System.DateTime(2016, 11, 13, 22, 54, 52, 0);
            // 
            // lUserBirthday
            // 
            this.lUserBirthday.AutoSize = true;
            this.lUserBirthday.Location = new System.Drawing.Point(21, 299);
            this.lUserBirthday.Name = "lUserBirthday";
            this.lUserBirthday.Size = new System.Drawing.Size(127, 13);
            this.lUserBirthday.TabIndex = 13;
            this.lUserBirthday.Text = "Введите дату рождения";
            // 
            // lUserBirthplace
            // 
            this.lUserBirthplace.AutoSize = true;
            this.lUserBirthplace.Location = new System.Drawing.Point(21, 338);
            this.lUserBirthplace.Name = "lUserBirthplace";
            this.lUserBirthplace.Size = new System.Drawing.Size(94, 13);
            this.lUserBirthplace.TabIndex = 15;
            this.lUserBirthplace.Text = "Выберите страну";
            // 
            // bRegistrate
            // 
            this.bRegistrate.Location = new System.Drawing.Point(23, 395);
            this.bRegistrate.Name = "bRegistrate";
            this.bRegistrate.Size = new System.Drawing.Size(120, 23);
            this.bRegistrate.TabIndex = 16;
            this.bRegistrate.Text = "Регистрация";
            this.bRegistrate.UseVisualStyleBackColor = true;
            this.bRegistrate.Click += new System.EventHandler(this.bRegistrate_Click);
            // 
            // cbUserBirthplace
            // 
            this.cbUserBirthplace.FormattingEnabled = true;
            this.cbUserBirthplace.Items.AddRange(new object[] {
            "Россия",
            "Украина",
            "Беларусь",
            "Казахстан",
            "Киргизия",
            "Грузия",
            "Азербайджан",
            "Латвия",
            "Литва",
            "Эстония",
            "Германия",
            "США",
            "Англия",
            "Франция",
            "Испания"});
            this.cbUserBirthplace.Location = new System.Drawing.Point(23, 354);
            this.cbUserBirthplace.Name = "cbUserBirthplace";
            this.cbUserBirthplace.Size = new System.Drawing.Size(121, 21);
            this.cbUserBirthplace.TabIndex = 17;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(888, 519);
            this.Controls.Add(this.cbUserBirthplace);
            this.Controls.Add(this.bRegistrate);
            this.Controls.Add(this.lUserBirthplace);
            this.Controls.Add(this.lUserBirthday);
            this.Controls.Add(this.dtpUserBirthday);
            this.Controls.Add(this.lGender);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.lPassword2);
            this.Controls.Add(this.tbRepeatPass);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.Text = "Кинопоиск";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TextBox tbRepeatPass;
        private System.Windows.Forms.Label lPassword2;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label lGender;
        private System.Windows.Forms.DateTimePicker dtpUserBirthday;
        private System.Windows.Forms.Label lUserBirthday;
        private System.Windows.Forms.Label lUserBirthplace;
        private System.Windows.Forms.Button bRegistrate;
        private System.Windows.Forms.ComboBox cbUserBirthplace;
    }
}