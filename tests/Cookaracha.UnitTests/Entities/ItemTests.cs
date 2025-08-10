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
        exception.ShouldBeOfType<InvliadItemNameException>();
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


    #region TestData

    public static TheoryData<Guid?, Guid?> ChangeProductIdTestData = new()
    {
        { null, null },
        { Guid.Parse(ValidGuid), Guid.Parse(ValidGuid) }
    };

    #endregion
}