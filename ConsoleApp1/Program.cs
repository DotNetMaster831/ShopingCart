using System.Net.Mime;
using System.Windows;


namespace ConsoleApp1
{
    class Program
    {
        [STAThread] // Required for WPF
        static void Main(string[] args)
        {
            Console.WriteLine("Launching WPF Window from Console Application...");

            // Create a WPF Application instance
            var app = new Application();

            // Instantiate the WPF Window from MyLibrary
            var window = new WpfLibrary1.Window1();

            // Run the WPF Application with the Custom Window
            app.Run(window);

            Console.WriteLine("WPF Window closed. Press any key to exit.");
            Console.ReadKey();
        }
    }
}