namespace CheckProject
{
    partial class Main
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
            this.checkView = new System.Windows.Forms.DataGridView();
            this.checkDataSet = new System.Data.DataSet();
            this.check = new System.Data.DataTable();
            this.idCheck = new System.Data.DataColumn();
            this.conclusionDateCheck = new System.Data.DataColumn();
            this.travelAgentNameCheck = new System.Data.DataColumn();
            this.customerNameCheck = new System.Data.DataColumn();
            this.orderCostCheck = new System.Data.DataColumn();
            this.checkInfo = new System.Data.DataTable();
            this.idCheckInfo = new System.Data.DataColumn();
            this.departureDateCheckInfo = new System.Data.DataColumn();
            this.arrivalDateCheckInfo = new System.Data.DataColumn();
            this.tourPriceCheckInfo = new System.Data.DataColumn();
            this.customerNameCheckInfo = new System.Data.DataColumn();
            this.idCheckCheckInfo = new System.Data.DataColumn();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.specification = new System.Windows.Forms.Button();
            this.addInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.checkView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // checkView
            // 
            this.checkView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkView.Location = new System.Drawing.Point(12, 77);
            this.checkView.Name = "checkView";
            this.checkView.Size = new System.Drawing.Size(586, 150);
            this.checkView.TabIndex = 0;
            // 
            // checkDataSet
            // 
            this.checkDataSet.DataSetName = "NewDataSet";
            this.checkDataSet.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("CheckToCheckInfo", "Check", "CheckInfo", new string[] {
                        "id"}, new string[] {
                        "idCheck"}, false)});
            this.checkDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.check,
            this.checkInfo});
            // 
            // check
            // 
            this.check.Columns.AddRange(new System.Data.DataColumn[] {
            this.idCheck,
            this.conclusionDateCheck,
            this.travelAgentNameCheck,
            this.customerNameCheck,
            this.orderCostCheck});
            this.check.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "id"}, true)});
            this.check.PrimaryKey = new System.Data.DataColumn[] {
        this.idCheck};
            this.check.TableName = "Check";
            // 
            // idCheck
            // 
            this.idCheck.AllowDBNull = false;
            this.idCheck.AutoIncrement = true;
            this.idCheck.ColumnName = "id";
            this.idCheck.DataType = typeof(int);
            // 
            // conclusionDateCheck
            // 
            this.conclusionDateCheck.ColumnName = "conclusionDate";
            this.conclusionDateCheck.DataType = typeof(System.DateTime);
            // 
            // travelAgentNameCheck
            // 
            this.travelAgentNameCheck.ColumnName = "travelAgentName";
            // 
            // customerNameCheck
            // 
            this.customerNameCheck.ColumnName = "customerName";
            // 
            // orderCostCheck
            // 
            this.orderCostCheck.ColumnName = "orderCost";
            this.orderCostCheck.DataType = typeof(decimal);
            // 
            // checkInfo
            // 
            this.checkInfo.Columns.AddRange(new System.Data.DataColumn[] {
            this.idCheckInfo,
            this.departureDateCheckInfo,
            this.arrivalDateCheckInfo,
            this.tourPriceCheckInfo,
            this.customerNameCheckInfo,
            this.idCheckCheckInfo});
            this.checkInfo.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "id"}, true),
            new System.Data.ForeignKeyConstraint("CheckToCheckInfo", "Check", new string[] {
                        "id"}, new string[] {
                        "id"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade),
            new System.Data.ForeignKeyConstraint("Constraint2", "Check", new string[] {
                        "id"}, new string[] {
                        "idCheck"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.checkInfo.PrimaryKey = new System.Data.DataColumn[] {
        this.idCheckInfo};
            this.checkInfo.TableName = "CheckInfo";
            // 
            // idCheckInfo
            // 
            this.idCheckInfo.AllowDBNull = false;
            this.idCheckInfo.AutoIncrement = true;
            this.idCheckInfo.Caption = "id";
            this.idCheckInfo.ColumnName = "id";
            this.idCheckInfo.DataType = typeof(int);
            // 
            // departureDateCheckInfo
            // 
            this.departureDateCheckInfo.ColumnName = "departureDate";
            this.departureDateCheckInfo.DataType = typeof(System.DateTime);
            // 
            // arrivalDateCheckInfo
            // 
            this.arrivalDateCheckInfo.ColumnName = "arrivalDate";
            this.arrivalDateCheckInfo.DataType = typeof(System.DateTime);
            // 
            // tourPriceCheckInfo
            // 
            this.tourPriceCheckInfo.ColumnName = "tourPrice";
            this.tourPriceCheckInfo.DataType = typeof(decimal);
            // 
            // customerNameCheckInfo
            // 
            this.customerNameCheckInfo.ColumnName = "customerName";
            // 
            // idCheckCheckInfo
            // 
            this.idCheckCheckInfo.ColumnName = "idCheck";
            this.idCheckCheckInfo.DataType = typeof(int);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(23, 274);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 1;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(301, 274);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 2;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // specification
            // 
            this.specification.Location = new System.Drawing.Point(401, 274);
            this.specification.Name = "specification";
            this.specification.Size = new System.Drawing.Size(117, 23);
            this.specification.TabIndex = 3;
            this.specification.Text = "Детализация";
            this.specification.UseVisualStyleBackColor = true;
            // 
            // addInfo
            // 
            this.addInfo.Location = new System.Drawing.Point(128, 274);
            this.addInfo.Name = "addInfo";
            this.addInfo.Size = new System.Drawing.Size(75, 23);
            this.addInfo.TabIndex = 4;
            this.addInfo.Text = "button1";
            this.addInfo.UseVisualStyleBackColor = true;
            this.addInfo.Click += new System.EventHandler(this.addInfo_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 321);
            this.Controls.Add(this.addInfo);
            this.Controls.Add(this.specification);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.checkView);
            this.Name = "Main";
            this.Text = "Просмотр чеков";
            ((System.ComponentModel.ISupportInitialize)(this.checkView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView checkView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button specification;
        private System.Data.DataSet checkDataSet;
        private System.Data.DataTable check;
        private System.Data.DataColumn idCheck;
        private System.Data.DataColumn conclusionDateCheck;
        private System.Data.DataColumn travelAgentNameCheck;
        private System.Data.DataColumn customerNameCheck;
        private System.Data.DataColumn orderCostCheck;
        private System.Data.DataTable checkInfo;
        private System.Data.DataColumn idCheckInfo;
        private System.Data.DataColumn departureDateCheckInfo;
        private System.Data.DataColumn arrivalDateCheckInfo;
        private System.Data.DataColumn tourPriceCheckInfo;
        private System.Data.DataColumn customerNameCheckInfo;
        private System.Data.DataColumn idCheckCheckInfo;
        private System.Windows.Forms.Button addInfo;
    }
}

