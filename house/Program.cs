/*
 * This demo is property of vasily tserekh if you want more stuff like this you
 * can visit my blog at http://vasilydev.blogspot.com
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Casa
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
            Application.Run(new MainForm());
        }
    }
}
