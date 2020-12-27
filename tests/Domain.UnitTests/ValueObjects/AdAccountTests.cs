using Xunit;
using FluentAssertions;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.UnitTests.ValueObjects
{
    public class AdAccountTests
    {
        [Fact]
        public void ShouldHaveCorrectDomainAndName()
        {
            const string accountString = "RCN\\Emmy";
            
            var account = AdAccount.For(accountString);
            account.Domain.Should().Be("RCN");
            account.Name.Should().Be("Emmy");
        }

        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const string accountString = "RCN\\Emmy";
            var account = AdAccount.For(accountString);

            var result = account.ToString();
            result.Should().Be(accountString);
        }

        [Fact]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string accountString = "RCN\\Emmy";
            var account = AdAccount.For(accountString);
            
            string result = account;
            result.Should().Be(accountString);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            const string accountString = "RCN\\Emmy";
            
            var account = (AdAccount)accountString;
            account.Domain.Should().Be("RCN");
            account.Name.Should().Be("Emmy");
        }

        [Fact]
        public void ShouldThrowAdAccountInvalidExceptionForInvalidAdAccount()
        {
            FluentActions.Invoking(() => (AdAccount)"RCNEmmy")
                .Should().Throw<AdAccountInvalidException>();
        }
    }
}