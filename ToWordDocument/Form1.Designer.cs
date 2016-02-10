namespace ToWordDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnRunConvertation = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMessage = new System.Windows.Forms.Label();
            this.NUDFirstLineIndentaion = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbJustifyBothSides = new System.Windows.Forms.CheckBox();
            this.NUDAfterParagraphIndentation = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIncludeSubfolders = new System.Windows.Forms.CheckBox();
            this.labWorkFolder = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbFolderPath = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUDFirstLineIndentaion)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAfterParagraphIndentation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunConvertation
            // 
            this.btnRunConvertation.Location = new System.Drawing.Point(199, 382);
            this.btnRunConvertation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunConvertation.Name = "btnRunConvertation";
            this.btnRunConvertation.Size = new System.Drawing.Size(145, 49);
            this.btnRunConvertation.TabIndex = 0;
            this.btnRunConvertation.Text = "Run convertion";
            this.btnRunConvertation.UseVisualStyleBackColor = true;
            this.btnRunConvertation.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(158, 130);
            this.btnChooseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(145, 49);
            this.btnChooseFolder.TabIndex = 1;
            this.btnChooseFolder.Text = "Change folder";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Visible = false;
            this.btnChooseFolder.Click += new System.EventHandler(this.chooseFolderButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 437);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(543, 31);
            this.progressBar1.TabIndex = 2;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(27, 488);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(518, 18);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Status messages------------------------------------------------------------------" +
    "-------------";
            // 
            // NUDFirstLineIndentaion
            // 
            this.NUDFirstLineIndentaion.DecimalPlaces = 1;
            this.NUDFirstLineIndentaion.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUDFirstLineIndentaion.Location = new System.Drawing.Point(10, 31);
            this.NUDFirstLineIndentaion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NUDFirstLineIndentaion.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDFirstLineIndentaion.Name = "NUDFirstLineIndentaion";
            this.NUDFirstLineIndentaion.Size = new System.Drawing.Size(47, 24);
            this.NUDFirstLineIndentaion.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "First line indentation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbJustifyBothSides);
            this.groupBox1.Controls.Add(this.NUDAfterParagraphIndentation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NUDFirstLineIndentaion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(288, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DOC Settings";
            // 
            // cbJustifyBothSides
            // 
            this.cbJustifyBothSides.AutoSize = true;
            this.cbJustifyBothSides.Location = new System.Drawing.Point(10, 106);
            this.cbJustifyBothSides.Name = "cbJustifyBothSides";
            this.cbJustifyBothSides.Size = new System.Drawing.Size(141, 22);
            this.cbJustifyBothSides.TabIndex = 8;
            this.cbJustifyBothSides.Text = "Justify both sides";
            this.cbJustifyBothSides.UseVisualStyleBackColor = true;
            // 
            // NUDAfterParagraphIndentation
            // 
            this.NUDAfterParagraphIndentation.DecimalPlaces = 1;
            this.NUDAfterParagraphIndentation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUDAfterParagraphIndentation.Location = new System.Drawing.Point(10, 66);
            this.NUDAfterParagraphIndentation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NUDAfterParagraphIndentation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDAfterParagraphIndentation.Name = "NUDAfterParagraphIndentation";
            this.NUDAfterParagraphIndentation.Size = new System.Drawing.Size(47, 24);
            this.NUDAfterParagraphIndentation.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "After paragraph indentation";
            // 
            // cbIncludeSubfolders
            // 
            this.cbIncludeSubfolders.AutoSize = true;
            this.cbIncludeSubfolders.Location = new System.Drawing.Point(319, 197);
            this.cbIncludeSubfolders.Name = "cbIncludeSubfolders";
            this.cbIncludeSubfolders.Size = new System.Drawing.Size(191, 22);
            this.cbIncludeSubfolders.TabIndex = 9;
            this.cbIncludeSubfolders.Text = "Include files in subfolders";
            this.cbIncludeSubfolders.UseVisualStyleBackColor = true;
            this.cbIncludeSubfolders.Visible = false;
            // 
            // labWorkFolder
            // 
            this.labWorkFolder.AutoSize = true;
            this.labWorkFolder.Location = new System.Drawing.Point(19, 225);
            this.labWorkFolder.Name = "labWorkFolder";
            this.labWorkFolder.Size = new System.Drawing.Size(94, 18);
            this.labWorkFolder.TabIndex = 10;
            this.labWorkFolder.Text = "Chosen files:";
            this.labWorkFolder.Click += new System.EventHandler(this.labWorkFolder_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(350, 382);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(57, 49);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbFolderPath
            // 
            this.tbFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFolderPath.Location = new System.Drawing.Point(22, 246);
            this.tbFolderPath.Name = "tbFolderPath";
            this.tbFolderPath.ReadOnly = true;
            this.tbFolderPath.Size = new System.Drawing.Size(543, 118);
            this.tbFolderPath.TabIndex = 13;
            this.tbFolderPath.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(319, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 178);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // btnChooseFiles
            // 
            this.btnChooseFiles.Location = new System.Drawing.Point(22, 163);
            this.btnChooseFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnChooseFiles.Name = "btnChooseFiles";
            this.btnChooseFiles.Size = new System.Drawing.Size(145, 49);
            this.btnChooseFiles.TabIndex = 15;
            this.btnChooseFiles.Text = "Choose files";
            this.btnChooseFiles.UseVisualStyleBackColor = true;
            this.btnChooseFiles.Click += new System.EventHandler(this.btnChooseFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 515);
            this.Controls.Add(this.btnChooseFiles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbFolderPath);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.labWorkFolder);
            this.Controls.Add(this.cbIncludeSubfolders);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnChooseFolder);
            this.Controls.Add(this.btnRunConvertation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Batch TXT to DOC converter 1.03";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.NUDFirstLineIndentaion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAfterParagraphIndentation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunConvertation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.NumericUpDown NUDFirstLineIndentaion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown NUDAfterParagraphIndentation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbJustifyBothSides;
        private System.Windows.Forms.CheckBox cbIncludeSubfolders;
        private System.Windows.Forms.Label labWorkFolder;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox tbFolderPath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnChooseFiles;
    }
}

