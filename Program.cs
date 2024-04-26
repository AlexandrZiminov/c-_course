namespace Base;

internal class Program
{
    private static void Main(string[] args)
    {
        var maxValue = 100000.0;
        var randInt = new Random().Next(0, (int)maxValue);
        var attempts = (int)Math.Ceiling(Math.Log2(maxValue));
        var currentGuess = Math.Ceiling(maxValue / 2);
        var step = Math.Ceiling(maxValue / 2);

        Console.WriteLine(
            $"I have an integer number from 0 to {maxValue}, you have {attempts} attempts, try to guess it");

        for (var i = 0; i < attempts; i++)
        {
            step = Math.Ceiling(step / 2);
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
                currentGuess = currentGuess + step;

            else if (res == "less")
                currentGuess = currentGuess - step;
        }
    }
}