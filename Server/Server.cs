using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace Server
{
    public partial class F_Server : Form
    {
        //服务器文件目录
        public static string Server_rootDirectory;
        //客户端服务文件目录
        public static string Client_rootDirectory;

        //主体程序
        public F_Server()
        {
            InitializeComponent();
            //设置输入格式为*
            txt_pass.PasswordChar = '*';
            //设置根目录为程序文件夹下的Server_Files文件夹
            Server_rootDirectory = Path.Combine(Application.StartupPath, "Server_Files");
            //设置根目录为程序文件夹下的Client_Files文件夹
            Client_rootDirectory = Path.Combine(Application.StartupPath, "Client_Files");
            //如果目录不存在
            if (!Directory.Exists(Server_rootDirectory) || !Directory.Exists(Client_rootDirectory))
            {
                //创建目录
                Directory.CreateDirectory(Server_rootDirectory);
                Directory.CreateDirectory(Client_rootDirectory);
            }
        }

        //监听线程
        public void workthread()
        {  //设置IP为本机127.0.0.1IP，端口为8888
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8686);
            //创建服务器socket对象
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //绑定这个IP及端口
                serverSocket.Bind(ipEndPoint);
                //设置最大监听个数1
                serverSocket.Listen(1);
                //满足条件会一直监听
                while (true)
                {
                    //创建一个客户端接收
                    Socket clientSocket = serverSocket.Accept();
                    //创建一个新的缓存器
                    CacheBuffer cacheBuffer = new CacheBuffer();
                    //创建一个ClientHandler类
                    ClientHandler clientHandler = new ClientHandler(clientSocket, cacheBuffer);
                    //开始运行
                    clientHandler.Start();
                }
            }
            //捕捉异常
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //启动服务器
        private void btn_Server_Start_Click(object sender, EventArgs e)
        {
            lbl_Server.Text = "Current Status: Starting";
            btn_Server_Start.Text = "Shut down the service";
            btn_Server_Start.Enabled = false;
            MessageBox.Show("To prevent exceptions, to shut down the service, close the window and enter the administrator password to exit the server!！", "Message");
            //开启一个新线程防止组织GUI页面的正常运行
            Thread work = new Thread(workthread);
            //开启线程
            work.Start();
        }

        //加载事刷新文件目录
        private void F_Server_Load(object sender, EventArgs e)
        {
            //服务目录刷新按钮
            btn_Srefresh_Click(sender, e);
            //客户目录刷新按钮
            btn_Crefresh_Click(sender, e);
        }

        //关闭时需要输入密码-123456
        private void F_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            lbl_warning.Text = "You must enter a password.";
            if (txt_pass.Text == "123456")
                e.Cancel = false;
        }

        //服务器端下载文件
        private void btn_download_Click(object sender, EventArgs e)
        {
            //获取文本框中的完整路径
            string fullPath = txt_file.Text;  
            //判断文本框是否为空
            if (fullPath == "")
            {
                MessageBox.Show("The file is empty! Please select a file!", "Message");
            }
            else
            {
                // 提取文件名
                string fileName = Path.GetFileName(fullPath);  
                //生成一个缓存方法
                CacheBuffer cacheBuffer = new CacheBuffer();
                //先访问服务器的文件夹地址
                string filePath = Path.Combine(Server_rootDirectory, fileName);
                //如果缓存中存在这个文件名
                if (cacheBuffer.Exsits(fileName))
                {
                    //从缓存中读取
                    byte[] Cache_Save = File.ReadAllBytes(filePath);
                    //打开数据流获取缓存中数据
                    MemoryStream ms = new MemoryStream(Cache_Save);
                    //利用Image绘制这个数据
                    Image image = Image.FromStream(ms);
                    //保存地址-创建前使用
                    string _Save = Path.Combine("C:\\", "Server_Download");
                    //如果目录不存在
                    if (!Directory.Exists(_Save))
                    {
                        //创建目录
                        Directory.CreateDirectory(_Save);
                    }
                    //保存地址-创建后使用
                    string _Path = Path.Combine(@"C:\Server_Download", fileName);

                    //保存图片
                    image.Save(_Path, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Download from cache!The download location is:C:\\Server_Download", "Message");
                }
                else
                {
                    //保存地址-创建前使用
                    string _Save = Path.Combine("C:\\", "Server_Download_Disk");
                    if (!Directory.Exists(_Save))
                    {
                        //创建目录
                        Directory.CreateDirectory(_Save);
                    }
                    string _Path = Path.Combine(@"C:\Server_Download_Disk", fileName);
                    try
                    {
                        //通过磁盘复制到新的路径
                        File.Copy(filePath, _Path);
                        //转换成二进制
                        byte[] fileContent = File.ReadAllBytes(filePath);
                        //转换后保存到缓存中
                        cacheBuffer.SetFileContent(fileName, fileContent);
                        MessageBox.Show("The file was downloaded from disk and cached!The download location is:C:\\Server_Download_Disk", "Message");
                    }
                    catch
                    {
                        MessageBox.Show("File already exists", "Message");
                    }
                }
            }
        }

        //服务器添加文件
        private void btn_Sinsert_Click(object sender, EventArgs e)
        {
            //打开选项框对象
            OpenFileDialog ofd_Server = new OpenFileDialog();
            //打开文件类型
            ofd_Server.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            if (ofd_Server.ShowDialog() == DialogResult.OK)
            {
                //用户选择了一个图片文件
                string filePath = ofd_Server.FileName;
                //添加的目标文件夹
                string targetFolderPath = Server_rootDirectory;
                //获取文件名
                string fileName = System.IO.Path.GetFileName(filePath);
                //添加的文件夹+文件名
                string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);
                try
                {
                    //复制到刚刚的地址
                    File.Copy(filePath, targetFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //消除占用资源
            ofd_Server.Dispose();
            //刷新文件列表
            btn_Srefresh_Click(sender, e);
        }

        //服务器文件夹刷新
        private void btn_Srefresh_Click(object sender, EventArgs e)
        {
            //先清空
            lb_Sshow.Items.Clear();
            //文件夹地址
            string[] Sfiles = Directory.GetFileSystemEntries(Server_rootDirectory);
            //遍历文件夹
            foreach (string dir in Sfiles)
            {
                //添加到listbox列表
                lb_Sshow.Items.Add(dir);
            }
        }

        //客户端添加文件
        private void btn_Cinsert_Click(object sender, EventArgs e)
        {
            //打开选项框对象
            OpenFileDialog ofd_Client = new OpenFileDialog();
            //打开文件类型
            ofd_Client.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            if (ofd_Client.ShowDialog() == DialogResult.OK)
            {
                //用户选择了一个图片文件
                string filePath = ofd_Client.FileName;
                //添加的目标文件夹
                string targetFolderPath = Client_rootDirectory;
                //获取文件名
                string fileName = System.IO.Path.GetFileName(filePath);
                //添加的文件夹+文件名
                string targetFilePath = System.IO.Path.Combine(targetFolderPath, fileName);
                try
                {
                    //复制到刚刚的地址
                    File.Copy(filePath, targetFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //消除占用资源
            ofd_Client.Dispose();
            //刷新文件列表
            btn_Crefresh_Click(sender, e);
        }

        //客户端文件夹刷新
        private void btn_Crefresh_Click(object sender, EventArgs e)
        {
            //先清空
            lb_Cshow.Items.Clear();
            //文件夹地址
            string[] Cfiles = Directory.GetFileSystemEntries(Client_rootDirectory);
            //遍历文件夹
            foreach (string dir in Cfiles)
            {
                //添加到listbox列表
                lb_Cshow.Items.Add(dir);
            }

        }

        //服务器listbox文件夹选择后更改textbox的值
        private void lb_Sshow_SelectedIndexChanged(object sender, EventArgs e)
        {
            //要判断不为null，不然会异常
            if (lb_Sshow.SelectedItem != null)
            {
                //获取当前选取的值
                string selectedItemText = lb_Sshow.SelectedItem.ToString();
                //显示到textbox中
                txt_file.Text = selectedItemText.ToString();
            }
        }

        //密码验证
        private void btn_pass_Click(object sender, EventArgs e)
        {
            if (txt_pass.Text == "123456")
            {
                //找出当前项目的程序名
                Process[] processes = Process.GetProcessesByName("Server");
                foreach (Process process in processes)
                {
                    //杀死进程
                    process.Kill();
                }
                //应用退出
                Application.Exit();
            }
            else
            {
                MessageBox.Show("The password is incorrect!", "Message");
            }
        }
    }
}
