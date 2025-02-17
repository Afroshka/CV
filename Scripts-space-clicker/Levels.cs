using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public Woods woods;
    public GUIButtons guiButtons;
    public Pause pause;

    private int ScoreMultiplier = 1;
    private int timeMultiplier = 1;

    private float timeToAdd;
    private float ScoreTimeToAdd;

    private bool doubleScore = false;
    private bool doubleTime = false;

    #region Objects
    [SerializeField] private TextMeshProUGUI doubleScoreText;
    [SerializeField] private TextMeshProUGUI doubleTimeText;

    [SerializeField] private GameObject doubleScoreClock;
    [SerializeField] private GameObject doubleTimeClock;

    [SerializeField] private Animator ScoreAnimator;
    [SerializeField] private Animator timeAnimator;
    #endregion

    public static Levels Instance { get; private set; }

    private int timesScoreed;
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

    public void DoubleScoreLevelOnAndOff(int activeTime)
    {
        if (!doubleScore)
        {
        StartCoroutine(DoubleScoreCoroutine(activeTime));
        }
        else
        {
            ScoreTimeToAdd = activeTime;
        }
    }

    public void DoubleTimeLevelOnAndOff(int activeTime)
    {
        if (!doubleTime)
        {
        StartCoroutine(DoubleTimeCoroutine(activeTime));
        }
        else
        {
            timeToAdd = activeTime;
        }
    }

    public void AddScoreLevel(double amount)
    {
        woods.PlayerInfo.ScoreLevel += amount;
        ScoreCounter();
        guiButtons.UpdateScoreLevelText();
        woods.Save();
    }

    public void AddTimeLevel(double amount)
    {
        woods.PlayerInfo.timeLevel += amount;
        ScoreCounter();
        guiButtons.UpdateTimeLevelText();
        woods.Save();
    }

    public void DoubleLevelsAdv()
    {
        DoubleScoreLevelOnAndOff(60);
        DoubleTimeLevelOnAndOff(60);
    }

    private void AnimateBeatingText(Animator animator)
    {
        animator.SetTrigger("TextBeating");
    }
    public double GetScoreLevel()
    {
        return woods.PlayerInfo.ScoreLevel * ScoreMultiplier;
    }

    public double GetTimeLevel()
    {
        return woods.PlayerInfo.timeLevel * timeMultiplier;
    }

    private IEnumerator DoubleScoreCoroutine(float secondsActivated)
    {
        doubleScore = true;
        ScoreMultiplier = 2;
        doubleScoreClock.SetActive(true);
        guiButtons.UpdateScoreLevelText();

        while (secondsActivated > 0)
        {
            yield return null;
            if (ScoreTimeToAdd != 0)
            {
                secondsActivated += ScoreTimeToAdd;
                ScoreTimeToAdd = 0;
            }
            secondsActivated -= Time.deltaTime;
            doubleScoreText.text = "" + secondsActivated.ToString("0.0");
        }

        doubleScore = false;
        ScoreMultiplier = 1;
        doubleScoreClock.SetActive(false);
        guiButtons.UpdateScoreLevelText();
    }

    private IEnumerator DoubleTimeCoroutine(float secondsActivated)
    {
        doubleTime = true;
        timeMultiplier = 2;
        doubleTimeClock.SetActive(true);
        guiButtons.UpdateTimeLevelText();

        while (secondsActivated > 0)
        {
            yield return null;
            if (timeToAdd != 0)
            {
                secondsActivated += timeToAdd;
                timeToAdd = 0;
            }
            secondsActivated -= Time.deltaTime;
            doubleTimeText.text = "" + secondsActivated.ToString("0.0");
        }

        doubleTime = false;
        timeMultiplier = 1;
        doubleTimeClock.SetActive(false);
        guiButtons.UpdateTimeLevelText();
    }

    private void ScoreCounter()
    {
        timesScoreed++;
        if ((timesScoreed % 10) == 0)
        {
            Debug.Log("Button Scoreed " + timesScoreed + " times");
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString("ScoreLevel", woods.PlayerInfo.ScoreLevel.ToString());
        PlayerPrefs.SetString("TimeLevel", woods.PlayerInfo.timeLevel.ToString());
        PlayerPrefs.Save();
    }

    private void Load()
    {
        woods.PlayerInfo.ScoreLevel = double.Parse(PlayerPrefs.GetString("ScoreLevel", "1"));
        woods.PlayerInfo.timeLevel = double.Parse(PlayerPrefs.GetString("TimeLevel", "1"));
    }

    //public void ClearProgress()
    //{
    //    Load();
    //}

    //private void OnEnable()
    //{
    //    Load();
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