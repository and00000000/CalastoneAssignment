using System;
using System.Collections.Generic;
using System.Text;

namespace CalastoneAssignment.Readers
{
    public interface IFileReader
    {
        public IEnumerable<string> ReadLines();

        public bool FileExists(string filepath);
    }
}
