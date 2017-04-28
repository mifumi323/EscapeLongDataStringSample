using System;
using System.Text;

namespace EscapeLongDataStringSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToEscape = "なが".PadRight(99996, 'ー') + "い文字列";
            var result = EscapeLongDataString(stringToEscape);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static string EscapeLongDataString(string stringToEscape)
        {
            var sb = new StringBuilder();
            var length = stringToEscape.Length;

            // Uri.c_MaxUriBufferSize以上だとエラーになるため
            // Uri.c_MaxUriBufferSize - 1を上限とする
            var limit = 0xFFF0 - 1;

            // limitごとに区切って処理
            for (int i = 0; i < length; i += limit)
            {
                sb.Append(Uri.EscapeDataString(stringToEscape.Substring(i, Math.Min(limit, length - i))));
            }

            return sb.ToString();
        }
    }
}
