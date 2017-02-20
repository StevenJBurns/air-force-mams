using System;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;

namespace MAMS.WPF
	{
	public class ApplicationEntry
		{
		[STAThread]
		public static void Main(String[] args)
			{
			SingleInstanceApplication sia = new SingleInstanceApplication();
			sia.Run(args);
			}
		}
	
	public class SingleInstanceApplication : WindowsFormsApplicationBase
		{
		private Application app;

		public SingleInstanceApplication()
			{ this.IsSingleInstance = true; }

		protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
			{
			app = new Application();
			app.Run(new WindowMain());

			return false;
			}
		
		protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
			{
			eventArgs.BringToForeground = true;
			app.MainWindow.Activate();
			}

		}

	}