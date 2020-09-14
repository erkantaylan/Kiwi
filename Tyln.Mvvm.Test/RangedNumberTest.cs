using Xunit;

namespace Tyln.Mvvm.Test
{
    public class RangedNumberTest
    {
        [Fact]
        public void FixToMaximum()
        {
            const int minimum = 0;
            const int maximum = 5;
            const int value = 2;
            var number = new RangedNumber<int>(minimum, maximum, value);
            number.Value = 10;
            Assert.Equal(number.Value, maximum);
        }

        [Fact]
        public void FixToMinimum()
        {
            const int minimum = 0;
            const int maximum = 5;
            const int value = 2;
            var number = new RangedNumber<int>(minimum, maximum, value);
            number.Value = -10;
            Assert.Equal(number.Value, minimum);
        }

        [Fact]
        public void MinimumBiggerThanMaximum()
        {
            Assert.Throws<MinimumIsBiggerThanMaximumException>(() =>
            {
                var _ = new RangedNumber<int>
                {
                    Maximum = 0, 
                    Minimum = 10
                };
            });
        }
    }
}