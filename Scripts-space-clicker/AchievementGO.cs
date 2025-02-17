using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementGO : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] achievementSprites;
    [SerializeField] private AudioSource audioSource;

    private int achievement;
    private int language;

    private void Start()
    {
        PlaySound();
    }

    public void SetAchievementProperties(int achievementNumber)
    {
        achievement = achievementNumber;
        language = Texts.Language();
        string[][] name = Texts.WoodsAchievementsNames();

        titleText.text = name[achievementNumber][language];
        image.sprite = achievementSprites[achievementNumber];
        descriptionText.text = GetDescription();
    }

    private string GetDescription()
    {
        string description;
        double woodsNumber = 1000;
        string[][] descriptionArray = Texts.WoodsAchievementsDescriptions();

        for (int i = 0; i < achievement; i++)
        {
            woodsNumber *= 10;
        }
        description = descriptionArray[0][language] + Texts.ConvertedCardsString(woodsNumber);
        return description;
    }

    private void PlaySound()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Sounds");
        audioSource.Play();
    }
}
