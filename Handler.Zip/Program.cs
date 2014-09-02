namespace Handler.Zip
{
    using System;
    using System.IO;

    public class Program
    {
        static void Main()
        {
            Unzip(@"..\..\..\", @"data.zip", @"data\extracted");
        }

        static public bool Unzip(string _path, string _filename, string _extrectFolder)
        {
            //string path = @"..\..\..\";
            //string fileName = @"sample.zip";
            //string extractFolder = @"data\extracted";
            string path = _path;
            string fileName = _filename;
            string extractFolder = _extrectFolder;
            string filePath = path + fileName;
            string extractPath = path + extractFolder;

            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(filePath, extractPath);
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Could not unzip file -> ArgumentException");
                return false;
                //throw new ArgumentException("Could not unzip file -> argument exception");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Could not unzip file -> PathTooLongException");
                return false;
                //throw new ArgumentException("Could not unzip file -> PathTooLongException");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Could not unzip file -> DirectoryNotFoundException");
                return false;
                //throw new ArgumentException("Could not unzip file -> DirectoryNotFoundException");
            }
            catch (IOException)
            {
                Console.WriteLine("Could not unzip file -> IOException");
                return false;
                //throw new ArgumentException("Could not unzip file -> IOException");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Could not unzip file -> UnauthorizedAccessException");
                return false;
                //throw new ArgumentException("Could not unzip file -> UnauthorizedAccessException");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Could not unzip file -> NotSupportedException");
                return false;
                //throw new ArgumentException("Could not unzip file -> NotSupportedException");
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Could not unzip file -> InvalidDataException");
                return false;
                //throw new ArgumentException("Could not unzip file -> InvalidDataException");
            }
        }
    }
}