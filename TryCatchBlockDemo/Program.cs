using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchBlockDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number:");
                int number = int.Parse(Console.ReadLine()); // May throw FormatException
                int result = 100 / number; // May throw DivideByZeroException
                Console.WriteLine($"100 divided by {number} is {result}");

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution completed. Thank you for using the program!");
            }
        }
    }
}
