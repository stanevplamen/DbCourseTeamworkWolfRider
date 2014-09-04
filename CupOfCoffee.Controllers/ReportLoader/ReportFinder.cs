namespace CupOfCoffee.Controllers.ReportLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class ReportFinder
    {
        public static void TraverseDirectory(string currentPath, string fileExtension, List<string> files)
        {
            try
            {
                var currentDirFiles = Directory.GetFiles(currentPath, fileExtension);
                files.AddRange(currentDirFiles);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            var curretDirDirectories = Directory.GetDirectories(currentPath);

            foreach (var dir in curretDirDirectories)
            {
                TraverseDirectory(dir, fileExtension, files);
            }
        }
    }
}
