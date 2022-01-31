using System;
using System.Collections.Generic;

namespace CFGIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            string gfile = args[0];
            string gramspec;
            using (var r = new System.IO.StreamReader(gfile))
            {
                gramspec = r.ReadToEnd();
            }
            var g = new Grammar(gramspec);

            var opts = new System.Text.Json.JsonSerializerOptions();
            opts.IncludeFields = true;
            opts.WriteIndented = true;
            opts.MaxDepth = 1000000;
            string J;
            J = System.Text.Json.JsonSerializer.Serialize(new Output(g.terminals,g.nonterminal,gramspec), opts);

            Console.WriteLine(J);
        }
    }
}
