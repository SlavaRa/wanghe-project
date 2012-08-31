using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net;

namespace LightingClick
{
    public partial class MainFrm : Form
    {
        MySign mysign;
        MyServer myserver;
        Thread t;

        public delegate void dd();
        public MainFrm()
        {
            mysign=new MySign();
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_port.Text == null || txt_port.Text.Length == 0)
                {
                    MessageBox.Show("端口不能为空！", "提示");
                }

                int port = Int32.Parse(txt_port.Text);

                mysign.sign = true;
                myserver = new MyServer(port, mysign);
                myserver.AndSocketReceived += new MyServer.AndSocketEventHandler(myserver_AndSocketReceived);
                t = new Thread(new ThreadStart(myserver.StartListen));
                t.IsBackground = true;
                t.Start();

                lb_state.Text = "服务状态：开启";
                rtxt_log.AppendText("服务状态：开启");
                btn_start.Enabled = false;
                btn_stop.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void myserver_AndSocketReceived(object sender, AndSocketEventArgs e)
        {
            dd a = delegate()
            {
                rtxt_log.AppendText(Environment.NewLine);
                rtxt_log.AppendText(e.info);
            };
            rtxt_log.Invoke(a);

            if (e.info.StartsWith("SHUT_DOWN;"))
            {
                String tip=e.info.Split(';')[1];
                IPAddress[] ips = Utils.GetIPs();

                foreach (IPAddress ip in ips)
                {
                    if(ip.ToString()==tip)
                        ShowDownWindow();
                }
            }
            
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if(mysign!=null&&t!=null)
            {
                t.Abort();
                myserver.StopListen();
                mysign.sign = false;
                lb_state.Text = "服务状态：关闭";
                btn_stop.Enabled = false;
                btn_start.Enabled = true;
            }
        }



        /// <summary>
        /// 关机
        /// </summary>
        private void ShowDownWindow()
        {
            System.Diagnostics.Process process = new Process();
            //StartInfo获取或设置要传递给Process的Start方法的属性.为ProcessStartInfo类型
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;//设置UseShellExecute以指定是否使用操作系统外壳程序启动进程
            process.StartInfo.RedirectStandardInput = true;//使进程从文件或其他设备获取输入
            process.StartInfo.RedirectStandardOutput = true;//向文件或其他设备返回输出
            process.StartInfo.CreateNoWindow = true;
            process.Start();//开始进程
            process.StandardInput.WriteLine("shutdown -s -t 0");//给命令行传入关机命令
            process.StandardInput.WriteLine("exit");
            process.Close();
        }


        /// <summary>
        /// 验证字符串是否为IP地址
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private bool FoundMatch(string txt)
        {
            try
            {
                return Regex.IsMatch(txt, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }
}
