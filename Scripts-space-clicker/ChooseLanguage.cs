using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseLanguage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string ru;
    [SerializeField] private string en;
    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UpdateText();
        }
    }
    private void UpdateText()
    {
        text.text = GetTranslatedString();
    }
    private string GetTranslatedString()
    {
        string resultText;
        var language = PlayerPrefs.GetString("Language", "ru");
        if (language == "en")
        {
            resultText = en;
        }
        else
        {
            resultText = ru;
        }
        return resultText;
    }
}
