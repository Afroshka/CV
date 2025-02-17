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
            new string[] {"��e���", "Woods"},
            new string[] {"��e���/����", "Woods/Click"},
            new string[] {"��e���/���", "Woods/Sec"},
        };
        return woodsTexts;
    }

    public static string[][] WeaponsCardsDescription()
    {
        string[][] weaponDescription = new string[][]
        {
            new string[] { " �����", " damage"},
            new string[] {"������������ ������!", "Not Enought Woods!"},
        };
        return weaponDescription;
    }


    public static string[][] WoodsCardsDesription()
    {
        string[][] woodsCardsDescription = new string[][]
        {
            new string[] {"�� ����", "per click"},
            new string[] {"� �������", "per sec"},
        };
        return woodsCardsDescription;
    }

    public static string[][] WoodsCardsName()
    {
        string[][] woodsCardsName = new string[][]
        {
            new string[] {"���� �����", "Click card"},
            new string[] {"����� �������", "Time card"},
        };
        return woodsCardsName;
    }

    public static string[][] WoodsAchievementsNames()
    {
        string[][] woodsAchievementsNames = new string[][]
        {
            new string[]{ "��������� ������", "Little Sapling"},
            new string[]{ "��������� ������", "Growing Forest"},
            new string[]{ "������� ��������", "Green Palm"},
            new string[]{ "X������� ���", "Wooden Grove"},
            new string[]{ "������ �������", "Forest Patrol"},
            new string[]{ "��������� ���", "Ancient Forest"},
            new string[]{ "��������� ����", "Forest Builder"},
            new string[]{ "B������ ��������", "Tree Master"},
            new string[]{ "������ ����", "King of the Forest"},
            new string[]{ "������� ���", "Green God"},
            new string[]{ "B����� �����", "Eternal Tree"},
            new string[]{ "��������x������ ����", "Ecological Guru"},
            new string[]{ "������ �������", "Arbiter of Nature"},
            new string[]{ "������� ��������", "Tree Wizard"},
            new string[]{ "������ ������x", "Forest Tycoon"},
            new string[]{ "������� ������� x��������", "Master of Forestry"},
            new string[]{ "��������� ������", "Emperor of Greenery"},
            new string[]{ "����� �������", "Nature's Protector"},
            new string[]{ "������ ����", "Avatar of the Forest"},
            new string[]{ "������� ��������", "Legend of the Trees"},
            new string[]{ "B�������� ����", "Oak Lord"},
            new string[]{ "������������ ���", "Divine Grove"},
            new string[]{ "������ ���x �����", "King of All Forests"},
            new string[]{ "B������ ������� ���", "Great Garden Magician"},
            new string[]{ "��������� ���x� ��������", "Enchanted Era of Trees" },
            new string[]{ "������� ���������", "Ecosystem of Giants" },
            new string[]{ "����������� ���", "Mystical Forest" },
            new string[]{ "������� ����������", "Ecosystem of Giants" },
            new string[]{ "������� �������", "World Gardener" },
            new string[]{ "B������ ����", "Lord of the forest" },
            new string[]{ "������ �x�����", "Forest hunter" },
            new string[]{ "��� ������", "Wooden lord" }
        };
        return woodsAchievementsNames;
    }

    public static string[][] WoodsAchievementsDescriptions()
    {
        string[][] woodsAchievementsDescriptions = new string[][]
        {
            new string[]{ "�������� ��������: ", "Accumulate trees: "},
        };
        return woodsAchievementsDescriptions;
    }

    public static string[][] FirstStartTexts()
    {
        string[][] firstTexts = new string[][]
        {
            new string[]{"������������ � ������������ ���x!", "Welcome to era destroyer!"},
            new string[]{ "���������� ���� � ���� ������������ � ����������� ���x� ���� �� ������!", "Try your hand as an destroyer and exterminate eras one by one!"},
            new string[]{"CTA�T", "START"},
            new string[]{"����� �� ������", "Push Button"},
        };
        return firstTexts;
    }

    public static string[][] WelcomeBackTexts()
    {
        string[][] welcomeBackTexts = new string[][]
        {
            new string[]{"����� ������������!", "Welcome Back!"},
            new string[]{"� ���������� �x��� �� ����������:", "Since the last entry into the game you have received woods:"},
            new string[]{"OK", "Receive"},
        };
        return welcomeBackTexts;
    }

    public static string[][] PauseTexts()
    {
        string[][] pauseTexts = new string[][]
        {
            new string[]{"3����", "Sounds"},
            new string[]{"������", "Music"}
        };
        return pauseTexts;
    }

    public static string[][] AutoBuyTexts()
    {
        string[][] autoBuyTexts = new string[][]
        {
            new string[]{"�����������", "Autobuy"},
            new string[]{"B��", "On"},
            new string[]{"B���", "Off"},
        };
        return autoBuyTexts;
    }

    public static string[][] ErrorsTexts()
    {
        string[][] errorsTexts = new string[][]
        {
            new string[] {"�������� ����������� ���������!", " Reached maximum of autobuys!"},
        };
        return errorsTexts;
    }

    public static string[][] WeaponCardsNames()
    {
        string[][] weaponCardsNames = new string[][]
        {
            new string[] {"��������� ���", "Banana man"},
            new string[] {"������� ������", "Red Boy"},
            new string[] {"������", "Knight"},
            new string[] {"���������� ������", "Purple Knight"},
            new string[] {"�������� ������", "Secret Knight"},
            new string[] {"������", "Ninja"},
            new string[] {"������", "Pinja"},
            new string[] {"�������", "Grinja"},
            new string[] {"���������", "Chupacabra"},
            new string[] {"������� ���������", "Sick Chupacabra"},
            new string[] {"���������", "Pupacabra"},
            new string[] {"������", "Archer"},
            new string[] {"������� ������", "Sick Archer"},
            new string[] {"������� ������", "Marine Archer"},
            new string[] {"����", "Boss"},
            new string[] {"���� �����", "Mafia Boss"},
            new string[] {"����-����", "Hulk Boss"},
            new string[] {"����������", "Purifier"},
            new string[] {"����������", "Infector"},
            new string[] {"���������� ���", "Purple Guy"},
            new string[] {"��������� ������", "Small Rocket"},
            new string[] {"��������� ������", "Orange Menace"},
            new string[] {"������� ������", "Red Rocket"},
            new string[] {"����� �����", "Blue Light"},
            new string[] {"������������", "Destroyer"},
        };
        return weaponCardsNames;
    }

    public static string[][] TargetDestroyedTexts()
    {
        string[][] texts = new string[][]
            {
                new string[] { "������ ���������!!!\r\n (���-�� �� �������)", "HRMAUMA BEDINGA!!\r\n (something in ancient language)" },
                new string[] { "����� ��� �����?", "Did it you why do?" },
                new string[] { "��� ������� ��������!", "Revenge come from past. Your fault!" },
                new string[] { "���� ����� �������� �����! ", "I didn't even have time to get my pants!" },
                new string[] { "��x, x��� ������ � ������!", "Phew, at least I'm wearing clothes now!" },
                new string[] { "�������� ���? ����� ���x� ����������!", "Do you like it? You're doing a very bad thing!" },
                new string[] { "�� � �� ��� ��� ������� ��� ��x��?", "So why do you need my kitchen?" },
                new string[] { "����� x�����? � �� �������� �������� ���!", "Will you stop it? Otherwise I'll have to punish you!" },
                new string[] { "���... B�����, ������� ��������...", "Yeah... I guess I'm not strong enough..." },
                new string[] { "���-�� ������� ������������?", "Did someone call for backup?" },
                new string[] { "����� �� ������� �����������?", "When will you finally calm down?" },
                new string[] { "���x... E�� ���������� �������������...", "Argh... This is impossible to resist..." },
                new string[] { "� ��� �? ��� ������ �������...", "What about me? I'm just building..." },
                new string[] { "�� ��� ����� ������� ���������?", "Do you need a curse put on you?" },
                new string[] { "��� ������, ��� ���� ������!", "My queen, we must run!" },
                new string[] { "�� ����� �������...", "I didn't have time to escape..." },
                new string[] { "���� ���������� ����.. ������� �� ����!", "At least the diapers were given... Thank you for that!" },
                new string[] { "T����� � ������... � ��� ��� ���?", "Just got off work... And where is my house?" },
                new string[] { "����� ��� ��������, ��������?", "May I amuse you, sir?" },
                new string[] { "������� �� ��������� �� ������?", "Will he really get to the king?" },
                new string[] { "������! ������� ��� ������!", "Guards! Abandon all troops!" },
                new string[] { "� ����� ��������� ��� ����?", "Can I ask you to leave?" },
                new string[] { "������ � ������ ������ �������� � ��� �����?", "Why did I come here instead of school?" },
                new string[] { "���� ���� �������, �����, ��������!", "But I found a horse, guys, look!" },
                new string[] { "���� �� ����� ��������? B�� � �����?", "What are you doing here? Is everybody attacking?" },
                new string[] { "� � ������ ������?", "I'm black, actually..." },
                new string[] { "����� ���-�� ����? B�x���, ����!", "Is someone here? Come out, you coward!" },
                new string[] { "����� ��� ������ �����?", "Can I get a weapon?" },
                new string[] { "�� ����� ���� �� x��� ������� �����..", "Well, you could at least light the torch.." },
                new string[] { "���x�! �� �������!", "Aloha! Board it!" },
                new string[] { "����, ���� ���� �����..", "Crap, I forgot my eye at home.."},
                new string[] { "� ���� �� ����� �� ����� ��������!", "And we could have been friends!" },
                new string[] { "�� ������, � ���� ���� ����� �� ��������!", "That's okay, I have one just like it!" },
                new string[] { "�� �� ���????!?!??!", "Why????!?!?" },
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
