using System;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace txtCombine
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                listFiles.Items.Clear();
                string[] files = openFileDialog1.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listFiles.Items.Add(files[i]);
                }
            }
        }

        private void btnSelectOneFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listFiles.Items.Add(openFileDialog1.FileName);
            }
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFiles.SelectedItem!=null)
                toolTip1.SetToolTip(listFiles, listFiles.SelectedItem.ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listFiles.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listFiles.Items.Count!=0&&listFiles.SelectedItem!=null)
            {
                listFiles.Items.Remove(listFiles.SelectedItem);
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int lbxLength = this.listFiles.Items.Count;  
            int iselect = this.listFiles.SelectedIndex;
            if (lbxLength > iselect && iselect > 0)
            {
                object oTempItem = this.listFiles.SelectedItem;
                this.listFiles.Items.RemoveAt(iselect);
                this.listFiles.Items.Insert(iselect - 1, oTempItem);
                this.listFiles.SelectedIndex = iselect - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int lbxLength = this.listFiles.Items.Count;
            int iselect = this.listFiles.SelectedIndex;
            if (lbxLength > iselect && iselect < lbxLength - 1)
            {
                object oTempItem = this.listFiles.SelectedItem;
                this.listFiles.Items.RemoveAt(iselect);
                this.listFiles.Items.Insert(iselect + 1, oTempItem);
                this.listFiles.SelectedIndex = iselect + 1;
            }   
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CombineFiles(saveFileDialog1.FileName);
            }
        }

        private void CombineFiles(string destFile)
        {
            if (listFiles.Items.Count == 0||listFiles.Items.Count == 1)
            {
                MessageBox.Show("请选择最少2个文件","提示");
                return;
            }

            File.WriteAllText(destFile, "", Encoding.Default);
            

            for (int i = 0; i < listFiles.Items.Count; i++)
            {
                string s = File.ReadAllText(listFiles.Items[i].ToString(),Encoding.Default);
                File.AppendAllText(destFile, "\n", Encoding.Default);
                File.AppendAllText(destFile, s, Encoding.Default);
            }
            MessageBox.Show("OK");
        }
    }
}
