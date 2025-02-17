using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Pause pause;

    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        ShowGameObject(gameScreen);
    }

    private void PlayClickSound()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Sounds", 0.15f);
        audioSource.Play();
    }
    public void ShowGameObject(GameObject gameObject)
    {
        UnableAllObjects();
        Activate(gameObject);
        PlayClickSound();
    }

    public void WatchAd()
    {
        Yandex.Instance.DoubleWoodsAdv();
    }

    private void UnableAllObjects()
    {
        gameScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    private void Activate(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
