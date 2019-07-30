using System;
using System.IO;
using System.Net;

namespace sherlock
{
    class Sherlock
    {
        /*
         * 1st line = Site name
         * 2nd line = Site string
         * 3rd line = Site contains
         */
        public void start(string Username)
        {
            string sitesDir = Directory.GetCurrentDirectory() + "\\sites\\";
            string[] files = Directory.GetFiles(sitesDir);

            int i = 0;
            while (i < files.Length)
            {
                string currentFile = files[i];
                string[] currentLines = File.ReadAllLines(currentFile);

                string siteName = currentLines[0];
                string siteString = currentLines[1];
                string siteContains = currentLines[2];

                WebClient wc = new WebClient();
                    
                try
                {
                    string source = wc.DownloadString(siteString + Username);
                   
                    if (source.Contains(siteContains))
                    {
                        Console.Write("- " + siteName + "[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("+");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("] - ");
                        Console.WriteLine(siteString + Username);
                    }

                    else
                    {
                        Console.Write("- " + siteName + " [");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("-");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("] - ");
                        Console.WriteLine("User Not Found");
                    }
                }
                catch
                {
                    Console.Write("- " + siteName + " [");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("-");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("] - ");
                    Console.WriteLine("User Not Found");
                }

                i++;
            }
        }
    }
}