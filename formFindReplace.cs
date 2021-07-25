using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WritingIsWorthy
{
    public partial class formFindReplace : Form
    {
        NoteWin mainForm1;
        public formFindReplace(NoteWin form1)         //为原来的构造函数新增一个Form1参数
        {
            InitializeComponent();
            mainForm1 = form1;                      //form1是主窗体属性的Name值
            //form1 class用函数参数传过来，之后便可以调用其相应的方法
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //查找下一个字符串按钮响应
            if (textBox1.Text.Length != 0)
            {
                //查找字符串不为空，调用主窗体的查找方法
                mainForm1.FindRichTextBoxString(textBox1.Text);
            }
            else
            {
                MessageBox.Show("查找的字符串不能为空", "提示", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //替换字符串按钮响应
            if (textBox1.Text.Length != 0)
            {
                //查找字符串不为空，调用主窗体中的替换函数
                mainForm1.ReplaceRichTextBoxString(textBox1.Text, textBox2.Text);
            }
            else
            {
                MessageBox.Show("替换字符串不能为空", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 记事本查找与替换子窗体功能实现代码
        /// </summary>
        /// <param name="..."></param>
        /// <param name="..."></param>



    }
}
