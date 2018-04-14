﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CefSharp;
using CefSharp.Wpf;
using System.Diagnostics;


namespace WpfJSApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void txtAdress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                browser.Load(txtAdress.Text);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string script = "alert(\"Привет\");";
            string script1 = @"alert(""Привет"");";
            string script2 = "document.write(\"Hello World! <br>\");";
            string script3 = "document.write(\"<h1> Hello World!</h1><p>Have a nice day!</p>\");";
            string script4 = "document.write(\"Hello World!!!   \"); document.write(Date()); document.write(\"<br>\");";
            browser.GetMainFrame().ExecuteJavaScriptAsync(script4);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            browser.Load("C:/Users/eugen/source/repos/WpfJSApp/WpfJSApp/Pages/HTMLPage1.html");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            const string script = @"(function()
    					{
	    					return 1 + 1;
    					})();";

            browser.EvaluateScriptAsync(script).ContinueWith(x =>
            {
                var response = x.Result;

                if (response.Success && response.Result != null)
                {
                    var onePlusOne = (int)response.Result;
                    MessageBox.Show(onePlusOne.ToString());
                    //Do something here (To interact with the UI you must call BeginInvoke)
                    Dispatcher.BeginInvoke((Action)delegate()
                    {
                        stsBar1.Content = onePlusOne;
                    }
                    );
                 
                }
            });
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            browser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(), true);
            browser.Load("C:/Users/eugen/source/repos/WpfJSApp/WpfJSApp/Pages/HTMLPage3.html");
        }
    }

    public class BoundObject
    {
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
