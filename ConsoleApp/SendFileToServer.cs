using System;
using System.Collections.Generic;
using System.Text;
using Renci.SshNet;

namespace ConsoleApp
{
    public static class SendFileToServer
    {
        // Enter your host name or IP here
        private static string host = @"158.69.52.119";

        private static int port = 11022;
        // Enter your sftp username here
        private static string username = @"erjan";
        // Enter your sftp password here
        private static readonly string password = @"6eYbUb4MuD";
        public static int Send(string fileName)
        {
            try
            {
                //var connectionInfo = new ConnectionInfo(host, "erjan", new PasswordAuthenticationMethod(username, password));
                // Upload File
                using (var sftp = new SftpClient(host, port, username, password))
                {

                    sftp.Connect();
                    sftp.ChangeDirectory("/docker/appdata/herbarium/uploads/raw");
                    using (var uplfileStream = System.IO.File.OpenRead(fileName))
                    {
                        sftp.UploadFile(uplfileStream, fileName, true);
                    }
                    sftp.Disconnect(); 
                    Console.WriteLine("\n\n" + fileName + " uploaded successfully.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\n\n" + fileName + " was not uploaded.\n\n");
            }
            return 0;
        }
    }
}
