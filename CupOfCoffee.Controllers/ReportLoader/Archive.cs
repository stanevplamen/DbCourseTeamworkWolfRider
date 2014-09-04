namespace CupOfCoffee.Controllers.ReportLoader
{
    using System;
    using System.IO.Compression;

    public static class Archive
    {
        static public bool Extract(string _path, string _filename, string _extrectFolder)
        {
            var path = _path;
            var fileName = _filename;
            var extractFolder = _extrectFolder;
            var filePath = path + fileName;
            var extractPath = path + extractFolder;

            try
            {
                ZipFile.ExtractToDirectory(filePath, extractPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
