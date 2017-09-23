namespace DepartmentMessageQueue
{
    partial class Form1
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
            this.TicketGrid = new System.Windows.Forms.DataGridView();
            this.DepartmentTV = new System.Windows.Forms.TreeView();
            this.SelectedDEPT = new System.Windows.Forms.Label();
            this.CurrentDEPT = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TicketGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TicketGrid
            // 
            this.TicketGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TicketGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TicketGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TicketGrid.Location = new System.Drawing.Point(150, 44);
            this.TicketGrid.Name = "TicketGrid";
            this.TicketGrid.Size = new System.Drawing.Size(595, 277);
            this.TicketGrid.TabIndex = 1;
            this.TicketGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TicketGrid_CellContentClick);
            // 
            // DepartmentTV
            // 
            this.DepartmentTV.Location = new System.Drawing.Point(12, 44);
            this.DepartmentTV.Name = "DepartmentTV";
            this.DepartmentTV.Size = new System.Drawing.Size(121, 277);
            this.DepartmentTV.TabIndex = 2;
            this.DepartmentTV.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DepartmentTV_NodeMouseDoubleClick);
            // 
            // SelectedDEPT
            // 
            this.SelectedDEPT.AutoSize = true;
            this.SelectedDEPT.Location = new System.Drawing.Point(12, 9);
            this.SelectedDEPT.Name = "SelectedDEPT";
            this.SelectedDEPT.Size = new System.Drawing.Size(110, 13);
            this.SelectedDEPT.TabIndex = 3;
            this.SelectedDEPT.Text = "Selected Department:";
            this.SelectedDEPT.Click += new System.EventHandler(this.label1_Click);
            // 
            // CurrentDEPT
            // 
            this.CurrentDEPT.AutoSize = true;
            this.CurrentDEPT.Location = new System.Drawing.Point(12, 28);
            this.CurrentDEPT.Name = "CurrentDEPT";
            this.CurrentDEPT.Size = new System.Drawing.Size(35, 13);
            this.CurrentDEPT.TabIndex = 4;
            this.CurrentDEPT.Text = "label2";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(562, 18);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 5;
            this.searchTextBox.Text = "Search Ticket ID";
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(668, 16);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(755, 332);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.CurrentDEPT);
            this.Controls.Add(this.SelectedDEPT);
            this.Controls.Add(this.DepartmentTV);
            this.Controls.Add(this.TicketGrid);
            this.Name = "Form1";
            this.Text = "Department Queue";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.TicketGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView TicketGrid;
        private System.Windows.Forms.TreeView DepartmentTV;
        private System.Windows.Forms.Label SelectedDEPT;
        private System.Windows.Forms.Label CurrentDEPT;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}

