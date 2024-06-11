// namespace Base;
//
// public class FightArbiter
// {
//     private readonly BaseShip _first;
//     private readonly BaseShip _second;
//
//     private static Random _rand = new Random();
//
//     public FightArbiter(BaseShip first, BaseShip second)
//     {
//         _first = first;
//         _second = second;
//     }
//
//     private (bool vision, bool fight) AttackTick(BaseShip a, BaseShip b, bool discovery)
//     {
//         var damage = _rand.Next(a.BaseDamage / 2, a.BaseDamage + a.BaseDamage / 2 + 1);
//         if (!discovery)
//         {
//             var vision = a.VisionRange >= b.VisionRange;
//             if (!vision)
//             {
//                 return (false, false);
//             }
//         }
//
//         var instaDeath = damage > b.Shield + b.HP;
//         if (instaDeath)
//         {
//             b.Shield = 0;
//             b.HP = 0;
//             return (true, true);
//         }
//
//         var availableShield = b.Shield - damage;
//         if (availableShield >= 0)
//         {
//             b.Shield = availableShield;
//             b.IncomeDamage(damage, 0);
//             return (true, true);
//         }
//
//         b.Shield = 0;
//         var hpDamage = 0 - availableShield;
//         var hpAvailable = b.HP - hpDamage;
//         if (hpAvailable <= 0)
//         {
//             b.HP = 0;
//             return (true, true);
//         }
//
//         b.HP = hpAvailable;
//         b.IncomeDamage(0, hpDamage);
//         return (true, true);
//     }
//
//     public void Fight()
//     {
//         var random = new Random();
//         var b = random.Next(0, 1000);
//         var firstAttack = b % 2 == 0;
//
//         var attackOrder = firstAttack;
//         var firstAttackHappened = false;
//
//         while (_first.HP >= 0 && _second.HP >= 0)
//         {
//             if (attackOrder)
//             {
//                 firstAttackHappened = FightTick(firstAttackHappened, _first, _second);
//             }
//             else
//             {
//                 firstAttackHappened = FightTick(firstAttackHappened, _second, _first);
//             }
//
//             attackOrder = !attackOrder;
//             
//             _first.HP -= 1;
//             _second.HP -= 1;
//         }
//     }
//
//     private bool FightTick(bool firstAttackHappened, BaseShip first, BaseShip second)
//     {
//         var (vision, fight) = AttackTick(first, second, firstAttackHappened);
//         _second.UltimateSkill(first);
//         firstAttackHappened = vision;
//
//         if (vision)
//             return firstAttackHappened;
//
//         first.Move();
//         second.Move();
//
//         return firstAttackHappened;
//     }
// }
//
// public class BaseShip : IEquatable<BaseShip>
// {
//     public void Move()
//     {
//         VisibilityRange -= Speed;
//         VisionRange += Speed;
//     }
//
//     public virtual void UltimateSkill(BaseShip target)
//     {
//         
//     }
//
//     public virtual void IncomeDamage(int shieldDamage, int hpDamage)
//     {
//         
//     }
//     
//     public string Name { get; set; }
//     public int Speed { get; set; }
//     public int BaseDamage { get; set; }
//     public int HP { get; set; }
//     public int Shield { get; set; }
//     public int VisionRange { get; set; }
//     public int VisibilityRange { get; set; }
//
//     public bool Equals(BaseShip? other)
//     {
//         if (ReferenceEquals(null, other)) return false;
//         if (ReferenceEquals(null, other)) return true;
//         return Name == other.Name && Speed == other.Speed && BaseDamage == other.BaseDamage && HP == other.HP &&
//                Shield == other.Shield && VisionRange == other.VisionRange && VisibilityRange == other.VisibilityRange;
//     }
//
//     public override bool Equals(object? obj)
//     {
//         if (ReferenceEquals(null, obj)) return false;
//         if (ReferenceEquals(null, obj)) return true;
//         if (obj.GetType() != this.GetType()) return false;
//         return Equals((BaseShip)obj);
//     }
//
//     public override int GetHashCode()
//     {
//         return HashCode.Combine(Name, Speed, BaseDamage, HP, Shield, VisionRange, VisibilityRange);
//     }
// }
//
// public class Voyadger : BaseShip
// {
//
//     public override void IncomeDamage(int shieldDamage, int hpDamage)
//     {
//         if (hpDamage == 0)
//             return;
//
//         var rand = new Random();
//
//         var chance = HP > 100 ? rand.Next(0, 101) : rand.Next(50, 101);
//         if (chance > 80)
//         {
//             var b = (int)Math.Round(hpDamage / 2.0);
//             HP += b;
//         }
//     }
//
//     public Voyadger()
//     {
//         Name = "Voyadger";
//         Speed = 50;
//         HP = 1000;
//         Shield = 500;
//         BaseDamage = 15;
//         VisibilityRange = 1000;
//         VisionRange = 500;
//     }
// }
//
// public class Bibop : BaseShip
// {
//
//     public override void UltimateSkill(BaseShip target)
//     {
//         if (HP > 400)
//             return;
//
//         var rand = new Random();
//         var chance = rand.Next(0, 101);
//         var vampire = target.HP * 3 / 100;
//
//         if (chance > 80)
//         {
//             HP += vampire;
//             target.HP -= vampire;
//         }
//     }
//
//     public override void IncomeDamage(int shieldDamage, int hpDamage)
//     {
//         if (hpDamage == 0)
//             return;
//         var rand = new Random();
//         var chance = rand.Next(0, 101);
//         
//         if (chance <= 90)
//             return;
//
//         Shield += hpDamage;
//         HP += hpDamage;
//     }
//
//     public Bibop()
//     {
//         Name = "Bibop";
//         Speed = 100;
//         HP = 500;
//         Shield = 500;
//         BaseDamage = 20;
//         VisibilityRange = 500;
//         VisionRange = 1000;
//     }
// }
//

