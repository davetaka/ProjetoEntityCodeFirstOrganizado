using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Framework
{
    public static class FileHelper
    {
        public static void SaveFile(string content, string fileName)
        {
            StreamWriter sw = new StreamWriter("C:\\CursoEntity\\log_entity.txt", true);
            sw.Write(content);
            sw.Close();
            sw.Dispose();
        }

        public static void SaveFile(string content)
        {
            SaveFile(content, "C:\\CursoEntity\\log_entity.txt");
        }
    }
}
