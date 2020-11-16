using System;
using System.IO;
using System.Linq;
using System.Drawing;

namespace CreateFileList
{
    class Program
    {
        private static string sourcePath = @"D:\\Projects\\6.12a1\\12a1\\1";
        private static string targetPath = @"D:\\Projects\\6.12a1\\12a1\\1\\thumbnails";
        static void Main(string[] args)
        {
            string yol = "filelist.txt";
            StreamWriter zzz = new StreamWriter(yol);
            string[] lines = Directory.GetFiles(sourcePath, "*.JPG")
                                     .Select(Path.GetFileName)
                                     .ToArray();
            foreach (string name in lines)
            {
                ThumbCreate(name);
                string item = "<li><a href=\"1/" + name + "\"><img style=\"width: 69px; height: 47px;\" src=\"1/thumbnails/thumb_" + name  + "\" data-large=\"1/" + name + "\" alt=\"" + name + "\" data-description=\"\" /></a></li>";
                zzz.WriteLine(item);
            }
            zzz.Close();
            
        }
        public static void ThumbCreate(string fileName)
        {
            
            string thumbName = "thumb_" + fileName;
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);
            string destthumbName = Path.Combine(targetPath, thumbName);
            //File.Copy(sourceFile, destFile, true);
            Image image = Image.FromFile(sourceFile);
            Image thumb = image.GetThumbnailImage(69, 47, () => true, IntPtr.Zero);
            //thumb.Save(Path.ChangeExtension(fileName, "thumb"));
            thumb.Save(destthumbName);
            image.Dispose();
        }
    }
}
