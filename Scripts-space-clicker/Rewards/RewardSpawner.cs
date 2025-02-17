using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] rewardObject;

    private void Start()
    {
        StartCoroutine(SpawnRewardCoroutine());
    }

    private Vector3 RewardSpawnPos()
    {
        float spawnPosX = 0;
        float spawnPosY = 5;
        float spawnPosZ = Camera.main.transform.position.z + 32;

       Vector3 spawnPos = new (spawnPosX, spawnPosY, spawnPosZ);

        return spawnPos;
    }

    private float SpawningTime()
    {
        float spawningTime = Random.Range(10, 20);
        return spawningTime;
    }

    private IEnumerator SpawnRewardCoroutine()
    {
        int boosterNumber = Random.Range(0, rewardObject.Length);
        yield return new WaitForSeconds(SpawningTime());
        Instantiate(rewardObject[boosterNumber], RewardSpawnPos(), Quaternion.identity);

        StartCoroutine(SpawnRewardCoroutine());
    }
}
