using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZAR.WPF.Properties;

namespace ZAR.WPF
	{
	public partial class WindowMain : Window
		{
		public WindowMain()
			{
			InitializeComponent();
			InitializeSettings();
			}

		public WindowMain(String windowtitle)
			{
			InitializeComponent();
			InitializeSettings();

			this.Title = windowtitle;
			}

		private void InitializeSettings()
			{
			if (Settings.Default.WindowMainRect.IsEmpty == true)
				{
				this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
				this.Height = 600;
				this.Width =  800;
				}
			else
				{
				this.Top = Settings.Default.WindowMainRect.Top;
				this.Left = Settings.Default.WindowMainRect.Left;
				this.Height = Settings.Default.WindowMainRect.Height;
				this.Width = Settings.Default.WindowMainRect.Width;
				}

			this.WindowState = Settings.Default.WindowMainState;
			}

		private void ShowOptionsWindow(object sender, RoutedEventArgs e)
			{
			WindowOptions winOptions = new WindowOptions
				{
				WindowStartupLocation = WindowStartupLocation.CenterOwner,
				Background = this.Background,
				Icon = this.Icon,
				Owner = this
				};
			
			winOptions.ShowDialog();
			}

		private void ShowAboutWindow(object sender, RoutedEventArgs e)
			{
			WindowAbout winAbout = new WindowAbout
				{
				WindowStartupLocation = WindowStartupLocation.CenterOwner,
				Background = this.Background,
				Icon = this.Icon,
				Owner = this
				};
			
			winAbout.ShowDialog();
			}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
			{
			base.OnClosing(e);

			Settings.Default.WindowMainRect = this.RestoreBounds;
			Settings.Default.WindowMainState = this.WindowState;
			Settings.Default.Save();
			}
		}
	}
