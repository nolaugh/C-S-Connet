using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;


namespace Client
{
    public partial class F_Client : Form
    {
        //创建客户端连接对象
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // 连接到服务器
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8686);

        public static string Cache;
        public static int back;
        
        public F_Client()
        {
            InitializeComponent();
            //Cache文件夹
            Cache = Path.Combine(Application.StartupPath, "Cache");
            if (!Directory.Exists(Cache))
            {
                //创建目录
                Directory.CreateDirectory(Cache);
            }

            //Cache文件夹下的log.txt
            string Cache_log = Path.Combine(Application.StartupPath, "Cache\\log.txt");
            if (!File.Exists(Cache_log))
            {
                // 创建文件，并返回表示该文件的StreamWriter对象
                StreamWriter streamWriter = File.CreateText(Cache_log);

                // 关闭StreamWriter对象，释放资源
                streamWriter.Close();
            }
        }

        //连接
        public void workthread()
        {
            try
            {
                //连接服务器
                clientSocket.Connect(serverEndPoint);
            }
            catch
            {
                MessageBox.Show("The connection is abnormal, please check whether the server is turned on!", "Message");
            }
        }

        //加载
        private void F_Client_Load(object sender, EventArgs e)
        {

            try
            {
                //开启新线程防止阻塞GUI
                Thread thread=new Thread(workthread);
                //开启线程
                thread.Start();

                lbl_connect.Text = "Connected";
                if (lbl_connect.Text == "Connected")
                {
                    //调用刷新，减少代码重复写
                    btn_refresh_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        //刷新
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            //清空列表
            lb_file.Items.Clear();
            //发送LIST指令
            string request = "LIST";
            //byte形式存储
            byte[] requestBuffer = Encoding.UTF8.GetBytes(request);
            //发送指令
            clientSocket.Send(requestBuffer);
            //创建一个接收数组
            byte[] responseBuffer = new byte[1024 * 1024];
            //int接收数据大小
            int bytesRead = clientSocket.Receive(responseBuffer);
            //string方式获取文件信息
            string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
            //根据C:分割
            string[] paths = response.Split(new[] { "C:" }, StringSplitOptions.RemoveEmptyEntries);
            //遍历
            foreach (string path in paths)
            {
                //给这些值添加地址
                lb_file.Items.Add("C:" + path);
            }
        }

        private void lb_file_SelectedIndexChanged(object sender, EventArgs e)
        {
            //判断不为空防止异常
            if (lb_file.SelectedItem != null)
            {
                //获取选择的值
                string selectedItemText = lb_file.SelectedItem.ToString();
                //传给textbox
                txt_download.Text = selectedItemText.ToString();
                //获取文件名
                string filePath = txt_download.Text.ToString().Trim();
                //绘制图片
                System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                //预览到picturebox
                pic_show.Image = image;
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            //获取文本框中的完整路径
            string fullPath = txt_download.Text;  
            //判断文本框是否为空
            if (fullPath == "")
            {
                MessageBox.Show("The file is empty! Please select a file!", "Message");
            }
            else
            {
                //提取文件名
                string fileName = Path.GetFileName(fullPath.Trim());
                //定义请求方式
                string request = "DOWNLOAD:" + fileName;
                //将请求转换为数组
                byte[] requestBuffer = Encoding.UTF8.GetBytes(request);
                //发送请求
                clientSocket.Send(requestBuffer);
                //创建一个接受数组
                byte[] buffer = new byte[1024 * 1024];
                //传回文件的大小
                int bytesRead = clientSocket.Receive(buffer);
                //16进制分割字符
                string hexData = BitConverter.ToString(buffer, 0, bytesRead).Replace("-", "");
                //限制最大2KB
                hexData = hexData.Substring(0, Math.Min(hexData.Length, 2048));
                //读取第一个位的source
                byte source = buffer[0];
                //减去第一位
                byte[] fileContent = new byte[bytesRead - 1];
                //复制数组
                Array.Copy(buffer, 1, fileContent, 0, bytesRead - 1);
                //从缓存中获取的数据
                if (source == 1)
                {
                    //开启数据流
                    MemoryStream ms = new MemoryStream(fileContent);
                    //绘制数据
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    //保存地址
                    string _Save = Path.Combine("C:\\", "Client_Download");
                    //如果目录不存在
                    if (!Directory.Exists(_Save))
                    {
                        //创建目录
                        Directory.CreateDirectory(_Save);
                    }
                    //保存地址-创建后使用
                    string _Path = Path.Combine(@"C:\Client_Download", fileName);
                    //保存为png
                    image.Save(_Path, System.Drawing.Imaging.ImageFormat.Png);
                    //获取文件大小
                    double fileSize = new FileInfo(_Path).Length;
                    //传回的缓存数据大小
                    double back = Convert.ToDouble(bytesRead);
                    //得到由缓存构筑的大小
                    double result = (back / fileSize) * 100;
                    //只留整数位
                    int roundedInt = (int)Math.Round(result, 0);
                    //添加日志
                    AddLog(fileName, roundedInt);
                    MessageBox.Show("Download from cache!The download location is:C:\\Client_Download", "Message");
                }
                //从磁盘中获取的数据
                else
                {
                    //开启数据流
                    MemoryStream ms = new MemoryStream(fileContent);
                    //绘制数据
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    //保存地址
                    string _Save = Path.Combine("C:\\", "Client_Download_Disk");
                    //如果目录不存在
                    if (!Directory.Exists(_Save))
                    {
                        //创建目录
                        Directory.CreateDirectory(_Save);
                    }
                    //保存地址-创建后使用
                    string _Path = Path.Combine(@"C:\Client_Download_Disk", fileName);
                    //保存为png
                    image.Save(_Path, System.Drawing.Imaging.ImageFormat.Png);
                    //添加日志，此处直接传入0，因为一个数据不由缓存构成从磁盘读取那么构筑他的缓存就是0
                    AddLog(fileName, 0);
                    //添加缓存的数据
                    lb_data.Items.Add(hexData);
                    MessageBox.Show("The file was downloaded from disk and cached!The download location is:C:\\Client_Download_Disk", "Message");
                }
            }
        }


        public void AddLog(string name, int result)
        {
            // 获取当前日期和时间，用于日志时间戳
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 构建日志字符串
            string logMessage = $"用户请求：文件{name}在{timeStamp:HH:mm:ss yyyy-MM-dd}。\n响应。{result}%的文件{name}是用缓存的数据构建的。";
            // 将日志写入文件
            string logPath = (Application.StartupPath + "\\Cache\\log.txt");
            //使用数据流写入log
            using (StreamWriter writer = File.AppendText(logPath))
            {
                //写入
                writer.WriteLine(logMessage);
                //缓存列表添加
                lb_cache.Items.Add(logMessage);
            }
            // 从文件中读取日志，仅保留最新的 20 条
            string[] lines = File.ReadAllLines(logPath);
            if (lines.Length > 20)
            {
                //删除20条
                string[] latestLines = lines.Skip(lines.Length - 20).ToArray();
                File.WriteAllLines(logPath, latestLines, Encoding.UTF8);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //listbox清空
            lb_data.Items.Clear();
            //传给服务器CLEAR指令
            string request = "CLEAR";
            //用byte[]形式传
            byte[] requestBuffer = Encoding.UTF8.GetBytes(request);
            //发送
            clientSocket.Send(requestBuffer);
            //清空
            lb_data.Items.Clear();
        }
    }
}
