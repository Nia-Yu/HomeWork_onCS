using System;

namespace HWBossBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minHealthBoss = 150;
            int maxHealthBoss = 300;
            float healthBoss = random.Next(minHealthBoss, maxHealthBoss);
            int minDamageBoss = 20;
            int maxDamageBoss = 75;
            int damageBoss = random.Next(minDamageBoss, maxDamageBoss);
            int minArmoreBoss = 10;
            int maxArmoreBoss = 75;
            int armoreBoss = random.Next(minArmoreBoss, maxArmoreBoss);
            float healthHero = 250;
            float currentHealthHero = healthHero;
            float damageHero = 2;
            int spellHero;
            string spell1 = "Бестелестность";
            string spell2 = "Берсерк";
            string spell3 = "Свет небес";
            string spell4 = "Огненая стрела";
            float contentSpell1 = 50;
            int contentSpell2 = 2;
            float contentSpell3 = 20;
            float contentSpell4 = 50;
            float armoreHero = 0;
            int increasedDamage = 1;
            int downgradeArmoreHero = 5;
            float damage;
            int usageRoundSpell = 5;
            int usageRoundSpell1 = 0;
            bool spell1Used = false;

            Console.WriteLine($"Ваш герой - Маг огня.\n" +
                $"Ваши основные характеристики:\n" +
                $"Здоровье - {healthHero}\n" +
                $"Урон -  {damageHero}\n" +
                $"Броня - {armoreHero}% \n" +
                $"У вас есть 4 заклинания.\n" +
                $"{spell1} - увеличивает вашу броню на {contentSpell1}%. Можно использовать 1 раз в {usageRoundSpell} раундов. Броня снижается каждый ход на {downgradeArmoreHero}%.\n" +
                $"{spell2} - увеличивает ваш урон в {contentSpell2} раза, но снижает вашу броню до 0\n" +
                $"{spell3} - востанавливает здоровье на {contentSpell3} ед.\n" +
                $"{spell4} - наносит врагу {contentSpell4} ед. урона, можно использовать только после заклинания {spell2}.\n");

            Console.WriteLine($"\nВаш враг Элементаль.\n" +
                $"Его основные характеристики:\n" +
                $"Здоровье - {healthBoss}\n" +
                $"Урон -  от 0 до {damageBoss}\n" +
                $"Броня - от 0 до {armoreBoss}");

            while (healthBoss >= 1 && healthHero >= 1)
            {
                if (armoreHero >= downgradeArmoreHero)
                {
                    armoreHero -= downgradeArmoreHero;
                }
                else
                {
                    armoreHero = 0;
                }
                Console.WriteLine($"\nВаш ход:\n" +
                    $"Обычная атака (Быстрая клавиша [0])\n" +
                    $"{spell1}(Быстрая клавиша [1])\n" +
                    $"{spell2}(Быстрая клавиша [2])\n" +
                    $"{spell3}(Быстрая клавиша [3])\n" +
                    $"{spell4}(Быстрая клавиша [4])"); ;
                spellHero = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (spellHero == 0)
                {
                    damage = increasedDamage * (damageHero - (damageHero * armoreBoss / 100));
                    healthBoss -= damage;
                    Console.WriteLine($"\nВы нанесли урон {damage}.");
                }
                else if (spellHero == 1)
                {
                    if (spell1Used == false)
                    {
                        armoreHero += contentSpell1;
                        Console.WriteLine($"\nВаша броня - {armoreHero}");
                        spell1Used = true;
                    }
                    else
                    {
                        Console.WriteLine($"Вы не можете прочитать это заклинание. Оно еще активно.\n" +
                            $"Вы пропускаете ход.");
                    }
                }
                else if (spellHero == 2)
                {
                    if (increasedDamage == 1)
                    {
                        armoreHero = 0;
                        increasedDamage *= contentSpell2;
                        Console.WriteLine($"\nСледущая ваша атака увеличена в {contentSpell2} раза.");
                    }
                    else
                    {
                        Console.WriteLine("\nВаша атака не может быть увеличена повторно.");
                    }
                }
                else if (spellHero == 3)
                {
                    if (currentHealthHero < healthHero)
                    {
                        if (currentHealthHero > healthHero - contentSpell3)
                        {
                            currentHealthHero = healthHero;
                            Console.WriteLine("\nВаше здоровье полностью восстановлено.");
                        }
                        else
                        {
                            currentHealthHero += contentSpell3;
                            Console.WriteLine($"\nЗдоровье востановлено на {contentSpell3}. Ваше текущее здоровье {currentHealthHero}.");
                        }
                    }
                }
                else if (spellHero == 4)
                {
                    if (increasedDamage == contentSpell2)
                    {
                        damage = increasedDamage * (contentSpell4 - (contentSpell4 * armoreBoss / 100));
                        healthBoss -= damage;
                        increasedDamage = 1;
                        Console.WriteLine($"\nВы нанесли урон {damage}.");
                    }
                    else
                    {
                        Console.WriteLine($"\nЭто заклинание не возможно прочитать, пока не произнесено заклинание {spell2}.");
                    }
                }

                if (spell1Used == true)
                {
                    if (usageRoundSpell1 == usageRoundSpell)
                    {
                        spell1Used = false;

                    }
                    else
                    {
                        usageRoundSpell1 += 1;
                    }
                }

                Console.WriteLine("\nХод противника");
                armoreBoss = random.Next(0, armoreBoss);
                damage = (damageBoss - (damageBoss * armoreHero) / 100);
                healthHero -= damage;
                Console.WriteLine($"\nВам нанесен урон {damage}.");
                Console.WriteLine($"\nВаши характеристики:\n" +
                    $"Здоровье - {healthHero}\n" +
                    $"Урон -  {damageHero}\n" +
                    $"Броня - {armoreHero}% \n" +
                    $"Увеличение атаки - х{increasedDamage}");

                if (spell1Used == false)
                {
                    Console.WriteLine($"Заклинание {spell1} доступно.");
                }
                else
                {
                    Console.WriteLine($"Заклинание {spell1} будет доступно через {usageRoundSpell - usageRoundSpell1} раундов");
                }
                Console.WriteLine($"\nХарактеристики Элементаля:\n" +
                    $"Здоровье - {healthBoss}\n" +
                    $"Урон -  {damageBoss}\n" +
                    $"Броня - {armoreBoss}%");
            }

            Console.WriteLine("\nБой окончен.");

            if (healthHero <= 0 && healthBoss <= 0)
            {
                Console.WriteLine("Ваш герой и Элементаль нанесли последний удар одновременно. Они оба мертвы.");
            }
            else if (healthHero <= 0)
            {
                Console.WriteLine("Ваш герой мертв.");
            }
            else
            {
                Console.WriteLine("Элементаль повержен");
            }

        }
    }
}
