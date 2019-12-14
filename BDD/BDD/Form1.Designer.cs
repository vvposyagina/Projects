namespace BDD
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
            this.tbSequenceVar = new System.Windows.Forms.TextBox();
            this.lSequenceVar = new System.Windows.Forms.Label();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.Mode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBuildingBDD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSemanticTree = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFormule = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.lbCountOfVar = new System.Windows.Forms.ListBox();
            this.lCountOfVar = new System.Windows.Forms.Label();
            this.bBuildBDD = new System.Windows.Forms.Button();
            this.pBuildBySemanticTree = new System.Windows.Forms.Panel();
            this.bSaveResult = new System.Windows.Forms.Button();
            this.bNextStepTree = new System.Windows.Forms.Button();
            this.bPhasedImplementTree = new System.Windows.Forms.Button();
            this.lOrderVar = new System.Windows.Forms.Label();
            this.tbOrderVar = new System.Windows.Forms.TextBox();
            this.lFunction = new System.Windows.Forms.Label();
            this.tbFunction = new System.Windows.Forms.TextBox();
            this.pBuildOnTheFormula = new System.Windows.Forms.Panel();
            this.bSaveBmpByFormula = new System.Windows.Forms.Button();
            this.bNextStep = new System.Windows.Forms.Button();
            this.bPhasedImplementation = new System.Windows.Forms.Button();
            this.rbSecondMethod = new System.Windows.Forms.RadioButton();
            this.rbFirstMethod = new System.Windows.Forms.RadioButton();
            this.bAutomaticOrder = new System.Windows.Forms.Button();
            this.pOperators = new System.Windows.Forms.Panel();
            this.bConjunction = new System.Windows.Forms.Button();
            this.bAdditionByModule2 = new System.Windows.Forms.Button();
            this.bDisjunction = new System.Windows.Forms.Button();
            this.bEquivalence = new System.Windows.Forms.Button();
            this.bInverse = new System.Windows.Forms.Button();
            this.bImplication = new System.Windows.Forms.Button();
            this.bBuildBDDOnTheFormula = new System.Windows.Forms.Button();
            this.lSeqVarInFormula = new System.Windows.Forms.Label();
            this.tbSeqVarInFormula = new System.Windows.Forms.TextBox();
            this.lInputForFormula = new System.Windows.Forms.Label();
            this.tbForFromula = new System.Windows.Forms.TextBox();
            this.pForDrawingBDD = new System.Windows.Forms.Panel();
            this.pWelcome = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lWelcome = new System.Windows.Forms.Label();
            this.msMenu.SuspendLayout();
            this.pBuildBySemanticTree.SuspendLayout();
            this.pBuildOnTheFormula.SuspendLayout();
            this.pOperators.SuspendLayout();
            this.pWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSequenceVar
            // 
            this.tbSequenceVar.AcceptsReturn = true;
            this.tbSequenceVar.Location = new System.Drawing.Point(15, 129);
            this.tbSequenceVar.Name = "tbSequenceVar";
            this.tbSequenceVar.Size = new System.Drawing.Size(262, 20);
            this.tbSequenceVar.TabIndex = 0;
            // 
            // lSequenceVar
            // 
            this.lSequenceVar.Location = new System.Drawing.Point(12, 68);
            this.lSequenceVar.Name = "lSequenceVar";
            this.lSequenceVar.Size = new System.Drawing.Size(274, 59);
            this.lSequenceVar.TabIndex = 1;
            this.lSequenceVar.Text = "Введите имена переменных. В качестве переменных можно использовать слова, состоящ" +
    "ие из символов английского и русского алфавитов. Разделителем служит запятая";
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mode,
            this.Help});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1458, 24);
            this.msMenu.TabIndex = 2;
            this.msMenu.Text = "Меню";
            // 
            // Mode
            // 
            this.Mode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBuildingBDD});
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(101, 20);
            this.Mode.Text = "Режим работы";
            // 
            // tsmBuildingBDD
            // 
            this.tsmBuildingBDD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSemanticTree,
            this.tsmFormule});
            this.tsmBuildingBDD.Name = "tsmBuildingBDD";
            this.tsmBuildingBDD.Size = new System.Drawing.Size(167, 22);
            this.tsmBuildingBDD.Text = "Построение BDD";
            // 
            // tsmSemanticTree
            // 
            this.tsmSemanticTree.Name = "tsmSemanticTree";
            this.tsmSemanticTree.Size = new System.Drawing.Size(226, 22);
            this.tsmSemanticTree.Text = "По семантическому дереву";
            this.tsmSemanticTree.Click += new System.EventHandler(this.tsmSemanticTree_Click);
            // 
            // tsmFormule
            // 
            this.tsmFormule.Name = "tsmFormule";
            this.tsmFormule.Size = new System.Drawing.Size(226, 22);
            this.tsmFormule.Text = "По формуле";
            this.tsmFormule.Click += new System.EventHandler(this.tsmFormule_Click);
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(65, 20);
            this.Help.Text = "Справка";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // lbCountOfVar
            // 
            this.lbCountOfVar.FormattingEnabled = true;
            this.lbCountOfVar.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbCountOfVar.Location = new System.Drawing.Point(15, 35);
            this.lbCountOfVar.Name = "lbCountOfVar";
            this.lbCountOfVar.Size = new System.Drawing.Size(57, 30);
            this.lbCountOfVar.TabIndex = 3;
            // 
            // lCountOfVar
            // 
            this.lCountOfVar.Location = new System.Drawing.Point(12, 9);
            this.lCountOfVar.Name = "lCountOfVar";
            this.lCountOfVar.Size = new System.Drawing.Size(183, 23);
            this.lCountOfVar.TabIndex = 4;
            this.lCountOfVar.Text = "Введите количество переменных";
            // 
            // bBuildBDD
            // 
            this.bBuildBDD.Location = new System.Drawing.Point(15, 298);
            this.bBuildBDD.Name = "bBuildBDD";
            this.bBuildBDD.Size = new System.Drawing.Size(147, 35);
            this.bBuildBDD.TabIndex = 6;
            this.bBuildBDD.Text = "Полная выгрузка результата";
            this.bBuildBDD.UseVisualStyleBackColor = true;
            this.bBuildBDD.Click += new System.EventHandler(this.bBuildBDD_Click);
            // 
            // pBuildBySemanticTree
            // 
            this.pBuildBySemanticTree.Controls.Add(this.bSaveResult);
            this.pBuildBySemanticTree.Controls.Add(this.bNextStepTree);
            this.pBuildBySemanticTree.Controls.Add(this.bPhasedImplementTree);
            this.pBuildBySemanticTree.Controls.Add(this.lOrderVar);
            this.pBuildBySemanticTree.Controls.Add(this.tbOrderVar);
            this.pBuildBySemanticTree.Controls.Add(this.lFunction);
            this.pBuildBySemanticTree.Controls.Add(this.tbFunction);
            this.pBuildBySemanticTree.Controls.Add(this.lCountOfVar);
            this.pBuildBySemanticTree.Controls.Add(this.bBuildBDD);
            this.pBuildBySemanticTree.Controls.Add(this.lbCountOfVar);
            this.pBuildBySemanticTree.Controls.Add(this.lSequenceVar);
            this.pBuildBySemanticTree.Controls.Add(this.tbSequenceVar);
            this.pBuildBySemanticTree.Location = new System.Drawing.Point(12, 33);
            this.pBuildBySemanticTree.Name = "pBuildBySemanticTree";
            this.pBuildBySemanticTree.Size = new System.Drawing.Size(350, 551);
            this.pBuildBySemanticTree.TabIndex = 7;
            this.pBuildBySemanticTree.Visible = false;
            // 
            // bSaveResult
            // 
            this.bSaveResult.Location = new System.Drawing.Point(15, 380);
            this.bSaveResult.Name = "bSaveResult";
            this.bSaveResult.Size = new System.Drawing.Size(276, 23);
            this.bSaveResult.TabIndex = 21;
            this.bSaveResult.Text = "Сохранить результат";
            this.bSaveResult.UseVisualStyleBackColor = true;
            this.bSaveResult.Visible = false;
            this.bSaveResult.Click += new System.EventHandler(this.bSaveResult_Click);
            // 
            // bNextStepTree
            // 
            this.bNextStepTree.Location = new System.Drawing.Point(168, 339);
            this.bNextStepTree.Name = "bNextStepTree";
            this.bNextStepTree.Size = new System.Drawing.Size(123, 35);
            this.bNextStepTree.TabIndex = 20;
            this.bNextStepTree.Text = "Следующий шаг";
            this.bNextStepTree.UseVisualStyleBackColor = true;
            this.bNextStepTree.Visible = false;
            this.bNextStepTree.Click += new System.EventHandler(this.bNextStepTree_Click);
            // 
            // bPhasedImplementTree
            // 
            this.bPhasedImplementTree.Location = new System.Drawing.Point(15, 339);
            this.bPhasedImplementTree.Name = "bPhasedImplementTree";
            this.bPhasedImplementTree.Size = new System.Drawing.Size(147, 35);
            this.bPhasedImplementTree.TabIndex = 19;
            this.bPhasedImplementTree.Text = "Поэтапное выполнение";
            this.bPhasedImplementTree.UseVisualStyleBackColor = true;
            this.bPhasedImplementTree.Click += new System.EventHandler(this.bPhasedImplementTree_Click);
            // 
            // lOrderVar
            // 
            this.lOrderVar.AutoSize = true;
            this.lOrderVar.Location = new System.Drawing.Point(12, 162);
            this.lOrderVar.Name = "lOrderVar";
            this.lOrderVar.Size = new System.Drawing.Size(301, 39);
            this.lOrderVar.TabIndex = 10;
            this.lOrderVar.Text = "Введите порядок переменных, если он отличен от\r\nвведенной ранее последовательност" +
    "и имен переменных.\r\nВ качестве разделителя используйте запятую";
            // 
            // tbOrderVar
            // 
            this.tbOrderVar.Location = new System.Drawing.Point(15, 204);
            this.tbOrderVar.Name = "tbOrderVar";
            this.tbOrderVar.Size = new System.Drawing.Size(262, 20);
            this.tbOrderVar.TabIndex = 9;
            // 
            // lFunction
            // 
            this.lFunction.AutoSize = true;
            this.lFunction.Location = new System.Drawing.Point(12, 243);
            this.lFunction.Name = "lFunction";
            this.lFunction.Size = new System.Drawing.Size(285, 13);
            this.lFunction.TabIndex = 8;
            this.lFunction.Text = "Введите значение функции(подряд, без разделителей)\r\n";
            // 
            // tbFunction
            // 
            this.tbFunction.Location = new System.Drawing.Point(15, 259);
            this.tbFunction.Name = "tbFunction";
            this.tbFunction.Size = new System.Drawing.Size(262, 20);
            this.tbFunction.TabIndex = 7;
            // 
            // pBuildOnTheFormula
            // 
            this.pBuildOnTheFormula.Controls.Add(this.bSaveBmpByFormula);
            this.pBuildOnTheFormula.Controls.Add(this.bNextStep);
            this.pBuildOnTheFormula.Controls.Add(this.bPhasedImplementation);
            this.pBuildOnTheFormula.Controls.Add(this.rbSecondMethod);
            this.pBuildOnTheFormula.Controls.Add(this.rbFirstMethod);
            this.pBuildOnTheFormula.Controls.Add(this.bAutomaticOrder);
            this.pBuildOnTheFormula.Controls.Add(this.pOperators);
            this.pBuildOnTheFormula.Controls.Add(this.bBuildBDDOnTheFormula);
            this.pBuildOnTheFormula.Controls.Add(this.lSeqVarInFormula);
            this.pBuildOnTheFormula.Controls.Add(this.tbSeqVarInFormula);
            this.pBuildOnTheFormula.Controls.Add(this.lInputForFormula);
            this.pBuildOnTheFormula.Controls.Add(this.tbForFromula);
            this.pBuildOnTheFormula.Location = new System.Drawing.Point(12, 27);
            this.pBuildOnTheFormula.Name = "pBuildOnTheFormula";
            this.pBuildOnTheFormula.Size = new System.Drawing.Size(362, 548);
            this.pBuildOnTheFormula.TabIndex = 8;
            this.pBuildOnTheFormula.Visible = false;
            // 
            // bSaveBmpByFormula
            // 
            this.bSaveBmpByFormula.Location = new System.Drawing.Point(10, 360);
            this.bSaveBmpByFormula.Name = "bSaveBmpByFormula";
            this.bSaveBmpByFormula.Size = new System.Drawing.Size(276, 23);
            this.bSaveBmpByFormula.TabIndex = 22;
            this.bSaveBmpByFormula.Text = "Сохранить результат";
            this.bSaveBmpByFormula.UseVisualStyleBackColor = true;
            this.bSaveBmpByFormula.Visible = false;
            this.bSaveBmpByFormula.Click += new System.EventHandler(this.bSaveBmpByFormula_Click);
            // 
            // bNextStep
            // 
            this.bNextStep.Enabled = false;
            this.bNextStep.Location = new System.Drawing.Point(163, 308);
            this.bNextStep.Name = "bNextStep";
            this.bNextStep.Size = new System.Drawing.Size(123, 35);
            this.bNextStep.TabIndex = 19;
            this.bNextStep.Text = "Следующий шаг";
            this.bNextStep.UseVisualStyleBackColor = true;
            this.bNextStep.Visible = false;
            this.bNextStep.Click += new System.EventHandler(this.bNextStep_Click);
            // 
            // bPhasedImplementation
            // 
            this.bPhasedImplementation.Location = new System.Drawing.Point(10, 308);
            this.bPhasedImplementation.Name = "bPhasedImplementation";
            this.bPhasedImplementation.Size = new System.Drawing.Size(147, 35);
            this.bPhasedImplementation.TabIndex = 18;
            this.bPhasedImplementation.Text = "Поэтапное выполнение";
            this.bPhasedImplementation.UseVisualStyleBackColor = true;
            this.bPhasedImplementation.Click += new System.EventHandler(this.bPhasedImplementation_Click);
            // 
            // rbSecondMethod
            // 
            this.rbSecondMethod.AutoSize = true;
            this.rbSecondMethod.Location = new System.Drawing.Point(166, 236);
            this.rbSecondMethod.Name = "rbSecondMethod";
            this.rbSecondMethod.Size = new System.Drawing.Size(77, 17);
            this.rbSecondMethod.TabIndex = 17;
            this.rbSecondMethod.TabStop = true;
            this.rbSecondMethod.Text = "Метод №2";
            this.rbSecondMethod.UseVisualStyleBackColor = true;
            this.rbSecondMethod.Visible = false;
            // 
            // rbFirstMethod
            // 
            this.rbFirstMethod.AutoSize = true;
            this.rbFirstMethod.Location = new System.Drawing.Point(166, 213);
            this.rbFirstMethod.Name = "rbFirstMethod";
            this.rbFirstMethod.Size = new System.Drawing.Size(77, 17);
            this.rbFirstMethod.TabIndex = 16;
            this.rbFirstMethod.TabStop = true;
            this.rbFirstMethod.Text = "Метод №1";
            this.rbFirstMethod.UseVisualStyleBackColor = true;
            this.rbFirstMethod.Visible = false;
            // 
            // bAutomaticOrder
            // 
            this.bAutomaticOrder.Location = new System.Drawing.Point(10, 208);
            this.bAutomaticOrder.Name = "bAutomaticOrder";
            this.bAutomaticOrder.Size = new System.Drawing.Size(147, 48);
            this.bAutomaticOrder.TabIndex = 15;
            this.bAutomaticOrder.Text = "Автоматический подбор оптимального порядка переменных";
            this.bAutomaticOrder.UseVisualStyleBackColor = true;
            this.bAutomaticOrder.Click += new System.EventHandler(this.bAutomaticOrder_Click);
            // 
            // pOperators
            // 
            this.pOperators.Controls.Add(this.bConjunction);
            this.pOperators.Controls.Add(this.bAdditionByModule2);
            this.pOperators.Controls.Add(this.bDisjunction);
            this.pOperators.Controls.Add(this.bEquivalence);
            this.pOperators.Controls.Add(this.bInverse);
            this.pOperators.Controls.Add(this.bImplication);
            this.pOperators.Location = new System.Drawing.Point(10, 94);
            this.pOperators.Name = "pOperators";
            this.pOperators.Size = new System.Drawing.Size(259, 38);
            this.pOperators.TabIndex = 14;
            // 
            // bConjunction
            // 
            this.bConjunction.Location = new System.Drawing.Point(3, 11);
            this.bConjunction.Name = "bConjunction";
            this.bConjunction.Size = new System.Drawing.Size(33, 23);
            this.bConjunction.TabIndex = 8;
            this.bConjunction.Text = "/\\";
            this.bConjunction.UseVisualStyleBackColor = true;
            this.bConjunction.Click += new System.EventHandler(this.bConjunction_Click);
            // 
            // bAdditionByModule2
            // 
            this.bAdditionByModule2.Location = new System.Drawing.Point(195, 11);
            this.bAdditionByModule2.Name = "bAdditionByModule2";
            this.bAdditionByModule2.Size = new System.Drawing.Size(33, 23);
            this.bAdditionByModule2.TabIndex = 13;
            this.bAdditionByModule2.Text = "+";
            this.bAdditionByModule2.UseVisualStyleBackColor = true;
            this.bAdditionByModule2.Click += new System.EventHandler(this.bAdditionByModule2_Click);
            // 
            // bDisjunction
            // 
            this.bDisjunction.Location = new System.Drawing.Point(39, 11);
            this.bDisjunction.Name = "bDisjunction";
            this.bDisjunction.Size = new System.Drawing.Size(33, 23);
            this.bDisjunction.TabIndex = 9;
            this.bDisjunction.Text = "\\/";
            this.bDisjunction.UseVisualStyleBackColor = true;
            this.bDisjunction.Click += new System.EventHandler(this.bDisjunction_Click);
            // 
            // bEquivalence
            // 
            this.bEquivalence.Location = new System.Drawing.Point(156, 11);
            this.bEquivalence.Name = "bEquivalence";
            this.bEquivalence.Size = new System.Drawing.Size(33, 23);
            this.bEquivalence.TabIndex = 12;
            this.bEquivalence.Text = "~";
            this.bEquivalence.UseVisualStyleBackColor = true;
            this.bEquivalence.Click += new System.EventHandler(this.bEquivalence_Click);
            // 
            // bInverse
            // 
            this.bInverse.Location = new System.Drawing.Point(78, 11);
            this.bInverse.Name = "bInverse";
            this.bInverse.Size = new System.Drawing.Size(33, 23);
            this.bInverse.TabIndex = 10;
            this.bInverse.Text = "!";
            this.bInverse.UseVisualStyleBackColor = true;
            this.bInverse.Click += new System.EventHandler(this.bInverse_Click);
            // 
            // bImplication
            // 
            this.bImplication.Location = new System.Drawing.Point(117, 11);
            this.bImplication.Name = "bImplication";
            this.bImplication.Size = new System.Drawing.Size(33, 23);
            this.bImplication.TabIndex = 11;
            this.bImplication.Text = "->";
            this.bImplication.UseVisualStyleBackColor = true;
            this.bImplication.Click += new System.EventHandler(this.bImplication_Click);
            // 
            // bBuildBDDOnTheFormula
            // 
            this.bBuildBDDOnTheFormula.Location = new System.Drawing.Point(10, 267);
            this.bBuildBDDOnTheFormula.Name = "bBuildBDDOnTheFormula";
            this.bBuildBDDOnTheFormula.Size = new System.Drawing.Size(147, 35);
            this.bBuildBDDOnTheFormula.TabIndex = 7;
            this.bBuildBDDOnTheFormula.Text = "Полная выгрузка результата";
            this.bBuildBDDOnTheFormula.UseVisualStyleBackColor = true;
            this.bBuildBDDOnTheFormula.Click += new System.EventHandler(this.bBuildBDDOnTheFormula_Click);
            // 
            // lSeqVarInFormula
            // 
            this.lSeqVarInFormula.AutoSize = true;
            this.lSeqVarInFormula.Location = new System.Drawing.Point(7, 162);
            this.lSeqVarInFormula.Name = "lSeqVarInFormula";
            this.lSeqVarInFormula.Size = new System.Drawing.Size(160, 13);
            this.lSeqVarInFormula.TabIndex = 3;
            this.lSeqVarInFormula.Text = "Введите порядок переменных";
            // 
            // tbSeqVarInFormula
            // 
            this.tbSeqVarInFormula.Location = new System.Drawing.Point(10, 181);
            this.tbSeqVarInFormula.Name = "tbSeqVarInFormula";
            this.tbSeqVarInFormula.Size = new System.Drawing.Size(276, 20);
            this.tbSeqVarInFormula.TabIndex = 2;
            // 
            // lInputForFormula
            // 
            this.lInputForFormula.AutoSize = true;
            this.lInputForFormula.Location = new System.Drawing.Point(7, 26);
            this.lInputForFormula.Name = "lInputForFormula";
            this.lInputForFormula.Size = new System.Drawing.Size(180, 39);
            this.lInputForFormula.TabIndex = 1;
            this.lInputForFormula.Text = "Введите формулу, для написания \r\nоператоров воспользуйтесь \r\nкнопками ниже";
            // 
            // tbForFromula
            // 
            this.tbForFromula.Location = new System.Drawing.Point(10, 68);
            this.tbForFromula.Name = "tbForFromula";
            this.tbForFromula.Size = new System.Drawing.Size(276, 20);
            this.tbForFromula.TabIndex = 0;
            // 
            // pForDrawingBDD
            // 
            this.pForDrawingBDD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pForDrawingBDD.AutoScroll = true;
            this.pForDrawingBDD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pForDrawingBDD.Location = new System.Drawing.Point(385, 33);
            this.pForDrawingBDD.Name = "pForDrawingBDD";
            this.pForDrawingBDD.Size = new System.Drawing.Size(1061, 551);
            this.pForDrawingBDD.TabIndex = 9;
            // 
            // pWelcome
            // 
            this.pWelcome.Controls.Add(this.pictureBox1);
            this.pWelcome.Controls.Add(this.lWelcome);
            this.pWelcome.Location = new System.Drawing.Point(5, 42);
            this.pWelcome.Name = "pWelcome";
            this.pWelcome.Size = new System.Drawing.Size(357, 433);
            this.pWelcome.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 140);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lWelcome
            // 
            this.lWelcome.AutoSize = true;
            this.lWelcome.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lWelcome.Location = new System.Drawing.Point(5, 162);
            this.lWelcome.Name = "lWelcome";
            this.lWelcome.Size = new System.Drawing.Size(337, 148);
            this.lWelcome.TabIndex = 0;
            this.lWelcome.Text = "Здравствуйте! \r\nЧтобы начать работу\r\nв приложении,\r\nвыберите режим";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1458, 596);
            this.Controls.Add(this.pWelcome);
            this.Controls.Add(this.pBuildOnTheFormula);
            this.Controls.Add(this.pForDrawingBDD);
            this.Controls.Add(this.pBuildBySemanticTree);
            this.Controls.Add(this.msMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Name = "MainPage";
            this.Text = "BDD";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.pBuildBySemanticTree.ResumeLayout(false);
            this.pBuildBySemanticTree.PerformLayout();
            this.pBuildOnTheFormula.ResumeLayout(false);
            this.pBuildOnTheFormula.PerformLayout();
            this.pOperators.ResumeLayout(false);
            this.pWelcome.ResumeLayout(false);
            this.pWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSequenceVar;
        private System.Windows.Forms.Label lSequenceVar;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem Mode;
        private System.Windows.Forms.ToolStripMenuItem tsmBuildingBDD;
        private System.Windows.Forms.ToolStripMenuItem tsmSemanticTree;
        private System.Windows.Forms.ToolStripMenuItem tsmFormule;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ListBox lbCountOfVar;
        private System.Windows.Forms.Label lCountOfVar;
        private System.Windows.Forms.Button bBuildBDD;
        private System.Windows.Forms.Panel pBuildBySemanticTree;
        private System.Windows.Forms.TextBox tbFunction;
        private System.Windows.Forms.Label lFunction;
        private System.Windows.Forms.Panel pBuildOnTheFormula;
        private System.Windows.Forms.TextBox tbSeqVarInFormula;
        private System.Windows.Forms.Label lInputForFormula;
        private System.Windows.Forms.TextBox tbForFromula;
        private System.Windows.Forms.Button bBuildBDDOnTheFormula;
        private System.Windows.Forms.Label lSeqVarInFormula;
        private System.Windows.Forms.Button bInverse;
        private System.Windows.Forms.Button bDisjunction;
        private System.Windows.Forms.Button bConjunction;
        private System.Windows.Forms.Button bAdditionByModule2;
        private System.Windows.Forms.Button bEquivalence;
        private System.Windows.Forms.Button bImplication;
        private System.Windows.Forms.Panel pOperators;
        private System.Windows.Forms.TextBox tbOrderVar;
        private System.Windows.Forms.Label lOrderVar;
        private System.Windows.Forms.Panel pForDrawingBDD;
        private System.Windows.Forms.RadioButton rbSecondMethod;
        private System.Windows.Forms.RadioButton rbFirstMethod;
        private System.Windows.Forms.Button bAutomaticOrder;
        private System.Windows.Forms.Button bNextStep;
        private System.Windows.Forms.Button bPhasedImplementation;
        private System.Windows.Forms.Button bNextStepTree;
        private System.Windows.Forms.Button bPhasedImplementTree;
        private System.Windows.Forms.Button bSaveResult;
        private System.Windows.Forms.Button bSaveBmpByFormula;
        private System.Windows.Forms.Panel pWelcome;
        private System.Windows.Forms.Label lWelcome;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

