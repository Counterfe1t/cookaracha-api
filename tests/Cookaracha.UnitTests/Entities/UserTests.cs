using Cookaracha.Core.Entities;
using Cookaracha.Core.Exceptions;
using Shouldly;

namespace Cookaracha.UnitTests.Entities;

public class UserTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("f")]
    [InlineData("user_name_longer_than_fifty_characters_should_throw_exception")]
    public void ChangeName_UserNameIsInvalid_ShouldThrowException(string invalidName)
    {
        // arrange
        var User = new User(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            "dummy user name",
            "dummy@cookaracha.net",
            "dummy password");

        // act
        var exception = Record.Exception(() => User.ChangeName(invalidName));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidUserNameException>();
    }

    [Theory]
    [InlineData("DUMMY", "DUMMY")]
    [InlineData("Dummy", "Dummy")]
    [InlineData(" dummy ", "dummy")]
    [InlineData(" Dummy  User Name ", "Dummy User Name")]
    public void ChangeName_UserNameIsValid_ShouldSanitizeAndChangeUserName(string newValue, string expectedValue)
    {
        // arrange
        var User = new User(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            "dummy username",
            "dummy@cookaracha.net",
            "dummy password");

        // act
        User.ChangeName(newValue);

        // assert
        User.Name.Value.ShouldBe(expectedValue);
    }
}