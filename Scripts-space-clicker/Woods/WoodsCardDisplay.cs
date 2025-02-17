using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WoodsCardDisplay : MonoBehaviour
{

    [SerializeField] private WoodsCard woodsCard;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private GameObject discountImage;
    [SerializeField] private AudioSource audioSource;

    private Button buyButton;

    private double levelsToAdd = 10;
    private double price = 100;

    private bool isActive = false;

    private void Start()
    {
        buyButton = GetComponentInChildren<Button>();
        InitializeCard();
        Woods.Instance.WoodsAdded += OnWoodsChanged;
        OnWoodsChanged(Woods.Instance.GetWoodsNumber());
        AttachTexts();
        discountImage.SetActive(HaveDiscount());
    }
    private void OnWoodsChanged(double Woods)
    {
        if (Woods >= price && !isActive)
        {
            buyButton.interactable = true;
            isActive = true;
        }
        else if (isActive && Woods < price)
        {
            buyButton.interactable = false;
            isActive = false;
        }
    }

    private void InitializeCard()
    {
        for (uint i = 0; i < woodsCard.cardLevel; i++)
        {
            price *= 5;
            levelsToAdd *= 4;
        }
        if (HaveDiscount())
        {
            price = Math.Round(price * 0.7, 2);
        }
    }

    private string GetName()
    {

        string[][] namesArray = Texts.WoodsCardsName();
        int language = Texts.Language();

        uint cardNumber = woodsCard.cardLevel + 1;
        string cardName;

        if (woodsCard.description == "per click")
        {
            cardName = namesArray[0][language] + " " + cardNumber.ToString();
        }
        else
        {
            cardName = namesArray[1][language] + " " + cardNumber.ToString();
        }
        return cardName;
    }

    private string GetDescription()
    {
        string[][] descriptionsArray = Texts.WoodsCardsDesription();
        int language = Texts.Language(); 

        string description;
        if (woodsCard.description == "per click")
        {
            description = descriptionsArray[0][language];
        }
        else
        {
            description = descriptionsArray[1][language];
        }
        return description;
    }
    private void AttachTexts()
    {
        nameText.text = GetName();
        descriptionText.text = string.Format("{0:N0}", Texts.ConvertedCardsString(levelsToAdd)) + " " + GetDescription();
        iconImage.sprite = woodsCard.icon;
        priceText.text = Texts.ConvertedCardsString(price);
    }

    private void BuySound()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Sounds", 0.3f);
        audioSource.Play();
    }
    public void BuyClickLevel()
    {
        var WoodsInst = Woods.Instance;

        if (WoodsInst.GetWoodsNumber() > price)
        {
            WoodsInst.OnBuy(price);
            BuySound();
            Levels.Instance.AddClickLevel(levelsToAdd);
            OnWoodsChanged(WoodsInst.GetWoodsNumber());
        }
    }
    public void BuyTimeLevel()
    {
        var WoodsInst = Woods.Instance;

        if (WoodsInst.GetWoodsNumber() > price)
        {
            WoodsInst.OnBuy(price);
            BuySound();
            Levels.Instance.AddTimeLevel(levelsToAdd);
            OnWoodsChanged(WoodsInst.GetWoodsNumber());
        }
    }

    private bool HaveDiscount()
    {
        var level = (woodsCard.cardLevel + 1);

        if (woodsCard.description == "per sec" && (level % 3) == 0)
        {
            return true;
        }
        else if (woodsCard.description == "per click" && (level % 5) == 0)
        {
            return true;
        }
        else if (woodsCard.cardLevel == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
