using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad
{
    public class File
    {
        string fileName;
        public bool saved = false;

        public File()
        {
            fileName = "test.text";
        }

        public File(string fileName)
        {
            this.fileName = fileName;
        }

      
    }
}
