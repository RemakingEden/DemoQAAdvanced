using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace DemoQAAdvanced.Helpers
{
    internal static class TestFolders
    {
        public static readonly string UniqueId = DateTime.Now.ToString("s", CultureInfo.InvariantCulture).Replace(":", "");

        public static string InputFolder
        {
            get { return Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath); }
        }

        public static string OutputFolder
        {
            //a simple solution that puts everyting to the output folder directly would look like this:
            //get { return Directory.GetCurrentDirectory(); }
            get
            {
                var outputFolder = Path.Combine(Directory.GetCurrentDirectory(), UniqueId);
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);
                return outputFolder;
            }
        }

        public static string TempFolder
        {
            get { return Path.GetTempPath(); }
        }

        public static string CurrentFolder
        {
            get { return Directory.GetCurrentDirectory(); }
        }

        // very simple helper methods that can improve the test code readability

        public static string GetInputFilePath(string fileName)
        {
            return Path.GetFullPath(Path.Combine(InputFolder, fileName));
        }

        public static string GetOutputFilePath(string fileName)
        {
            return Path.GetFullPath(Path.Combine(OutputFolder, fileName));
        }

        public static string GetTempFilePath(string fileName)
        {
            return Path.GetFullPath(Path.Combine(TempFolder, fileName));
        }

        public static string GetCurrentFilePath(string fileName)
        {
            return Path.GetFullPath(Path.Combine(CurrentFolder, fileName));
        }
    }
}