using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerName : MonoBehaviour
{
    private string playerName;
    public TMP_InputField inputField;
    public GameObject playScreen;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            gameObject.SetActive(false);
            playScreen.SetActive(true);
        }
        else
        {
            gameObject.SetActive(true);
            playScreen.SetActive(false);    
        }
    }

    public void EnterPlayerName()
    {
        SavePlayerName();
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        gameObject.SetActive(false);
        playScreen.SetActive(true);
    }
    private string SavePlayerName()
    {
        playerName = inputField.text;
        return playerName;
    }
}
