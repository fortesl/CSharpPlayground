﻿using System.Windows;
using System;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.Properties["GodMode"] = false;
            foreach (string arg in e.Args)
            {
                if (arg.Equals("/godmode", StringComparison.OrdinalIgnoreCase))
                {
                    Current.Properties["GodMode"] = true;
                    break;
                }
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }
    }

    
}
