using System;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Console;

namespace TaskCompletionSource
{
    internal class Program
    {
        //Number of iterations for calculation
        private const int iterations = 500000;

        private static void Main(string[] args)
        {
            // Print
            WriteLine($"Starting Heavy Calculation and a simple couting from 0 to {iterations:N0}...\n");

            // Start a new task to simulate heavy calculation
            var heavyCalculationTask =
                Task.Run(function: ()
                    => HeavyCalculation.Run(
                        iterations: iterations));

            // Run a simple counter
            for (int i = 0; i <= iterations; i++)
                Write(format: $"\r => Current: {i:N0}");

            // Print Heavy calculation result
            WriteLine($"\r\n => HeavyCalculation result: {heavyCalculationTask.Result:N0}");

            // Print
            WriteLine("\nDone!");
            Read();
        }
    }

    /// <summary>
    /// Simulate a heavy calculation, multiply by a random number and check if
    /// it is a even number;
    /// </summary>
    public static class HeavyCalculation
    {
        /// <summary>
        /// Get current DateTime tick
        /// </summary>
        /// <param name="iterations">Number of iterations</param>
        /// <returns>Int result</returns>
        public static Task<int> Run(int iterations)
        {
            // Task Completion Source (receive calculation result)
            var tcs = new TaskCompletionSource<int>();

            // Accumulator of even numbers
            var acc = 0;

            // Stopwatch
            var sw = new Stopwatch();

            // Stopwatch start
            sw.Start();

            // Heavy calculation
            for (var i = 0; i < iterations; i++)
                if (EvenNumber(arg: DateTime.Now.Ticks * new Random().Next()))
                    acc++;

            // Stopwatch stop
            sw.Stop();

            // Set task result
            tcs.SetResult(result: acc);

            // Print
            WriteLine(value: $"\r => Heavy calculation elapsed: {sw.Elapsed.TotalMilliseconds} milliseconds");

            // Return task
            return tcs.Task;
        }

        /// <summary>
        /// Check if a given number is even
        /// </summary>
        private static Func<long, bool> EvenNumber => n
                  => n % 2 == 0;
    }
}