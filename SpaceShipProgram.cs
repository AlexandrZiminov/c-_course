// using System.Text.Json;
//
// namespace Base;
//
// public class Program
// {
//     private static async Task Main(string[] args)
//     {
//         var tasks = new List<Task>();
//         for (int i = 0; i < 1; i++)
//         {
//             tasks.Add(FindBalance());
//         }
//
//         await Task.WhenAny(tasks);
//     }
//
//     private static async Task FindBalance()
//     {
//         await Task.Delay(1);
//         var count = 0L;
//         var alreadyChecked = new List<(BaseShip, BaseShip)>();
//         while (true)
//         {
//             var fightList = new List<FightResult>();
//             var ship1 = RandomVoyadger();
//             var ship2 = RandomBibop();
//
//
//             if (alreadyChecked.Any(x => x.Item1.Equals(ship1) && x.Item2.Equals(ship2)))
//             {
//                 continue;
//             }
//
//             for (var i = 0; i < 10000; i++)
//             {
//                 var ship1Copy = new Voyadger
//                 {
//                     BaseDamage = ship1.BaseDamage,
//                     HP = ship1.HP,
//                     Shield = ship1.Shield,
//                     VisionRange = ship1.VisionRange,
//                     VisibilityRange = ship1.VisibilityRange
//                 };
//
//                 var ship2Copy = new Bibop
//                 {
//                     BaseDamage = ship2.BaseDamage,
//                     HP = ship2.HP,
//                     Shield = ship2.Shield,
//                     VisionRange = ship2.VisionRange,
//                     VisibilityRange = ship2.VisibilityRange
//                 };
//
//                 var arbiter = new FightArbiter(ship1Copy, ship2Copy);
//                 arbiter.Fight();
//
//                 BaseShip winner = ship1Copy.HP > 0 ? ship1Copy : ship2Copy;
//
//                 fightList.Add(new FightResult { Winner = winner });
//             }
//
//             var voyadgerWins = fightList.Count(x => x.Winner is Voyadger);
//             var bibopWins = fightList.Count(x => x.Winner is Bibop);
//
//             var chance = (double)voyadgerWins / (voyadgerWins + bibopWins);
//             count++;
//
//             if (chance is <= 0.1 or >= 0.9)
//             {
//                 alreadyChecked.Add((ship1, ship2));
//                 continue;
//             }
//
//             Console.WriteLine($"Count: {count}");
//             Console.WriteLine($"Voyadger wins: {voyadgerWins}");
//             Console.WriteLine($"Bibop wins: {bibopWins}");
//             Console.WriteLine($"Chance: {chance}");
//
//             var voyadger = JsonSerializer.Serialize(ship1, new JsonSerializerOptions()
//             {
//                 WriteIndented = true
//             });
//
//             var bibop = JsonSerializer.Serialize(ship2, new JsonSerializerOptions()
//             {
//                 WriteIndented = true
//             });
//
//             Console.WriteLine(voyadger);
//             Console.WriteLine(bibop);
//
//             break;
//         }
//     }
//
//     public static Voyadger RandomVoyadger()
//     {
//         var random = new Random();
//
//         return new Voyadger
//         {
//             HP = random.Next(1000, 2000),
//             Shield = random.Next(1000, 2000),
//             BaseDamage = random.Next(30, 200)
//         };
//
//     }
//     
//     public static Bibop RandomBibop()
//     {
//         var random = new Random();
//
//         return new Bibop
//         {
//             HP = random.Next(500, 1000),
//             Shield = random.Next(500, 1000),
//             BaseDamage = random.Next(30, 350)
//         };
//     }
//     
//     public class FightResult
//     {
//         public BaseShip Winner { get; set; }
//     }
//     
// }
//

