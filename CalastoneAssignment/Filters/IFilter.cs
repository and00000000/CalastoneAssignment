using System;
using System.Collections.Generic;
using System.Text;

namespace CalastoneAssignment.Filters
{
    public interface IFilter
    {
        bool FilterText(string text);
    }
}
