namespace CheckProject
{
    partial class AddCheck
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
            this.conclusionDate = new System.Windows.Forms.TextBox();
            this.travelAgentName = new System.Windows.Forms.TextBox();
            this.customerName = new System.Windows.Forms.TextBox();
            this.orderCost = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // conclusionDate
            // 
            this.conclusionDate.Location = new System.Drawing.Point(175, 110);
            this.conclusionDate.Name = "conclusionDate";
            this.conclusionDate.Size = new System.Drawing.Size(100, 20);
            this.conclusionDate.TabIndex = 1;
            // 
            // travelAgentName
            // 
            this.travelAgentName.Location = new System.Drawing.Point(174, 155);
            this.travelAgentName.Name = "travelAgentName";
            this.travelAgentName.Size = new System.Drawing.Size(100, 20);
            this.travelAgentName.TabIndex = 2;
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(174, 200);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(100, 20);
            this.customerName.TabIndex = 3;
            // 
            // orderCost
            // 
            this.orderCost.Location = new System.Drawing.Point(173, 241);
            this.orderCost.Name = "orderCost";
            this.orderCost.Size = new System.Drawing.Size(100, 20);
            this.orderCost.TabIndex = 4;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(173, 281);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 5;
            this.add.Text = "button1";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // AddCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 316);
            this.Controls.Add(this.add);
            this.Controls.Add(this.orderCost);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.travelAgentName);
            this.Controls.Add(this.conclusionDate);
            this.Name = "AddCheck";
            this.Text = "AddCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox conclusionDate;
        private System.Windows.Forms.TextBox travelAgentName;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.TextBox orderCost;
        private System.Windows.Forms.Button add;

    }
}