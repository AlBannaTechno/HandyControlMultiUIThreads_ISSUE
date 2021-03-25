using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            app.Run();
        }
        
        private static void RunSplashWindow(int index)
        {
            var thread = new Thread(() =>
            {
                var window = new SecondWindow
                {
                    Title = $"SecondWindow :  {index.ToString().PadLeft(2, ' ')}",
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
