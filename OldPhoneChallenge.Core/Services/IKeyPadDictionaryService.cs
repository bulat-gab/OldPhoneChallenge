namespace OldPhoneChallenge.Core.Services;
public interface IKeyPadDictionaryService
{
    string MapPressesToLetter(char button, int pressedCount);
}
