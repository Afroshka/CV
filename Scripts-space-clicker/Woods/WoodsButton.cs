using UnityEngine;

public class WoodsButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private GUIButtons guiButtons;

    private void Start()
    {
        guiButtons = GUIButtons.Instance;
    }
    public void AddWoods()
    {
        guiButtons.AddWoodsButton();
    }
    private void ClickSound()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Sounds", 0.3f);
        audioSource.Play();
    }
}
