

using System;

namespace Nullable
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
            var nullable = new Nullable(g.nonterminal);

            while(nullable.removeOneRoundOfLeftRecursion()){

            }
            OutputObject output = new OutputObject();
            output.nullable = nullable.calculateNullableSet();
            var opts = new System.Text.Json.JsonSerializerOptions();
            opts.IncludeFields = true;
            opts.WriteIndented = true;
            opts.MaxDepth = 1000000;
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(output, opts));
        }
    }
}
