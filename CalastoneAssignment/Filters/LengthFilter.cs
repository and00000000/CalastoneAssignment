using System;
using System.Collections.Generic;
using System.Text;

namespace CalastoneAssignment.Filters
{
    public class LengthFilter : IFilter
    {
        private readonly int _minLength;
        
        public LengthFilter(int minLength)
        {
            _minLength = minLength;
        }

        public bool FilterText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            //if text is shorter than the set minimum length, filter it 
            return text.Length < _minLength;
        }

       
    }
}
