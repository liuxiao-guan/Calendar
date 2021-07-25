using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace WritingIsWorthy
{
    
    class Calendar
    {
        #region 日历的属性
        ChineseLunisolarCalendar LunCalendar;
        DateTime currentTime;
        //阳历的年 月 日 日期 周数
        private int year;
        private int month;
        private int day;
        public DateTime date;
        private string week;
        //阴历的年月日 以数字形式表示
        private int LuYear;
        private int LuMonth;
        private int LuDate;
        private int DayofMonth;
        //十天干 十二地支 十二生肖
        private string[] Heavenly = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        private string[] Branch = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        private string[] Zodiac= { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        private string[] LunarMonth = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊",};
        private string[] Lunarday1 = { "初", "十", "廿", "三" };
        private string[] Lunarday2 = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
        private string[] Constellation = { 
            "水瓶座", "双鱼座", "白羊座", "金牛座", 
            "双子座", "巨蟹座", "狮子座", "处女座", 
            "天秤座", "天蝎座", "射手座", "魔蝎座" };
        private static string[] StarName =
            {   
                  //四        五      六         日        一      二      三     
                "角木蛟","亢金龙","女土蝠","房日兔","心月狐","尾火虎","箕水豹",
                "斗木獬","牛金牛","氐土貉","虚日鼠","危月燕","室火猪","壁水獝",
                "奎木狼","娄金狗","胃土彘","昴日鸡","毕月乌","觜火猴","参水猿",
                "井木犴","鬼金羊","柳土獐","星日马","张月鹿","翼火蛇","轸水蚓"
            };
        private static DateTime StarReferDay = new DateTime(2007, 9, 13);//28星宿参考值,本日为角
        private static DateTime HBStartDay = new DateTime(1899, 12, 22);//计算干支日的起始日
        private DateTime[] NearSolarTermDate = new DateTime[4];
        private static string[] SolarTerm =
                   {
                    "小寒", "大寒", "立春", "雨水",
                    "惊蛰", "春分", "清明", "谷雨",
                    "立夏", "小满", "芒种", "夏至",
                    "小暑", "大暑", "立秋", "处暑",
                    "白露", "秋分", "寒露", "霜降",
                    "立冬", "小雪", "大雪", "冬至"
                    };
        private static readonly int[] SolarTermInfo = {
            0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989,
            308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758
        };
        //星期
        private string[] Week = { "星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        #endregion
        #region 初始化阳历的年月日星期 阴历的年月日
        public Calendar(DateTime dateTime)
        {
            try
            {
                LunCalendar = new ChineseLunisolarCalendar();
                currentTime = dateTime;
                //currentTime = System.DateTime.Now;
                //currentTime = new DateTime(2021, 6, 20);
                this.year = currentTime.Year;
                this.month = currentTime.Month;
                this.day = currentTime.Day;
                this.date = currentTime.Date;
                this.week = Week[(int)currentTime.DayOfWeek];
                this.LuYear = LunCalendar.GetYear(currentTime);
                this.LuMonth = LunCalendar.GetMonth(currentTime);//注意这里是从1-13 如果是闰年的话
                this.LuDate = LunCalendar.GetDayOfMonth(currentTime);
                //this.DayofMonth = currentTime.
            }
            catch (ArgumentOutOfRangeException error)
            {
                MessageBox.Show("抱歉，你要查询的月份已经超出可查询范围", "提醒", MessageBoxButtons.OK);
                currentTime =DateTime.Now;
                this.year = currentTime.Year;
                this.month = currentTime.Month;
                this.day = currentTime.Day;
                this.date = currentTime.Date;
                this.week = Week[(int)currentTime.DayOfWeek];
                this.LuYear = LunCalendar.GetYear(currentTime);
                this.LuMonth = LunCalendar.GetMonth(currentTime);//注意这里是从1-13 如果是闰年的话
                this.LuDate = LunCalendar.GetDayOfMonth(currentTime);
            }

        }

        #endregion
        #region 获取阳历的年月日星期 阴历的年月日
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int Month
        {
            get  { return month;}
            set { month = value;}
        }
        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        public string Week_
        {
            get { return week; }
            set { week = value; }
        }
        public int LuYear_
        {
            get { return LuYear; }
            set { LuYear = value; }
        }
        public int LuMonth_
        {
            get { return LuMonth; }
            set { LuMonth = value; }
        }
        public int LuDate_
        {
            get { return LuDate; }
            set { LuDate = value; }
        }
        public DateTime dateTime
        {
           get { return currentTime; }
           set { currentTime = value; }
        }
        #endregion
        #region 对当前该月信息的获取
        //返回该月的第一天是星期几
        public int WeekDayOfFirstDay()
        {
            DateTime FirstDayofMonth = new DateTime(year, month, 1);
            return (int)FirstDayofMonth.DayOfWeek;
        }
       
        //返回这个月的天数
        public int DaysofMonth()
        {
            return DateTime.DaysInMonth(year, month);

        }
        public string[] GetLunDayInMon()
        {
            DateTime FirstDayofMonth = new DateTime(year, month, 1);
            ChineseLunisolarCalendar LunCalFirDay = new ChineseLunisolarCalendar();
            int FDLuYear = LunCalFirDay.GetYear(FirstDayofMonth);
            int FDLuMonth = LunCalFirDay.GetMonth(FirstDayofMonth);
            int Days = DaysofMonth();
            string[] LunDayInMon = new string[Days];
            int FDLuDate;
            int FDLuMon;
            
            //bool IsLeap = 
            for(int i = 0; i < Days; i = i + 1) 
            {
                //返回月份的1-31
                FDLuDate = LunCalFirDay.GetDayOfMonth(FirstDayofMonth.AddDays(i));
                FDLuMon = LunCalFirDay.GetMonth(FirstDayofMonth.AddDays(i));
                FDLuYear = LunCalFirDay.GetYear(FirstDayofMonth.AddDays(i));
                if(FDLuDate == 10)
                {
                    LunDayInMon[i] = Lunarday1[0] + Lunarday2[(FDLuDate - 1) % 10];

                }else if(FDLuDate == 20)
                {
                    LunDayInMon[i] = "二" + Lunarday2[(FDLuDate - 1) % 10];

                }
                else if(FDLuDate == 1)
                {
                    //要考虑是否是闰月
                    if (LunCalFirDay.IsLeapMonth(FDLuYear, FDLuMon) == true)
                    {
                        LunDayInMon[i] =  LunarMonth[FDLuMon - 1 - 1] + "月";//

                    }
                    else if (LunCalendar.IsLeapYear(FDLuYear) == true && LunCalendar.GetLeapMonth(FDLuYear) < FDLuMon)
                    {

                        LunDayInMon[i] = LunarMonth[FDLuMon - 1 - 1] + "月";

                    }
                    else
                    {
                        LunDayInMon[i] =  LunarMonth[FDLuMon - 1] + "月";

                    }
                    //LunDayInMon[i] = LunarMonth[FDLuMon - 1] + "月";
                }
                else
                {
                    LunDayInMon[i] = Lunarday1[FDLuDate / 10] + Lunarday2[(FDLuDate - 1) % 10];

                }
            }
            return LunDayInMon;              
            
        }
        //返回这一个月的所有节气信息
        public string[] GetSolarTermInMon()
        {
            DateTime FirstDayofMonth = new DateTime(year, month, 1);
            ChineseLunisolarCalendar SolTerFirDay = new ChineseLunisolarCalendar();
            int FDLuYear = SolTerFirDay.GetYear(FirstDayofMonth);
            int FDLuMonth = SolTerFirDay.GetMonth(FirstDayofMonth);
            int Days = DaysofMonth();
            string[] SolTerInMon = new string[Days];


            //bool IsLeap = 
            for (int i = 0; i < Days; i = i + 1)
            {
                SolTerInMon[i] = GetCurSolarTerm(FirstDayofMonth.AddDays(i));
            }
            return SolTerInMon;
        }
        #endregion
        #region 阳历节日 农历节日 周节日
        //阳历的节日
        private struct SolarHolidayStruct
        {
            public int Month;
            public int Day;
            public int Recess; //假期长度   
            public string HolidayName;
            public SolarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }
        //农历的节日
        private struct LunarHolidayStruct
        {
            public int Month;
            public int Day;
            public int Recess;
            public string HolidayName;
            public LunarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }
        private struct WeekHolidayStruct
        {
            public int Month;
            public int WeekAtMonth;
            // public int WeekDay;
            public string WeekDay;
            public string HolidayName;
            public WeekHolidayStruct(int month, int weekAtMonth, string weekDay, string name)
            {
                Month = month;
                WeekAtMonth = weekAtMonth;
                WeekDay = weekDay;
                HolidayName = name;
            }
        }
        private static SolarHolidayStruct[] sHolidayInfo = new SolarHolidayStruct[]{
            new SolarHolidayStruct(1, 1, 1, "元旦"),
            new SolarHolidayStruct(2, 2, 0, "世界湿地日"),
            new SolarHolidayStruct(2, 10, 0, "国际气象节"),
            new SolarHolidayStruct(2, 14, 0, "情人节"),
            new SolarHolidayStruct(3, 1, 0, "国际海豹日"),
            new SolarHolidayStruct(3, 5, 0, "学雷锋纪念日"),
            new SolarHolidayStruct(3, 8, 0, "妇女节"),
            new SolarHolidayStruct(3, 12, 0, "植树节 孙中山逝世纪念日"),
            new SolarHolidayStruct(3, 14, 0, "国际警察日"),
            new SolarHolidayStruct(3, 15, 0, "消费者权益日"),
            new SolarHolidayStruct(3, 17, 0, "中国国医节 国际航海日"),
            new SolarHolidayStruct(3, 21, 0, "世界森林日 消除种族歧视国际日 世界儿歌日"),
            new SolarHolidayStruct(3, 22, 0, "世界水日"),
            new SolarHolidayStruct(3, 24, 0, "世界防治结核病日"),
            new SolarHolidayStruct(4, 1, 0, "愚人节"),
            new SolarHolidayStruct(4, 7, 0, "世界卫生日"),
            new SolarHolidayStruct(4, 22, 0, "世界地球日"),
            new SolarHolidayStruct(5, 1, 1, "劳动节"),
            new SolarHolidayStruct(5, 2, 1, "劳动节假日"),
            new SolarHolidayStruct(5, 3, 1, "劳动节假日"),
            new SolarHolidayStruct(5, 4, 0, "青年节"),
            new SolarHolidayStruct(5, 8, 0, "世界红十字日"),
            new SolarHolidayStruct(5, 12, 0, "国际护士节"),
            new SolarHolidayStruct(5, 31, 0, "世界无烟日"),
            new SolarHolidayStruct(6, 1, 0, "国际儿童节"),
            new SolarHolidayStruct(6, 5, 0, "世界环境保护日"),
            new SolarHolidayStruct(6, 26, 0, "国际禁毒日"),
            new SolarHolidayStruct(7, 1, 0, "建党节 香港回归纪念 世界建筑日"),
            new SolarHolidayStruct(7, 11, 0, "世界人口日"),
            new SolarHolidayStruct(8, 1, 0, "建军节"),
            new SolarHolidayStruct(8, 8, 0, "中国男子节 父亲节"),
            new SolarHolidayStruct(8, 15, 0, "抗日战争胜利纪念"),
            new SolarHolidayStruct(9, 9, 0, "  逝世纪念"),
            new SolarHolidayStruct(9, 10, 0, "教师节"),
            new SolarHolidayStruct(9, 18, 0, "九·一八事变纪念日"),
            new SolarHolidayStruct(9, 20, 0, "国际爱牙日"),
            new SolarHolidayStruct(9, 27, 0, "世界旅游日"),
            new SolarHolidayStruct(9, 28, 0, "孔子诞辰"),
            new SolarHolidayStruct(10, 1, 1, "国庆节 国际音乐日"),
            new SolarHolidayStruct(10, 2, 1, "国庆节假日"),
            new SolarHolidayStruct(10, 3, 1, "国庆节假日"),
            new SolarHolidayStruct(10, 6, 0, "老人节"),
            new SolarHolidayStruct(10, 24, 0, "联合国日"),
            new SolarHolidayStruct(11, 10, 0, "世界青年节"),
            new SolarHolidayStruct(11, 12, 0, "孙中山诞辰纪念"),
            new SolarHolidayStruct(12, 1, 0, "世界艾滋病日"),
            new SolarHolidayStruct(12, 3, 0, "世界残疾人日"),
            new SolarHolidayStruct(12, 20, 0, "澳门回归纪念"),
            new SolarHolidayStruct(12, 24, 0, "平安夜"),
            new SolarHolidayStruct(12, 25, 0, "圣诞节"),
            new SolarHolidayStruct(12, 26, 0, " 诞辰纪念")
           };
        private static LunarHolidayStruct[] lHolidayInfo = new LunarHolidayStruct[]{
            new LunarHolidayStruct(1, 1, 1, "春节"),
            new LunarHolidayStruct(1, 15, 0, "元宵节"),
            new LunarHolidayStruct(5, 5, 0, "端午节"),
            new LunarHolidayStruct(7, 7, 0, "七夕情人节"),
            new LunarHolidayStruct(7, 15, 0, "中元节 盂兰盆节"),
            new LunarHolidayStruct(8, 15, 0, "中秋节"),
            new LunarHolidayStruct(9, 9, 0, "重阳节"),
            new LunarHolidayStruct(12, 8, 0, "腊八节"),
            new LunarHolidayStruct(12, 23, 0, "北方小年(扫房)"),
            new LunarHolidayStruct(12, 24, 0, "南方小年(掸尘)"),   
            //new LunarHolidayStruct(12, 30, 0, "除夕")  //注意除夕需要其它方法进行计算   
        };
        private static WeekHolidayStruct[] wHolidayInfo = new WeekHolidayStruct[]{
            new WeekHolidayStruct(5, 2,"星期天", "母亲节"),
            new WeekHolidayStruct(5, 3,"星期天", "全国助残日"),
            new WeekHolidayStruct(6, 3,"星期天", "父亲节"),
            new WeekHolidayStruct(9, 3,"星期二", "国际和平日"),
            new WeekHolidayStruct(9, 4,"星期天","国际聋人节"),
            new WeekHolidayStruct(10,1,"星期一", "国际住房日"),
            new WeekHolidayStruct(10, 1,"星期三", "国际减轻自然灾害日"),
            new WeekHolidayStruct(11, 4,"星期四", "感恩节")
        };
        #endregion 
        #region 十二生肖 十二星座 二十四节气 二十八星宿 
        //获取十二生肖
        public string GetZodiac()
        {
            return Zodiac[(LuYear - 4) % 12];
        }
        //获取十二星座 根据新历的月日判断
        public string GetConstellation()
        {
            int ConNum =  month * 100+ day;//将年月日改为三位小数，进而根据所处区间判断
            string con = "星座";
            if (ConNum >= 120 && ConNum <= 218)
            {
                con = Constellation[0];
            }
            else if (ConNum >= 219 && ConNum <= 320)
            {
                con = Constellation[1];
            }
            else if (ConNum >= 321 && ConNum <= 419)
            {
                con = Constellation[2];
            }
            else if (ConNum >= 420 && ConNum <= 520)
            {
                con = Constellation[3];
            }
            else if (ConNum >= 521 && ConNum <= 621)
            {
                con = Constellation[4];
            }
            else if (ConNum >= 622 && ConNum <= 722)
            {
                con = Constellation[5];
            }
            else if (ConNum >= 723 && ConNum <= 822)
            {
                con = Constellation[6];
            }
            else if (ConNum >= 823 && ConNum <= 922)
            {
                con = Constellation[7];
            }
            else if (ConNum >= 923 && ConNum <= 1023)
            {
                con = Constellation[8];
            }
            else if (ConNum >= 1024 && ConNum <= 1122)
            {
                con = Constellation[9];
            }
            else if (ConNum >= 1123 && ConNum <= 1221)
            {
                con = Constellation[10];
            }
            else 
            {
                con = Constellation[11];
            }
           
            return con;
        }
        //获取二十四节气
        
        //初始化靠近当前日期四个节气的日期数
        public void GetSolarTerm1()
        {
            DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0);
            
            double num;
            //该月与四个可能节气的相对应关系
            int[] SeaSolarTerm = new int[4] {month*2 -3, month * 2 - 2, month * 2 - 1, month * 2};
            int j = 0;
            //搜索时不能全是month*2 -3 -- month*2,对于一月以及十二月会有错误
            if (month == 1)
            {
                SeaSolarTerm[0] = 23;
            }
            else if(month == 12)
            {
                SeaSolarTerm[3] = 0;
            }
            foreach(int SolarId in SeaSolarTerm)                  
            {
                
                num = 525948.76 * (year - 1900) + SolarTermInfo[SolarId];
                NearSolarTermDate[j] = baseDateAndTime.AddMinutes(num);//按分钟计算
                j++;

            }
        }
        //获取当前节气
        public string GetCurSolarTerm(DateTime dateTime)
        {
            //对每一个月初始化靠近他四个节气的信息
            GetSolarTerm1();
            string CurSolarTerm = "无";
            for (int i = 0;i< 4; i++)
            {
                if (NearSolarTermDate[i].DayOfYear == dateTime.DayOfYear)
                {
                    if(month == 1 && i == 0)
                    {
                        CurSolarTerm =  SolarTerm[23];
                    }else if(month == 12 && i == 3)
                    {
                        CurSolarTerm = SolarTerm[0];
                    }
                    else
                    {
                        CurSolarTerm = SolarTerm[2 * month - 3 + i];
                    }
                    break;
                }
                //if(month == 1 &&  i = 0 )
            }
            return CurSolarTerm;
        }
        //得到当前日期的上一个节气，当当前不是节气日时
        public string GetLastSolarTerm()
        {
            GetSolarTerm1();
            string LastSolarTerm = "无";
            for (int i = 3; i >= 0; i--)//要想从后面开始
            {
                if (NearSolarTermDate[i].DayOfYear < currentTime.DayOfYear)
                {
                    if (month == 1 && i == 0)
                    {
                        LastSolarTerm = SolarTerm[23];
                    }
                    else if (month == 12 && i == 3)
                    {
                        LastSolarTerm = SolarTerm[0];
                    }
                    else
                    {
                        LastSolarTerm = SolarTerm[2 * month - 3 + i];
                    }
                    break;
                }
                //if(month == 1 &&  i = 0 )
            }
            return LastSolarTerm;
        }
        public string GetNextSolarTerm()
        {
            GetSolarTerm1();
            string NextSolarTerm = "无";
            for (int i = 0; i < 4; i++)
            {
                if (NearSolarTermDate[i].DayOfYear > currentTime.DayOfYear)
                {
                    if (month == 1 && i == 0)
                    {
                        NextSolarTerm = SolarTerm[23];
                    }
                    else if (month == 12 && i == 3)
                    {
                        NextSolarTerm = SolarTerm[0];
                    }
                    else
                    {
                        NextSolarTerm = SolarTerm[2 * month - 3 + i];
                    }
                    break;
                }
                //if(month == 1 &&  i = 0 )
            }
            return NextSolarTerm;
        }
        
        //返回当前一个月的节气

        //获取二十八星宿
        public string GetStar()
        {
            int offset = 0;
            int modStarDay = 0;

            TimeSpan ts = date - StarReferDay;//使用时间戳计算出与参考时间距离的天数
            offset = ts.Days;
            modStarDay = offset % 28;
            //参考时间为2007会出现负数
            return (modStarDay >= 0 ? StarName[modStarDay] : StarName[27 + modStarDay]);
        }
        #endregion
        #region 获取农历的天干地支的年
        //农历时间 天干地支
        //适用于公元年后
        /// <summary>
        /// 获取干支年
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetHBYear()
        {
            
            return Heavenly[(year - 4) % 10 ] + Branch[(year - 4) % 12 ];
        }
        /// 设置节气与月份的对应关系
        public int LunMon_SolTerm(string SolarTerm)
        {
            int STLunarMonth = 0;
            if (SolarTerm == "立春" || SolarTerm == "雨水")
            {
                STLunarMonth = 1;
            }
            else if (SolarTerm == "惊蛰" || SolarTerm == "春分")
            {
                STLunarMonth = 2;
            }
            else if (SolarTerm == "清明" || SolarTerm == "谷雨")
            {
                STLunarMonth = 3;
            }
            else if (SolarTerm == "立夏" || SolarTerm == "小满")
            {
                STLunarMonth = 4;
            }
            else if (SolarTerm == "芒种" || SolarTerm == "夏至")
            {
                STLunarMonth = 5;
            }
            else if (SolarTerm == "小暑" || SolarTerm == "大暑")
            {
                STLunarMonth = 6;
            }
            else if (SolarTerm == "立秋" || SolarTerm == "处暑")
            {
                STLunarMonth = 7;
            }
            else if (SolarTerm == "白露" || SolarTerm == "秋分")
            {
                STLunarMonth = 8;
            }
            else if (SolarTerm == "寒露" || SolarTerm == "霜降")
            {
                STLunarMonth = 9;
            }
            else if (SolarTerm == "立冬" || SolarTerm == "小雪")
            {
                STLunarMonth = 10;
            }
            else if (SolarTerm == "大雪" || SolarTerm == "冬至")
            {
                STLunarMonth = 11;
            }
            else if (SolarTerm == "小寒" || SolarTerm == "大寒")
            {
                STLunarMonth = 12;
            }
            return STLunarMonth;
        }
        //获取当前日期的节气或者上一个节气，得到对应的月份
        public string GetHBMonth()
        {
            string CurSolarTerm = GetCurSolarTerm(currentTime);
            //string LonMon_SolTerm = "无";
            int STLunarMonth;
            if (CurSolarTerm == "无")
            {
                STLunarMonth = LunMon_SolTerm(GetLastSolarTerm());

            }
            else
            {
                STLunarMonth = LunMon_SolTerm(GetCurSolarTerm(currentTime));
            }
            string HBMonth = GetHBMonth0(STLunarMonth);
            return HBMonth;
        }
        //获取干支月
        
        public string GetHBMonth0(int Month)
        {
            string Heaven = Heavenly[(LuYear - 4) % 10];
            int forward = 0;//按原来天干推移的步数
            if(Heaven == "甲" || Heaven == "巳")
            {
                forward = 2;
            }else if (Heaven == "乙" || Heaven == "庚")
            {
                forward = 4;
            }
            else if (Heaven == "丙" || Heaven == "辛")
            {
                forward = 6;
            }
            else if (Heaven == "丁" || Heaven == "壬")
            {
                forward = 8;
            }
            else if (Heaven == "戊" || Heaven == "癸")
            {
                forward = 0;
            }
           
                return Heavenly[(forward + Month -1) % 10] + Branch[(2 + Month-1) % 12];
        }
       
        //获取干支日
        public string GetHBDay()
        {
            int i, offset;
            TimeSpan ts = date - HBStartDay; //使用时间戳，计算相隔的天数
            offset = ts.Days;
            i = offset % 60;
            return Heavenly[i % 10].ToString() + Branch[i % 12].ToString();
        }
        
        public string GetLunMon()
        { 
            //判断是否是闰月
            //注意如果是闰年的话，LunCalendar类里的月会有十三个月，所以后续月份要多减一次1
            if(LunCalendar.IsLeapMonth(LuYear,LuMonth)== true)
            {
                return "闰" + LunarMonth[LuMonth - 1 - 1] + "月";//

            }
            else if(LunCalendar.IsLeapYear(LuYear) == true && LunCalendar.GetLeapMonth(LuYear)< LuMonth)
            {

                return LunarMonth[LuMonth - 1 - 1] + "月";

            }
            else
            {
                return LunarMonth[LuMonth - 1] + "月";

            }
            //要注意减一
        }
        public string GetLunDay()
        {
            //判断是否是闰月
            if (LuDate == 10)
            {
                return Lunarday1[0] + Lunarday2[(LuDate - 1) % 10];
                //因为十号是用初十来表示的

            }
            else if (LuDate == 20)
            {
                return "二" + Lunarday2[(LuDate - 1) % 10];
                //二十是用二十来表示的，而不是廿十
            }
            else
            {
               return  Lunarday1[LuDate / 10] + Lunarday2[(LuDate - 1) % 10];

            }
            //return Lunarday1[LuDate / 10] + Lunarday2[(LuDate-1) % 10 ];
           //要注意减一
        }

        #endregion
        #region 获取新历节日 农历节日 周节日
        //获取最近的新历节日
        public string GetSolarHoliday()
        {
            string SolarHoliday = "无";
            foreach(SolarHolidayStruct SHStruct in sHolidayInfo)
            {
                if(month == SHStruct.Month && day == SHStruct.Day )
                {
                    
                    SolarHoliday = SHStruct.HolidayName;
                    break;
                }
            }
            return SolarHoliday;
        }
        //获取最近的农历日期 但闰月不算节日 而且考虑除夕
        public string GetLunarHoliday()
        {
            string LunarHoliday = "无";
            DateTime LunarNewYear = new DateTime(LuYear, 1, 1);
            if (LunCalendar.IsLeapMonth(LuYear, LuMonth) == false)
            {
                foreach (LunarHolidayStruct LHStruct in lHolidayInfo)
                {
                    if (LuMonth == LHStruct.Month && LuDate == LHStruct.Day )
                    {
                        LunarHoliday = LHStruct.HolidayName;
                        break;
                    }
                }
                //前一个是该年的天数 后一个是当前时间在这一年的天数
                if(LunCalendar.GetDaysInYear(LuYear) == LunCalendar.GetDayOfYear(currentTime) )
                {
                    LunarHoliday = "除夕";
                }
                
               
            }
            return LunarHoliday;
        }
        //获取最近的
        public string GetWeekHoliday()
        {
            string WeekHoliday = "无";
            foreach (WeekHolidayStruct WHStruct in wHolidayInfo)
            {

                if (month == WHStruct.Month && week == WHStruct.WeekDay )
                {
                    if((day / 7 + 1) == WHStruct.WeekAtMonth)
                    {
                        WeekHoliday = WHStruct.HolidayName;
                    }
                   
                    break;
                }
            }
            return WeekHoliday;
        }
        //得到一个月的节日信息
        public string GetHoliofMonth()
        {
            DateTime FirstDayofMonth = new DateTime(year, month, 1);
            ChineseLunisolarCalendar LunCalFirDay = new ChineseLunisolarCalendar();
            int Days = DaysofMonth();
            return "无";
        }

        #endregion

    }


}
