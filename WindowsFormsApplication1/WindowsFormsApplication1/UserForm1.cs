using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CopyDirectory;

namespace WindowsFormsApplication1
{
    
    public partial class UserForm1 : Form
    {
        string sourcePath = string.Empty;
        string destinationPath = string.Empty;
        bool recursiveCopy = true;
        Directory_ copyDirectory = null;
        public UserForm1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            this.copyDirectory = new CopyDirectory.Directory_();
            this.copyDirectory.FileRead += new EventHandler<FileReadEventArgs>(this.copyDirectory_FileRead);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string Browse_(FolderBrowserDialog folderBrowserDialog , string successMessage)
        {
            int size = -1;
            string path = string.Empty;
            DialogResult result = folderBrowserDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                path = folderBrowserDialog.SelectedPath;
                resultLabel.Text = successMessage+" selected "+path;
                Console.WriteLine(path);
            }
            return path;
        }
    
        private void source_Click(object sender, EventArgs e)
        {
             this.sourcePath= Browse_(sourceFolder ,"Source Folder " );
             
        }

        private void destination_Click(object sender, EventArgs e)
        {
            this.destinationPath = Browse_(destinationFolder, "Destination Folder ");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                ModifyProgressBarColor.SetState(progressBar1, 2);
            }
            
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (this.sourcePath != string.Empty &&
                 this.destinationPath != string.Empty)
            {
                ModifyProgressBarColor.SetState(progressBar1, 1);
                progressBar1.Maximum = 100;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                resultLabel.Text = "Browse Source And Destination Folders to start the copying process!";
            }
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string currentf = string.Empty;
            
            this.copyDirectory.Copy(this.sourcePath, this.destinationPath, this.recursiveCopy );
            /*
            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i * 10);
                }
            }*/
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: do something with final calculation.
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
                //this.Close();
                
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = string.Format("All the contents of  Folder :{0} Copied to {1}!", this.sourcePath, this.destinationPath);
                progressBar1.Value = 100;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        public void copyDirectory_FileRead(object sender, CopyDirectory.FileReadEventArgs e)
        {
                SetText(e);
        }

        delegate void SetTextCallback(FileReadEventArgs e);

        private void SetText(FileReadEventArgs e)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (resultLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { e });
            }
            else
            {
                resultLabel.Text = string.Format("copying file {0} from {1} to {2}",e.name ,e.source.ToString(), e.destination.ToString()) ;
            }
        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
