using System;

namespace Lab2.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var explorer = new SystemFileExplorerWithCI(new FileManager());

            //Console.WriteLine(explorer.MergeTemporaryFiles(@"C:\Temporary") ? "Done!" : "Failed!");
            explorer.RemoveTemporaryFiles(@"C:\Temporary");

            Console.ReadLine();
        }
    }
}
