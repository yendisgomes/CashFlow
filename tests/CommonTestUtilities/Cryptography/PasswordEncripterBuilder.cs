using CashFlow.Domain.Security.Crryptography;
using Moq;

namespace CommonTestUtilities.Cryptography
{
    public class PasswordEncripterBuilder
    {
        public static IPasswordEncripter Build()
        {
            var mock = new Mock<IPasswordEncripter>();
            mock.Setup(config => config.Encrypt(It.IsAny<string>())).Returns("!#$r%^&$!a");
            return mock.Object;
        }
    }
}
