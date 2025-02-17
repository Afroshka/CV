using UnityEngine;

public class RocketRotate : MonoBehaviour
{
    private void Awake()
    {
        transform.Rotate(new Vector3(90,0,0));
        transform.position  = RocketRandomPosition();
    }

    private Vector3 RocketRandomPosition()
    {
        float spawnPosX = Random.Range(-5f, 5f);
        float spawnPosY = Random.Range(1, 4);
        float spawnPozZ = Camera.main.transform.position.z;
        Vector3 SpawnPosition = new Vector3(transform.position.x, spawnPosY, transform.position.z);
        return SpawnPosition;
    }
}
