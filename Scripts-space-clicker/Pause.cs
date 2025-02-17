using System.Collections;
using TMPro;
using UnityEngine;

public class Pause: MonoBehaviour
{
    public GameObject pausePanel;
    public float timeOfCountdown;
    public bool isPaused;

    [Header("Texts")]
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI soundsText;
    public TextMeshProUGUI musicText;

    private void Start()
    {
        PauseOff();
        UpdateTexts();
    }
    private void Update()
    {
        if (timeOfCountdown > 0)
        {
            timeOfCountdown -= Time.unscaledDeltaTime;
            countdownText.text = "" +  timeOfCountdown.ToString("0.0");
        }
    }

    public void PauseOn()
    {
        pausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void UpdateTexts()
    {
        string[][] pauseTexts = Texts.PauseTexts();
        int language = Texts.Language();
        soundsText.text = pauseTexts[0][language];
        musicText.text = pauseTexts[1][language];
    }

    public void ChangeLanguage()
    {
        int language = PlayerPrefs.GetInt("Language", 0);
        if (language == 0)
        {
            PlayerPrefs.SetInt("Language", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Language", 0);
        }
    }

    private IEnumerator CountdownTimerStart()
    {
        timeOfCountdown = 3;
        do
        {
            yield return new WaitForSecondsRealtime(0.1f);
        } while (timeOfCountdown > 0);
        PauseOff();
    }
}
