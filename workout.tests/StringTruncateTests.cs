using Xunit;

namespace workout.tests
{
    public class StringTruncateTests
    {
        [Theory]
        [InlineData("There is an animal with four legs", 15, "There is an ...")]
        [InlineData("Hello there", 5, "...")]
        [InlineData("I saw an unicorn", 16, "I saw an unicorn")]
        public void ShouldTruncateMessage(string message, int limit, string expected)
        {
            Assert.Equal(expected, StringTruncate.Solution(message, limit));
        }
    }
}
