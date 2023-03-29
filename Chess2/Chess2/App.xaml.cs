﻿namespace Chess2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e)
		{
			ViewModelLocator.Init();
			base.OnStartup(e);
		}
	}
}
