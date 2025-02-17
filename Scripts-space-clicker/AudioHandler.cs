using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    public Slider soundsSlider;
    public Slider musicSlider;

    [SerializeField] private AudioSource musicSource;

    private readonly string music = "Music";
    private readonly string sounds = "Sounds";

    private float defaultVolume = 0.15f;

    private void Awake()
    {
        UpdateSlider(soundsSlider);
        UpdateSlider(musicSlider);
        soundsSlider.onValueChanged.AddListener(delegate { SaveVolume(sounds, soundsSlider.value); });
        musicSlider.onValueChanged.AddListener(delegate { SaveVolume(music, musicSlider.value); });
    }

    private void Start()
    {
        UpdateMusicSound();
    }

    private void UpdateMusicSound()
    {
        musicSource.volume = GetVolume(music);
    }

    private void UpdateSlider(Slider slider)
    {
        string volumeString;
        if (slider == soundsSlider)
        {
            volumeString = sounds;
        }
        else
        {
            volumeString = music;
        }
        slider.value = PlayerPrefs.GetFloat(volumeString, defaultVolume);
    }

    public static void PlaySounds(AudioSource audioSource, AudioClip audioClip, float volume)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
    }

    private void SaveVolume(string volumeToSave, float floatToSave)
    {
        PlayerPrefs.SetFloat(volumeToSave, floatToSave);
        UpdateMusicSound();
    }

    public static float GetVolume(string volumeToGet)
    {
        float defaultVolume = 0.15f;
        float volume = PlayerPrefs.GetFloat(volumeToGet, defaultVolume);
        return volume;
    }
}
