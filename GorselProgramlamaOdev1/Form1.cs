using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselProgramlamaOdev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string text;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var text = File.ReadAllText(dialog.FileName);
                this.text = text;
                richTextBox1.Text = text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            richTextBox1.Text = richTextBox1.Text.ToString();
            string text = textBox1.Text;
            if (text.Length == 0)
            {
                return;
            }

            int i = 0;
            int found = 0;
            while (i < richTextBox1.TextLength)
            {
                int start = richTextBox1.Find(text, i, checkBox1.Checked ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None);
                if (start != -1)
                {
                    richTextBox1.SelectionStart = start;
                    richTextBox1.SelectionLength = text.Length;
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    i += start + text.Length;
                    found++;
                }
                else
                {
                    break;
                }
            }
            label1.Text = found + " adet sonuç bulundu!";
        }
    }
}
