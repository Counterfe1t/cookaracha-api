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
    public void ChangeItemName_ItemNameIsInvalid_ShouldThrowException(string invalidName)
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
}