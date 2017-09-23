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
            this.DeptCB = new System.Windows.Forms.ComboBox();
            this.OwnerCB = new System.Windows.Forms.ComboBox();
            this.StatusCB = new System.Windows.Forms.ComboBox();
            this.PriorityCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PriorityLabel = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ClientLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.SubjectNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReplyRTB
            // 
            this.ReplyRTB.Location = new System.Drawing.Point(15, 194);
            this.ReplyRTB.Name = "ReplyRTB";
            this.ReplyRTB.Size = new System.Drawing.Size(861, 263);
            this.ReplyRTB.TabIndex = 0;
            this.ReplyRTB.Text = "";
            // 
            // DeptCB
            // 
            this.DeptCB.FormattingEnabled = true;
            this.DeptCB.Location = new System.Drawing.Point(15, 167);
            this.DeptCB.Name = "DeptCB";
            this.DeptCB.Size = new System.Drawing.Size(121, 21);
            this.DeptCB.TabIndex = 1;
            // 
            // OwnerCB
            // 
            this.OwnerCB.FormattingEnabled = true;
            this.OwnerCB.Location = new System.Drawing.Point(186, 167);
            this.OwnerCB.Name = "OwnerCB";
            this.OwnerCB.Size = new System.Drawing.Size(121, 21);
            this.OwnerCB.TabIndex = 2;
            // 
            // StatusCB
            // 
            this.StatusCB.FormattingEnabled = true;
            this.StatusCB.Location = new System.Drawing.Point(357, 167);
            this.StatusCB.Name = "StatusCB";
            this.StatusCB.Size = new System.Drawing.Size(121, 21);
            this.StatusCB.TabIndex = 3;
            // 
            // PriorityCB
            // 
            this.PriorityCB.FormattingEnabled = true;
            this.PriorityCB.Location = new System.Drawing.Point(528, 167);
            this.PriorityCB.Name = "PriorityCB";
            this.PriorityCB.Size = new System.Drawing.Size(121, 21);
            this.PriorityCB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Department";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // OwnerLabel
            // 
            this.OwnerLabel.AutoSize = true;
            this.OwnerLabel.Location = new System.Drawing.Point(183, 151);
            this.OwnerLabel.Name = "OwnerLabel";
            this.OwnerLabel.Size = new System.Drawing.Size(38, 13);
            this.OwnerLabel.TabIndex = 7;
            this.OwnerLabel.Text = "Owner";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(354, 151);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Status";
            this.StatusLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // PriorityLabel
            // 
            this.PriorityLabel.AutoSize = true;
            this.PriorityLabel.Location = new System.Drawing.Point(525, 151);
            this.PriorityLabel.Name = "PriorityLabel";
            this.PriorityLabel.Size = new System.Drawing.Size(38, 13);
            this.PriorityLabel.TabIndex = 9;
            this.PriorityLabel.Text = "Priority";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(741, 165);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(128, 23);
            this.SendButton.TabIndex = 10;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(90, 67);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(264, 20);
            this.EmailTB.TabIndex = 12;
            this.EmailTB.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "To:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ClientLabel
            // 
            this.ClientLabel.AutoSize = true;
            this.ClientLabel.Location = new System.Drawing.Point(12, 9);
            this.ClientLabel.Name = "ClientLabel";
            this.ClientLabel.Size = new System.Drawing.Size(67, 13);
            this.ClientLabel.TabIndex = 14;
            this.ClientLabel.Text = "Client Name:";
            this.ClientLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(87, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(33, 13);
            this.NameLabel.TabIndex = 15;
            this.NameLabel.Text = "Label";
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(12, 37);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(46, 13);
            this.SubjectLabel.TabIndex = 16;
            this.SubjectLabel.Text = "Subject:";
            // 
            // SubjectNameLabel
            // 
            this.SubjectNameLabel.AutoSize = true;
            this.SubjectNameLabel.Location = new System.Drawing.Point(90, 37);
            this.SubjectNameLabel.Name = "SubjectNameLabel";
            this.SubjectNameLabel.Size = new System.Drawing.Size(35, 13);
            this.SubjectNameLabel.TabIndex = 17;
            this.SubjectNameLabel.Text = "label2";
            // 
            // WorkFlowGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(893, 498);
            this.Controls.Add(this.SubjectNameLabel);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ClientLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.PriorityLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.OwnerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PriorityCB);
            this.Controls.Add(this.StatusCB);
            this.Controls.Add(this.OwnerCB);
            this.Controls.Add(this.DeptCB);
            this.Controls.Add(this.ReplyRTB);
            this.Name = "WorkFlowGUI";
            this.Text = "Workflow";
            this.Load += new System.EventHandler(this.WorkFlowGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ReplyRTB;
        private System.Windows.Forms.ComboBox DeptCB;
        private System.Windows.Forms.ComboBox OwnerCB;
        private System.Windows.Forms.ComboBox StatusCB;
        private System.Windows.Forms.ComboBox PriorityCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OwnerLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label PriorityLabel;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ClientLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.Label SubjectNameLabel;
    }
}

