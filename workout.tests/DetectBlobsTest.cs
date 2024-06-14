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
            Assert.Equal(expected, DetectBlobs.Solution(data, minSize));
        }
    }
}