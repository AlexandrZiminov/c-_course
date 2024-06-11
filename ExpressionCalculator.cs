namespace CalculatorExamples;

internal class Program
{
    private static void Main(string[] args)
    {
        var c = new Calc();
        // var exp = Console.ReadLine();
        var exp = "4+5-98+18+0-40";
        var ans = c.Calculate(exp);
        Console.WriteLine("Answer is {0}.", ans);
    }
}

internal class Calc
{
    public int Calculate(string exp)
    {
        var parseRes = int.TryParse(exp, out var firstNum);
        var listNums = new List<int>();
        var listSymbols = new List<char>();
        if (!parseRes)
        {
            var accumStr = "";
            for (var i = 0; i < exp.Length; i++)
            {
                var current = exp[i];
                var parseCharRes = int.TryParse(current.ToString(), out var unusedNum);

                if (parseCharRes)
                    accumStr += current;
                else
                    switch (current)
                    {
                        case '+':
                            var resInt = int.Parse(accumStr);
                            listNums.Add(resInt);
                            accumStr = "";
                            listSymbols.Add(current);
                            break;
                        case '-':
                            resInt = int.Parse(accumStr);
                            listNums.Add(resInt);
                            accumStr = "";
                            listSymbols.Add(current);
                            break;
                        default:
                            Console.WriteLine("Пытаешься наебать?");
                            break;
                    }

                if (i == exp.Length - 1)
                {
                    var resInt = int.Parse(accumStr);
                    listNums.Add(resInt);
                }
            }
        }
        else
        {
            Console.WriteLine("Какую операцию вы хотите сделать?");
            return firstNum;
        }
        
        var returnRes = listNums[0];
        for (var i = 0; i < listSymbols.Count(); i++)
            if (listSymbols[i] == '+')
                returnRes += listNums[i + 1];
            else
                returnRes -= listNums[i + 1];
        return returnRes;
    }
}