namespace ClassSorterUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lbInputFiles = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            removeAllToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            btnCancel = new Button();
            btnBrowseInput = new Button();
            btnOK = new Button();
            tbOutput = new TextBox();
            label2 = new Label();
            btnBrowseOutputDir = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lbInputFiles
            // 
            lbInputFiles.AllowDrop = true;
            lbInputFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbInputFiles.ContextMenuStrip = contextMenuStrip1;
            lbInputFiles.FormattingEnabled = true;
            lbInputFiles.Location = new Point(12, 34);
            lbInputFiles.Name = "lbInputFiles";
            lbInputFiles.Size = new Size(433, 154);
            lbInputFiles.TabIndex = 0;
            lbInputFiles.DragDrop += lbInputFiles_DragDrop;
            lbInputFiles.DragOver += lbInputFiles_DragOver;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem, removeAllToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(133, 48);
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(132, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // removeAllToolStripMenuItem
            // 
            removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            removeAllToolStripMenuItem.Size = new Size(132, 22);
            removeAllToolStripMenuItem.Text = "Remove all";
            removeAllToolStripMenuItem.Click += removeAllToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(164, 15);
            label1.TabIndex = 1;
            label1.Text = "Drag and drop files to process";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(12, 310);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnBrowseInput
            // 
            btnBrowseInput.Location = new Point(182, 5);
            btnBrowseInput.Name = "btnBrowseInput";
            btnBrowseInput.Size = new Size(75, 23);
            btnBrowseInput.TabIndex = 3;
            btnBrowseInput.Text = "Browse";
            btnBrowseInput.UseVisualStyleBackColor = true;
            btnBrowseInput.Click += btnBrowseInput_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(370, 316);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // tbOutput
            // 
            tbOutput.AllowDrop = true;
            tbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbOutput.Location = new Point(12, 246);
            tbOutput.Name = "tbOutput";
            tbOutput.Size = new Size(433, 23);
            tbOutput.TabIndex = 5;
            tbOutput.DragDrop += tbOutput_DragDrop;
            tbOutput.DragOver += tbOutput_DragOver;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 221);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 6;
            label2.Text = "Choose Output Folder";
            // 
            // btnBrowseOutputDir
            // 
            btnBrowseOutputDir.Location = new Point(142, 217);
            btnBrowseOutputDir.Name = "btnBrowseOutputDir";
            btnBrowseOutputDir.Size = new Size(75, 23);
            btnBrowseOutputDir.TabIndex = 7;
            btnBrowseOutputDir.Text = "Browse";
            btnBrowseOutputDir.UseVisualStyleBackColor = true;
            btnBrowseOutputDir.Click += btnBrowseOutputDir_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 351);
            Controls.Add(btnBrowseOutputDir);
            Controls.Add(label2);
            Controls.Add(tbOutput);
            Controls.Add(btnOK);
            Controls.Add(btnBrowseInput);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(lbInputFiles);
            Name = "MainForm";
            ShowIcon = false;
            Text = "Class Sorter";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbInputFiles;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem removeAllToolStripMenuItem;
        private Button btnCancel;
        private Button btnBrowseInput;
        private Button btnOK;
        private TextBox tbOutput;
        private Label label2;
        private Button btnBrowseOutputDir;
    }
}
