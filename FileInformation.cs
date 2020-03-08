using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsOrganizer
{
    class FileInformation
    {
        private static readonly string docPath = ConfigurationManager.AppSettings["DocumentsPath"];
        private static readonly string photoPath = ConfigurationManager.AppSettings["PhotosPath"];
        private static readonly string musicPath = ConfigurationManager.AppSettings["MusicPath"];
        private static readonly string othersPath = ConfigurationManager.AppSettings["OthersPath"];

        private static List<string> docExt = new List<string>() { "doc", "docx", "odt", "pdf", "rtf", "tex", "txt", "wks", "wps", "wpd", "xps", "vsdx", "xls", "xlsx" };
        private static List<string> photoExt = new List<string>() { "jpg", "jpeg", "png", "gif", "tiff", "psd", "eps", "ai", "raw", "indd", "cdr", "svg" };
        private static List<string> musicExt = new List<string>() { "aac", "aif", "aiff", "iff", "m3u", "m4a", "mid", "mp3", "mpa", "oga", "ra", "wav", "wma" };
        private static List<string> othersExt = new List<string>() { "exe", "zip", "rar", "7z", "torrent", "mp4", "ct" };
        internal async static void OnCreated(object source, FileSystemEventArgs e)
        {
            string extension = Path.GetExtension(e.Name).Replace(".", "").ToLower();
            System.Threading.Thread.Sleep(1000);

            if ((e.ChangeType == WatcherChangeTypes.Created ||
                e.ChangeType == WatcherChangeTypes.Renamed ||
                e.ChangeType == WatcherChangeTypes.Changed) &&
                File.Exists(e.FullPath))
            {
                if (e.ChangeType == WatcherChangeTypes.Created && docExt.Contains(extension))
                {
                    using (Stream streamSource = File.Open(e.FullPath, FileMode.Open))
                    {
                        using (Stream destination = File.Create(String.Format(docPath, e.Name)))
                        {
                            await streamSource.CopyToAsync(destination);
                        }
                    }
                    File.Delete(e.FullPath);
                }
                else if (e.ChangeType == WatcherChangeTypes.Created && photoExt.Contains(extension))
                {
                    using (Stream streamSource = File.Open(e.FullPath, FileMode.Open))
                    {
                        using (Stream destination = File.Create(String.Format(photoPath, e.Name)))
                        {
                            await streamSource.CopyToAsync(destination);
                        }
                    }
                    File.Delete(e.FullPath);
                }
                else if (e.ChangeType == WatcherChangeTypes.Created && musicExt.Contains(extension))
                {
                    using (Stream streamSource = File.Open(e.FullPath, FileMode.Open))
                    {
                        using (Stream destination = File.Create(String.Format(musicPath, e.Name)))
                        {
                            await streamSource.CopyToAsync(destination);
                        }
                    }
                    File.Delete(e.FullPath);
                }
                else if (e.ChangeType == WatcherChangeTypes.Created && othersExt.Contains(extension))
                {
                    using (Stream streamSource = File.Open(e.FullPath, FileMode.Open))
                    {
                        using (Stream destination = File.Create(String.Format(othersPath, e.Name)))
                        {
                            await streamSource.CopyToAsync(destination);
                        }
                    }
                    File.Delete(e.FullPath);
                }
            }
        }                                     
    }
}
