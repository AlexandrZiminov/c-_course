namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        var c = new Calc();
        var exp1 = Console.ReadLine();
        var exp2 = Console.ReadLine();
        var ans = c.Calculate(exp1, exp2);
        Console.WriteLine("Answer is {0}.", ans);
        Console.ReadLine();
    }
}

internal class Calc
{
    public int Calculate(string exp1, string exp2)
    {
        return int.Parse(exp1) + int.Parse(exp2);
    }
}