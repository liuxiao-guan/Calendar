using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace WritingIsWorthy
{
    public partial class CalWin : Form
    {
        public CalWin()
        {
            InitializeComponent();
           
        }
        DateTime currentTime =System.DateTime.Now;
        //DateTime currentTime = new DateTime(2100, 3, 5);
         Calendar calendar;
        Calendar calendar1;
        int MonUp = 0;
        int YearUp = 0;
        Panel Panel = new Panel();
        string Weainfo;
       

        private void CalWin_Load(object sender, EventArgs e)
        {
           
            calendar = new Calendar(currentTime);
            calendar1 = new Calendar(currentTime);
            //显示该天的相关信息
            label1.Text =calendar.Year + "年"+" "+ calendar.Month.ToString() + "月" +" "+  calendar.Week_;
            label2.Text = "农历" + "\n"+ calendar.GetHBYear() + "年" + calendar.GetHBMonth()+ "月" + calendar.GetHBDay() + "日";
            label2.Text = calendar.Day.ToString();
            label3.Text = calendar.GetHBYear() +"年"+ " " + "【" + calendar.GetZodiac() +"年" + "】";
            label4.Text = calendar.GetStar();
            label5.Text = calendar.GetConstellation();
            label6.Text = (calendar.GetLunarHoliday() + calendar.GetSolarHoliday() + calendar.GetWeekHoliday()).Replace("无", string.Empty);
            label14.Text = calendar.GetHBMonth() + "月" +" "+ calendar.GetHBDay() + "日";
            label13.Text = calendar.Month.ToString() + "月";
            label15.Text = calendar.Year.ToString() + "年";

            //显示天气
            WritingIsWorthy.cn.com.webxml.www.WeatherWebService w = new WritingIsWorthy.cn.com.webxml.www.WeatherWebService();
            string[] s = new string[23];//声明string数组存放返回结果 
            s = w.getWeatherbyCityName("武汉");
           
            if (s[8] == "")
            {
                MessageBox.Show("暂时不支持您查询的城市");
            }
            else
            {
                //对天气信息进行进行适当地删改
                string snew = s[10].Replace("今日天气实况：", string.Empty);
                string snew1 = snew.Replace("。", string.Empty);
                string snew2 = snew1.Replace("风向/风力", "风况");
                string time = calendar.Month.ToString() + "月" + calendar.Day.ToString() + "日";
                label10.Text = s[1] + " " + s[6].Replace(time, string.Empty) + "\n\n" + snew2.Replace("；", "\n\n");
                
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void CalWin_Paint(object sender, PaintEventArgs e)
        {  
            PaintCal(calendar);
            //绘制一个月

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Font font = new Font("宋体",12);
            graphics.DrawString(Weainfo, font, Brushes.Black, 40, 10);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            Graphics graphics = CreateGraphics();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Font font = new Font("宋体", 12);
            graphics.DrawString(Weainfo, font, Brushes.Black, 400, 10);
        }
        //转换成下一个月
        private void button1_Click_1(object sender, EventArgs e)
        {
            calendar1 = new Calendar(calendar1.dateTime.AddMonths(1));
            PaintCal(calendar1);
            label13.Text = calendar1.Month.ToString() + "月";
            label15.Text = calendar1.Year.ToString() + "年";  
         
        }

        //月份减少
        private void button2_Click(object sender, EventArgs e)
        {
            //MonUp--;
            calendar1 = new Calendar(calendar1.dateTime.AddMonths(-1));
            PaintCal(calendar1);
            label13.Text = calendar1.Month.ToString() + "月";
            label15.Text = calendar1.Year.ToString() + "年";
        }
        //
        private void button3_Click(object sender, EventArgs e)
        {
            MonUp = 0;
            YearUp = 0;
            DateTime dateTime = currentTime.AddMonths(MonUp);
           calendar1 = new Calendar(dateTime.AddYears(YearUp));
            PaintCal(calendar1);
            label13.Text = calendar1.Month.ToString() + "月";
            label15.Text = calendar1.Year.ToString() + "年";
        }
        #region 绘制日历部分
        void PaintCal(Calendar calendar)
        {
            Font font = new Font("微软雅黑", 12);
            Point point = new Point(200, 200);
            Graphics graphics = CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            int WeekDayOfFD = calendar.WeekDayOfFirstDay();//获取第一天是星期几 星期天是0
            string[] LunDayInMonth = calendar.GetLunDayInMon();//获取一个月农历日子
            string[] SolTerInMonth = calendar.GetSolarTermInMon();//获取一个月可能有的节气

            graphics.Clear(Color.FromArgb(255, 224, 192));//需要清掉以前月份的记录
           
            //绘制星期
            string[] Week = { "日", "一", "二", "三", "四", "五", "六" };
            for (int i = 0; i < 7; i++)
            {
                Point point1 = new Point(20 + i * 50, 95);
                graphics.DrawString(Week[i], font, Brushes.Black, point1);

            }
            //绘制当天月份信息
            for (int j = 1; j <= calendar.DaysofMonth(); j++)
            {
                int quotient = (WeekDayOfFD + j - 1) / 7 + 1;//用来判定垂直方向
                int remainder = (WeekDayOfFD + j - 1) % 7;//用来判定水平方向

                Point point2 = new Point(20 + remainder * 50, 70 + quotient * 50);
                Point point3 = new Point(10 + remainder * 50, 90 + quotient * 50);
                Rectangle RecCal = new Rectangle(10 + remainder * 50, 92 + quotient * 50, 43, 43);

                if (j == calendar.Day)
                {
                    Brush bush = new SolidBrush(Color.FromArgb(255, 192, 192));
                    graphics.FillEllipse(bush, 7 + remainder * 50, 69 + quotient * 50, 48, 48);
                }
                if (remainder == 6 || remainder == 0)//如果是周末则要标红
                {
                    graphics.DrawString(j.ToString(), font, Brushes.Red, point2);
                }
                else
                {
                    graphics.DrawString(j.ToString(), font, Brushes.Black, point2);
                }
                //优先级：节气 > 初一 > 普通
                //初一在Calendar的类中已作了判断与设置，原因见如下
                if (SolTerInMonth[j - 1] != "无")
                {
                    graphics.DrawString(SolTerInMonth[j - 1], font, Brushes.Red, point3);

                }
                //else if (LunDayInMonth[j - 1] == "初一")
                //{
                //    此GetLunMon的方法没有考虑到一个月中可能出现两个月的初一的情况
                //  graphics.DrawString(calendar.GetLunMon(), font, Brushes.Black, point3);
                //}

                else
                {
                    graphics.DrawString(LunDayInMonth[j - 1], font, Brushes.Black, point3);
                }


            }
            //给日期画线，每一行划一次
            graphics.DrawLine(new Pen(Color.Black, 1), 0, 167, 531, 167);
            graphics.DrawLine(new Pen(Color.Black, 1), 0, 217, 531, 217);
            graphics.DrawLine(new Pen(Color.Black, 1), 0, 267, 531, 267);
            graphics.DrawLine(new Pen(Color.Black, 1), 0, 317, 531, 317);
            graphics.DrawLine(new Pen(Color.Black, 1), 0, 367, 531, 367);
            graphics.DrawLine(new Pen(Color.Black, 1), 0, 417, 531, 417);
           

        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            //YearUp--;
            calendar1 = new Calendar(calendar1.dateTime.AddYears(-1));
            PaintCal(calendar1);
            label13.Text = calendar1.Month.ToString() + "月";
            label15.Text = calendar1.Year.ToString() + "年";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //YearUp++;
            calendar1 = new Calendar(calendar1.dateTime.AddYears(1));
            PaintCal(calendar1);
            label13.Text = calendar1.Month.ToString() + "月";
            label15.Text = calendar1.Year.ToString() + "年";
        }
    }
}
