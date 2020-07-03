using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    static class Config
    {
        // Enter path which has to be monitored
        public static readonly string pathToMonitor = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        // Enter path on the server where app has to save files
        public static readonly string directoryToSave = "/docker/appdata/herbarium/uploads/raw";
        // Enter your host name or IP here
        public static readonly string host = @"158.69.52.119";
        // Enter your port here
        public static readonly int port = 11022;
        // Enter your sftp username here
        public static readonly string username = @"erjan";
        // Enter your sftp password here
        public static readonly string password = @"6eYbUb4MuD";
    }
}
