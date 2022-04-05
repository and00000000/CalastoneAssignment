using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalastoneAssignment.Readers
{
    public class TextFileReader : IFileReader
    {
        private string _filepath { get; set; }

        public TextFileReader(string filepath)
        {
            _filepath = filepath;
            
        }

        public IEnumerable<string> ReadLines()
        {

            //if file doesn't exist throw exception
            if (FileExists(_filepath))
            { 
                //else read only one line at the time 
                using (StreamReader reader = File.OpenText(_filepath))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }

        public bool FileExists(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException(filepath, "File not found in directory : " + filepath);
            }
            return true;

        }

    }
}



