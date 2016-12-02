using Xunit;
using NumbersToWords.Objects;

namespace NumbersToWordsTest
{
    public class NumbersConvertedToWords
    {
        [Fact]
        public void NumbersConvertedToWords_NumberIs1_ReturnOne()
        {
            long input = 1;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("one", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs20_ReturnTwenty()
        {
            long input = 20;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("twenty", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs11_ReturnEleven()
        {
            long input = 11;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("eleven", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs111_ReturnOneHundredEleven()
        {
            long input = 111;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("one hundred eleven", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs1111_ReturnOneThousandOneHundredEleven()
        {
            long input = 1111;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("one thousand one hundred eleven", result);
        }
        [Fact]
        public void NumbersConvertedToWords_NumberIs29111111111111_ReturnAppropriateVeryLongWordNumber()
        {
            long input = 29111111111111;
            NumberConverter newConverter = new NumberConverter(input);
            string result = newConverter.Convert();
            Assert.Equal("twenty nine trillion one hundred eleven billion one hundred eleven million one hundred eleven thousand one hundred eleven", result);
        }
    }
}
