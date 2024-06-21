using Xunit;

namespace workout.tests
{
    public class DetectBlobsTest
    {
        [Theory]
        [InlineData(new string[] { "0110" }, 0, 1)]
        [InlineData(new string[] { "0110", "0000", "1000", "1000" }, 0, 2)]
        public void ShouldDetectBlob(string[] data, int minSize, int expected)
        {
            Assert.Equal(expected, DetectBlobsSolutionOne.Solution(data, minSize));
        }

        [Theory]
        [InlineData(new string[] { "0110" }, 3, 0)]
        [InlineData(new string[] { "0110", "0000", "1000", "0001" }, 2, 1)]
        public void ShouldDetectBlobAlt(string[] data, int minSize, int expected)
        {
            Assert.Equal(expected, DetectBlobsSolutionTwo.Solution(data, minSize));
        }
    }
}