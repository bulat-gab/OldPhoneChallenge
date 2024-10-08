namespace OldPhoneChallenge.Core.Services;
public class KeyPadDictionaryService : IKeyPadDictionaryService
{
    private static readonly Dictionary<char, string> _Mapping = new()
    {
        { '1', "" },
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '*', "" },
        { '0', "" },
        { '#', "" },
    };


    public string MapPressesToLetter(char button, int pressedCount)
    {
        var letters = _Mapping[button];
        int lettersCount = letters.Length;
        if (lettersCount == 0)
        {
            return "";
        }

        var actualLetter = letters[pressedCount % lettersCount];
        return actualLetter.ToString();
    }
}
