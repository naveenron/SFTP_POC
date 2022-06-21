
using Renci.SshNet;
using System.Text;

string hostName = "newdemosftp100.blob.core.windows.net";
string userName = "newdemosftp100.naveen";
string password = "c5rinQbe2tuqWKRcje7weXOGV477Qd2MSPEXSiu1YXiyJ0lhxjPBm1WW+AYQmRcpgufXqjR44jLv2kZjP0zzQg==";

using (SftpClient client = new SftpClient(new PasswordConnectionInfo(hostName,userName,password)))
{
    client.Connect();

    string tempPath = Path.Combine(Path.GetTempPath() + "test.conf");
    // Create a new file     
    using (FileStream fs = File.Create(tempPath))
    {
        // Add some text to file    
        Byte[] title = new UTF8Encoding(true).GetBytes("Hello,");
        fs.Write(title, 0, title.Length);
        byte[] author = new UTF8Encoding(true).GetBytes("  Naveen Kumar");
        fs.Write(author, 0, author.Length);
    }

    // Open the stream and read it back.    
    using (StreamReader sr = File.OpenText(tempPath))
    {
        string s = "";
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine(s);
        }
    }
    //string sourceFile = @"C:\Users\navee\Downloads\sample.txt";
    using (Stream stream = File.OpenRead(tempPath))
    {
        client.UploadFile(stream, Path.GetFileName(tempPath), x =>
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
