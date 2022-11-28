
using System.Diagnostics;

namespace simple;

internal class Program
{
    static void Main(string[] args)
    {
        var arr = new byte[268435456]; // 268Mb
        Random.Shared.NextBytes(arr);

        long all = 0;
        var sw = new Stopwatch();
        for (int loop = 0; loop < 21; loop++) {

            double d = 0.0;
            int a;
            sw.Start();
            for (int intr = 0; intr < arr.Length; intr++) {
                a = arr[intr] * 2;
                d = d + a / 313.0;
            }
            sw.Stop();

            long hlp = sw.ElapsedMilliseconds;
            all = all + hlp;
            Console.WriteLine("[{1}] - Time: {0} ms. {2}", hlp, loop, d);
            sw.Reset();
        }

        Console.WriteLine($"AvgTime: {all / 21} ms.");
    }
}
