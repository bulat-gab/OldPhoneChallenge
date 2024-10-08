using FluentAssertions;
using OldPhoneChallenge.Core;
using OldPhoneChallenge.Core.Services;

namespace OldPhoneChallengeTaskTests;

public class OldPhonePadTests
{
    private readonly KeyPadDictionaryService _keyPadDictionary = new KeyPadDictionaryService();
    private readonly OldPhonePad _oldPhonePad;

    public OldPhonePadTests()
    {
        this._oldPhonePad = new OldPhonePad(_keyPadDictionary);
    }

    [Theory]
    [InlineData("222 2 22#", "CAB")]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")]
    [InlineData("11#", "")]
    [InlineData("2*#", "")]
    [InlineData("222*#", "")]
    [InlineData("3222*#", "D")]
    [InlineData("*2#", "A")]
    [InlineData("****#", "")]
    [InlineData("********#", "")]
    [InlineData("2222222222222222#", "A")]
    public void Convert_Test(string input, string expected)
    {
        // act
        var actual = this._oldPhonePad.Convert(input);

        // assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("")]
    [InlineData("           ")]
    [InlineData(null)]
    public void Convert_WhenEmptyInput_ShouldThrow_ArgumentNullException(string input)
    {
        // act
        var action = () => this._oldPhonePad.Convert(input);

        // assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .Where(e => e.Message.Contains("Input string cannot be null or white space."));
    }

    [Theory]
    [InlineData("222 333")]
    public void Convert_WhenInputDoesNotEndWithHash_ShouldThrow_FormatException(string input)
    {
        // act
        var action = () => this._oldPhonePad.Convert(input);

        // assert
        action.Should()
            .ThrowExactly<FormatException>()
            .Where(e => e.Message.Contains("Input string must contain '#' character at the end."));
    }

    [Theory]
    [InlineData("222 AB 333#")]
    public void Convert_WhenInputContainsInvalidCharacters_ShouldThrow_FormatException(string input)
    {
        // act
        var action = () => this._oldPhonePad.Convert(input);

        // assert
        action.Should()
            .ThrowExactly<FormatException>()
            .Where(e => e.Message.Contains("is not allowed"));
    }
}