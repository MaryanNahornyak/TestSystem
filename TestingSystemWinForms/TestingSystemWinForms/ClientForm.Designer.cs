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
            this.testInitPanel = new System.Windows.Forms.Panel();
            this.testBegin = new System.Windows.Forms.Button();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.testPanel = new System.Windows.Forms.Panel();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.testInitPanel.SuspendLayout();
            this.testPanel.SuspendLayout();
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
            // testInitPanel
            // 
            this.testInitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.testInitPanel.Controls.Add(this.testBegin);
            this.testInitPanel.Controls.Add(this.folderSelectButton);
            this.testInitPanel.Controls.Add(this.testList);
            this.testInitPanel.Location = new System.Drawing.Point(0, 1);
            this.testInitPanel.Name = "testInitPanel";
            this.testInitPanel.Size = new System.Drawing.Size(327, 400);
            this.testInitPanel.TabIndex = 1;
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
            this.testBegin.Click += new System.EventHandler(this.testBegin_Click);
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
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionLabel.Location = new System.Drawing.Point(8, 7);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(104, 25);
            this.questionLabel.TabIndex = 2;
            this.questionLabel.Text = "Question:";
            // 
            // testPanel
            // 
            this.testPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testPanel.Controls.Add(this.nextQuestionButton);
            this.testPanel.Controls.Add(this.questionLabel);
            this.testPanel.Location = new System.Drawing.Point(3, 1);
            this.testPanel.Name = "testPanel";
            this.testPanel.Size = new System.Drawing.Size(689, 400);
            this.testPanel.TabIndex = 4;
            this.testPanel.Visible = false;
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Location = new System.Drawing.Point(567, 367);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(120, 31);
            this.nextQuestionButton.TabIndex = 3;
            this.nextQuestionButton.Text = "Next";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            this.nextQuestionButton.Click += new System.EventHandler(this.nextQuestionButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 402);
            this.Controls.Add(this.testPanel);
            this.Controls.Add(this.testInitPanel);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.testInitPanel.ResumeLayout(false);
            this.testPanel.ResumeLayout(false);
            this.testPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox testList;
        private System.Windows.Forms.Panel testInitPanel;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.Button testBegin;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Panel testPanel;
        private System.Windows.Forms.Button nextQuestionButton;
    }
}