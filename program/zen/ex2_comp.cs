using System;
using ZenLib;
using static ZenLib.Language;

namespace SampleConsole
{
    class Program
    {
        static Zen<int> Mult(Zen<int> x,Zen<int> y){
            return x+y;
        }
        static void Main(string[] args)
        {
            ZenFunction<int,int,int> function = Function<int,int,int>(Mult);
            /*
            var output = function.Evaluate(10,10);
            var a = function.Find((s,t,u) => And(s<=0,u==11));
            Console.WriteLine(output);
            */



            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
                function.Evaluate(3, 2);

            Console.WriteLine($"interpreted function time: {watch.ElapsedMilliseconds}ms");
            watch.Restart();

            function.Compile();

            Console.WriteLine($"compilation time: {watch.ElapsedMilliseconds}ms");
            watch.Restart();

            for (int i = 0; i < 1000000; i++)
                function.Evaluate(3, 2);

            Console.WriteLine($"compiled function time: {watch.ElapsedMilliseconds}ms");
        }
    }
}
