﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Search_and_copy_files_tool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Seach_And_Copy_Files_Tool());
        }
    }
}
