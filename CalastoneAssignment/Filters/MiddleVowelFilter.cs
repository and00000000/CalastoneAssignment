using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalastoneAssignment.Filters
{
    public class MiddleVowelFilter : IFilter
    {
        private readonly char[] _vowels;

        public MiddleVowelFilter()
        {
            _vowels = new char[] { 'A', 'E', 'I', 'O', 'U'};
        }

        public bool FilterText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            //if length is more or equal to 3 - don't filter it
            if (text.Length >= 3)
            {
                bool evenLength = IsEvenLength(text);

                if (evenLength)
                {
                    // find the middle two letters for even letter words 

                    string midChars = text.Substring((text.Length / 2) - 1, 2);
                    // are either of the middle letters within the array of defined vowels
                    if (_vowels.Intersect(midChars.ToUpper().ToCharArray()).Count() > 0)
                    {
                        return true;
                    }                   
                }
                else
                {
                    // find middle letters for even letter words 
                    char midChar = char.ToUpper(char.Parse(text.Substring(text.Length / 2, 1)));
                    if (_vowels.Any(vowel => Equals(vowel, midChar)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsEvenLength(string text)
        {
            return text.Length % 2 == 0;
        }

    }
}
