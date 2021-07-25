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


namespace WritingIsWorthy
{
    public partial class NoteWin : Form
    {
        public NoteWin()
        {
            InitializeComponent();
          
        }
        FirInterface FirInterface = new FirInterface();
        private void NoteWin_Load(object sender, EventArgs e)
        {
            
            this.Text = "无标题 - 记事本";
           toolStripStatusLabel1.Text = "欢迎使用记事本；";
            FirInterface.TopLevel = false;

        }
        bool IsSave = false;//文件是否保存的标志
        string filename = "";//文件名初始化为空的
        //int TextChangeKey = 0;//文件是否改动过的标志
        int findposition = 0;
        //返回主界面
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
        #region 文件菜单
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //判断richbox是否为空，空则默认，非空则询问是否保存
            if (Note.Text != "" )
            {
                
                if (this.Text != "*无标题 - 记事本" && IsSave == false)
                {
                    DialogResult dialogResult = new DialogResult();
                    dialogResult = MessageBox.Show("是否保存当前文件", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dialogResult != DialogResult.Cancel)
                    {
                        if (dialogResult == DialogResult.Yes)
                        {
                            Note.SaveFile(filename, RichTextBoxStreamType.PlainText);
                            IsSave = true;

                        }
                        //无论是否保存，文本框都要清空以及窗口名要变
                        this.Text = Path.GetFileName(filename) + " - 记事本";
                    }
                }
                else if (IsSave == false || this.Text == "*无标题 - 记事本")
                {
                   
                    DialogResult dialogResult = new DialogResult();
                    dialogResult = MessageBox.Show("是否保存当前文件", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dialogResult != DialogResult.Cancel)
                    {
                        if (dialogResult == DialogResult.Yes)
                        {
                            savefile();

                        }
                        //无论是否保存，文本框都要清空以及窗口名要变
                        
                    }

                }
                this.Text = "无标题 - 记事本";
                //this.Close();
                //noteWin1.Show();
                Note.Clear();

            }
            

        }

        private void 新窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteWin noteWin1 = new NoteWin();
            noteWin1.Show();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Note.Text != "")
            {
                
                //已存在未保存
                if (this.Text != "*无标题 - 记事本" && IsSave == false)
                {
                    DialogResult dialogResult = new DialogResult();
                    dialogResult = MessageBox.Show("是否保存当前文件", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dialogResult != DialogResult.Cancel)
                    {
                        if (dialogResult == DialogResult.Yes)
                        {
                            Note.SaveFile(filename, RichTextBoxStreamType.PlainText);
                            IsSave = true;

                        }
                        //无论是否保存，文本框都要清空以及窗口名要变
                        this.Text = Path.GetFileName(filename) + " - 记事本";
                    }
                }
                else if (IsSave == false || this.Text == "*无标题 - 记事本")
                {

                    DialogResult dialogResult = new DialogResult();
                    dialogResult = MessageBox.Show("是否保存当前文件", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (dialogResult != DialogResult.Cancel)
                    {
                        if (dialogResult == DialogResult.Yes)
                        {
                            savefile();

                        }
                       

                    }

                }
                this.Text = "无标题 - 记事本";
                //this.Close();
                //noteWin1.Show();
                Note.Clear();

            }
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "请选择要打开的文档；";
                openFileDialog1.Filter = "文本文档|*.txt";
                openFileDialog1.InitialDirectory = Application.StartupPath;//设置初始文件夹，要不然会默认存储在文档处
                                                                           //openFileDialog1.FileName = "File";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream fsRead = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                    byte[] buffer = new byte[fsRead.Length];//缓冲区作为文件流与用户界面的媒介
                    fsRead.Read(buffer, 0, buffer.Length);
                    //注意编码格式，要不然会有乱码
                    Note.Text = System.Text.Encoding.Default.GetString(buffer);

                    fsRead.Close();
                    IsSave = true;
                    filename = openFileDialog1.FileName;
                    this.Text = Path.GetFileName(filename);
                }
            }
            catch(FileNotFoundException error)
            {
                MessageBox.Show("文件不存在", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
                            
        }

        
        //对于打开文件修改后的保存
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)

        {
            //要考虑两种情况，一种完全新文件的保存，另一种是旧文件修改的保存
            if (this.Text == "*无标题 - 记事本" || this.Text == "无标题 - 记事本")

            {
                savefile();//要弹出对话框  
                
            }
            else
            {
                
            
                Note.SaveFile(filename, RichTextBoxStreamType.PlainText);
                IsSave = true;
            }
            this.Text = Path.GetFileName(filename) + " - 记事本";

        }
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
            this.Text = Path.GetFileName(filename);

        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
             this.Hide();
        }
        #endregion

        #region 文件编辑

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Note.SelectedText != "")
            {
                Note.Cut();
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Note.SelectedText !="")
            {
                Note.Copy();
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note.Paste();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Note.SelectedText != "")
            {
                Note.SelectedText = "";
            }
        }

        //查找，替换
        public void FindRichTextBoxString(string findString)
        {
            //查询语句代码实现
            if (findposition >= Note.Text.Length)
            {
                //已经查找到文本底部，弹出用户提示
                MessageBox.Show("已到文本底部，再次查找将回到顶部", "提示", MessageBoxButtons.OK);
                findposition = 0;
                return;
            }
            /* 
             * 下面的代码进行查找并返回找到的位置，如果未找到则返回-1
             * 参数1是待找的字符串，参数2是查找的开始位置，参数3是查找的
             * 选项，如大小写是否匹配、查找方向等。
             */
            findposition = Note.Find(findString, findposition,
                RichTextBoxFinds.MatchCase);
            if (-1 == findposition)
            {
                //未找到，弹出用户提示
                MessageBox.Show("已到文本底部，再次查找将回到顶部", "提示", MessageBoxButtons.OK);
                findposition = 0;
            }
            else
            {
                //成功匹配到查找的字符串
                Note.Focus();                               //主窗体获得字符串焦点
                findposition += findString.Length;                  //更新查找位置到当前查找的到的字符串处
            }
        }
        public void ReplaceRichTextBoxString(string findString, string replaceString)
        {
            //替换字符串代码实现
            if (Note.SelectedText.Length != 0)
            {
                //文本框内选中的子串存在，执行替换
                Note.SelectedText = replaceString;
            }
        }

        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //查找和替换选项响应函数
            findposition = 0;
            //创建一个查找和替换窗体对象并基于当前窗体类型this作为参数
            formFindReplace FindReplaceDialog = new formFindReplace(this);
            FindReplaceDialog.Show();                                  //使用Show打开非模式对话框                                  
        }
        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note.Undo();
        }
        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note.SelectAll();
        }
        #endregion
        #region 文件格式
        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Note.WordWrap == true)
            {
                Note.WordWrap = false;
                自动换行ToolStripMenuItem.Checked = false;

            }
            else
            {
                Note.WordWrap = true;
                自动换行ToolStripMenuItem.Checked = false;
            }

        }
        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            Note.Font = fontDialog.Font;
        }
        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            Note.ForeColor = colorDialog.Color;
        }
        #endregion
        #region 文件查看
        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                状态栏ToolStripMenuItem.Checked = false;
                statusStrip1.Visible = false;
            }
            else
            {
                状态栏ToolStripMenuItem.Checked = true;
                statusStrip1.Visible = true;
            }
        }

        #endregion
        #region 文件帮助
        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://answers.microsoft.com/en-us/windows/forum/apps_windows_10");
        }
        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox messageBox = new MessageBox
            FormAbout formAbout = new FormAbout();
            formAbout.Show();
        }

        #endregion

        //当文件内容有所更改时，窗口文件头的改变

        private void Note_TextChanged(object sender, EventArgs e)
        {
            IsSave = false;
            
            string OldTitle = this.Text.Replace("*",string.Empty);
            
            this.Text = "*" + OldTitle;
           
            
        }

        
        void savefile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "请保存你的文件";
            saveFileDialog.Filter = "文本文件| *.txt";

            //file.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Application.StartupPath;
            

            if (saveFileDialog.ShowDialog() == DialogResult.OK )
            {

                
                //要先判断用户是否确认保存
                using (FileStream fsWrite1 = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    
                    byte[] buffer = Encoding.Default.GetBytes(Note.Text);
                    fsWrite1.Write(buffer, 0, buffer.Length);
                    fsWrite1.Close();
                    MessageBox.Show("保存成功");

                }
                IsSave = true;

                filename = saveFileDialog.FileName;
                
            }
            
        }

//绘画记事本
        private void NoteWin_Paint(object sender, PaintEventArgs e)
        {
            Graphics gra = this.CreateGraphics();
            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Green);
            Brush bush = new SolidBrush(Color.Green);//填充的颜色
            gra.FillEllipse(bush, 30, 10, 17, 17);//画填充椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
            gra.FillEllipse(bush, 100, 10, 17, 17);
            gra.FillEllipse(bush, 170, 10, 17, 17);
            gra.FillEllipse(bush, 240, 10, 17, 17);
            gra.FillEllipse(bush, 310, 10, 17, 17);
            gra.FillEllipse(bush, 380, 10, 17, 17);
            gra.FillEllipse(bush, 450, 10, 17, 17);
            gra.DrawLine(pen, 0, 50, 30, 0);
            gra.DrawLine(pen, 0, 40, 20, 0);
            gra.DrawLine(pen, 640, 653, 679, 613);//679 653
            gra.DrawLine(pen, 660, 653, 679, 633);//679 653
        }
    }
}
