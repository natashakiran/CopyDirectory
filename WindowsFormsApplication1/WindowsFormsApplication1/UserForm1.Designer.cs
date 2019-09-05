namespace WindowsFormsApplication1
{
    partial class UserForm1
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
            this.srcDir = new System.Windows.Forms.Button();
            this.dstDir = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.resultLabel = new System.Windows.Forms.Label();
            this.sourceFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.destinationFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // srcDir
            // 
            this.srcDir.Location = new System.Drawing.Point(29, 94);
            this.srcDir.Name = "srcDir";
            this.srcDir.Size = new System.Drawing.Size(107, 41);
            this.srcDir.TabIndex = 0;
            this.srcDir.Text = "Source Directory";
            this.srcDir.UseVisualStyleBackColor = true;
            this.srcDir.Click += new System.EventHandler(this.source_Click);
            // 
            // dstDir
            // 
            this.dstDir.Location = new System.Drawing.Point(154, 94);
            this.dstDir.Name = "dstDir";
            this.dstDir.Size = new System.Drawing.Size(116, 41);
            this.dstDir.TabIndex = 1;
            this.dstDir.Text = "Destination Directory";
            this.dstDir.UseVisualStyleBackColor = true;
            this.dstDir.Click += new System.EventHandler(this.destination_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(299, 94);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 41);
            this.start.TabIndex = 2;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(390, 94);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 41);
            this.stop.TabIndex = 3;
            this.stop.Text = "Cancel";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Directory Copy Utility";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressBar1.Location = new System.Drawing.Point(35, 246);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(430, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(32, 296);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 6;
            // 
            // UserForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 353);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.dstDir);
            this.Controls.Add(this.srcDir);
            this.Name = "UserForm1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button srcDir;
        private System.Windows.Forms.Button dstDir;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.FolderBrowserDialog sourceFolder;
        private System.Windows.Forms.FolderBrowserDialog destinationFolder;


    }
}

