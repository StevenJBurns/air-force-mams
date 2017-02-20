using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace MAMS.WinForms
	{
	public class SingleInstanceApplication : WindowsFormsApplicationBase
		{
		public SingleInstanceApplication()
            { this.IsSingleInstance = true; }

        protected override void OnCreateMainForm()
            { this.MainForm = new FormMain(); }

        [STAThread]
        static void Main(string[] args)
            {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleInstanceApplication app = new SingleInstanceApplication();
            app.Run(args);
            }
		}
	}

