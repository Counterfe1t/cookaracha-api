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

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("f")]
    [InlineData("invalid@email")]
    [InlineData("email_name_longer_than_fifty_characters_should_throw_exception")]
    public void ChangeEmail_EmailIsInvalid_ShouldThrowException(string invalidEmail)
    {
        // arrange
        var User = new User(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            "dummy user name",
            "dummy@cookaracha.net",
            "dummy password");

        // act
        var exception = Record.Exception(() => User.ChangeEmail(invalidEmail));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidEmailException>();
    }

    [Theory]
    [InlineData("valid@email.address", "valid@email.address")]
    [InlineData("VALID@EMAIL.ADDRESS", "valid@email.address")]
    public void ChangeEmail_EmailIsValid_ShouldSanitizeAndChangeUserEmail(string newValue, string expectedValue)
    {
        // arrange
        var User = new User(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            "dummy username",
            "dummy@cookaracha.net",
            "dummy password");

        // act
        User.ChangeEmail(newValue);

        // assert
        User.Email.Value.ShouldBe(expectedValue);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("short")]
    [InlineData("password_name_longer_than_two_hundred_characters_should_throw_exception_8c4bca6068d442dc928f7344f13ada60ce0a8858203b47c18a943bd6cdb44f7b2fb7afa6ced14e7c8f588f3d251e8f3a7aa1e39074084827aa1e3907408482abb")]
    public void ChangePassword_PasswordIsInvalid_ShouldThrowException(string invalidPassword)
    {
        // arrange
        var User = new User(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            "dummy user name",
            "dummy@cookaracha.net",
            "dummy password");

        // act
        var exception = Record.Exception(() => User.ChangePassword(invalidPassword));

        // assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidPasswordException>();
    }

    [Fact]
    public void ChangePassword_PasswordIsValid_ShouldSanitizeAndChangeUserPassword()
    {
        // arrange
        var expectedValue = "valid_password";
        var User = new User(
            Guid.NewGuid(),
            DateTimeOffset.UtcNow,
            "dummy username",
            "dummy@cookaracha.net",
            "dummy password");

        // act
        User.ChangePassword(expectedValue);

        // assert
        User.Password.Value.ShouldBe(expectedValue);
    }
}