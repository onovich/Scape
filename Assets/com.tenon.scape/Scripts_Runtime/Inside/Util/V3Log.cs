using System;

namespace TenonKit.Scape {

    public static class V3Log {
        public static Action<string> Log = Console.WriteLine;
        public static Action<string> Warning = (msg) => Console.WriteLine($"WARNING: {msg}");
        public static Action<string> Error = (msg) => Console.Error.WriteLine($"ERROR: {msg}");
    }

}