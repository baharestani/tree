using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var curDir = args.Any() ? args[0] : Directory.GetCurrentDirectory();

            OutputToConsole(curDir);

            // OutputToFile(curDir, "c:\\test.txt");
        }

        private static void OutputToConsole(string curDir)
        {
            var treeDrawer = new TreeDrawer();
            treeDrawer.Draw(curDir, s => Console.Write(s));
        }

        private static void OutputToFile(string curDir, string filePath)
        {
            var treeDrawer = new TreeDrawer();
            using (var sw = new StreamWriter(filePath))
            {
                treeDrawer.Draw(curDir, s => sw.Write(s));
            }
        }


    }




}
