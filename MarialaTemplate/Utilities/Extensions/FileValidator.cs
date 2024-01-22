using MarialaTemplate.Utilities.Enums;

namespace MarialaTemplate.Utilities.Extensions
{
    public static class FileValidator
    {
        public static bool ValidateFileType(this IFormFile file,FileHelper type)
        {
            string filename=file.ContentType;
            switch (type)
            {
                case FileHelper.Image:
                    return filename.Contains("image/");
                case FileHelper.Video:
                    return filename.Contains("video/");
                case FileHelper.Audio:
                    return filename.Contains("audio/"); 
            }
            return false;
        }
        public static bool ValidateFileSize(this IFormFile file,SizeHelper size)
        {
            long filesize = file.Length;
            switch (size)
            {
                case SizeHelper.kb:
                    return filesize<=1028;
                case SizeHelper.mb:
                    return filesize <= 1028*1028;
                case SizeHelper.gb:
                    return filesize <= 1028 * 1028 * 1028;
            }
             return false;
        }
        public static void DeleteFile(this string filename,string root,params string[] folders)
        {
            string path = root;
            for (int i = 0; i < folders.Length; i++)
            {
                Path.Combine(folders[i]);
            }
            path= Path.Combine(path, filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
