using System;
using System.Collections.Generic;

namespace Tokenize
{
    class Program
    {
        static void Main(string[] args)
        {
            string gfile = args[0];
            string ifile = args[1];
            string gramspec;
            using (var r = new System.IO.StreamReader(gfile))
            {
                gramspec = r.ReadToEnd();
            }
            var g = new Grammar(gramspec);
            var tokenizer = new Tokenizer(g);
            string input;
            using (var r = new System.IO.StreamReader(ifile))
            {
                input = r.ReadToEnd();
            }
            tokenizer.setInput(input);
            List<Token> tokens = new List<Token>();
            var opts = new System.Text.Json.JsonSerializerOptions();
            opts.IncludeFields = true;
            opts.WriteIndented = true;
            opts.MaxDepth = 1000000;
            string J;
            while (true)
            {
                try
                {
                    Token t = tokenizer.next();
                    if (t.sym == "$")
                        break;      //end of file
                    tokens.Add(t);           //do something with t
                }
                catch (Exception e)
                {
                    J = System.Text.Json.JsonSerializer.Serialize(new Output(1,tokens), opts);
                    Console.WriteLine(J);
                }
            }
            J = System.Text.Json.JsonSerializer.Serialize(new Output(-1 ,tokens), opts);
            Console.WriteLine(J);
        }
    }
}
