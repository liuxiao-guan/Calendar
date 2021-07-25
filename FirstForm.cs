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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CalWin calWin;
        NoteWin noteWin;
        FirInterface FirInterface;
        //Form1 form = new Form1();
        private void Form1_Load(object sender, EventArgs e)
        {
            calWin = new CalWin();
            noteWin = new NoteWin();
            FirInterface = new FirInterface();

            //其中在属性中也将FormBorderStyle改为none
            calWin.TopLevel = false;//取消窗体为顶级控件的属性，使之可以放置于panel中
            noteWin.TopLevel = false;
            FirInterface.TopLevel = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calWin.Show();
            panel2.Controls.Clear();    //清空原容器上的控件
            panel2.Controls.Add(calWin);    //将窗体一加入容器panel2
        }

        private void button2_Click(object sender, EventArgs e)
        {
            noteWin.Show();
            panel2.Controls.Clear();    //清空原容器上的控件
            panel2.Controls.Add(noteWin);    //将窗体一加入容器panel2
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FirInterface.Show();
            panel2.Controls.Clear();    //清空原容器上的控件
            panel2.Controls.Add(FirInterface);    //将窗体一加入容器panel2
        }
    }
}
