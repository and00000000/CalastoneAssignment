using CalastoneAssignment.Filters;
using CalastoneAssignment.Processors;
using CalastoneAssignment.Readers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CalastoneAssignment.Tests
{
    public class TextFilteringProcessorTests
    {

        [Fact]
        public void ApplyFilters_ReturnsTrue()
        {
            IEnumerable<string> textFileLines = new List<string>()
            {
                "I am writing some text to test the TextProcessor with maybe it will work, this is the first line.",
                "And here comes the second line with some more stuff.",
                "Third line added as well.",
                "Lastly fourth line to finish off with."
            };

            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(r => r.ReadLines()).Returns(textFileLines);

            List<string> lines = mockFileReader.Object.ReadLines().ToList();

            List<IFilter> filters = new List<IFilter> { new CharFilter('T'), new LengthFilter(3), new MiddleVowelFilter() };
            TextFilteringProcessor textProcessor = new TextFilteringProcessor(mockFileReader.Object, filters);

            textProcessor.Process();
            Assert.Equal("maybe , . And comes . added . off .", textProcessor.Output);
        }
    }

}
