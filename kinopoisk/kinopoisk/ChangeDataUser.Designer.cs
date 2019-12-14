namespace kinopoisk
{
    partial class ChangeDataUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeDataUser));
            this.pForChangeData = new System.Windows.Forms.Panel();
            this.cbUserBirthplace = new System.Windows.Forms.ComboBox();
            this.lUserBirthplace = new System.Windows.Forms.Label();
            this.lUserBirthday = new System.Windows.Forms.Label();
            this.dtpUserBirthday = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bSaveChange = new System.Windows.Forms.Button();
            this.pForChangeData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pForChangeData
            // 
            this.pForChangeData.Controls.Add(this.cbUserBirthplace);
            this.pForChangeData.Controls.Add(this.lUserBirthplace);
            this.pForChangeData.Controls.Add(this.lUserBirthday);
            this.pForChangeData.Controls.Add(this.dtpUserBirthday);
            this.pForChangeData.Controls.Add(this.label2);
            this.pForChangeData.Controls.Add(this.rbFemale);
            this.pForChangeData.Controls.Add(this.rbMale);
            this.pForChangeData.Controls.Add(this.tbEmail);
            this.pForChangeData.Controls.Add(this.label3);
            this.pForChangeData.Location = new System.Drawing.Point(12, 80);
            this.pForChangeData.Name = "pForChangeData";
            this.pForChangeData.Size = new System.Drawing.Size(310, 188);
            this.pForChangeData.TabIndex = 14;
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
            this.cbUserBirthplace.Location = new System.Drawing.Point(2, 144);
            this.cbUserBirthplace.Name = "cbUserBirthplace";
            this.cbUserBirthplace.Size = new System.Drawing.Size(121, 21);
            this.cbUserBirthplace.TabIndex = 26;
            // 
            // lUserBirthplace
            // 
            this.lUserBirthplace.AutoSize = true;
            this.lUserBirthplace.Location = new System.Drawing.Point(0, 128);
            this.lUserBirthplace.Name = "lUserBirthplace";
            this.lUserBirthplace.Size = new System.Drawing.Size(94, 13);
            this.lUserBirthplace.TabIndex = 25;
            this.lUserBirthplace.Text = "Выберите страну";
            // 
            // lUserBirthday
            // 
            this.lUserBirthday.AutoSize = true;
            this.lUserBirthday.Location = new System.Drawing.Point(-1, 90);
            this.lUserBirthday.Name = "lUserBirthday";
            this.lUserBirthday.Size = new System.Drawing.Size(127, 13);
            this.lUserBirthday.TabIndex = 24;
            this.lUserBirthday.Text = "Введите дату рождения";
            // 
            // dtpUserBirthday
            // 
            this.dtpUserBirthday.Location = new System.Drawing.Point(3, 105);
            this.dtpUserBirthday.Name = "dtpUserBirthday";
            this.dtpUserBirthday.Size = new System.Drawing.Size(223, 20);
            this.dtpUserBirthday.TabIndex = 23;
            this.dtpUserBirthday.Value = new System.DateTime(2016, 11, 13, 22, 54, 52, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Выберите пол";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(57, 73);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 21;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(3, 73);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 20;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(3, 26);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(223, 20);
            this.tbEmail.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Введите e-mail";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kinopoisk.Properties.Resources.logoOrange;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 50);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // bSaveChange
            // 
            this.bSaveChange.Location = new System.Drawing.Point(12, 289);
            this.bSaveChange.Name = "bSaveChange";
            this.bSaveChange.Size = new System.Drawing.Size(145, 23);
            this.bSaveChange.TabIndex = 16;
            this.bSaveChange.Text = "Сохранить изменения";
            this.bSaveChange.UseVisualStyleBackColor = true;
            this.bSaveChange.Click += new System.EventHandler(this.bSaveChange_Click);
            // 
            // ChangeDataUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 341);
            this.Controls.Add(this.bSaveChange);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pForChangeData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeDataUser";
            this.Text = "Кинопоиск";
            this.pForChangeData.ResumeLayout(false);
            this.pForChangeData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pForChangeData;
        private System.Windows.Forms.ComboBox cbUserBirthplace;
        private System.Windows.Forms.Label lUserBirthplace;
        private System.Windows.Forms.Label lUserBirthday;
        private System.Windows.Forms.DateTimePicker dtpUserBirthday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bSaveChange;
    }
}