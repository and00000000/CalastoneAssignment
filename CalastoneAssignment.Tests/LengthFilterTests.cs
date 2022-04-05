using CalastoneAssignment.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalastoneAssignment.Tests
{
    public class LengthFilterTests
    {
        [Fact]
        public void ShorterThanMinimumLength_ReturnsTrue()
        {
            IFilter lengthFilter = new LengthFilter(5);
            Assert.True(lengthFilter.FilterText("kite"));
        }

        [Fact]
        public void LongerThanMinimumLength_ReturnsFalse()
        {
            IFilter lengthFilter = new LengthFilter(5);
            Assert.False(lengthFilter.FilterText("telephone"));
        }

        [Fact]
        public void EqualToMinimumLength_ReturnsFalse()
        {
            IFilter lengthFilter = new LengthFilter(5);
            Assert.False(lengthFilter.FilterText("apple"));
        }

        [Fact]
        public void InputNullOrWhiteSpace_ReturnsFalse()
        {
            IFilter lengthFilter = new LengthFilter(5);

            Assert.False(lengthFilter.FilterText(null));
            Assert.False(lengthFilter.FilterText(" "));
            Assert.False(lengthFilter.FilterText(""));

        }

    }
}
