using System.IO;
using System.Text.RegularExpressions;


namespace DJ_check
{
    class Sparator
    {
        private readonly string jpgPath;
        private readonly string dngPath;
        private readonly DirectoryInfo jpgFolder;
        private readonly DirectoryInfo dngFolder;

        public Sparator(string pathA, string pathB)
        {
            var folderA = new DirectoryInfo(pathA);
            var filesA = folderA.GetFiles();

            if (Regex.IsMatch(filesA[0].Name, "[\\w]*.(?i)jpg(?-i)"))//如果是jpg文件夹
            {
                (jpgPath, jpgFolder) = (pathA, folderA);
                (dngPath, dngFolder) = (pathB, new DirectoryInfo(pathB));
            }
            else
            {
                (jpgPath, jpgFolder) = (pathB, new DirectoryInfo(pathB));
                (dngPath, dngFolder) = (pathA, folderA);
            }
        }

        public (string, DirectoryInfo) JPG() => (jpgPath, jpgFolder);
        public (string, DirectoryInfo) DNG() => (dngPath, dngFolder);
    }
}
