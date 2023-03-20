using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Server.F_Server;
using System.Windows.Forms;

namespace Server
{
    public class ClientHandler
    {

        public Socket clientSocket;
        public  CacheBuffer cacheBuffer;

        public  ClientHandler(Socket clientSocket, CacheBuffer cacheBuffer)
        {
            this.clientSocket = clientSocket;
            this.cacheBuffer = cacheBuffer;
        }

        public void Start()
        {
            //MessageBox.Show("客户端已连接！");

            while (true)
            {
                //接收客户端的请求2KB大小，其实传入的指令1KB就足够，防止异常
                byte[] buffer = new byte[2048];
                //接受请求大小
                int bytesRead = clientSocket.Receive(buffer);
                //返回的请求
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // 处理客户端请求
                string[] tokens = request.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //用command接受请求用于判断
                string command = tokens[0];
                //提取出指令中下载的文件名
                string name = command.Replace("DOWNLOAD:", "");
                
                switch (command)
                {
                    //请求列表
                    case "LIST":
                        ListFiles();
                        break;
                    //清楚缓存
                    case "CLEAR":
                        cacheBuffer.ClearCache();
                        break;
                    //下载文件
                    default:
                        DownloadFile(name);
                        break;
                }
            }
        }

        public void ListFiles()
        {
            // 从缓存器中获取文件列表
            string fileList = cacheBuffer.GetFileList();
            //缓存中若没有
            if (fileList == null)
            {
                // 从磁盘中读取文件列表
                StringBuilder sb = new StringBuilder();
                //文件地址
                string[] files = Directory.GetFiles(Client_rootDirectory);
                //遍历文件夹
                foreach (string file in files)
                {
                    //添加到file中
                    sb.AppendLine(file);
                }
                //添加遍历结果到文件列表中
                fileList = sb.ToString();

                //将文件列表保存到缓存器
                cacheBuffer.SetFileList(fileList);
            }
            else
            {
                // 比较缓存中的文件列表与磁盘上的文件列表，找出不同之处
                string[] diskFiles = Directory.GetFiles(Client_rootDirectory);
                //分行
                string[] cacheFiles = fileList.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //list一个不同的文件列表
                List<string> diffFiles = new List<string>();
                //遍历不同
                foreach (string diskFile in diskFiles)
                {
                    //不包含这个文件
                    if (!cacheFiles.Contains(diskFile))
                    {
                        //添加进list
                        diffFiles.Add(diskFile);
                    }
                }

                //如果不同的行大于0
                if (diffFiles.Count > 0)
                {
                    // 读取不同的文件，并将其更新到文件列表中
                    foreach (string diffFile in diffFiles)
                    {
                        //用一个fileContent读取文本
                        string fileContent = File.ReadAllText(diffFile);
                        //以byte形式储存
                        byte[] newFC = Encoding.UTF8.GetBytes(fileContent);
                        //保存到缓存中
                        cacheBuffer.SetFileData(diffFile, newFC);
                    }

                    //更新文件列表
                    StringBuilder sb = new StringBuilder();
                    //遍历添加
                    foreach (string cacheFile in cacheFiles)
                    {
                        sb.AppendLine(cacheFile);
                    }
                    //遍历添加
                    foreach (string diffFile in diffFiles)
                    {
                        sb.AppendLine(diffFile);
                    }
                    //添加到list中
                    fileList = sb.ToString();
                    //保存到缓存中
                    cacheBuffer.SetFileList(fileList);
                }
            }
            // 将文件列表发送给客户端
            byte[] buffer = Encoding.UTF8.GetBytes(fileList);
            clientSocket.Send(buffer);
            //MessageBox.Show("服务器已发送最新文件列表！", "提示");
        }

        public void DownloadFile(string fileName)
        {
            //传回的source
            byte source = 0;
            //从缓存器中获取文件内容
            byte[] fileContent = cacheBuffer.GetFileContent(fileName);
            //如果缓存为空
            if (fileContent == null)
            {
                //传回source=0代表从磁盘中读取
                source = 0;
                // 从磁盘中读取文件内容
                string filePath = Path.Combine(Client_rootDirectory, fileName);
                //读取文件
                fileContent = File.ReadAllBytes(filePath);
                // 将文件内容保存到缓存器
                cacheBuffer.SetFileContent(fileName, fileContent);
                //传回一个+1字节的消息，这里是0
                byte[] messageBody = new byte[fileContent.Length + 1];
                //标记第一个地址
                messageBody[0] = source;
                //复制结果
                Array.Copy(fileContent, 0, messageBody, 1, fileContent.Length);
                //传给客户端
                clientSocket.Send(messageBody);
            }
            else
            {
                //读取缓存
                byte[] fileContent1 = cacheBuffer.GetFileContent(fileName);
                //传回source=1代表从缓存中读取
                source = 1;
                //传回一个+1字节的消息，这里是1
                byte[] messageBody = new byte[fileContent1.Length + 1];
                //标记第一个地址
                messageBody[0] = source;
                //复制结果
                Array.Copy(fileContent1, 0, messageBody, 1, fileContent1.Length);
                //传给客户端
                clientSocket.Send(messageBody);
            }
        }


    }
}

