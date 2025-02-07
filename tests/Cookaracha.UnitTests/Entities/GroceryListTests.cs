using Cookaracha.Core.Entities;
using Cookaracha.Core.Exceptions;
using Shouldly;

namespace Cookaracha.UnitTests.Entities;

public class GroceryListTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("f")]
    [InlineData("grocery_list_name_longer_than_fifty_characters_should_throw_exception")]
    public void ChangeGroceryListName_GroceryListNameIsInvalid_ShouldThrowException(string invalidName)
    {
        // arrange
        var groceryList = new GroceryList(Guid.NewGuid(), "dummy");

        // act
        var exception = Record.Exception(() => groceryList.ChangeGroceryListName(invalidName));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidGroceryListNameException>();
    }

    [Theory]
    [InlineData("DUMMY", "DUMMY")]
    [InlineData("Dummy", "Dummy")]
    [InlineData(" dummy ", "dummy")]
    [InlineData(" Dummy  Grocery List ", "Dummy Grocery List")]
    public void ChangeGroceryListName_GroceryListNameIsValid_ShouldSanitizeAndChangeGroceryListName(string newValue, string expectedValue)
    {
        // arrange
        var groceryList = new GroceryList(Guid.NewGuid(), "dummy");

        // act
        groceryList.ChangeGroceryListName(newValue);

        // assert
        groceryList.Name.Value.ShouldBe(expectedValue);
    }
}