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
                Console.WriteLine("Removes the shortcut text from files such as \"Photoshop - Shortcut\"\nUsage: remShort \"C:\\example_folder\"");

            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(args[0]);

                foreach (var f in dir.GetFiles())
                {
                    if (f.Name.Contains(" - Shortcut"))
                    {
                        int start = f.FullName.IndexOf(" - Shortcut");
                        string newName = f.FullName.Remove(start, 11);
                        File.Move(f.FullName, newName);
                    }
                }
            }
        }
    }
}
