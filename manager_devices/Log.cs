using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThanVong
{
      public static   class Log
    {
        static string logFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Logs\\" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
        static FileInfo logFileInfo = new FileInfo(logFilePath);
        static DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
        static string time = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss:fff");

         public static    void Error(string strLog)
        {
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    time = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss:fff");
                    log.WriteLine($"{time} - Error:\t{strLog}");
                }
            }
        }

         public static    void Info(string strLog)
        {
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    time = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss:fff");
                    log.WriteLine($"{time} - Info:\t{strLog}");
                }
            }
        }

         public static    void Warning(string strLog)
        {
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    time = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss:fff");
                    log.WriteLine($"{time} - Warning:\t{strLog}");
                }
            }
        }
    }
}
