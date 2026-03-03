using System.IO;
using System.Numerics;
int ToIntClamped(BigInteger x)
{
    if (x < int.MinValue) return int.MinValue;
    if (x > int.MaxValue) {
        Console.WriteLine("Integer overflow going to 32 bit integer limit");
        return int.MaxValue;
    }
    return (int)x;
}

char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+-={}[]\\|:\";'<>,./?~`".ToCharArray();

var x = 1;
Random rnd = new Random();

Console.Write("Minimum: ");
string? minString = Console.ReadLine();
if(string.IsNullOrWhiteSpace(minString) || !BigInteger.TryParse(minString, out _)) {
    Console.WriteLine("Next time enter 0 for no minimum.");
    System.Environment.Exit(1);
}
BigInteger min = BigInteger.Parse(minString);
Console.Write("Maximum: ");
string? maxString = Console.ReadLine();
if(string.IsNullOrWhiteSpace(maxString) || !BigInteger.TryParse(maxString, out _)) {
    Console.WriteLine("Next time enter 0 for no maximum.");
    System.Environment.Exit(1);
}
BigInteger max = BigInteger.Parse(maxString);

var y = rnd.Next(ToIntClamped(min),ToIntClamped(max));

//var y = rnd.Next(567123); 
//var y = rnd.Next(100); 
Console.WriteLine(y);
List<String> array = new List<String>();
string appendTmp = "";
while(x < y) {
    foreach (var i in alpha) {
        appendTmp += $"{i}{x}";
    }
    array.Add(appendTmp);
    appendTmp = "";
    x++;
}

Console.Write("Filename: ");
string? name = Console.ReadLine();
if(string.IsNullOrWhiteSpace(name)) {Console.WriteLine("Unable to write to a blank file"); System.Environment.Exit(1);}
File.WriteAllLines(name, array);
