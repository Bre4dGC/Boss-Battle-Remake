Enemy boss = new Enemy();
User player = new User();
Random randBossInput = new Random();
Console.Write($"Придумайте себе ник: ");
player.UserName = Console.ReadLine(); Console.Clear();

Console.Write("Легенда\nВ краю, где царствует тьма, прозябал зловещий Теневой Босс – непобедимый и коварный. " +
    "\nНо в центре этой темницы среди тьмы стоял Маг, некогда великий, но когда-то побежденный. " +
    "\nЕго душа дремала, ожидая момента, когда он снова станет тем, кем был прежде. " +
    "\nПоднявшись из пепла, Маг ощутил множество эмоций – гнев, решимость, пробуждение внутренней магии. " +
    "\nЕго арсенал был полон заклинаний, способных пробудить силы, замирающие в мире тьмы. " +
    "\nС увиденным врагом лицом к лицу, он знал, что долг его – покончить с этой угрозой, иначе ему не предстоит покоя."); Console.ReadKey(); Console.Clear();

while(player.PlayerHealth > 0 && boss.BossHealth > 0)
{
    CharactersHealth(boss, player);
    Console.Write("Введите номер атаки: ");

    switch (Console.ReadLine())
    {
        case "1":
            CharactersHealth(boss, player);
            player.Huganzakura(boss); Clean();
            break;
        case "2":
            CharactersHealth(boss, player);
            player.magicalAttack(boss); Clean();
            break;
        case "3":
            CharactersHealth(boss, player);
            player.Healing(boss); Clean();
            break;
    }

    int bossAttack = randBossInput.Next(1, 3);
    switch (bossAttack)
    {
        case 1:
            CharactersHealth(boss, player);
            boss.Rashamon(player); Clean();
            break;
        case 2:
            CharactersHealth(boss, player);
            boss.ShadowCloning(player); Clean();
            break;
    }
    if (boss.BossHealth <= 200 && boss.PotionCount > 0)
    {
        CharactersHealth(boss, player); boss.Healing(); Clean();
    }
}
if (boss.BossHealth <= 0)
{
    Console.Clear();
    Console.WriteLine($"Игрок {player.UserName} победил босса");
}
else if (player.PlayerHealth <= 0)
{
    Console.Clear();
    Console.WriteLine($"Босс победил игрока {player.UserName}");
}
static void Clean()
{
    Console.ReadKey(); Console.Clear();
}

static void CharactersHealth(Enemy boss, User player)
{
    Console.SetCursorPosition(0, 5);
    Console.WriteLine($"| Хп босса - {boss.BossHealth}, броня босса - {boss.BossArmor} | Хп {player.UserName} - {player.PlayerHealth}, броня {player.UserName} - {player.PlayerArmor}");
    Console.SetCursorPosition(0, 0);
}
class User
{
    public int PlayerHealth = 500, PlayerArmor = 100, PotionCount = 3;
    public string UserName;

    public void Huganzakura(Enemy enemy)
    {
        if(enemy.assign == true)
        {
            enemy.BossHealth -= enemy.Attack = 220 / 100 * enemy.BossArmor;
            Console.Write($"{UserName} использовал атаку Хаганзакура и нанес {enemy.Attack} урона боссу");
            enemy.assign = false;
        }
        else Console.Write("Босс не использовал атаку Рашамон");
    }
    public void magicalAttack(Enemy enemy)
    {
        enemy.BossHealth -= enemy.Attack = 180;
        Console.Write($"{UserName} использовал Магическую атаку и нанес {enemy.Attack} урона боссу");
    }
    public void Healing(Enemy enemy)
    {
        if (PotionCount > 0)
        {
            Random randomHeal = new Random();
            PlayerHealth += enemy.heal = randomHeal.Next(25, 100); PotionCount--;
            Console.Write($"{UserName} отхилился на {enemy.heal} хп");
        }
        else Console.WriteLine("Не достаточно зелий");
    }
}
class Enemy
{

    public int BossHealth = 750, BossArmor = 50, PotionCount = 3;
    public bool assign = false; public int Attack, heal;
    public void Rashamon(User player)
    {
        assign = true;
        player.PlayerHealth -= Attack = 180 / 100 * player.PlayerArmor;
        Console.Write($"Босс использовал атаку Рашамон и нанес {Attack} урона игроку {player.UserName}");
    }
    public void ShadowCloning(User player)
    {
        player.PlayerHealth -= Attack = 120 / 100 * player.PlayerArmor;
        Console.Write($"Босс использовал атаку теневого клонирования и нанес {Attack} урона игроку {player.UserName}");
    }
    public void Healing()
    {
        if (PotionCount > 0)
        {
            Random randomHeal = new Random();
            BossHealth += heal = randomHeal.Next(25, 100); PotionCount--;
            Console.Write($"Босс отхилился на {heal} хп");
        }
        else Console.WriteLine("Не достаточно зелий");
    }
}
