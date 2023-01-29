using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenText
{ 
    internal class log
    {
        private String LogPath = "";

        public log(string path)
        {
            LogPath = path + "\\OpenText.log";
        }

        public void WriteLine(string text)
        {
            File.WriteAllTextAsync(LogPath, text);
        }
    }
}
