using System;
using System.Windows;
using System.Reflection;
using Microsoft.VisualBasic.ApplicationServices;

namespace ZAR.WPF
	{
	public class ApplicationEntry
		{
		[STAThread]
		public static void Main(String[] args)
			{
			SingleInstanceApp singleinstanceapp = new SingleInstanceApp();
			singleinstanceapp.Run(args);
			}
		}
	
	public class SingleInstanceApp : WindowsFormsApplicationBase
		{
		private Application app;

		public SingleInstanceApp()
			{ this.IsSingleInstance = true; }

		protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
			{
			app = new Application();
			app.Run(new WindowMain("ZAR.WPF"));
			return false;
			}

		protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
			{
			eventArgs.BringToForeground = true;
			app.MainWindow.Activate();
			}

		}

	}
