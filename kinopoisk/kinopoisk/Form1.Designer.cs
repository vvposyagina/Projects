namespace kinopoisk
{
    partial class MainPage
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.llExit = new System.Windows.Forms.LinkLabel();
            this.llMyPage = new System.Windows.Forms.LinkLabel();
            this.lAutoriz = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.llRegistration = new System.Windows.Forms.LinkLabel();
            this.llAuthorization = new System.Windows.Forms.LinkLabel();
            this.bSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pResultOfSearch = new System.Windows.Forms.Panel();
            this.lPersons = new System.Windows.Forms.Label();
            this.lFilms = new System.Windows.Forms.Label();
            this.lResultOfSearch = new System.Windows.Forms.Label();
            this.gbMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pResultOfSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMenu
            // 
            this.gbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMenu.BackColor = System.Drawing.Color.DarkGray;
            this.gbMenu.Controls.Add(this.llExit);
            this.gbMenu.Controls.Add(this.llMyPage);
            this.gbMenu.Controls.Add(this.lAutoriz);
            this.gbMenu.Controls.Add(this.pictureBox1);
            this.gbMenu.Controls.Add(this.label2);
            this.gbMenu.Controls.Add(this.llRegistration);
            this.gbMenu.Controls.Add(this.llAuthorization);
            this.gbMenu.Controls.Add(this.bSearch);
            this.gbMenu.Controls.Add(this.tbSearch);
            this.gbMenu.Font = new System.Drawing.Font("Arial Unicode MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbMenu.ForeColor = System.Drawing.Color.Black;
            this.gbMenu.Location = new System.Drawing.Point(12, 12);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(913, 100);
            this.gbMenu.TabIndex = 0;
            this.gbMenu.TabStop = false;
            // 
            // llExit
            // 
            this.llExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llExit.AutoSize = true;
            this.llExit.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llExit.LinkColor = System.Drawing.Color.Black;
            this.llExit.Location = new System.Drawing.Point(754, 25);
            this.llExit.Name = "llExit";
            this.llExit.Size = new System.Drawing.Size(46, 18);
            this.llExit.TabIndex = 8;
            this.llExit.TabStop = true;
            this.llExit.Text = "Выйти";
            this.llExit.Visible = false;
            this.llExit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llExit_LinkClicked);
            // 
            // llMyPage
            // 
            this.llMyPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llMyPage.AutoSize = true;
            this.llMyPage.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llMyPage.LinkColor = System.Drawing.Color.Black;
            this.llMyPage.Location = new System.Drawing.Point(611, 25);
            this.llMyPage.Name = "llMyPage";
            this.llMyPage.Size = new System.Drawing.Size(35, 18);
            this.llMyPage.TabIndex = 7;
            this.llMyPage.TabStop = true;
            this.llMyPage.Text = "User";
            this.llMyPage.Visible = false;
            this.llMyPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llMyPage_LinkClicked);
            // 
            // lAutoriz
            // 
            this.lAutoriz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lAutoriz.AutoSize = true;
            this.lAutoriz.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lAutoriz.Location = new System.Drawing.Point(517, 25);
            this.lAutoriz.Name = "lAutoriz";
            this.lAutoriz.Size = new System.Drawing.Size(95, 18);
            this.lAutoriz.TabIndex = 6;
            this.lAutoriz.Text = "Вы вошли, как";
            this.lAutoriz.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kinopoisk.Properties.Resources.logoWhite;
            this.pictureBox1.Location = new System.Drawing.Point(6, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 69);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(372, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Все о любом фильме:";
            // 
            // llRegistration
            // 
            this.llRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llRegistration.AutoSize = true;
            this.llRegistration.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llRegistration.ForeColor = System.Drawing.Color.Black;
            this.llRegistration.LinkColor = System.Drawing.Color.Black;
            this.llRegistration.Location = new System.Drawing.Point(567, 25);
            this.llRegistration.Name = "llRegistration";
            this.llRegistration.Size = new System.Drawing.Size(131, 18);
            this.llRegistration.TabIndex = 3;
            this.llRegistration.TabStop = true;
            this.llRegistration.Text = "Зарегистрироваться";
            this.llRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegistration_LinkClicked);
            // 
            // llAuthorization
            // 
            this.llAuthorization.ActiveLinkColor = System.Drawing.Color.Black;
            this.llAuthorization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llAuthorization.AutoSize = true;
            this.llAuthorization.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llAuthorization.ForeColor = System.Drawing.Color.Black;
            this.llAuthorization.LinkColor = System.Drawing.Color.Black;
            this.llAuthorization.Location = new System.Drawing.Point(517, 25);
            this.llAuthorization.Name = "llAuthorization";
            this.llAuthorization.Size = new System.Drawing.Size(44, 18);
            this.llAuthorization.TabIndex = 2;
            this.llAuthorization.TabStop = true;
            this.llAuthorization.Text = "Войти";
            this.llAuthorization.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAuthorization_LinkClicked);
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSearch.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Location = new System.Drawing.Point(806, 46);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(101, 50);
            this.bSearch.TabIndex = 1;
            this.bSearch.Text = "Искать!";
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(520, 46);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(279, 50);
            this.tbSearch.TabIndex = 0;
            // 
            // pResultOfSearch
            // 
            this.pResultOfSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pResultOfSearch.AutoScroll = true;
            this.pResultOfSearch.Controls.Add(this.lPersons);
            this.pResultOfSearch.Controls.Add(this.lFilms);
            this.pResultOfSearch.Controls.Add(this.lResultOfSearch);
            this.pResultOfSearch.Location = new System.Drawing.Point(12, 131);
            this.pResultOfSearch.Name = "pResultOfSearch";
            this.pResultOfSearch.Size = new System.Drawing.Size(913, 346);
            this.pResultOfSearch.TabIndex = 1;
            this.pResultOfSearch.Visible = false;
            // 
            // lPersons
            // 
            this.lPersons.AutoSize = true;
            this.lPersons.Location = new System.Drawing.Point(300, 31);
            this.lPersons.Name = "lPersons";
            this.lPersons.Size = new System.Drawing.Size(56, 13);
            this.lPersons.TabIndex = 3;
            this.lPersons.Text = "Персоны:";
            // 
            // lFilms
            // 
            this.lFilms.AutoSize = true;
            this.lFilms.Location = new System.Drawing.Point(4, 31);
            this.lFilms.Name = "lFilms";
            this.lFilms.Size = new System.Drawing.Size(55, 13);
            this.lFilms.TabIndex = 2;
            this.lFilms.Text = "Фильмы:";
            // 
            // lResultOfSearch
            // 
            this.lResultOfSearch.AutoSize = true;
            this.lResultOfSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lResultOfSearch.Location = new System.Drawing.Point(3, 0);
            this.lResultOfSearch.Name = "lResultOfSearch";
            this.lResultOfSearch.Size = new System.Drawing.Size(164, 22);
            this.lResultOfSearch.TabIndex = 0;
            this.lResultOfSearch.Text = "Результаты поиска:";
            // 
            // MainPage
            // 
            this.BackgroundImage = global::kinopoisk.Properties.Resources.background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(937, 451);
            this.Controls.Add(this.pResultOfSearch);
            this.Controls.Add(this.gbMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "Кинопоиск";
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pResultOfSearch.ResumeLayout(false);
            this.pResultOfSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.LinkLabel llRegistration;
        private System.Windows.Forms.LinkLabel llAuthorization;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llMyPage;
        private System.Windows.Forms.Label lAutoriz;
        private System.Windows.Forms.Panel pResultOfSearch;
        private System.Windows.Forms.Label lResultOfSearch;
        private System.Windows.Forms.Label lPersons;
        private System.Windows.Forms.Label lFilms;
        private System.Windows.Forms.LinkLabel llExit;
    }
}

