using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenText
{
    internal class FileHandle
    {
        private FileStream file;
        public string FilePath = "";
        public string FileName = "";
        public string FileContents = "";
        public bool IsOpen = false;
        
        public FileHandle(string path)
        {
            try
            {
                file = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
                IsOpen = true;
                StreamReader reader = new StreamReader(file);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(!line.EndsWith(Environment.NewLine)) FileContents += line + Environment.NewLine;
                    else FileContents += line;
                }
                FileName = Path.GetFileName(path);
                FilePath = path;
            }
            catch(Exception ex) { 
                FileContents = ex.Message;
                IsOpen = false;
            }
        }

        public void Close(bool delOnClose = false)
        {
            file.Close();
            if (delOnClose)
            {
                File.Delete(FilePath);
            }
        }

        public bool Save(string LinesToWrite)
        {  
            try
            {
                file.Close();
                file = File.Open(FilePath, FileMode.Create, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.Write(LinesToWrite);
                }
                file.Close();
                file = File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.Read);
            }
            catch (Exception ex)
            {
                FileContents = ex.Message;
                return false;
            }
            
            return true;
        }

        public bool Open()
        {
            return false;
        }
    }
}
