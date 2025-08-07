using Cookaracha.Core.Entities;
using Cookaracha.Core.Exceptions;
using Shouldly;

namespace Cookaracha.UnitTests.Entities;

public class ItemTests
{
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
}