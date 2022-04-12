

using System;
using System.Collections.Generic;

namespace FirstAndFollow
{
    class Program
    {
        static void Main(string[] args)
        {

            string gfile = args[0];
            string gfile2 = args[1];

            string gramspec;
            using (var r = new System.IO.StreamReader(gfile))
            {
                gramspec = r.ReadToEnd();
            }
            var g = new Grammar(gramspec);
            var lrr = new LeftRecursionRemover(g.nonterminal);
            var nullable = new Nullable();
            var first = new First();
            var follow = new Follow();

            while(lrr.removeOneRoundOfLeftRecursion()){

            }
            OutputObject output = new OutputObject();
            HashSet<string> nullableSet = nullable.calculateNullableSet(lrr.nonterminals);
            output.first = first.calculateFirstSet(lrr.nonterminals,g.terminals, nullableSet,lrr.alteredSymbols);
            output.follow = follow.calculateFollowSet(lrr.nonterminals, output.first, nullableSet);
            var opts = new System.Text.Json.JsonSerializerOptions();
            opts.IncludeFields = true;
            opts.WriteIndented = true;
            opts.MaxDepth = 1000000;
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(output, opts));
        }
    }
}
