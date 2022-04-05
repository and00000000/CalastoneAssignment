using CalastoneAssignment.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalastoneAssignment.Tests
{
    public class MiddleVowelFilterTests
    {
        [Fact]
        public void ContainsMidVowelUpperAndLowerCaseInput_ReturnsTrue()
        {
            IFilter midVowel = new MiddleVowelFilter();
            Assert.True(midVowel.FilterText("what"));
            Assert.True(midVowel.FilterText("currently"));
            Assert.True(midVowel.FilterText("WHAT"));
            Assert.True(midVowel.FilterText("CURRENTLY"));
        }

        [Fact]
        public void DoesntContainMidVowelUpperAndLowerCaseInput_ReturnsFalse()
        {
            IFilter midVowelFilter = new MiddleVowelFilter();
            Assert.False(midVowelFilter.FilterText("the"));
            Assert.False(midVowelFilter.FilterText("rather"));
            Assert.False(midVowelFilter.FilterText("THE"));
            Assert.False(midVowelFilter.FilterText("RATHER"));
        }

        [Fact]
        public void InputNullOrWhiteSpace_ReturnsFalse()
        {
            IFilter midVowelFilter = new MiddleVowelFilter();

            Assert.False(midVowelFilter.FilterText(null));
            Assert.False(midVowelFilter.FilterText(" "));
        }
    }
}
