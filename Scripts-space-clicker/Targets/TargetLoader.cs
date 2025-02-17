using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetLoader : MonoBehaviour
{
    private string lastTarget;
    public GameObject targetDestroyedText;
    public GameObject rewardObj;

    [SerializeField] private CameraMove cameraMove;
    [SerializeField] private Ground ground;
    [SerializeField] private Transform playScreen;

    private void Start()
    {
        SpawnLastTargetWithHealth();
    }

    private void SpawnLastTargetWithHealth()
    {
        lastTarget = PlayerPrefs.GetInt("LastTarget", 0).ToString();

        GameObject target = Resources.Load<GameObject>(lastTarget);
        GameObject instance = Instantiate(target, TargetSpawnPosition(), Quaternion.LookRotation(StartPosition()));
        Target targetScript = instance.GetComponent<Target>();
        if (PlayerPrefs.HasKey("healthOnExit"))
        {
            targetScript.currentHealth = double.Parse(PlayerPrefs.GetString("healthOnExit"));
            PlayerPrefs.DeleteKey("healthOnExit");
            PlayerPrefs.Save();
        }

    }
    public void SpawnTargetDestroyedPanel(string destroyedTarget)
    {

        string[][] destroyedTexts = Texts.TargetDestroyedTexts();
        Sprite[] destroyedSprite = Texts.TargetDestroyedSprite();
        int language = Texts.Language();

        GameObject destroyedGO = Instantiate(targetDestroyedText, parent: playScreen);

        TextMeshProUGUI text = destroyedGO.GetComponentInChildren<TextMeshProUGUI>();
        text.text = destroyedTexts[int.Parse(destroyedTarget)][language];

        Image image = destroyedGO.GetComponentsInChildren<Image>()[2];
        image.sprite = destroyedSprite[int.Parse(destroyedTarget)];

        Destroy(destroyedGO, 5f);
    }

    public void SpawnNextTarget(GameObject nextTarget, Vector3 nextPosition)
    {
        Instantiate(nextTarget, nextPosition, Quaternion.LookRotation(StartPosition()));
        cameraMove.MoveForward();
        ground.ChangeGroundMaterial();
    }
    private Vector3 TargetSpawnPosition()
    {
        return new Vector3(0, 10f, 30);
    }

    private Vector3 StartPosition()
    {
        return new Vector3(0, 0, -10);
    }
}
