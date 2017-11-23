using System;
using static Bitwise.Helpers;
using static System.Console;

namespace Bitwise
{
    /// <summary>
    /// Flag enum examples (bitwise)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("### behavior of ToString()");
            {
                wFlags((DevicesFlag.MacbookPro | DevicesFlag.MacbookAir).ToString());
                woFlags((Devices.MacbookPro | Devices.MacbookAir).ToString());
            }

            WriteLine("\n ### behavior during looping");
            {
                wFlags("");
                for (int i = 1; i < 8; i++)
                    WriteLine("{0,3} - {1:G}", i, (DevicesFlag)i);

                woFlags("");
                for (int i = 1; i < 8; i++)
                    WriteLine("{0,3} - {1:G}", i, (Devices)i);
            }

            ReadLine();
        }

        /// <summary>
        /// Enum with flag (bitwise)
        /// </summary>
        [Flags]
        enum DevicesFlag
        {
            MacbookPro = 1,
            MacbookAir = 2,
            Iphone = 4,
        }

        /// <summary>
        /// Enum without flag (bitwise)
        /// </summary>
        enum Devices
        {
            MacbookPro = 1,
            MacbookAir = 2,
            Iphone = 4,
        }
    }

    /// <summary>
    /// Print helper class
    /// </summary>
    static class Helpers
    {
        /// <summary>
        /// Print helpers with flags
        /// </summary>
        public static Action<string> wFlags = (s)
            => WriteLine($@"with Flags          => {s}");

        /// <summary>
        /// Print helpers without flags
        /// </summary>
        public static Action<string> woFlags = (s)
            => WriteLine($@"without Flags       => {s}");
    }
}