using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtons : MonoBehaviour
{
    public static GUIButtons Instance { get; private set; }

    public Woods woodsInstance;
    public Levels levels;
    private Pause pause;

    [SerializeField] private TextMeshProUGUI WoodsText;
    [SerializeField] private TextMeshProUGUI currentClickLevelText;
    [SerializeField] private TextMeshProUGUI currentTimeLevelText;
    [SerializeField] private GameObject welcomeBackPanel;
    [SerializeField] private GameObject firstStartPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip errorClip;
    public TextMeshProUGUI errorText;

    public bool doubleDamage;

    private string woodsStr, woodsPerClickStr, woodsPerSecStr;

    private WeaponsCardDisplay[] weaponCards;
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
        pause = FindObjectOfType<Pause>();
    }

    //private void OnEnable()
    //{
    //    UpdateClickLevelText();
    //    UpdateTimeLevelText();
    //    Invoke(nameof(AddWoodsPerSecond), 1);
    //    UpdateWoodsText();
    //}

    private void Start()
    {
        weaponCards = FindAllWeaponsCards();
        GetTexts();
        UpdateWoodsText();
        UpdateClickLevelText();
        UpdateTimeLevelText();
        Invoke(nameof(AddWoodsPerSecond), 5);
        if (PlayerPrefs.HasKey("lastExitTime"))
        {
            ActivatePanel(welcomeBackPanel, true);
        }
        else
        {
            ActivatePanel(firstStartPanel, true);
        }
    }

    private void ActivatePanel(GameObject panel, bool boolean)
    {
        panel.SetActive(boolean);
    }

    private void GetTexts()
    {
        string[][] texts = Texts.WoodsTexts();
        int language = Texts.Language();
        woodsStr = texts[0][language];
        woodsPerClickStr = texts[1][language];
        woodsPerSecStr = texts[2][language];
    }

    public void AddWoodsButton()
    {
        woodsInstance.AddWoods(levels.GetClickLevel());
        UpdateWoodsText();
    }

    private void AddWoodsPerSecond()
    {
        woodsInstance.AddWoods(levels.GetTimeLevel());
        UpdateWoodsText();
        Invoke(nameof(AddWoodsPerSecond),1);
    }

    public void UpdateWoodsText()
    {
        WoodsText.text = woodsStr + " : " + Texts.ConvertedString(woodsInstance.GetWoodsNumber());
    }
    public void UpdateClickLevelText()
    {
        currentClickLevelText.text = woodsPerClickStr + ":\r\n" + Texts.ConvertedString(levels.GetClickLevel());
    }

    public void UpdateTimeLevelText()
    {
        currentTimeLevelText.text = woodsPerSecStr + ":\r\n" + Texts.ConvertedString(levels.GetTimeLevel());
    }

    public void InstantiateErrorText(string textOfError)
    {
        errorText.text = textOfError;
        TextMeshProUGUI errorTextInst = Instantiate(errorText, parent: transform.Find("PlayScreen"));
        PlaySound(errorClip, 2f);
        Destroy(errorTextInst.gameObject, 1.5f);
    }

    private void PlaySound(AudioClip audioClip, float volumeMultiplier)
    {
        audioSource.clip = audioClip;
        audioSource.volume = AudioHandler.GetVolume("Sounds") * volumeMultiplier;
        audioSource.Play();
    }

    public void EnterAddWoods(double woodsToAdd)
    {
        woodsInstance.AddWoods(woodsToAdd);
        UpdateWoodsText();
    }

    public void DoubleDamageActivate(float activeTime)
    {
        StartCoroutine(DoubleDamageCoroutine(activeTime));
    }

    private IEnumerator DoubleDamageCoroutine(float activeTime)
    {
        doubleDamage = true;
        FindAllWeaponCardsAndUpdateDamage(true);
        FindAllWeaponCardsAndUpdateBackground(true);

        yield return new WaitForSeconds(activeTime);


        yield return new WaitForSeconds(1f);

        doubleDamage = false;
        FindAllWeaponCardsAndUpdateBackground(false);
        FindAllWeaponCardsAndUpdateDamage(false);
    }

    private WeaponsCardDisplay[] FindAllWeaponsCards()
    {
        WeaponsCardDisplay[] weaponCards = FindObjectsOfType<WeaponsCardDisplay>();
        return weaponCards;
    }
    private void FindAllWeaponCardsAndUpdateDamage(bool boolean)
    {
        foreach (WeaponsCardDisplay weaponCard in weaponCards)
        {
            weaponCard.UpdateDamage(boolean);
        }
    }
    private void FindAllWeaponCardsAndUpdateBackground(bool boolean)
    {
        foreach (WeaponsCardDisplay weaponCard in weaponCards)
        {
            weaponCard.TurnFireBackground(boolean);
        }
    }

    public void PauseOn()
    {
        pause.PauseOn();
    }
    public void PauseOff()
    {
        pause.PauseOff();
    }
    public void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        woodsInstance.ClearProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("lastExitTime", System.DateTime.Now.ToString());
        PlayerPrefs.Save();
    }
}
