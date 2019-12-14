namespace kinopoisk
{
    partial class FormForUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForUser));
            this.bChangeData = new System.Windows.Forms.Button();
            this.bChangePassword = new System.Windows.Forms.Button();
            this.lMyLogin = new System.Windows.Forms.Label();
            this.lLogin = new System.Windows.Forms.Label();
            this.lMyBirthday = new System.Windows.Forms.Label();
            this.lBirthday = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lMyEmail = new System.Windows.Forms.Label();
            this.lBirthplace = new System.Windows.Forms.Label();
            this.lMyBirthplace = new System.Windows.Forms.Label();
            this.lGender = new System.Windows.Forms.Label();
            this.lMyGender = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.dgvViewedFilm = new System.Windows.Forms.DataGridView();
            this.lReviews = new System.Windows.Forms.Label();
            this.lViewedFilm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewedFilm)).BeginInit();
            this.SuspendLayout();
            // 
            // bChangeData
            // 
            this.bChangeData.Location = new System.Drawing.Point(30, 211);
            this.bChangeData.Name = "bChangeData";
            this.bChangeData.Size = new System.Drawing.Size(127, 23);
            this.bChangeData.TabIndex = 11;
            this.bChangeData.Text = "Изменить данные";
            this.bChangeData.UseVisualStyleBackColor = true;
            // 
            // bChangePassword
            // 
            this.bChangePassword.Location = new System.Drawing.Point(30, 240);
            this.bChangePassword.Name = "bChangePassword";
            this.bChangePassword.Size = new System.Drawing.Size(127, 23);
            this.bChangePassword.TabIndex = 12;
            this.bChangePassword.Text = "Изменить пароль";
            this.bChangePassword.UseVisualStyleBackColor = true;
            this.bChangePassword.Click += new System.EventHandler(this.bChangePassword_Click);
            // 
            // lMyLogin
            // 
            this.lMyLogin.AutoSize = true;
            this.lMyLogin.Location = new System.Drawing.Point(96, 86);
            this.lMyLogin.Name = "lMyLogin";
            this.lMyLogin.Size = new System.Drawing.Size(0, 13);
            this.lMyLogin.TabIndex = 1;
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(27, 86);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(63, 13);
            this.lLogin.TabIndex = 2;
            this.lLogin.Text = "Ваш логин:";
            // 
            // lMyBirthday
            // 
            this.lMyBirthday.AutoSize = true;
            this.lMyBirthday.Location = new System.Drawing.Point(123, 111);
            this.lMyBirthday.Name = "lMyBirthday";
            this.lMyBirthday.Size = new System.Drawing.Size(0, 13);
            this.lMyBirthday.TabIndex = 3;
            // 
            // lBirthday
            // 
            this.lBirthday.AutoSize = true;
            this.lBirthday.Location = new System.Drawing.Point(27, 106);
            this.lBirthday.Name = "lBirthday";
            this.lBirthday.Size = new System.Drawing.Size(90, 13);
            this.lBirthday.TabIndex = 4;
            this.lBirthday.Text = "День рождения:";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(27, 126);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(35, 13);
            this.lEmail.TabIndex = 5;
            this.lEmail.Text = "Email:";
            // 
            // lMyEmail
            // 
            this.lMyEmail.AutoSize = true;
            this.lMyEmail.Location = new System.Drawing.Point(123, 137);
            this.lMyEmail.Name = "lMyEmail";
            this.lMyEmail.Size = new System.Drawing.Size(0, 13);
            this.lMyEmail.TabIndex = 6;
            // 
            // lBirthplace
            // 
            this.lBirthplace.AutoSize = true;
            this.lBirthplace.Location = new System.Drawing.Point(27, 146);
            this.lBirthplace.Name = "lBirthplace";
            this.lBirthplace.Size = new System.Drawing.Size(46, 13);
            this.lBirthplace.TabIndex = 7;
            this.lBirthplace.Text = "Страна:";
            // 
            // lMyBirthplace
            // 
            this.lMyBirthplace.AutoSize = true;
            this.lMyBirthplace.Location = new System.Drawing.Point(123, 160);
            this.lMyBirthplace.Name = "lMyBirthplace";
            this.lMyBirthplace.Size = new System.Drawing.Size(0, 13);
            this.lMyBirthplace.TabIndex = 8;
            // 
            // lGender
            // 
            this.lGender.AutoSize = true;
            this.lGender.Location = new System.Drawing.Point(27, 166);
            this.lGender.Name = "lGender";
            this.lGender.Size = new System.Drawing.Size(30, 13);
            this.lGender.TabIndex = 9;
            this.lGender.Text = "Пол:";
            // 
            // lMyGender
            // 
            this.lMyGender.AutoSize = true;
            this.lMyGender.Location = new System.Drawing.Point(113, 183);
            this.lMyGender.Name = "lMyGender";
            this.lMyGender.Size = new System.Drawing.Size(0, 13);
            this.lMyGender.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kinopoisk.Properties.Resources.logoOrange;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgvReviews
            // 
            this.dgvReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReviews.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReviews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvReviews.Location = new System.Drawing.Point(330, 106);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.Size = new System.Drawing.Size(555, 93);
            this.dgvReviews.TabIndex = 13;
            // 
            // dgvViewedFilm
            // 
            this.dgvViewedFilm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViewedFilm.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvViewedFilm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViewedFilm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewedFilm.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvViewedFilm.Location = new System.Drawing.Point(330, 240);
            this.dgvViewedFilm.Name = "dgvViewedFilm";
            this.dgvViewedFilm.Size = new System.Drawing.Size(555, 93);
            this.dgvViewedFilm.TabIndex = 14;
            // 
            // lReviews
            // 
            this.lReviews.AutoSize = true;
            this.lReviews.Location = new System.Drawing.Point(327, 86);
            this.lReviews.Name = "lReviews";
            this.lReviews.Size = new System.Drawing.Size(59, 13);
            this.lReviews.TabIndex = 15;
            this.lReviews.Text = "Рецензии:";
            // 
            // lViewedFilm
            // 
            this.lViewedFilm.AutoSize = true;
            this.lViewedFilm.Location = new System.Drawing.Point(327, 211);
            this.lViewedFilm.Name = "lViewedFilm";
            this.lViewedFilm.Size = new System.Drawing.Size(138, 13);
            this.lViewedFilm.TabIndex = 16;
            this.lViewedFilm.Text = "Просмотренные фильмы:";
            // 
            // FormForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 386);
            this.Controls.Add(this.lViewedFilm);
            this.Controls.Add(this.lReviews);
            this.Controls.Add(this.dgvViewedFilm);
            this.Controls.Add(this.dgvReviews);
            this.Controls.Add(this.bChangePassword);
            this.Controls.Add(this.bChangeData);
            this.Controls.Add(this.lMyGender);
            this.Controls.Add(this.lGender);
            this.Controls.Add(this.lMyBirthplace);
            this.Controls.Add(this.lBirthplace);
            this.Controls.Add(this.lMyEmail);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.lBirthday);
            this.Controls.Add(this.lMyBirthday);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.lMyLogin);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForUser";
            this.Text = "Кинопоиск";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewedFilm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bChangeData;
        private System.Windows.Forms.Button bChangePassword;
        private System.Windows.Forms.Label lMyLogin;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Label lMyBirthday;
        private System.Windows.Forms.Label lBirthday;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lMyEmail;
        private System.Windows.Forms.Label lBirthplace;
        private System.Windows.Forms.Label lMyBirthplace;
        private System.Windows.Forms.Label lGender;
        private System.Windows.Forms.Label lMyGender;
        private System.Windows.Forms.DataGridView dgvReviews;
        private System.Windows.Forms.DataGridView dgvViewedFilm;
        private System.Windows.Forms.Label lReviews;
        private System.Windows.Forms.Label lViewedFilm;
    }
}