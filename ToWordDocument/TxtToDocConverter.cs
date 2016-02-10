using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ToWordDocument
{
    class TxtToDocConverter
    {
        private string _abiWordPath;
        private string[] _allowedInputExtentions = { ".txt" };
        public string AbiWordPath
        {
            get { return _abiWordPath; }
            set { _abiWordPath = value; }
        }
        public double IndentBeginParagraph { get; set; }
        public double AfterParagraph { get; set; }
        public bool JustifyBothSides { get; set; }

        public void ConvertToDoc(string fileName, bool deleteOrigin = false)
        {
            FileInfo txtFile = new FileInfo(fileName);

            if (txtFile.Exists)
            {
                if (_allowedInputExtentions.Contains(txtFile.Extension.ToLower()))
                {
                    string docxfile = findAllowableDocxName(txtFile);
                    SaveAsFormattedDocX(txtFile.FullName, docxfile);

                    SaveAsDoc(docxfile);
                    File.Delete(docxfile);

                    if (deleteOrigin)
                        File.Delete(txtFile.FullName);
                }
                else
                    throw new InvalidDataException(String.Format("\"{0}\" is not a TXT file", fileName));
            }
            else
                throw new FileNotFoundException(fileName + " not found.");
        }

        private String findAllowableDocxName(FileInfo txtFile)
        {
            string docxfile;
            string docfile;


            docxfile = txtFile.FullName.Substring(0, txtFile.FullName.Length - txtFile.Extension.Length) + ".docx";
            docfile = txtFile.FullName.Substring(0, txtFile.FullName.Length - txtFile.Extension.Length) + ".doc";

            int i = 1;
            while (File.Exists(docxfile) || File.Exists(docfile))
            {
                docxfile = txtFile.FullName.Substring(0, txtFile.FullName.Length - txtFile.Extension.Length) + "_" + i + ".docx";
                docfile = txtFile.FullName.Substring(0, txtFile.FullName.Length - txtFile.Extension.Length) + "_" + i + ".doc";
                i++;

            }

            return docxfile;
        }

        private void SaveAsFormattedDocX(string textFile, string docName)
        {
            //string[] lines = File.ReadAllLines(textFile,Encoding.GetEncoding(1251));
            string[] lines = File.ReadAllLines(textFile);


            // Create a Wordprocessing document. 
            using (WordprocessingDocument myDoc = WordprocessingDocument.Create(docName, WordprocessingDocumentType.Document))
            {
                // Add a new main document part. 
                MainDocumentPart mainPart = myDoc.AddMainDocumentPart();
                //Create DOM tree for simple document. 
                mainPart.Document = new Document();
                Body body = new Body();
                foreach (string l in lines)
                {
                    string line = ReplaceHexadecimalSymbols(l);

                    Paragraph p = new Paragraph();
                    Run r = new Run();
                    Text t = new Text(line);
                    //Append elements appropriately. 
                    r.Append(t);
                    p.Append(r);
                    p.ParagraphProperties = new ParagraphProperties();
                    if (JustifyBothSides)
                    {
                        p.ParagraphProperties.Justification = new Justification();
                        p.ParagraphProperties.Justification.Val = JustificationValues.Both;
                    }
                    p.ParagraphProperties.Indentation = new Indentation() { FirstLine = (IndentBeginParagraph * 1000).ToString() };
                    p.ParagraphProperties.SpacingBetweenLines = new SpacingBetweenLines() { After = (AfterParagraph * 1000).ToString() };

                    body.Append(p);
                }

                mainPart.Document.Append(body);
                // Save changes to the main document part. 
                mainPart.Document.Save();


            }

        }

        static string ReplaceHexadecimalSymbols(string txt)
        {
            string invalidCharacters = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            return Regex.Replace(txt, invalidCharacters, "", RegexOptions.Compiled);

            //var invalidXmlCharactersRegex = new Regex("[^\u0009\u000a\u000d\u0020-\ud7ff\ue000-\ufffd]|([\ud800-\udbff](?![\udc00-\udfff]))|((?<![\ud800-\udbff])[\udc00-\udfff])");
            //return invalidXmlCharactersRegex.Replace(txt, "");


        }

        // MS Word needed
        //public void Convert(string inputFileName)
        //{
        //    Word._Application application = new Word.Application();
        //    object fileformat = Word.WdSaveFormat.wdFormatDocument97;

        //    FileInfo fileInfo = new FileInfo(inputFileName);
        //    //string newfilename = fileInfo.FullName.Substring(0, fileInfo.FullName..Extension;


        //    Word._Document document = application.Documents.Open(inputFileName);

        //    // document.Convert();
        //    document.SaveAs( inputFileName.TrimEnd('x').TrimEnd('X'), fileformat);
        //    document.Close();
        //    document = null;

        //    application.Quit();
        //    application = null;
        //}

        // need to buy licence or converting only 100 paragraphs
        //public void Convert2(string inputFileName)
        //{
        //    //Load Document  
        //    Spire.Doc.Document doc = new Spire.Doc.Document();
        //    //Pass path of Word Document in LoadFromFile method  
        //    doc.LoadFromFile(inputFileName);
        //    //Pass Document Name and FileFormat of Document as Parameter in SaveToFile Method 
        //    string docFileName = inputFileName.TrimEnd('x').TrimEnd('X');
        //    doc.SaveToFile(docFileName, Spire.Doc.FileFormat.Doc);
        //    //Launch Document  
        //    //System.Diagnostics.Process.Start(docFileName);
        //}

        // abbyword command line - free tool
        private void SaveAsDoc(string inputFileName)
        {

            if (!File.Exists(_abiWordPath))
                throw new FileNotFoundException("Application \"AbyWordPath\" by address \"" + _abiWordPath + "\" not found");

            string outputFileName = inputFileName.TrimEnd('x').TrimEnd('X');

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = _abiWordPath;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = string.Format("\"--to={0}\" \"{1}\"", outputFileName, inputFileName); ;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using-statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    //exeProcess.Id;
                    //exeProcess.ProcessName;
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                //kill AbiWord process
                throw;
            }
        }
    }
}
