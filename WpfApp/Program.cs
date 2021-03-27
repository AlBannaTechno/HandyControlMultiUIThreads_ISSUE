using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandyControl.Themes;

namespace WpfApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                RunSplashWindow(i);
            }

            var app = new App();
            app.InitializeComponent();

            for (int i = 0; i < 2; i++)
            {
                RunSplashWindow(i);
            }

            app.Run();
        }

        private static void RunSplashWindow(int index)
        {
            var thread = new Thread(() =>
            {
                // suppose any additional async operations before init the window
                Thread.Sleep(500);

                var window = new SecondWindow
                {
                    Title = $"SecondWindow :  {index.ToString().PadLeft(2, ' ')}",
                    Resources = new Theme()
                };
                window.Show();
                System.Windows.Threading.Dispatcher.Run();
            })
            {
                IsBackground = true,
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}