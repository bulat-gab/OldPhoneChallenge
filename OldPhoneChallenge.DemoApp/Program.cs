using OldPhoneChallenge.Core;
using OldPhoneChallenge.Core.Services;

var keyPadService = new KeyPadDictionaryService();
var oldPhonePad = new OldPhonePad(keyPadService);
string input = "222 2 22#";
string output = oldPhonePad.Convert(input);

Console.WriteLine($"Input string: {input}");
Console.WriteLine($"Converted output: {output}");