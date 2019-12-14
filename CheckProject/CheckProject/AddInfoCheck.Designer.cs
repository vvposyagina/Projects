namespace CheckProject
{
    partial class AddInfoCheck
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
            this.checkInfoView = new System.Windows.Forms.DataGridView();
            this.departureDate = new System.Windows.Forms.TextBox();
            this.arrivalDate = new System.Windows.Forms.TextBox();
            this.tourPrice = new System.Windows.Forms.TextBox();
            this.customerName = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.checkInfoView)).BeginInit();
            this.SuspendLayout();
            // 
            // checkInfoView
            // 
            this.checkInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkInfoView.Location = new System.Drawing.Point(12, 12);
            this.checkInfoView.Name = "checkInfoView";
            this.checkInfoView.Size = new System.Drawing.Size(449, 150);
            this.checkInfoView.TabIndex = 0;
            // 
            // departureDate
            // 
            this.departureDate.Location = new System.Drawing.Point(46, 191);
            this.departureDate.Name = "departureDate";
            this.departureDate.Size = new System.Drawing.Size(100, 20);
            this.departureDate.TabIndex = 1;
            // 
            // arrivalDate
            // 
            this.arrivalDate.Location = new System.Drawing.Point(47, 236);
            this.arrivalDate.Name = "arrivalDate";
            this.arrivalDate.Size = new System.Drawing.Size(100, 20);
            this.arrivalDate.TabIndex = 2;
            // 
            // tourPrice
            // 
            this.tourPrice.Location = new System.Drawing.Point(48, 275);
            this.tourPrice.Name = "tourPrice";
            this.tourPrice.Size = new System.Drawing.Size(100, 20);
            this.tourPrice.TabIndex = 3;
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(47, 316);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(100, 20);
            this.customerName.TabIndex = 4;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(297, 315);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 5;
            this.add.Text = "button1";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // AddInfoCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 362);
            this.Controls.Add(this.add);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.tourPrice);
            this.Controls.Add(this.arrivalDate);
            this.Controls.Add(this.departureDate);
            this.Controls.Add(this.checkInfoView);
            this.Name = "AddInfoCheck";
            this.Text = "AddInfoCheck";
            ((System.ComponentModel.ISupportInitialize)(this.checkInfoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView checkInfoView;
        private System.Windows.Forms.TextBox departureDate;
        private System.Windows.Forms.TextBox arrivalDate;
        private System.Windows.Forms.TextBox tourPrice;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.Button add;
    }
}