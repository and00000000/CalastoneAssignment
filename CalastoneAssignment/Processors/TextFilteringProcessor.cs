using CalastoneAssignment.Filters;
using CalastoneAssignment.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalastoneAssignment.Processors
{
    public class TextFilteringProcessor : IProcessor
    {
        private readonly IEnumerable<IFilter> _filters;
        private readonly IFileReader _fileReader;
        public string Output { get; set; }

        public TextFilteringProcessor(IFileReader fileReader, IEnumerable<IFilter> filters)
        {
            _fileReader = fileReader;
            _filters = filters;
        }

        public void Process()
        {
            StringBuilder outputBuilder = new StringBuilder();

            //read one line at a time
            foreach (string inputLine in _fileReader.ReadLines())
            {
                //build the output line without the filtered out values
                StringBuilder outputLineBuilder = new StringBuilder(inputLine);
                //finds all words of each line
                var words = Regex.Matches(inputLine, @"\b(?:[a-z]{2,}|[ai])\b",RegexOptions.IgnoreCase);

                //start from the end to avoid ArgumentOutOfRangeException whilst outputLineBuilder size increased as we remove words
                foreach (Match word in words.Reverse())
                {
                    bool remove = false;
                    // apply each filter in turn
                    foreach (IFilter filter in _filters)
                    {
                        //if word is filtered out by one of the filters proceed to the next word
                        remove = filter.FilterText(word.Value);
                        if(remove)
                        {
                            outputLineBuilder.Remove(word.Index, word.Length);
                            break;
                        }
                    }
                }
                //add filtered line to the output builder
                outputBuilder.AppendFormat("{0} ", outputLineBuilder.ToString());
            }
            //remove unnecessary extra white spaces
            Output= Regex.Replace(outputBuilder.ToString(), @"\s+", " ").Trim();
        }

    }
}

