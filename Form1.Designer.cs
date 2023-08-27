namespace ipcleaner
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
            lblStatus = new Label();
            txtFilePath = new TextBox();
            btnSelectFile = new Button();
            btnClean = new Button();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(33, 250);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(457, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Data cleaned and saved to: C:\\Users\\skarz\\Documents\\scripts\\scrape\\cleaned_file.csv";
            lblStatus.TextAlign = ContentAlignment.BottomCenter;
            lblStatus.Click += lblStatus_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFilePath.Location = new Point(125, 167);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(268, 23);
            txtFilePath.TabIndex = 1;
            txtFilePath.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(224, 64);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(75, 23);
            btnSelectFile.TabIndex = 2;
            btnSelectFile.Text = "Select file...";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click_1;
            // 
            // btnClean
            // 
            btnClean.Location = new Point(224, 105);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 3;
            btnClean.Text = "Process!";
            btnClean.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            ClientSize = new Size(524, 399);
            Controls.Add(btnClean);
            Controls.Add(btnSelectFile);
            Controls.Add(txtFilePath);
            Controls.Add(lblStatus);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private TextBox txtFilePath;
        private Button btnSelectFile;
        private Button btnClean;
    }
}
