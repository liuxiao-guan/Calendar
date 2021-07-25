namespace WritingIsWorthy
{
    partial class NoteWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteWin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.替换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动换行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于记事本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Note = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.格式ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.新窗口ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            resources.ApplyResources(this.新建ToolStripMenuItem, "新建ToolStripMenuItem");
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 新窗口ToolStripMenuItem
            // 
            this.新窗口ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.新窗口ToolStripMenuItem.Name = "新窗口ToolStripMenuItem";
            resources.ApplyResources(this.新窗口ToolStripMenuItem, "新窗口ToolStripMenuItem");
            this.新窗口ToolStripMenuItem.Click += new System.EventHandler(this.新窗口ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            resources.ApplyResources(this.打开ToolStripMenuItem, "打开ToolStripMenuItem");
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            resources.ApplyResources(this.保存ToolStripMenuItem, "保存ToolStripMenuItem");
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            resources.ApplyResources(this.另存为ToolStripMenuItem, "另存为ToolStripMenuItem");
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            resources.ApplyResources(this.退出ToolStripMenuItem, "退出ToolStripMenuItem");
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.剪切ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.替换ToolStripMenuItem,
            this.撤销ToolStripMenuItem,
            this.全选ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            resources.ApplyResources(this.编辑ToolStripMenuItem, "编辑ToolStripMenuItem");
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            resources.ApplyResources(this.剪切ToolStripMenuItem, "剪切ToolStripMenuItem");
            this.剪切ToolStripMenuItem.Click += new System.EventHandler(this.剪切ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            resources.ApplyResources(this.复制ToolStripMenuItem, "复制ToolStripMenuItem");
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            resources.ApplyResources(this.粘贴ToolStripMenuItem, "粘贴ToolStripMenuItem");
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            resources.ApplyResources(this.删除ToolStripMenuItem, "删除ToolStripMenuItem");
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 替换ToolStripMenuItem
            // 
            this.替换ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.替换ToolStripMenuItem.Name = "替换ToolStripMenuItem";
            resources.ApplyResources(this.替换ToolStripMenuItem, "替换ToolStripMenuItem");
            this.替换ToolStripMenuItem.Click += new System.EventHandler(this.替换ToolStripMenuItem_Click);
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            resources.ApplyResources(this.撤销ToolStripMenuItem, "撤销ToolStripMenuItem");
            this.撤销ToolStripMenuItem.Click += new System.EventHandler(this.撤销ToolStripMenuItem_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            resources.ApplyResources(this.全选ToolStripMenuItem, "全选ToolStripMenuItem");
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 格式ToolStripMenuItem
            // 
            this.格式ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.格式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动换行ToolStripMenuItem,
            this.字体ToolStripMenuItem,
            this.颜色ToolStripMenuItem});
            this.格式ToolStripMenuItem.Name = "格式ToolStripMenuItem";
            resources.ApplyResources(this.格式ToolStripMenuItem, "格式ToolStripMenuItem");
            // 
            // 自动换行ToolStripMenuItem
            // 
            this.自动换行ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.自动换行ToolStripMenuItem.Checked = true;
            this.自动换行ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.自动换行ToolStripMenuItem.Name = "自动换行ToolStripMenuItem";
            resources.ApplyResources(this.自动换行ToolStripMenuItem, "自动换行ToolStripMenuItem");
            this.自动换行ToolStripMenuItem.Click += new System.EventHandler(this.自动换行ToolStripMenuItem_Click);
            // 
            // 字体ToolStripMenuItem
            // 
            this.字体ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.字体ToolStripMenuItem.Name = "字体ToolStripMenuItem";
            resources.ApplyResources(this.字体ToolStripMenuItem, "字体ToolStripMenuItem");
            this.字体ToolStripMenuItem.Click += new System.EventHandler(this.字体ToolStripMenuItem_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.状态栏ToolStripMenuItem});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            resources.ApplyResources(this.查看ToolStripMenuItem, "查看ToolStripMenuItem");
            // 
            // 状态栏ToolStripMenuItem
            // 
            this.状态栏ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.状态栏ToolStripMenuItem.Checked = true;
            this.状态栏ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.状态栏ToolStripMenuItem.Name = "状态栏ToolStripMenuItem";
            resources.ApplyResources(this.状态栏ToolStripMenuItem, "状态栏ToolStripMenuItem");
            this.状态栏ToolStripMenuItem.Click += new System.EventHandler(this.状态栏ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于记事本ToolStripMenuItem,
            this.查看帮助ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            resources.ApplyResources(this.帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
            // 
            // 关于记事本ToolStripMenuItem
            // 
            this.关于记事本ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.关于记事本ToolStripMenuItem.Name = "关于记事本ToolStripMenuItem";
            resources.ApplyResources(this.关于记事本ToolStripMenuItem, "关于记事本ToolStripMenuItem");
            this.关于记事本ToolStripMenuItem.Click += new System.EventHandler(this.关于记事本ToolStripMenuItem_Click);
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            resources.ApplyResources(this.查看帮助ToolStripMenuItem, "查看帮助ToolStripMenuItem");
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // Note
            // 
            resources.ApplyResources(this.Note, "Note");
            this.Note.BackColor = System.Drawing.Color.Linen;
            this.Note.HideSelection = false;
            this.Note.Name = "Note";
            this.Note.TextChanged += new System.EventHandler(this.Note_TextChanged);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // 颜色ToolStripMenuItem
            // 
            this.颜色ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.颜色ToolStripMenuItem.Name = "颜色ToolStripMenuItem";
            resources.ApplyResources(this.颜色ToolStripMenuItem, "颜色ToolStripMenuItem");
            this.颜色ToolStripMenuItem.Click += new System.EventHandler(this.颜色ToolStripMenuItem_Click);
            // 
            // NoteWin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NoteWin";
            this.Load += new System.EventHandler(this.NoteWin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NoteWin_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Note;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 替换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动换行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 状态栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于记事本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 颜色ToolStripMenuItem;
    }
}