using UnityEngine;

public class BackGround : MonoBehaviour
{
    private int backgroundLevel;

    private void Start()
    {
        transform.position = BackgroundPosition();
    }

    private Vector3 BackgroundPosition()
    {
        backgroundLevel = PlayerPrefs.GetInt("LastTarget", 0) * 30;
        float spawnPosZ = transform.position.z - backgroundLevel;
        Vector3 nextPos = new Vector3(transform.position.x, transform.position.y, spawnPosZ);
        return nextPos;
    }
}