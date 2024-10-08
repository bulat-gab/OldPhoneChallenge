using System.Text;

namespace OldPhoneChallenge.Core.Extensions;

internal static class StringBuilderExtensions
{
    public static void RemoveLastCharacter(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder, nameof(stringBuilder));

        if (stringBuilder.Length > 0)
        {
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }
    }
}
