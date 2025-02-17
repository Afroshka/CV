using UnityEngine;

public class Achievements : MonoBehaviour
{
    [SerializeField] private GameObject achievementsPanel;

    private int achievementGot = 0;

    private int achievementMultiplier = 10;

    private int size = 100;
    private bool[] achievementDisplayed;

    private void Start()
    {
        LoadAchievement();
        achievementDisplayed = new bool[size];
        Woods.Instance.WoodsAdded += CheckAchievement;
    }

    public void CheckAchievement(double woodsNumber)
    {
        if (woodsNumber >= NextCount() && !achievementDisplayed[achievementGot])
        {
            achievementDisplayed[achievementGot] = true;
            AchievementUnlocked();
        }
    }
    
    private double NextCount()
    {
        double woods = 1000;

        for (int i = 0; i < achievementGot; i++)
        {
            woods *= achievementMultiplier;
        }
        return woods;
    }
    public void AchievementUnlocked()
    {
        GameObject achievementInst = Instantiate(achievementsPanel, parent: GameObject.Find("PlayScreen").transform);
        AchievementGO achiev = achievementInst.GetComponent<AchievementGO>();
        achiev.SetAchievementProperties(achievementGot);
        achievementGot++;
        SaveAchievement();
        Destroy(achievementInst, 5.8f);
    }

    private void SaveAchievement()
    {
        PlayerPrefs.SetInt("WoodsAchievement", achievementGot);
    }

    private void LoadAchievement()
    {
        achievementGot = PlayerPrefs.GetInt("WoodsAchievement", 0);
    }
}
