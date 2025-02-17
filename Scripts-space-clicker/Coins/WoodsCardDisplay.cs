using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WoodsCardDisplay : MonoBehaviour
{

    [SerializeField] private WoodsCard WoodsCard;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI priceText;

    private Button buyButton;

    private double price;
    private bool isActive = false;

    private void Start()
    {
        buyButton = GetComponentInChildren<Button>();
        Woods.Instance.WoodsAdded += OnWoodsChanged;
        OnWoodsChanged(Woods.Instance.GetWoodsNumber());
        price = double.Parse(WoodsCard.price);
        AttachTexts();
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

    private void AttachTexts()
    {
        nameText.text = WoodsCard.name;
        descriptionText.text = string.Format("{0:N0}", Texts.ConvertedCardsString(double.Parse(WoodsCard.levelsToAdd))) + " " + WoodsCard.description;
        iconImage.sprite = WoodsCard.icon;
        priceText.text = Texts.ConvertedCardsString(price);
    }

    public void BuyClickLevel()
    {
        var WoodsInst = Woods.Instance;

        if (WoodsInst.GetWoodsNumber() > price)
        {
            WoodsInst.OnBuy(price);
            Levels.Instance.AddClickLevel(double.Parse(WoodsCard.levelsToAdd));
            OnWoodsChanged(WoodsInst.GetWoodsNumber());
        }
    }
    public void BuyTimeLevel()
    {
        var WoodsInst = Woods.Instance;

        if (WoodsInst.GetWoodsNumber() > price)
        {
            WoodsInst.OnBuy(price);
            Levels.Instance.AddTimeLevel(double.Parse(WoodsCard.levelsToAdd));
            OnWoodsChanged(WoodsInst.GetWoodsNumber());
        }
    }
}
