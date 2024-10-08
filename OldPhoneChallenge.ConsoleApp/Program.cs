using System.CommandLine;
using System.CommandLine.Invocation;
using OldPhoneChallenge.Core;
using OldPhoneChallenge.Core.Services;

var keyPadService = new KeyPadDictionaryService();
var oldPhonePad = new OldPhonePad(keyPadService);

var numbersArg = new Argument<string>("numbers", "The sequence of numbers in quotes to convert. Example: \"222 33#\"");
var rootCommand = new RootCommand("Old Phone Pad Converter command-line app")
{
    numbersArg
};
rootCommand.SetHandler((InvocationContext context) =>
{
    var numbers = context.ParseResult.GetValueForArgument(numbersArg);
    Console.WriteLine($"Converting: {numbers}\n");
    try
    {
        var result = oldPhonePad.Convert(numbers);
        Console.WriteLine($"Result: {result}");
    }
    catch (FormatException e)
    {
        Console.WriteLine($"Invalid format: {e.Message}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception occured: {e.Message}");
    }
    finally
    {
        Environment.Exit(0);
    }
});

await rootCommand.InvokeAsync(args);