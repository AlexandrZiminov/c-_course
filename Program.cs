// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");

namespace Base;

internal class Program
{
    private static void Main(string[] args)
    {
        var maxValue = 100000.0;
        var randInt = new Random().Next(0, 1000);
        var attempts = (int)Math.Ceiling(Math.Log2(maxValue));
        var currentGuess = Math.Ceiling(maxValue / 2);
        maxValue = Math.Ceiling(maxValue / 2);
        // var currentMin = 0.0;
        // var currentMax = maxValue;

        Console.WriteLine(
            $"I have an integer number from 0 to {maxValue}, you have {attempts} attempts, try to guess it");

        for (var i = 0; i < attempts; i++)
        {
            maxValue = Math.Ceiling(maxValue / 2);
            Console.WriteLine($"Is it {currentGuess}?");
            var res = randInt > currentGuess ? "greater" : "less";
            Console.WriteLine(currentGuess == randInt
                ? "You won!"
                : $"Try again! My number is {res}, attempts cont: {attempts - 1 - i}");
            if (currentGuess == randInt)
            {
                Console.WriteLine($"Nice! I used {i + 1}/{attempts} attempts");
                break;
            }
            if (res == "greater")
                currentGuess = currentGuess + maxValue;
            // currentGuess = Math.Ceiling(currentMax - (currentMax - currentGuess) / 2);
            // currentMin = currentMax - currentGuess;
            else if (res == "less")
                currentGuess = currentGuess - maxValue;
            // currentMax = currentGuess;
            // currentGuess = currentMin + Math.Ceiling((currentGuess - currentMin) / 2);
        }
    }
}