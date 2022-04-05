using CalastoneAssignment.Filters;
using CalastoneAssignment.Processors;
using CalastoneAssignment.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CalastoneAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Filen Input.txt in Resources inside the project
            string fileName = "Input.txt";
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Resources\"+ fileName);

            //Set up filereader with filepath
            TextFileReader fr = new TextFileReader(filepath);
            //Create a list of filters to apply on the each word
            List<IFilter> filters = new List<IFilter> { new CharFilter('T'), new LengthFilter(3), new MiddleVowelFilter() };

            //Apply the filters, filter out text, get output
            TextFilteringProcessor textProcessor = new TextFilteringProcessor(fr, filters);
            textProcessor.Process();
            string output = textProcessor.Output;


            //PRINT DATA
            Console.WriteLine("##################################");
            Console.WriteLine("INPUT");
            Console.WriteLine("##################################");

            foreach (string line in fr.ReadLines())
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine("##################################");
            Console.WriteLine("OUTPUT");
            Console.WriteLine("##################################");

            Console.WriteLine(output);
            Console.WriteLine();


            Console.ReadLine();
        }

    }
}
