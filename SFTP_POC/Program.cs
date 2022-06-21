
using Renci.SshNet;

string hostName = "newdemosftp100.blob.core.windows.net";
string userName = "newdemosftp100.naveen";
string password = "c5rinQbe2tuqWKRcje7weXOGV477Qd2MSPEXSiu1YXiyJ0lhxjPBm1WW+AYQmRcpgufXqjR44jLv2kZjP0zzQg==";

using (SftpClient client = new SftpClient(new PasswordConnectionInfo(hostName,userName,password)))
{
    client.Connect();

    string sourceFile = @"C:\Users\navee\Downloads\sample.txt";
    using (Stream stream = File.OpenRead(sourceFile))
    {
        client.UploadFile(stream, Path.GetFileName(sourceFile), x =>
        {
            Console.WriteLine("Updated!!!");
        });
    }
    //string serverFile = @"\public\sample.txt";
    //string localFile = @"D:\Self Learning\SFTP\test.txt";
    //using (var stream = File.OpenWrite(localFile))
    //{
    //    client.DownloadFile(serverFile, stream);
    //}
    client.Disconnect();
}
