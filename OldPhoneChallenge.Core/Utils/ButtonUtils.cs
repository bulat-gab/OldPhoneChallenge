namespace OldPhoneChallenge.Core.Utils;
internal static class ButtonUtils
{
    public static bool IsSameAsNextButton(string input, int currentPosition)
    {
        ArgumentNullException.ThrowIfNull(nameof(input));

        if (currentPosition < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(currentPosition), "Current position cannot be negative.");
        }

        var currentButton = input[currentPosition];
        return currentPosition < input.Length - 1
            && currentButton == input[currentPosition + 1];
    }
}
