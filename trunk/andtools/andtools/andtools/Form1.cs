using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace andtools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择apk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnselapk_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                _txtapk.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// 选择反编译结果的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _savepath_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                _txtsavepath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnref_Click(object sender, EventArgs e)
        {
            string strapk = string.Empty;
            string strpath = string.Empty;

            if (_txtapk.Text.Length != 0 && _txtapk.Text != "" && File.Exists(_txtapk.Text) && _txtapk.Text.EndsWith(".apk"))
            {
                strapk = _txtapk.Text;
            }
            else
            {
                MessageBox.Show("请选择APK文件!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (_txtsavepath.Text.Length != 0 && _txtsavepath.Text != "")
            {
                strpath = _txtsavepath.Text;
            }
            else
            {
                MessageBox.Show("请选择保存路径!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //反编译
            string[] args = new string[4];
            args[0] = "d";
            args[1] = "-f";
            args[2] = strapk;
            args[3] = strpath;
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "apktool.bat";
            if (StartProcess(path, args))
            {
                _lbinfo.Text = "完成！";
                MessageBox.Show("完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 参数启动
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool StartProcess(string filename, string[] args)
        {
            try
            {
                string s = "";
                foreach (string arg in args)
                {
                    s = s + arg + " ";
                }
                s = s.Trim();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.WorkingDirectory = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                startInfo.FileName = filename;
                startInfo.Arguments = s;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;

                Process myprocess = Process.Start(startInfo);

                myprocess.WaitForExit();
                myprocess.Close();



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error：" + ex.Message);
            }
            return false;
        }

        private void _btnopenpath_Click(object sender, EventArgs e)
        {
            if (_txtsavepath.Text.Length == 0) return;
            System.Diagnostics.Process.Start("explorer.exe",_txtsavepath.Text);
        }

        /// <summary>
        /// 选择源代码的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnselbuildpath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _txtbuildpath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// 选择apk保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnbuildspkpath_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _txtbuildapkpath.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// 签名APK保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnsavesignapk_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _txtsignapk.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// 编译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnbuild_Click(object sender, EventArgs e)
        {
            string strapk = string.Empty;
            string strpath = string.Empty;


            if (_txtbuildpath.Text.Length != 0 && _txtbuildpath.Text != "")
            {
                strpath = _txtbuildpath.Text;
            }
            else
            {
                MessageBox.Show("请选择源码路径!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (_txtbuildapkpath.Text.Length != 0 && _txtbuildapkpath.Text != "" && _txtbuildapkpath.Text.EndsWith(".apk"))
            {
                strapk = _txtbuildapkpath.Text;
            }
            else
            {
                MessageBox.Show("请选择APK保存路径!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] args = new string[4];
            args[0] = "b";
            args[1] = "-f";
            args[2] = strpath;
            args[3] = strapk;
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "apktool.bat";
            if (StartProcess(path, args))
            {
                _lbinfo2.Text = "完成！";
                MessageBox.Show("编译成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnsign_Click(object sender, EventArgs e)
        {
            string strapk = string.Empty;
            string strsignapk = string.Empty;

            if (_txtbuildapkpath.Text.Length != 0 && _txtbuildapkpath.Text != "" && _txtbuildapkpath.Text.EndsWith(".apk"))
            {
                strapk = _txtbuildapkpath.Text;
            }
            else
            {
                MessageBox.Show("请选择未签名APK路径!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_txtsignapk.Text.Length != 0 && _txtsignapk.Text != "" && _txtsignapk.Text.EndsWith(".apk"))
            {
                strsignapk = _txtsignapk.Text;
            }
            else
            {
                MessageBox.Show("请选择签名APK保存路径!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] args = new string[6];
            args[0] = "-jar";
            args[1] = "signapk.jar";
            args[2] = "testkey.x509.pem";
            args[3] = "testkey.pk8";

            args[4] = strapk;
            args[5] = strsignapk;

            string path = "java";

            if (StartProcess(path, args))
            {
                _lbinfo2.Text = "完成！";
                MessageBox.Show("签名成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void _btnopenapk_Click(object sender, EventArgs e)
        {
            if (_txtsignapk.Text.Length == 0) return;
            FileInfo fi = new FileInfo(_txtsignapk.Text);
            System.Diagnostics.Process.Start("explorer.exe", fi.DirectoryName);
        }
    }
}
