using System;
using Renci.SshNet;

namespace ConsoleApp
{
    public static class SendFileToServer
    {
        // Enter your host name or IP here
        private static string host = Config.host;
        // Enter your port here
        private static int port = Config.port;
        // Enter your sftp username here
        private static string username = Config.username;
        // Enter your sftp password here
        private static readonly string password = Config.password;
        public static int Send(string fileName)
        {
            try
            {
                //var connectionInfo = new ConnectionInfo(host, "erjan", new PasswordAuthenticationMethod(username, password));
                // Upload File
                using (var sftp = new SftpClient(host, port, username, password))
                {

                    sftp.Connect();
                    sftp.ChangeDirectory(Config.directoryToSave);
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
