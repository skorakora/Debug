using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zielona_Alkaida_Launcher.Core;

namespace Updater.Core
{
    public static class Debug
    {
        public static bool debugConsole = true;

        static FileStream file;
        public static void init(string logPath)
        {
            if(File.Exists(logPath))
            {
                File.Delete(logPath);
            }

            file = new FileStream(logPath, FileMode.Create);

            if (true)
            {
                WinConsole.Initialize();
            }


        }

        public static void Log(string text)
        {
            byte[] data = StringToByte(text);

            file.Write(MergeByteArray(data,endLine), 0, data.Length+2);

            Console.WriteLine("[" + DateTime.Now.ToString("h:mm:ss tt") + "]" + " " + text);
        }

        public static void Warning(string text)
        {
            byte[] data = StringToByte(text);

            file.Write(MergeByteArray(data, endLine), 0, data.Length + 2);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[" + DateTime.Now.ToString("h:mm:ss tt") + "]" + " [WARNING!] " + text);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void Error(string text)
        {
            byte[] data = StringToByte(text);

            file.Write(MergeByteArray(data, endLine), 0, data.Length + 2);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("["+DateTime.Now.ToString("h:mm:ss tt")+"]"+" [ERROR!] "+text);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void Write(string text)
        {
            byte[] data = StringToByte(text);

            file.Write(data, 0, data.Length);

            Console.WriteLine(text);
        }

        public static void ShowConsole()
        {
            if (debugConsole)
            {
                return;
            }

            WinConsole.Initialize();

        }

        public static void HideConsole()
        {
            if (debugConsole)
            {
                return;
            }

            //hideconsole code
        }

        private static byte[] StringToByte(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        private static byte[] ASCIIStringToByte(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        private static byte[] MergeByteArray(byte[] data, byte[] appendData)
        {
            List<byte> newData = new List<byte>();
            newData.AddRange(data);
            newData.AddRange(appendData);

            return newData.ToArray();
        }

        private static byte[] endLine = { 0x0D, 0x0A };
    }
}
