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
using System.Net.Http;
using System.Diagnostics;
using System.Threading;

namespace WPF_Tasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool Downloading = false;

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Downloading)
            {
                Task.Run(() =>
                {
                    Downloading = true;
                    Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId}");
                    HttpClient webClient = new HttpClient();
                    string html = webClient.GetStringAsync("https://google.com").Result;
                    MyButton.Dispatcher.Invoke(() =>
                    {
                        Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} owns MyButton");
                        MyButton.Content = "Done";
                    });
                    Downloading = false;
                });
            }
        }

        // TODO: Setup this same test in Godot and see if it is blocking or not.
        // Testing threading is something I can use to ease myself into Godot development. 
        private async void MyButton_Click2(object sender, RoutedEventArgs e)
        {
            // Two things are going on when you use async/await:
            // 1) You are making a thread that does something
            // 2) You are pausing the execution of the function until the thread is done.
            // Any function that calls the async function has two choices:
            // 1) Call the function as normal, in which case as soon as the async function gets to
            //    await, it will bump back out to the calling function and continue execution there.
            //    I think this is what the yeild statement does in Godot.(Godot's yield statement pauses a function
            //    and saves its state. You can resume the function by calling .resume() on the function
            //    await/async is like a special case of yield, and yield is a general solution.)
            // 2) Call the function and use await on it or a task object you assign the function to.
            //    This will pause the calling function at the await point, and means the calling function
            //    must also be async and return a Task<T>. 
            Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} before await task");
            if (!Downloading)
            {
                string myHtml = "Bla";
                await Task.Run(async () =>
                {
                    Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} during await task");
                    Downloading = true;
                    HttpClient webClient = new HttpClient();
                    myHtml = webClient.GetStringAsync("https://google.com").Result;
                    Downloading = false;
                });
                Debug.WriteLine($"Thread Nr. {Thread.CurrentThread.ManagedThreadId} after await task");
                MyButton.Content = "Done Downloading";
                MyWebBrowser.SetValue(HtmlProperty, myHtml);
            }
        }

        private static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
                webBrowser.NavigateToString(e.NewValue as string);
        }
    }
}
