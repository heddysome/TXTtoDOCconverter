
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
//using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using Word = Microsoft.Office.Interop.Word;
//using Spire.Doc;

namespace ToWordDocument
{
    public partial class Form1 : Form
    {
        internal ConverterExecuter converterExecuter = null;
        TxtDocConverterSettings settings = null;
        string SettingsFilepath = "Settings.xml";

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            lblMessage.Text = "";

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            openFileDialog1.Filter = "Text files (TXT)|*.TXT";

            converterExecuter = new ConverterExecuter();
            converterExecuter.Message = ShowMessage;
            converterExecuter.NextFileConvertation += ConverterExecuter_NextFileConvertation;


            ReadSettingsFromFile();
            ApplySettingsToUI();

        }


        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Move;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            List<string> files = new List<string>();
            List<string> folders = new List<string>();


            string[] filesFolders = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filefolder in filesFolders)
            {
                if (Directory.Exists(filefolder))
                    folders.Add(filefolder);
                else
                    files.Add(filefolder);
            }

            converterExecuter.Files = files.ToArray();
            converterExecuter.Directories = folders.ToArray();

            btnStart_Click(this, null);
        }


        private void ConverterExecuter_NextFileConvertation(object sender, EventArgs e)
        {

            Invoke((MethodInvoker)delegate
            {
                progressBar1.Maximum = converterExecuter.FilesCount;
                progressBar1.Step = 1;
                progressBar1.Value = converterExecuter.CurrentFileNumber;
            });
        }

        Thread worker = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            BlockPage();
            worker = new Thread(Start);
            worker.Start();

        }





        private void Start()
        {
            try
            {
                ReadSettingFromUI();
                ApplySettings();
                SaveSettingsToFile();
                converterExecuter.Start();
            }
            catch (InvalidDataException e)
            {
                Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(String.Format(e.Message));
                });
            }
            catch (FileNotFoundException e)
            {
                Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(String.Format(e.Message));
                });
            }
            catch (DirectoryNotFoundException e)
            {
                Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(String.Format(e.Message));
                });
            }
            catch (Exception e)
            {
                Directory.CreateDirectory("Error logs");
                using (StreamWriter outputFile = new StreamWriter(String.Format("Error logs\\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss"))))
                {
                    outputFile.WriteLine("File {0}", converterExecuter.CurrentFile);
                    outputFile.WriteLine(e);
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Exception occured. See \"Error Logs\" folder. The Application will be closed.");
                        Close();
                    });
                }

            }
            finally
            {


                Process_Ended += Form1_Process_Ended;
                if (Process_Ended != null)
                    Process_Ended(this, null);
            }
        }

        private void Form1_Process_Ended(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = 0;
                    if (converterExecuter.Stopped)
                        ShowMessage("Converting stopped");
                    else
                        ShowMessage(string.Format("Converting finished!"));

                    UnBlockPage();
                });



        }

        private event EventHandler Process_Ended;





        void ShowMessage(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                lblMessage.Text = message; // runs on UI thread
            });
        }







        //
        //
        // settings part
        //
        //

        void SaveSettingsToFile()
        {
            SettingsManager.WriteToXmlFile(SettingsFilepath, settings);
        }

        void ReadSettingsFromFile()
        {
            if (File.Exists(SettingsFilepath))
                settings = SettingsManager.ReadFromXmlFile<TxtDocConverterSettings>(SettingsFilepath);
            else
            {
                // default settings
                settings = new TxtDocConverterSettings();
                settings.AbiwordPath = @"AbiWord\bin\AbiWord.exe";
                settings.FirstLineIndentation = 0.5;
                settings.AfterParagraphIndentation = 0.6;
                settings.FontSize = 14;
                settings.SpaceBetweenLines = 1.0;

                SaveSettingsToFile();
            }

        }



        void ReadSettingFromUI()
        {
            settings.FirstLineIndentation = (double)NUDFirstLineIndentaion.Value;
            settings.AfterParagraphIndentation = (double)NUDAfterParagraphIndentation.Value;
            settings.FontSize = (double)nudFontSize.Value;
            settings.SpaceBetweenLines = (double)nudSpaceBtwLines.Value;
        }

        void ApplySettingsToUI()
        {
            NUDFirstLineIndentaion.Value = (decimal)settings.FirstLineIndentation;
            NUDAfterParagraphIndentation.Value = (decimal)settings.AfterParagraphIndentation;
            nudFontSize.Value = (decimal)settings.FontSize;
            nudSpaceBtwLines.Value = (decimal)settings.SpaceBetweenLines;
        }



        void ApplySettings()
        {
            converterExecuter.DocConverter.AbiWordPath = settings.AbiwordPath;
            converterExecuter.DocConverter.AfterParagraph = settings.AfterParagraphIndentation;
            converterExecuter.DocConverter.IndentBeginParagraph = settings.FirstLineIndentation;
            converterExecuter.DocConverter.FontSize = settings.FontSize;
            converterExecuter.DocConverter.SpaceBtwLines = settings.SpaceBetweenLines;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ShowMessage("Stopping ...");
            converterExecuter.Stop();



        }


        private void BlockPage()
        {
            NUDAfterParagraphIndentation.Enabled = false;
            NUDFirstLineIndentaion.Enabled = false;
            btnRunConvertation.Enabled = false;
            nudFontSize.Enabled = false;
            nudSpaceBtwLines.Enabled = false;


        }
        private void UnBlockPage()
        {
            NUDAfterParagraphIndentation.Enabled = true;
            NUDFirstLineIndentaion.Enabled = true;
            btnRunConvertation.Enabled = true;
            nudFontSize.Enabled = true;
            nudSpaceBtwLines.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Do a fast check to see if the worker thread is still running.
            if (worker != null && !worker.Join(0))
            {
                e.Cancel = true; // Cancel the shutdown of the form.
                converterExecuter.Stop();
                var timer = new System.Timers.Timer();
                timer.AutoReset = false;
                timer.SynchronizingObject = this;
                timer.Interval = 200;
                timer.Elapsed +=
                  (s, args) =>
                  {
                      // Do a fast check to see if the worker thread is still running.
                      if (worker.Join(0))
                      {
                          // Reissue the form closing event.
                          Close();
                      }
                      else
                      {
                          // Keep restarting the timer until the worker thread ends.
                          timer.Start();
                      }
                  };
                timer.Start();
            }



        }

        private void labWorkFolder_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseFiles_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbFolderPath.Text = string.Join("\r\n", openFileDialog1.FileNames);
                ReadSettingFromUI();
                SaveSettingsToFile();
                converterExecuter.Files = openFileDialog1.FileNames;
                converterExecuter.Directories = new string[] { };
            }
        }
    }

}
