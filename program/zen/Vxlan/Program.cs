using System;
using ZenLib;
using static ZenLib.Language;
using ZenLib.Tests;

namespace main
{
    class Program
    {
        public static Zen<int> Mult(Zen<int> x,Zen<int> y)
        {
            return x+y;
        }

        static void Main(string[] args)
        {
            ZenFunction<int,int,int> function = Function<int,int,int>(Mult);
            var a = function.Evaluate(10,10);
        }
    }
}
