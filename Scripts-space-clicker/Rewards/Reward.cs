using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private int activeTime;
    [SerializeField] private int rewardType;

    private readonly float speed = 100;
    private Rigidbody rewardRb;
    void Start()
    {
        Destroy(gameObject, 10f);
        rewardRb = GetComponent<Rigidbody>();
        rewardRb.AddForce(Vector3.up * 700);
    }

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime * Vector3.up);
        OnFingerTouch();
    }

    private void OnMouseDown()
    {
        GiveRewardAndDestroy();
    }

    private void OnFingerTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                GiveRewardAndDestroy();
            }
        }
    }
    private void GiveRewardAndDestroy()
    {
        switch (rewardType)
        {
            case 0:
                Levels.Instance.DoubleClickLevelOnAndOff(activeTime);
                Levels.Instance.DoubleTimeLevelOnAndOff(activeTime);
                break;
            case 1:
                GUIButtons.Instance.DoubleDamageActivate(activeTime);
                break;
        }
        Destroy(gameObject);
    }
}
