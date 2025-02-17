using UnityEngine;

public class WoodCrate : MonoBehaviour
{
    [SerializeField] private GameObject woodsToButton;

    private Rigidbody rewardRb;

    void Start()
    {
        Destroy(gameObject, 10f);
        rewardRb = GetComponent<Rigidbody>();
        rewardRb.AddForce(Vector3.up * 700);
    }

    void Update()
    {
        OnFingerTouch();
    }

    private void OnMouseDown()
    {
        GiveWoodAndDestroy();
    }
    private void OnFingerTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                GiveWoodAndDestroy();
            }
        }
    }

    private void GiveWoodAndDestroy()
    {
        InstantiateWoods();
        Woods.Instance.RewardBoxWoods();
        Destroy(gameObject);
    }

    private void InstantiateWoods()
    {
        int numberOfWoods = Random.Range(5, 25);

        for (int i = 0; i < numberOfWoods; i++)
        {
            GameObject woodsInstance = Instantiate(woodsToButton, SpawnPosition(), Quaternion.identity);
            Destroy(woodsInstance, 1.1f);
        }
    }

    private Vector3 SpawnPosition()
    {
        float randomNumber = Random.Range(-5f, 5f);

        Vector3 spawnPos = new (transform.position.x + randomNumber, transform.position.y + randomNumber, transform.position.z + randomNumber);

        return spawnPos;
    }
}
