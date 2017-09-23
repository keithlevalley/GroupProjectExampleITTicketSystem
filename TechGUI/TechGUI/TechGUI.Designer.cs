namespace TechGUI
{
    partial class WorkFlowGUI
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
            this.ReplyRTB = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DeptLabel = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.DepartmentLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PriorityLabel = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReplyRTB
            // 
            this.ReplyRTB.Location = new System.Drawing.Point(146, 196);
            this.ReplyRTB.Name = "ReplyRTB";
            this.ReplyRTB.Size = new System.Drawing.Size(727, 303);
            this.ReplyRTB.TabIndex = 0;
            this.ReplyRTB.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(182, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // DeptLabel
            // 
            this.DeptLabel.FormattingEnabled = true;
            this.DeptLabel.Location = new System.Drawing.Point(374, 169);
            this.DeptLabel.Name = "DeptLabel";
            this.DeptLabel.Size = new System.Drawing.Size(121, 21);
            this.DeptLabel.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(570, 169);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(752, 169);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 4;
            // 
            // DepartmentLB
            // 
            this.DepartmentLB.FormattingEnabled = true;
            this.DepartmentLB.Location = new System.Drawing.Point(12, 66);
            this.DepartmentLB.Name = "DepartmentLB";
            this.DepartmentLB.Size = new System.Drawing.Size(128, 433);
            this.DepartmentLB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Department";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // OwnerLabel
            // 
            this.OwnerLabel.AutoSize = true;
            this.OwnerLabel.Location = new System.Drawing.Point(371, 153);
            this.OwnerLabel.Name = "OwnerLabel";
            this.OwnerLabel.Size = new System.Drawing.Size(38, 13);
            this.OwnerLabel.TabIndex = 7;
            this.OwnerLabel.Text = "Owner";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(567, 153);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Status";
            this.StatusLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // PriorityLabel
            // 
            this.PriorityLabel.AutoSize = true;
            this.PriorityLabel.Location = new System.Drawing.Point(749, 153);
            this.PriorityLabel.Name = "PriorityLabel";
            this.PriorityLabel.Size = new System.Drawing.Size(38, 13);
            this.PriorityLabel.TabIndex = 9;
            this.PriorityLabel.Text = "Priority";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(12, 32);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(128, 23);
            this.SendButton.TabIndex = 10;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(208, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(665, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "To:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // WorkFlowGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 507);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.PriorityLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.OwnerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DepartmentLB);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.DeptLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ReplyRTB);
            this.Name = "WorkFlowGUI";
            this.Text = "Workflow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ReplyRTB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox DeptLabel;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ListBox DepartmentLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OwnerLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label PriorityLabel;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
    }
}

