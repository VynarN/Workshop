namespace Workshop.OneDriveHomework
{
    using System.Linq;
    using System.IO;

    public static class OneDriveTaskAuxiliary
    {
        public static string ParseLink(string link)
        {
            return link.Replace("???", "&");
        }

        public static string GetLatestDownloadedFile(string fileName, string directory)
        {
            var files = Directory.EnumerateFiles(directory).Where(file => file.Contains(fileName));

            var latestDownloaded = files.Single(file => File.GetLastWriteTime(file) == files.Select( f => File.GetLastWriteTime(f)).Max());

            return latestDownloaded.Substring(0, latestDownloaded.LastIndexOf('.'));
        }
    }
}
