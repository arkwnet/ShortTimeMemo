/*
Short Time Memo
Copyright (c) 2022 Sora Arakawa
Licensed under the MIT License
*/

using System;
using System.Windows.Forms;

namespace ShortTimeMemo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
