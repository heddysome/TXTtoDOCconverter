using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ToWordDocument
{
    class ConverterExecuter
    {
        public class FileSearch
        {
            public static string[] inputExtentions { get; set; } = { ".txt" };

            public string WorkDirectory = null;
            public string[] Directories = new string[] { };
            public string[] Files = new string[] { };


            public bool IncludeSubfolders { get; set; } = true;
            public List<string> fileList = new List<string>();
            public void Stop() { _stop = true; }
            private bool _stop;



            // when files and folders propped on the app form
            public void DoMultipleSearch()
            {
                foreach (string dir in Directories)
                {
                    DoSearch(dir);
                }

                fileList.AddRange(Files);
            }

            public void DoSearch()
            {
                _stop = false;

                // FIX
                DoMultipleSearch();
                //Files = null;
                //Directories = null;

                ////  files and folders propped on the app form
                //if (Directories != null)
                //{
                //    DoMultipleSearch();
                //    Files = null;
                //    Directories = null;
                //}
                //else // usual rorking flow
                //{
                //    DoSearch(WorkDirectory);

                //}
            }

            private void DoSearch(string directory)
            {
                SearchDirectories(directory);
            }

            private void SearchDirectories(string directory)
            {
                if (_stop)
                    return;

                SearchFiles(directory);

                if (IncludeSubfolders)
                {
                    foreach (string dir in Directory.GetDirectories(directory))
                    {
                        if (_stop)
                            return;

                        SearchDirectories(dir);
                    }
                }
            }

            private void SearchFiles(string directory)
            {
                if (_stop)
                    return;

                DirectoryInfo di = new DirectoryInfo(directory);
                foreach (var file in di.GetFiles().Where(f => inputExtentions.Contains(f.Extension)))
                {
                    fileList.Add(file.FullName);
                }
            }

            public event EventHandler SearchCompleted;
        }
        public string WorkDirectory
        {
            get { return _fileSearch.WorkDirectory; }
            set { _fileSearch.WorkDirectory = value; }
        }
        public string[] Directories
        {
            set { _fileSearch.Directories = value; }
        }
        public string[] Files
        {
            set { _fileSearch.Files = value; }
        }

        private FileSearch _fileSearch = new FileSearch();
        public TxtToDocConverter DocConverter = new TxtToDocConverter();
        public int FilesCount;
        public int CurrentFileNumber;
        public event EventHandler NextFileConvertation;
        public bool Stopped;
        private string _currentFile = "";
        public string CurrentFile
        {
            get { return _currentFile; }
        }

        public void Stop()
        {
            _fileSearch.Stop();
            //_fileSearch.Directories = null;
            //_fileSearch.Files = null;
            Stopped = true;
          
        }


        public bool IncludeSubfolders
        {
            set { _fileSearch.IncludeSubfolders = value; }
        }


        public void Start()
        {
            _fileSearch.fileList.Clear();
            Stopped = false;
            MakeMessage("Searching files");
            _fileSearch.DoSearch();
            FilesCount = _fileSearch.fileList.Count;
            CurrentFileNumber = 0;

            foreach (string file in _fileSearch.fileList)
            {
                _currentFile = file;
                if (Stopped)
                {
                    return;
                }

                if (NextFileConvertation != null)
                {
                    NextFileConvertation(this, null);
                    CurrentFileNumber++;
                }


                MakeMessage(string.Format("Converting {0}", CropString(file, 60)));
                DocConverter.ConvertToDoc(file);
            }


            if (NextFileConvertation != null)
            {
                NextFileConvertation(this, null);
            }
            //Process.GetCurrentProcess()
        }

        private string CropString(string str, int maxLength)
        {
            if (str.Length > maxLength)
                return string.Format("..{0}", str.Substring(str.Length - maxLength));
            else return str;
        }

        private void MakeMessage(string message)
        {
            if (Message != null)
                Message(message);
        }

        public OperationMessage Message;
        public delegate void OperationMessage(string message);

    }
}
