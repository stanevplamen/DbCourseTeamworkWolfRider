namespace Providers.Controllers.ReportLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ReportFinder
    {
        public static void TraverseDirectory(string currentPath, string fileExtension, List<string> files)
        {
            try
            {
                string[] currentDirFiles = Directory.GetFiles(currentPath, fileExtension);
                files.AddRange(currentDirFiles);
            }
            catch (UnauthorizedAccessException e)
            {
                return;
            }

            string[] curretDirDirectories = Directory.GetDirectories(currentPath);

            foreach (var dir in curretDirDirectories)
            {
                TraverseDirectory(dir, fileExtension, files);
            }
        }
    }
}
