using Cookaracha.Core.Entities;
using Cookaracha.Core.Exceptions;
using Shouldly;

namespace Cookaracha.UnitTests.Entities;

public class ItemTests
{
    private const string ValidGuid = "4c386c8b-df4b-4fcc-9a77-b5e3f7fab967";

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("f")]
    [InlineData("item_name_longer_than_fifty_characters_should_throw_exception")]
    public void ChangeName_ItemNameIsInvalid_ShouldThrowException(string invalidName)
    {
        // arrange
        var item = new Item(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            Guid.NewGuid(),
            null,
            "dummy",
            1337,
            false);

        // act
        var exception = Record.Exception(() => item.ChangeName(invalidName));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidItemNameException>();
    }

    [Theory]
    [InlineData("DUMMY", "DUMMY")]
    [InlineData("Dummy", "Dummy")]
    [InlineData(" dummy ", "dummy")]
    [InlineData(" Dummy  Item List ", "Dummy Item List")]
    public void ChangeName_ItemNameIsValid_ShouldSanitizeAndChangeItemName(string newValue, string expectedValue)
    {
        // arrange
        var item = new Item(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            Guid.NewGuid(),
            null,
            "dummy",
            1337,
            false);

        // act
        item.ChangeName(newValue);

        // assert
        item.Name.Value.ShouldBe(expectedValue);
    }

    [Theory]
    [MemberData(nameof(ChangeProductIdTestData))]
    public void ChangeProductId_ProductIdIsValid_ShouldChangeProductId(Guid? productId, Guid? expectedValue)
    {
        // arrange
        var item = new Item(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            Guid.NewGuid(),
            null,
            "dummy",
            1337,
            false);

        // act
        item.ChangeProductId(productId);

        // assert
        Assert.Equal(expectedValue, item.ProductId?.Value);
    }

    [Fact]
    public void ChangeProductId_ProductIdIsInvalid_ShouldThrowException()
    {
        // arrange
        var invalidGuid = Guid.Empty;

        var item = new Item(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            Guid.NewGuid(),
            null,
            "dummy",
            1337,
            false);

        // act
        var exception = Record.Exception(() => item.ChangeProductId(invalidGuid));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidEntityIdException>();
    }

    [Fact]
    public void ChangeQuantity_QuantityIsValid_ShouldChangeQuantity()
    {
        // arrange
        var item = new Item(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            Guid.NewGuid(),
            null,
            "dummy",
            1337,
            false);

        // act
        item.ChangeQuantity(2137);
        
        // assert
        item.Quantity.Value.ShouldBe(2137);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void ChangeIsChecked_IsCheckedIsValid_ShouldChangeIsChecked(bool newValue)
    {
        // arrange
        var item = new Item(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            Guid.NewGuid(),
            null,
            "dummy",
            1337,
            false);

        // act
        item.ChangeIsChecked(newValue);

        // assert
        item.IsChecked.Value.ShouldBe(newValue);
    }

    #region TestData

    public static TheoryData<Guid?, Guid?> ChangeProductIdTestData = new()
    {
        { null, null },
        { Guid.Parse(ValidGuid), Guid.Parse(ValidGuid) }
    };

    #endregion
}