Enemy boss = new Enemy();
User player = new User();

Random randBossInput = new Random();

Console.Write($"Придумайте себе ник: ");
player.Name = Console.ReadLine();

Console.Write
    ("\nЛегенда\nВ краю, где царствует тьма, прозябал зловещий Теневой Босс – непобедимый и коварный. " +
    "\nНо в центре этой темницы среди тьмы стоял Маг, некогда великий, но когда-то побежденный. " +
    "\nЕго душа дремала, ожидая момента, когда он снова станет тем, кем был прежде. " +
    "\nПоднявшись из пепла, Маг ощутил множество эмоций – гнев, решимость, пробуждение внутренней магии. " +
    "\nЕго арсенал был полон заклинаний, способных пробудить силы, замирающие в мире тьмы. " +
    "\nС увиденным врагом лицом к лицу, он знал, что долг его – покончить с этой угрозой, иначе ему не предстоит покоя."); 

Console.ReadKey(); Console.Clear();

while(player.Health > 0 && boss.BossHealth > 0)
{
    CharactersHealth(boss, player);
    Console.Write("Введите номер атаки: ");

    switch (Console.ReadLine())
    {
        case "1":
            CharactersHealth(boss, player);
            player.Huganzakura(boss); 
            Clean();
            break;

        case "2":
            CharactersHealth(boss, player);
            player.MagicalAttack(boss); 
            Clean();
            break;

        case "3":
            CharactersHealth(boss, player);
            player.Healing(); 
            Clean();
            break;
    }

    int bossAttack = randBossInput.Next(1, 3);

    switch (bossAttack)
    {
        case 1:
            CharactersHealth(boss, player);
            boss.Rashamon(player); 
            Clean();
            break;

        case 2:
            CharactersHealth(boss, player);
            boss.ShadowCloning(player); 
            Clean();
            break;
    }
    if (boss.BossHealth <= 150 && boss.PotionCount > 0 && player.Health > 0)
    {
        CharactersHealth(boss, player); 
        boss.Healing(); 
        Clean();
    }
}

if (boss.BossHealth <= 0)
{
    Console.Clear();
    Console.WriteLine($"Игрок {player.Name} победил босса");
}
else if (player.Health <= 0)
{
    Console.Clear();
    Console.WriteLine($"Босс победил игрока {player.Name}");
}

static void Clean()
{
    Console.ReadKey(); 
    Console.Clear();
}

static void CharactersHealth(Enemy boss, User player)
{
    Console.SetCursorPosition(0, 5);
    Console.WriteLine($"| Хп босса - {boss.BossHealth}, броня босса - {boss.BossArmor} | Хп {player.Name} - {player.Health}, броня {player.Name} - {player.Armor}");
    Console.SetCursorPosition(0, 0);
}

class User
{
    public int Health = 500, Armor = 100, PotionCount = 3, heal;
    public string Name = "Jhon Dow";

    public void Huganzakura(Enemy enemy)
    {
        if(enemy.assign == true)
        {
            enemy.BossHealth -= 220;

            Console.Write($"{Name} использовал атаку Хаганзакура и нанес 220 урона боссу");

            enemy.assign = false;
        }
        else Console.Write("Босс не использовал атаку Рашамон");
    }
    public void MagicalAttack(Enemy enemy)
    {
        enemy.BossHealth -= 170;

        Console.Write($"{Name} использовал Магическую атаку и нанес 150 урона боссу");
    }
    public void Healing()
    {
        if (PotionCount > 0)
        {
            Random randomHeal = new Random();

            Health += heal = randomHeal.Next(25, 100); 
            PotionCount--;

            Console.Write($"{Name} отхилился на {heal} хп");
        }
        else Console.WriteLine("Не достаточно зелий");
    }
}

class Enemy
{
    public int BossHealth = 750, BossArmor = 50, PotionCount = 3, heal;
    public bool assign = false;

    public void Rashamon(User player)
    {
        assign = true;
        player.Health -= 180;

        Console.Write($"Босс использовал атаку Рашамон и нанес 180 урона игроку {player.Name}");
    }

    public void ShadowCloning(User player)
    {
        player.Health -= 120;

        Console.Write($"Босс использовал атаку теневого клонирования и нанес 120 урона игроку {player.Name}");
    }

    public void Healing()
    {
        if (PotionCount > 0)
        {
            Random randomHeal = new Random();

            BossHealth += heal = randomHeal.Next(25, 100); 
            PotionCount--;

            Console.Write($"Босс отхилился на {heal} хп");
        }

        else Console.WriteLine("Не достаточно зелий");
    }
}
