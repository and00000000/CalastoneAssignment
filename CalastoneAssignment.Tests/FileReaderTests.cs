using CalastoneAssignment.Readers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.IO;
using System.Collections;
using System.Linq;

namespace CalastoneAssignment.Tests
{
    public class FileReaderTests
    {
       
        [Fact]
        public void FileDoesntExist_ReturnsException()
        {
            String filepath = @"D:\inputNotFound.txt";
            var fr = new TextFileReader(filepath);
            Assert.Throws<FileNotFoundException>(() => fr.FileExists(filepath));
        }


        [Fact]
        public void FileExists_ReturnsTrue()
        {
            IEnumerable<string> inputLines = new List<string>()
            {
                "I am writing some text to test the TextProcessor with maybe it will work, this is the first line.",
                "And here comes the second line with some more stuff.",
                "Third line added as well.",
                "Lastly fourth line to finish off with."
            };

            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(r => r.ReadLines()).Returns(inputLines);

            List<string> lines = mockFileReader.Object.ReadLines().ToList();

            Assert.Equal(4, lines.Count());
            Assert.Equal("I am writing some text to test the TextProcessor with maybe it will work, this is the first line.", lines[0]);
            Assert.Equal("Lastly fourth line to finish off with.", lines[3]);

        }
    }
}
