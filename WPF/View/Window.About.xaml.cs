using System;
using System.Windows;
using System.Reflection;

namespace ZAR.WPF
	{
	public partial class WindowAbout : Window
		{
		String appname = Assembly.GetExecutingAssembly().GetName().Name;
		String appversion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

		public WindowAbout()
			{
			InitializeComponent();

			lblApp.Content = appname;
			lblVer.Content = "v" + appversion;
			}

		private void Button_OK_Click(object sender, RoutedEventArgs e)
			{
			this.Close();
			}
		}
	}