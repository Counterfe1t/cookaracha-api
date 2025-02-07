using Cookaracha.Core.Entities;
using Cookaracha.Core.Exceptions;
using Shouldly;

namespace Cookaracha.UnitTests.Entities;

public class ProductTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("f")]
    [InlineData("product_name_longer_than_fifty_characters_should_throw_exception")]
    public void ChangeProductName_ProductNameIsInvalid_ShouldThrowException(string invalidName)
    {
        // arrange
        var product = new Product(Guid.NewGuid(), "dummy", DateTimeOffset.UtcNow);

        // act
        var exception = Record.Exception(() => product.ChangeProductName(invalidName));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidProductNameException>();
    }

    [Theory]
    [InlineData("DUMMY", "dummy")]
    [InlineData("Dummy", "dummy")]
    [InlineData(" dummy ", "dummy")]
    [InlineData(" Dummy  Product ", "dummy product")]
    public void ChangeProductName_ProductNameIsValid_ShouldSanitizeAndChangeProductName(string newValue, string expectedValue)
    {
        // arrange
        var product = new Product(Guid.NewGuid(), "dummy", DateTimeOffset.UtcNow);

        // act
        product.ChangeProductName(newValue);

        // assert
        product.Name.Value.ShouldBe(expectedValue);
    }
}