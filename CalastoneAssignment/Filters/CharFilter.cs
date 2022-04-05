using System;
using System.Collections.Generic;
using System.Text;

namespace CalastoneAssignment.Filters
{
    public class CharFilter : IFilter
    {
        private readonly char _character;
        public CharFilter(char character)
        {
            _character = character;
        }
        public bool FilterText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            } 
            //convert both strings to uppercase and then compare
            return (text.ToUpper().Contains(Char.ToUpper(_character)));
        }
    }
}

