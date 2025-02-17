using System;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public double woods = 100;
    public double clickLevel = 1;
    public double timeLevel = 1;
    public int lastTarget = 0;
}

public class Woods : MonoBehaviour
{
    public PlayerInfo PlayerInfo;
    public Levels levels;
    public GUIButtons guiButtons;
    public Achievements achievements;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    #region Objects
    [SerializeField] private Animator woodsAnimator;
    [SerializeField] private GameObject woodsAdded;
    [SerializeField] private AudioSource audioSource;
    #endregion


    public static Woods Instance { get; private set; }

    public event Action<double> WoodsAdded;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //LoadExtern();
            //Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RewardBoxWoods()
    {
        StartCoroutine(RewardCor());
    }

    private IEnumerator RewardCor()
    {
        yield return new WaitForSeconds(1.25f);
        double woodToAdd = (levels.GetClickLevel() * 50) + (levels.GetTimeLevel() * 50);
        AddWoods(woodToAdd);
    }
    public void AddWoods(double amount)
    {
        PlayerInfo.woods += amount;
        FlowText(Texts.ConvertedString(amount));
        OnWoodsAdded();
        if (WoodsAdded != null)
        {
            WoodsAdded(PlayerInfo.woods);
        }
        Save();
    }

    public void OnBuy(double price)
    {
        PlayerInfo.woods -= price;
        if (WoodsAdded != null)
        {
            WoodsAdded(PlayerInfo.woods);
        }
        guiButtons.UpdateWoodsText();
        Save();
    }

    public double GetWoodsNumber()
    {
        return PlayerInfo.woods;
    }

    public void Save()
    {
        //PlayerPrefs.SetString("Woods", playerInfo.woods.ToString());
        //PlayerPrefs.SetString("Click", playerInfo.clickLevel.ToString());
        //PlayerPrefs.SetString("Time", playerInfo.timeLevel.ToString());
        //PlayerPrefs.Save();

#if UNITY_WEBGL
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        Debug.Log("SAVED GAME in unity = " + jsonString);
        //SaveExtern(jsonString);
#endif
    }

    public void Load(string value)
    {
        //playerInfo.woods = double.Parse(PlayerPrefs.GetString("Woods", "100"));
        //playerInfo.clickLevel = double.Parse(PlayerPrefs.GetString("Click", "1"));
        //playerInfo.timeLevel = double.Parse(PlayerPrefs.GetString("Time", "1"));

#if UNITY_WEBGL
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        Debug.Log("LOADed in unity = " + value);
#endif
        guiButtons.UpdateWoodsText();
    }

    public void OnWoodsAdded()
    {
        woodsAnimator.SetTrigger("TextBeating"); 
        WoodsAddSound();
        guiButtons.UpdateWoodsText();
    }

    private void WoodsAddSound()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Sounds", 0.3f) / 1.5f;
        audioSource.Play();
    }

    private void FlowText(string amount)
    {
        GameObject woodsAddedGO = Instantiate(woodsAdded, parent: GameObject.Find("WoodsPanel").transform);
        TextMeshProUGUI woodsAddedText = woodsAddedGO.GetComponent<TextMeshProUGUI>();
        woodsAddedText.text = "                +" + amount;
        Destroy(woodsAddedGO, 0.5f);
    }

    public void ClearProgress()
    {
        PlayerInfo = new PlayerInfo();
        Save();
    }

    //private void OnEnable()
    //{
    //    SetPlayerInfo();
    //}

    //private void OnDisable()
    //{
    //    Save();
    //}

    //private void OnApplicationQuit()
    //{
    //    Save();
    //}
}
