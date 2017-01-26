using System;
using System.IO;
using System.Text;

namespace MapperProject.Logger
{
    public class TextFileLogger : ILogger
    {
        private string filePath;
        private static readonly object Sync = new object();

        public TextFileLogger()
        {
            SetLoggerSettings();
        }

        private void SetLoggerSettings()
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);
                filePath = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
            }
            catch (Exception e)
            {

            }

        }

        public void WriteToLog(string data)
        {
            try
            {
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}]: {1}\r\n", DateTime.Now, data);
                lock (Sync)
                {
                    File.AppendAllText(filePath, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}