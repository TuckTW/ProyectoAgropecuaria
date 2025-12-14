using System;
using System.Windows.Forms;
using AgroCampoApp.Forms;

namespace AgroCampoApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
