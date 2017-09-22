using System;
using System.IO;

namespace projRemoveShortcutText
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Removes the shortcut text from files such as \"Photoshop - Shortcut\"\nUsage: remShort \"C:\\Users\\Chris\\Desktop\"");

            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(args[0]);

                try
                {
                    foreach (var f in dir.GetFiles())
                    {
                        if (f.Name.Contains(" - Shortcut"))
                        {
                            int start = f.FullName.IndexOf(" - Shortcut");
                            string newName = f.FullName.Remove(start , 11);
                            try
                            {
                                File.Move(f.FullName , newName);
                            }
                            catch (IOException ioe)
                            {
                                Console.WriteLine("The file {0} may contain a duplicate." , f.Name);
                            }
                        }
                    }
                }
                catch (DirectoryNotFoundException dnf)
                {
                    Console.WriteLine("The folder supplied does not exist.");
                }
            }
        }
    }
}
