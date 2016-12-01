using Xunit;
using NumbersToWords.Objects;

namespace NumbersToWordsTest
{
    public class NumbersConvertedToWords
    {
        [Fact]
        public void NumbersConvertedToWords_NumberIs1_ReturnOne()
        {
            int input = 1;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("one", result);
        }
    }
}
