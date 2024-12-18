using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp2
{
    internal class Program
    {
        [STAThread] // Required for WPF
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Launching WPF Window from Console Application...");

                // Create a WPF Application instance
                var app = new Application();

                // Instantiate the WPF Window from MyLibrary
                var window = new WpfLibrary2.Window2();

                // Run the WPF Application with the Custom Window
                app.Run(window);

                Console.WriteLine("WPF Window closed. Press any key to exit.");
            }
            catch(Exception ex)
            {

            }

            Console.ReadKey();
        }
    }
}
