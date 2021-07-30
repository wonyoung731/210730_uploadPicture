using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _20210729_piceditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button2.Click += button2_Click;
            this.button3.Click += button3_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                string textBox2 = fbd.SelectedPath;

                this.listBox1.Refresh();

                DirectoryInfo di = new DirectoryInfo(textBox2);

                if (di.Exists == true)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FileName", typeof(string));
                    dt.Columns.Add("FullName", typeof(string));


                    DataRow ds = null;

                    foreach (FileInfo file in di.GetFiles())
                    {
                        ds = dt.NewRow();
                        ds["FileName"] = file.Name.Substring(0, file.Name.Length - 4);
                        ds["FullName"] = file.FullName;
                        dt.Rows.Add(ds);
                    }
                 //   fbd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"

                    listBox1.DataSource = dt;
                    listBox1.ValueMember = "FullName";
                    listBox1.DisplayMember = "FileName";

                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if(listBox1.SelectedItem != null)
            //{
            //    textBox3.Text = listBox1.SelectedItem.ToString();
            //    DataRow ds = null;
            //}

            DataRowView drv = (DataRowView)listBox1.SelectedItem;
            textBox3.Text = drv["FullName"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //   this.textBox3.Text = System.IO.Directory.GetCurrentDirectory();
            //   this.pictureBox1.Image{ }
            pictureBox1.ImageLocation = textBox3.Text;
            
        }
    }
}

