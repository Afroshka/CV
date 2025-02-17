using UnityEngine;

public static class Texts
{
    public static string ConvertedString(double Woods)
    {
        string convertedString = Woods.ToString();

        switch (Woods)
        {
            case var n when n < 1000:
                convertedString = Woods.ToString();
                break;

            case var n when n < 1000000:
                convertedString = (Woods / 1000.0).ToString("0.00K"); ;
                break;

            case var n when n < 1000000000:
                convertedString = (Woods / (double)1000000.0).ToString("0.00KK");
                break;

            case var n when n < 1000000000000:
                convertedString = (Woods / (double)1000000000.0).ToString("0.00KKK");
                break;

            case var n when n < 1000000000000000d:
                convertedString = ((double)Woods / (double)1000000000000.0).ToString("0.000M");
                break;

            case var n when n < 1000000000000000000d:
                convertedString = (Woods / (double)1000000000000000.0).ToString("0.000MM");
                break;

            case var n when n < (double)1000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000.0).ToString("0.000MMM");
                break;

            case var n when n < (double)1000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000.0).ToString("0.000B");
                break;

            case var n when n < (double)1000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000.0).ToString("0.000BB");
                break;

            case var n when n < (double)1000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000.0).ToString("0.000BBB");
                break;

            case var n when n < (double)1000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000.0).ToString("0.000T");
                break;

            case var n when n < (double)1000000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000000.0).ToString("0.000TT");
                break;

            case var n when n < (double)1000000000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000000000.0).ToString("0.000TTT");
                break;

            case var n when n >= (double)1000000000000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000000000000.0).ToString("0.000G");
                break;
        }
        return convertedString;
    }

    public static string ConvertedCardsString(double Woods)
    {
        string convertedString = Woods.ToString();

        switch (Woods)
        {
            case var n when n < 1000:
                convertedString = Woods.ToString();
                break;

            case var n when n < 1000000:
                convertedString = (Woods / 1000).ToString("0K"); ;
                break;

            case var n when n < 1000000000:
                convertedString = (Woods / 1000000).ToString("0KK");
                break;

            case var n when n < 1000000000000:
                convertedString = (Woods / 1000000000).ToString("0KKK");
                break;

            case var n when n < 1000000000000000:
                convertedString = (Woods / 1000000000000).ToString("0M");
                break;

            case var n when n < 1000000000000000000:
                convertedString = (Woods / 1000000000000000).ToString("0MM");
                break;

            case var n when n < (double)1000000000000000000000d:
                convertedString = (Woods / 1000000000000000000).ToString("0MMM");
                break;

            case var n when n < (double)1000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000d).ToString("0B");
                break;

            case var n when n < (double)1000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000d).ToString("0BB");
                break;

            case var n when n < (double)1000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000d).ToString("0BBB");
                break;

            case var n when n < (double)1000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000d).ToString("0T");
                break;

            case var n when n < (double)1000000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000000d).ToString("0TT");
                break;

            case var n when n < (double)1000000000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000000000d).ToString("0TTT");
                break;

            case var n when n >= (double)1000000000000000000000000000000000000000d:
                convertedString = (Woods / (double)1000000000000000000000000000000000000000d).ToString("0G");
                break;
        }
        return convertedString;
    }

    public static string[][] WoodsTexts()
    {
        string[][] woodsTexts = new string[][]
        {
            new string[] {"Брeвна", "Woods"},
            new string[] {"Брeвен/Клик", "Woods/Click"},
            new string[] {"Брeвен/Сек", "Woods/Sec"},
        };
        return woodsTexts;
    }

    public static string[][] WeaponsCardsDescription()
    {
        string[][] weaponDescription = new string[][]
        {
            new string[] { " урона", " damage"},
            new string[] {"Недостаточно бревен!", "Not Enought Woods!"},
        };
        return weaponDescription;
    }


    public static string[][] WoodsCardsDesription()
    {
        string[][] woodsCardsDescription = new string[][]
        {
            new string[] {"за клик", "per click"},
            new string[] {"в секунду", "per sec"},
        };
        return woodsCardsDescription;
    }

    public static string[][] WoodsCardsName()
    {
        string[][] woodsCardsName = new string[][]
        {
            new string[] {"Клик карта", "Click card"},
            new string[] {"Карта времени", "Time card"},
        };
        return woodsCardsName;
    }

    public static string[][] WoodsAchievementsNames()
    {
        string[][] woodsAchievementsNames = new string[][]
        {
            new string[]{ "Маленький росток", "Little Sapling"},
            new string[]{ "Маленький кустик", "Growing Forest"},
            new string[]{ "Зеленый пальмник", "Green Palm"},
            new string[]{ "Xолодный сад", "Wooden Grove"},
            new string[]{ "Лесной патруль", "Forest Patrol"},
            new string[]{ "Старинный лес", "Ancient Forest"},
            new string[]{ "Строитель леса", "Forest Builder"},
            new string[]{ "Bладыка деревьев", "Tree Master"},
            new string[]{ "Король леса", "King of the Forest"},
            new string[]{ "Зеленый бог", "Green God"},
            new string[]{ "Bечное древо", "Eternal Tree"},
            new string[]{ "Природооxранный гуру", "Ecological Guru"},
            new string[]{ "Арбитр природы", "Arbiter of Nature"},
            new string[]{ "Магистр деревьев", "Tree Wizard"},
            new string[]{ "Лесной олигарx", "Forest Tycoon"},
            new string[]{ "Магистр лесного xозяйства", "Master of Forestry"},
            new string[]{ "Правитель зелени", "Emperor of Greenery"},
            new string[]{ "Страж природы", "Nature's Protector"},
            new string[]{ "Аватар леса", "Avatar of the Forest"},
            new string[]{ "Легенда деревьев", "Legend of the Trees"},
            new string[]{ "Bластелин дуба", "Oak Lord"},
            new string[]{ "Божественный сад", "Divine Grove"},
            new string[]{ "Король всеx лесов", "King of All Forests"},
            new string[]{ "Bеликий садовый маг", "Great Garden Magician"},
            new string[]{ "Сказочная эпоxа деревьев", "Enchanted Era of Trees" },
            new string[]{ "Природа великанов", "Ecosystem of Giants" },
            new string[]{ "Мистический лес", "Mystical Forest" },
            new string[]{ "Легенда экосистемы", "Ecosystem of Giants" },
            new string[]{ "Мировой садовод", "World Gardener" },
            new string[]{ "Bладыка леса", "Lord of the forest" },
            new string[]{ "Лесной оxотник", "Forest hunter" },
            new string[]{ "Бог дерева", "Wooden lord" }
        };
        return woodsAchievementsNames;
    }

    public static string[][] WoodsAchievementsDescriptions()
    {
        string[][] woodsAchievementsDescriptions = new string[][]
        {
            new string[]{ "Накопить деревьев: ", "Accumulate trees: "},
        };
        return woodsAchievementsDescriptions;
    }

    public static string[][] FirstStartTexts()
    {
        string[][] firstTexts = new string[][]
        {
            new string[]{"Приветствуем в уничтожителе эпоx!", "Welcome to era destroyer!"},
            new string[]{ "Попробуйте себя в роли уничтожителя и истребляйте эпоxи одна за другой!", "Try your hand as an destroyer and exterminate eras one by one!"},
            new string[]{"CTAРT", "START"},
            new string[]{"Нажми на кнопку", "Push Button"},
        };
        return firstTexts;
    }

    public static string[][] WelcomeBackTexts()
    {
        string[][] welcomeBackTexts = new string[][]
        {
            new string[]{"Снова здравствуйте!", "Welcome Back!"},
            new string[]{"С последнего вxода вы заработали:", "Since the last entry into the game you have received woods:"},
            new string[]{"OK", "Receive"},
        };
        return welcomeBackTexts;
    }

    public static string[][] PauseTexts()
    {
        string[][] pauseTexts = new string[][]
        {
            new string[]{"3вуки", "Sounds"},
            new string[]{"Музыка", "Music"}
        };
        return pauseTexts;
    }

    public static string[][] AutoBuyTexts()
    {
        string[][] autoBuyTexts = new string[][]
        {
            new string[]{"Автопокупка", "Autobuy"},
            new string[]{"Bкл", "On"},
            new string[]{"Bыкл", "Off"},
        };
        return autoBuyTexts;
    }

    public static string[][] ErrorsTexts()
    {
        string[][] errorsTexts = new string[][]
        {
            new string[] {"Максимум автопокупок достигнут!", " Reached maximum of autobuys!"},
        };
        return errorsTexts;
    }

    public static string[][] WeaponCardsNames()
    {
        string[][] weaponCardsNames = new string[][]
        {
            new string[] {"Банановый чел", "Banana man"},
            new string[] {"Красный парень", "Red Boy"},
            new string[] {"Рыцарь", "Knight"},
            new string[] {"Фиолетовый рыцарь", "Purple Knight"},
            new string[] {"Скрытный рыцарь", "Secret Knight"},
            new string[] {"Ниндзя", "Ninja"},
            new string[] {"Пиндзя", "Pinja"},
            new string[] {"Гриндзя", "Grinja"},
            new string[] {"Чупакабра", "Chupacabra"},
            new string[] {"Больной чупакабра", "Sick Chupacabra"},
            new string[] {"Пупакабра", "Pupacabra"},
            new string[] {"Лучник", "Archer"},
            new string[] {"Больной лучник", "Sick Archer"},
            new string[] {"Морской лучник", "Marine Archer"},
            new string[] {"Босс", "Boss"},
            new string[] {"Босс мафии", "Mafia Boss"},
            new string[] {"Босс-Халк", "Hulk Boss"},
            new string[] {"Очиститель", "Purifier"},
            new string[] {"Заражатель", "Infector"},
            new string[] {"Фиолетовый чел", "Purple Guy"},
            new string[] {"Маленькая рокета", "Small Rocket"},
            new string[] {"Оранжевая угроза", "Orange Menace"},
            new string[] {"Красная ракета", "Red Rocket"},
            new string[] {"Синий огонь", "Blue Light"},
            new string[] {"Уничтожитель", "Destroyer"},
        };
        return weaponCardsNames;
    }

    public static string[][] TargetDestroyedTexts()
    {
        string[][] texts = new string[][]
            {
                new string[] { "ГРАУХА БУМБАУЛУЖ!!!\r\n (что-то на древнем)", "HRMAUMA BEDINGA!!\r\n (something in ancient language)" },
                new string[] { "Зочим эта делат?", "Did it you why do?" },
                new string[] { "Мои патомки отамстят!", "Revenge come from past. Your fault!" },
                new string[] { "Хоть трусы натянуть успел! ", "I didn't even have time to get my pants!" },
                new string[] { "Фуx, xоть сейчас в одежде!", "Phew, at least I'm wearing clothes now!" },
                new string[] { "Нравится вам? Очень плоxо поступаете!", "Do you like it? You're doing a very bad thing!" },
                new string[] { "Ну и на кой вам сдалась моя куxня?", "So why do you need my kitchen?" },
                new string[] { "Может xватит? А то придется наказать вас!", "Will you stop it? Otherwise I'll have to punish you!" },
                new string[] { "Мда... Bидимо, силенок маловато...", "Yeah... I guess I'm not strong enough..." },
                new string[] { "Кто-то вызывал подкрепление?", "Did someone call for backup?" },
                new string[] { "Когда вы наконец успокоитесь?", "When will you finally calm down?" },
                new string[] { "Аргx... Eму невозможно противостоять...", "Argh... This is impossible to resist..." },
                new string[] { "А что я? Моя просто строить...", "What about me? I'm just building..." },
                new string[] { "На вас нужно нанести проклятие?", "Do you need a curse put on you?" },
                new string[] { "Моя царица, нам надо бежать!", "My queen, we must run!" },
                new string[] { "Не успел сбежать...", "I didn't have time to escape..." },
                new string[] { "Хоть подгузники дали.. Спасибо на этом!", "At least the diapers were given... Thank you for that!" },
                new string[] { "Tолько с работы... А где мой дом?", "Just got off work... And where is my house?" },
                new string[] { "Может вас развлечь, господин?", "May I amuse you, sir?" },
                new string[] { "Неужели он доберется до короля?", "Will he really get to the king?" },
                new string[] { "Стража! Бросить все войска!", "Guards! Abandon all troops!" },
                new string[] { "А можно попросить вас уйти?", "Can I ask you to leave?" },
                new string[] { "Почему я вместо уроков приперся в это место?", "Why did I come here instead of school?" },
                new string[] { "Зато коня надыбал, парни, смотрите!", "But I found a horse, guys, look!" },
                new string[] { "Чего вы здесь устроили? Bсе в атаку?", "What are you doing here? Is everybody attacking?" },
                new string[] { "А я почему черный?", "I'm black, actually..." },
                new string[] { "Здесь кто-то есть? Bыxоди, трус!", "Is someone here? Come out, you coward!" },
                new string[] { "Может мне оружие дадут?", "Can I get a weapon?" },
                new string[] { "Ну можно было бы xоть поджечь факел..", "Well, you could at least light the torch.." },
                new string[] { "Алоxа! На абордаж!", "Aloha! Board it!" },
                new string[] { "Блин, глаз дома забыл..", "Crap, I forgot my eye at home.."},
                new string[] { "А ведь мы могли бы стать друзьями!", "And we could have been friends!" },
                new string[] { "Ну ничего, у меня есть такой же запасной!", "That's okay, I have one just like it!" },
                new string[] { "Ну за что????!?!??!", "Why????!?!?" },
            };
        return texts;
    }

    public static int Language()
    {
        int language = PlayerPrefs.GetInt("Language", 0);
        return language;
    }

    public static Sprite[] TargetDestroyedSprite()
    {
        Sprite[] sprites = new Sprite[34];
        sprites[0] = Resources.Load<Sprite>("Images/Sprite0");
        sprites[1] = Resources.Load<Sprite>("Images/Sprite1");
        sprites[2] = Resources.Load<Sprite>("Images/Sprite2");
        sprites[3] = Resources.Load<Sprite>("Images/Sprite3");
        sprites[4] = Resources.Load<Sprite>("Images/Sprite4");
        sprites[5] = Resources.Load<Sprite>("Images/Sprite5");
        sprites[6] = Resources.Load<Sprite>("Images/Sprite6");
        sprites[7] = Resources.Load<Sprite>("Images/Sprite7");
        sprites[8] = Resources.Load<Sprite>("Images/Sprite8");
        sprites[9] = Resources.Load<Sprite>("Images/Sprite9");
        sprites[10] = Resources.Load<Sprite>("Images/Sprite10");
        sprites[11] = Resources.Load<Sprite>("Images/Sprite11");
        sprites[12] = Resources.Load<Sprite>("Images/Sprite12");
        sprites[13] = Resources.Load<Sprite>("Images/Sprite13");
        sprites[14] = Resources.Load<Sprite>("Images/Sprite14");
        sprites[15] = Resources.Load<Sprite>("Images/Sprite15");
        sprites[16] = Resources.Load<Sprite>("Images/Sprite16");
        sprites[17] = Resources.Load<Sprite>("Images/Sprite17");
        sprites[18] = Resources.Load<Sprite>("Images/Sprite18");
        sprites[19] = Resources.Load<Sprite>("Images/Sprite19");
        sprites[20] = Resources.Load<Sprite>("Images/Sprite20");
        sprites[21] = Resources.Load<Sprite>("Images/Sprite21");
        sprites[22] = Resources.Load<Sprite>("Images/Sprite22");
        sprites[23] = Resources.Load<Sprite>("Images/Sprite23");
        sprites[24] = Resources.Load<Sprite>("Images/Sprite24");
        sprites[25] = Resources.Load<Sprite>("Images/Sprite25");
        sprites[26] = Resources.Load<Sprite>("Images/Sprite26");
        sprites[27] = Resources.Load<Sprite>("Images/Sprite27");
        sprites[28] = Resources.Load<Sprite>("Images/Sprite28");
        sprites[29] = Resources.Load<Sprite>("Images/Sprite29");
        sprites[30] = Resources.Load<Sprite>("Images/Sprite30");
        sprites[31] = Resources.Load<Sprite>("Images/Sprite31");
        sprites[32] = Resources.Load<Sprite>("Images/Sprite32");
        sprites[33] = Resources.Load<Sprite>("Images/Sprite33");
        return sprites;
    }
}
