﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WritingIsWorthy
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Form1 form1 = new Form1();
            //Application.Run(form1);
            //CalWin calWin = new CalWin();
           // Application.Run(calWin);
            //form1.Show();
            
            
        }
    }
}
