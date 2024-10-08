using System.Text;
using OldPhoneChallenge.Core.Extensions;
using OldPhoneChallenge.Core.Services;
using OldPhoneChallenge.Core.Utils;

namespace OldPhoneChallenge.Core;

public class OldPhonePad
{
    private const string ValidCharacters = "123456789*# ";

    private readonly IKeyPadDictionaryService keyPadDictionary;

    public OldPhonePad(IKeyPadDictionaryService keyPadDictionary)
    {
        this.keyPadDictionary = keyPadDictionary;
    }

    public string Convert(string input)
    {
        EnsureValidInput(input);

        var outputStringBuilder = new StringBuilder();
        var pressCount = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var currentButton = input[i];

            if (currentButton == '#')
            {
                return outputStringBuilder.ToString();
            }
            if (currentButton == ' ')
            {
                pressCount = 0;
                continue;
            }
            if (currentButton == '*')
            {
                outputStringBuilder.RemoveLastCharacter();
                continue;
            }
            if (ButtonUtils.IsSameAsNextButton(input, i))
            {
                pressCount += 1;
                continue;
            }

            var nextLetter = keyPadDictionary.MapPressesToLetter(currentButton, pressCount);
            outputStringBuilder.Append(nextLetter);
            pressCount = 0;
        }
        return outputStringBuilder.ToString();
    }

    private static void EnsureValidInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input), "Input string cannot be null or white space.");
        }

        if (input[^1] != '#')
        {
            throw new FormatException("Input string must contain '#' character at the end.");
        }

        foreach (var c in input)
        {
            if (!ValidCharacters.Contains(c))
            {
                throw new FormatException($"Character {c} is not allowed.");
            }
        }
    }
}
