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
        [Fact]
        public void NumbersConvertedToWords_NumberIs20_ReturnTwenty()
        {
            int input = 20;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("twenty", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs11_ReturnEleven()
        {
            int input = 11;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("eleven", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs111_ReturnOneHundredEleven()
        {
            int input = 111;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("one hundred eleven", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs1111_ReturnOneThousandOneHundredEleven()
        {
            int input = 1111;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("one thousand one hundred eleven", result);
        }
    }
}
