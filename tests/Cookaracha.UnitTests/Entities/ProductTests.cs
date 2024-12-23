using Cookaracha.Core.Entities;
using Cookaracha.Core.Exceptions;
using Shouldly;

namespace Cookaracha.UnitTests.Entities;

public class ProductTests
{
    [Theory]
    [InlineData("")]
    [InlineData("product_name_longer_than_fifty_characters_should_throw_exception")]
    public void ChangeProductName_ProductNameIsInvalid_ShouldThrowException(string invalidName)
    {
        // arrange
        var product = new Product(Guid.NewGuid(), "dummy");

        // act
        var exception = Record.Exception(() => product.ChangeProductName(invalidName));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidProductNameException>();
    }

    [Fact]
    public void ChangeProductName_ProductNameIsValid_ShouldChangeProductName()
    {
        // arrange
        var product = new Product(Guid.NewGuid(), "foo");
        var newProductName = "bar";

        // act
        product.ChangeProductName(newProductName);

        // assert
        product.Name.Value.ShouldBe(newProductName);
    }
}