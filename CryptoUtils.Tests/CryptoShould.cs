using Xunit;

namespace CryptoUtils.Tests
{
    public class CryptoShould
    {
        private readonly Crypto _crypto;

        public CryptoShould()
        {
            _crypto = new Crypto();
        }

        [Fact]
        public void HashPassword()
        {
            var plainTextPassword = "test1234";

            var hashedPassword = _crypto.HashPassword(plainTextPassword);

            Assert.IsType<string>(hashedPassword);
            Assert.False(string.IsNullOrEmpty(hashedPassword));
            Assert.False(plainTextPassword.Equals(hashedPassword));
        }

        [Fact]
        public void VerifyMatchingPassword()
        {
            var plainTextPassword = "test1234";

            var hashedPassword = _crypto.HashPassword(plainTextPassword);

            Assert.True(_crypto.IsMatchPassword(plainTextPassword, hashedPassword));
        }

        [Fact]
        public void SetStandardHashWorkFactor()
        {
            var sut = new Crypto();

            Assert.Equal(Crypto.StandardHashWorkFactor, sut.HashWorkFactor);
        }

        [Fact]
        public void AllowCustomHashWorkFactor()
        {
            var sut = new Crypto();
            ushort customFactor = 13;

            sut.HashWorkFactor = customFactor;

            Assert.Equal(customFactor, sut.HashWorkFactor);
        }

        [Fact]
        public void IgnoreZeroHashWorkFactor()
        {
            var sut = new Crypto();

            sut.HashWorkFactor = 0;

            Assert.Equal(Crypto.StandardHashWorkFactor, sut.HashWorkFactor);
        }
    }
}
