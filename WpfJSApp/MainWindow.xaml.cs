using System;
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
        ChromiumWebBrowser browser;
        public MainWindow()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser();
            browser.Address = "google.com";
            browser.Margin = new Thickness(2);
            container.Content = browser;
           
            browser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(this), true);  // register object for interacting from JS
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
            string adress = "file:///C:/Users/eugen/source/repos/WpfJSApp/WpfJSApp/Pages/HTMLPage1.html";

            if (browser.Address != adress)
            {
                browser.Load("C:/Users/eugen/source/repos/WpfJSApp/WpfJSApp/Pages/HTMLPage1.html");
            }
            else
            {
                browser.ExecuteScriptAsync(@"myFunction(""Hello"");");
            }
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
            browser.Load("C:/Users/eugen/source/repos/WpfJSApp/WpfJSApp/Pages/HTMLPage2.html");
        }
    }

    public class BoundObject    // class for interaction from JS
    {
        MainWindow mainWindow;

        public BoundObject(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void ShowMessage(string msg)
        {
            mainWindow.Dispatcher.BeginInvoke((Action) delegate { mainWindow.stsBar1.Content = msg; });
            MessageBox.Show(msg, "Message Box");
        }
    }
}
