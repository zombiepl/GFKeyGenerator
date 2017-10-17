using System;
using System.Windows.Forms;
using GKKeyGenerator.Models;

namespace GKKeyGenerator
{
    static class Program
    {
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Company cmp = new Company();
        }
    }
}