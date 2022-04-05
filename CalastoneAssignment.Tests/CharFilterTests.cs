using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CalastoneAssignment.Filters;

namespace CalastoneAssignment.Tests
{
    public class CharFilterTests
    {      
        [Fact]
        public void ContainsUpperLowerCaseChar_ReturnsTrue()
        {
            IFilter charFilter = new CharFilter('t');
            Assert.True(charFilter.FilterText("telephone"));
            Assert.True(charFilter.FilterText("TELEPHONE"));

            IFilter charFilter2 = new CharFilter('T');
            Assert.True(charFilter2.FilterText("telephone"));
            Assert.True(charFilter2.FilterText("TELEPHONE"));
        }

        [Fact]
        public void NumberChar_ReturnsTrue()
        {
            IFilter charFilter = new CharFilter('3');
            Assert.True(charFilter.FilterText("948311"));
            Assert.True(charFilter.FilterText("jehfe3bdf"));
        }

        [Fact]
        public void DoesntContainUpperLowerCaseChar_ReturnsFalse()
        {
            IFilter charFilter = new CharFilter('a');
            Assert.False(charFilter.FilterText("telephone"));
            Assert.False(charFilter.FilterText("TELEPHONE"));

            IFilter charFilter2 = new CharFilter('A');
            Assert.False(charFilter2.FilterText("telephone"));
            Assert.False(charFilter2.FilterText("TELEPHONE"));
        }

        [Fact]
        public void InputNullOrWhiteSpace_ReturnsFalse()
        {
           IFilter charFilter = new CharFilter('A');

           Assert.False(charFilter.FilterText(null));
           Assert.False(charFilter.FilterText(" "));
        }

    }
}
