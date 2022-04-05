using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalastoneAssignment;
using Xunit;
using CalastoneAssignment.Filters;

namespace CalastoneAssignment.Tests
{
    public class LengthFilterTests
    {

        [Fact]
        public void Filter_validates_params()
        {
            var sut = new CharFilter('t');

            Assert.Throws<ArgumentNullException>(() => sut.Filter(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Filter(" "));
        }

    }
}
