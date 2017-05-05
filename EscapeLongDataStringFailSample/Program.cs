using System;

namespace EscapeLongDataStringFailSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToEscape = "なが".PadRight(99996, 'ー') + "い文字列";
            var result = Uri.EscapeDataString(stringToEscape);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
