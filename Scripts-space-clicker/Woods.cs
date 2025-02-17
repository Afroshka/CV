using System;
using TMPro;
using UnityEngine;

public class Woods : MonoBehaviour
{
    [SerializeField] private Animator woodsAnimator;
    [SerializeField] private GameObject woodsAdded;


    private double woods = 0;

    public static Woods Instance { get; private set; }

    public event Action<double> WoodsAdded;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddWoods(double amount)
    {
        woods += amount;
        SaveWoods();
        FlowText(Texts.ConvertedString(amount));
        OnWoodsAdded();
    }

    public void OnBuy(double price)
    {
        woods -= price;
        SaveWoods();
    }

    public double GetWoodsNumber()
    {
        return woods;
    }

    private void SaveWoods()
    {
        if (WoodsAdded != null)
        {
            WoodsAdded(woods);
        }
        PlayerPrefs.SetString("Woods",woods.ToString());
        PlayerPrefs.Save();
        GUIButtons.Instance.UpdateWoodsText();
    }

    private void LoadWoods()
    {
        woods = double.Parse(PlayerPrefs.GetString("Woods", "0"));
        GUIButtons.Instance.UpdateWoodsText();
    }

    public void OnWoodsAdded()
    {
        woodsAnimator.SetTrigger("TextBeating");
    }

    private void FlowText(string amount)
    {
        GameObject woodsAddedGO = Instantiate(woodsAdded, parent: GameObject.Find("WoodsPanel").transform);
        TextMeshProUGUI woodsAddedText = woodsAddedGO.GetComponent<TextMeshProUGUI>();
        woodsAddedText.text = "        +" + amount;
        Destroy(woodsAddedGO, 0.5f);
    }

    public void ClearProgress()
    {
        LoadWoods();
    }

    private void OnEnable()
    {
        LoadWoods();
    }

    private void OnDisable()
    {
        SaveWoods();
    }
}
