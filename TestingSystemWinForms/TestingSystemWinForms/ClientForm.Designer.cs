namespace TestingSystemWinForms
{
    partial class ClientForm
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
            this.testList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.testBegin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testList
            // 
            this.testList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.testList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testList.FormattingEnabled = true;
            this.testList.Location = new System.Drawing.Point(4, 40);
            this.testList.Name = "testList";
            this.testList.Size = new System.Drawing.Size(320, 353);
            this.testList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.testBegin);
            this.panel1.Controls.Add(this.folderSelectButton);
            this.panel1.Controls.Add(this.testList);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 400);
            this.panel1.TabIndex = 1;
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderSelectButton.Location = new System.Drawing.Point(4, 4);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(142, 30);
            this.folderSelectButton.TabIndex = 2;
            this.folderSelectButton.Text = "Select folder with tests";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // testBegin
            // 
            this.testBegin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testBegin.Location = new System.Drawing.Point(150, 4);
            this.testBegin.Name = "testBegin";
            this.testBegin.Size = new System.Drawing.Size(172, 30);
            this.testBegin.TabIndex = 3;
            this.testBegin.Text = "Begin test";
            this.testBegin.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 402);
            this.Controls.Add(this.panel1);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox testList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.Button testBegin;
    }
}