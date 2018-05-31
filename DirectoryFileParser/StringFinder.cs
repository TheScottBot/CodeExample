namespace DirectoryFileParser
{
    using System.IO;
    using System.Linq;

    public class StringFinder
    {
        private string[] _files;
        public StringFinder(string path, string fileType)
        {
            _files = Directory.GetFiles(path, EnsureFileTypeHasDot(fileType), SearchOption.AllDirectories);
        }

        public string[] GetFiles()
        {
            return _files;
        }
        private string EnsureFileTypeHasDot(string fileType)
        {
            var fileTypeToReturn = fileType;
            if(fileType[0] != '.')
            {
                fileTypeToReturn = "." + fileType;
            }
            return fileTypeToReturn;
        }
        public int FindStringInFiles(string contains, string[] files)
        {
            var count = 0;
            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    var test = File.ReadLines(file).Any(theFile => theFile.Contains(contains));
                    if (test)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
