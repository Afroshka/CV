using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsCardDisplay : MonoBehaviour
{

    public WeaponsCard weaponCard;

    [Header("GameObjects")]
    [SerializeField] private GameObject fireParticle;
    [SerializeField] private GameObject doubleDamageBackground; 
    [SerializeField] private Button buyButton;

    [SerializeField] private Image image;
    [SerializeField] private Image delayPanel;

    [SerializeField] private Sprite closedSprite;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip autoBuyClip;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI autoBuyText;
    [SerializeField] private TextMeshProUGUI onOffText;

    public GameObject woods;

    private new string name;
    private string[][] weaponDescriptions;
    private string[][] autoBuyArray;
    private int language;

    private double price = 20;
    private double damage = 2;
    private float delayDuration = 0.15f;
    private int maxAutoBuys = 2;


    private bool unlocked = false;
    private bool autoBuy;
    private bool delayIsActive;

    [HideInInspector] public uint speed;
    public static int autoBuyCount = 0;


    private void Start()
    {
        language = Texts.Language();
        InitializeCard();
        speed = weaponCard.speed;
        Woods.Instance.WoodsAdded += OnWoodsChanged;
        OnWoodsChanged(Woods.Instance.GetWoodsNumber());
        UpdateAutoBuyTexts();
        UpdateText();
    }

    private void FixedUpdate()
    {
        if (!delayIsActive && autoBuy && IsEnoughWoods())
        {
            DelayedAutoBuy();
        }
    }

    private void UpdateAutoBuyTexts()
    {
        language = Texts.Language();
        autoBuyArray = Texts.AutoBuyTexts();
        if (autoBuy)
        {
            onOffText.text = autoBuyArray[1][language];
        }
        else if (!autoBuy)
        {
            onOffText.text = autoBuyArray[2][language];
        }
        autoBuyText.text = autoBuyArray[0][language];
    }

    public void UpdateDamage(bool doubleDmg)
    {
        if (doubleDmg)
        {
            damage *= 2;
        }
        else
        {
            damage /= 2;
        }
        UpdateText();
    }

    public void TurnFireBackground(bool boolean)
    {

        doubleDamageBackground.SetActive(boolean);
    }

    private void InitializeCard()
    {
        string[][] weaponsCardsNames = Texts.WeaponCardsNames();
        weaponDescriptions = Texts.WeaponsCardsDescription();
        name = weaponsCardsNames[weaponCard.cardLevel][language];
        for (uint i = 0; i < weaponCard.cardLevel; i++)
        {
            price *= 2;
            damage *= 5;
            delayDuration += 0.05f;
        }
    }

    public void CheckIfPurchasable()
    {
        PlaySound(clickClip);
        StartCoroutine(InstantiateWeaponCoroutine());
    }

    private void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.volume = PlayerPrefs.GetFloat("Sounds", 0.15f);
        audioSource.Play();
    }

    private void UpdateText()
    {
        if (IsEnoughWoods())
        {
            ShowInformation();
        }
        else if (!IsEnoughWoods())
        {
            HideInformation();
        }
    }

    private void HideInformation()
    {
        switch (unlocked)
        {
            case false:
                HideAllInformation();
                break;
            case true:
                HidePartOfInformation();
                break;
        }
    }
    
    private void HidePartOfInformation()
    {
        nameText.text = name;
        descriptionText.text = weaponDescriptions[1][language];
        image.sprite = weaponCard.icon;
        priceText.text = Texts.ConvertedCardsString(price);
        buyButton.interactable = false;
    }
    private void HideAllInformation()
    {
        nameText.text = "????????";
        descriptionText.text = "????????";
        image.sprite = closedSprite;
        priceText.text = Texts.ConvertedCardsString(price);
        buyButton.interactable = false;
    }

    private void ShowInformation()
    {
        nameText.text = name;
        descriptionText.text = string.Format("{0:N0}", damage) + weaponDescriptions[0][language];
        image.sprite = weaponCard.icon;
        priceText.text = Texts.ConvertedCardsString(price);
        unlocked = true;
        buyButton.interactable = true;
    }

    private void OnWoodsChanged(double Woods)
    {
        UpdateText();
    }

    private void DelayedAutoBuy()
    {
        CheckIfPurchasable();
    }
    private IEnumerator DelayCoroutine()
    {
        delayIsActive = true;
        float startFillAmount = delayPanel.fillAmount = 1f;
        float targetFillAmount = 0f;

        float timeElapsed = 0f;

        delayPanel.gameObject.SetActive(true);

        while (timeElapsed < delayDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / delayDuration);

            // Выполняем плавное уменьшение fillAmount
            delayPanel.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, t);

            yield return null;
        }
        delayPanel.gameObject.SetActive(false);
        delayIsActive = false;

    }

    private void InstantiateWeaponWoods()
    {
        GameObject woodInst = Instantiate(woods, GameObject.Find("WoodsCanvas").transform);
        Destroy(woodInst, 1f);
    }
    
    private void InstantiateWeapon()
    {
        GameObject fireInst = Instantiate(fireParticle, WeaponSpawnPosition(), Quaternion.identity);
        Destroy(fireInst, 1);
        GameObject weaponInst = Instantiate(weaponCard.weapon, WeaponSpawnPosition(), Quaternion.identity);
        WeaponBehaviour weaponScript = weaponInst.GetComponent<WeaponBehaviour>();
        weaponScript.SetSettings(speed, damage);
    }
    private IEnumerator InstantiateWeaponCoroutine()
    {
        StartCoroutine(DelayCoroutine());
        Woods.Instance.OnBuy(price);
        InstantiateWeaponWoods();
        yield return new WaitForSeconds(1f);

        InstantiateWeapon();
    }

    public void AutoBuy()
    {
        if (!autoBuy && !AutoBuyMax())
        {
            autoBuyCount++;
            autoBuy = true;
            autoBuyText.text = "ON";
        }
        else if (autoBuy)
        {
            autoBuyCount--;
            autoBuy = false;
            autoBuyText.text = "OFF";
        }
        else if (AutoBuyMax())
        {
            GUIButtons.Instance.InstantiateErrorText(ErrorText());
        }
        UpdateAutoBuyTexts();
    }

    private Vector3 WeaponSpawnPosition()
    {
        float spawnPosX = Random.Range(-5f, 5f);
        float spawnPozZ = Camera.main.transform.position.z + 17;
        Vector3 SpawnPosition = new (spawnPosX, 0, spawnPozZ);
        return SpawnPosition;
    }
    
    private string ErrorText()
    {
        string[][] errorTexts = Texts.ErrorsTexts();
        string error = errorTexts[0][language];
        return error;
    }

    private bool IsEnoughWoods()
    {
        if (Woods.Instance.GetWoodsNumber() >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private bool AutoBuyMax()
    {
        if (autoBuyCount >= maxAutoBuys)
        {
            return true;
        }
        return false;
    }
}
