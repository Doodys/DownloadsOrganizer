using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsOrganizer
{
    class Watcher
    {
        static void Main(string[] args)
        {
            Run();
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = ConfigurationManager.AppSettings["PathToWatch"];

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                        | NotifyFilters.LastWrite
                                        | NotifyFilters.FileName
                                        | NotifyFilters.DirectoryName;

                // Add event handlers.
                watcher.Created += FileInformation.OnCreated;
                watcher.EnableRaisingEvents = true;
                // Constant watching
                while (true);
            }
        }
    }
}
