using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace X1Img2PCGData
{
    internal class Program
    {
        /// <summary>
        /// X1用のPCGデータを作成する。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if(args.Length == 0) {
                printUsing();
                Environment.Exit(1);
            }
            string sourceFilename = args[0];
            string letterFilename;
            string outputFilename;
            if(args.Length > 1) {
                letterFilename = args[1];
            } else {
                letterFilename = Path.ChangeExtension(sourceFilename, ".txt");
            }
            if(args.Length > 2) {
                outputFilename = args[2];
            } else {
                outputFilename = Path.ChangeExtension(sourceFilename, ".DAT");
            }
            string letter = File.ReadAllText(letterFilename);
            using(Bitmap sourceImage = new Bitmap(sourceFilename)) {
                byte[] data = PCG.ToByte(sourceImage, letter);
                File.WriteAllBytes(outputFilename, data.ToArray());
            }
        }

        static private void printUsing()
        {
            System.Console.WriteLine("PCG conversion tool for X1.");
            System.Console.WriteLine("X1Img2PCGData.exe <sourceImageFilename> [<letterFilename> [<outputFilename>]]");
            System.Console.WriteLine("    <sourceImageFilename> : Image source file. The extension is png, bmp, etc.");
            System.Console.WriteLine("    <letterFilename> : A text file with text paired with the image.");
            System.Console.WriteLine("                       If omitted, the extension of the image source");
            System.Console.WriteLine("                       file is changed to 'txt'.");
            System.Console.WriteLine("    <outputFilename> : Output file.");
            System.Console.WriteLine("                       If omitted, the extension of the image source");
            System.Console.WriteLine("                       source file is changed to 'DAT'.");
        }
    }
}
