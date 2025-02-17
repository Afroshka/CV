using System.Collections;
using UnityEngine;

public class WoodsToButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private readonly float speed = 35f; // �������� �����������
    private float height; // ������ ��������
    private Vector3 startPosition; // ��������� ������� �������
    private Vector3 targetPosition; // �������� ������� �������
    private readonly bool isMoving = true; // ����, �����������, �������� �� ������

    private float volume;

    void Start()
    {
        targetPosition = GameObject.Find("WoodsTarget").GetComponent<RectTransform>().transform.position;
        transform.LookAt(Camera.main.transform.position);
        startPosition = transform.position;
        height = Random.Range(1, 6);
        StartCoroutine(MoveToTarget());
        volume = PlayerPrefs.GetFloat("Sounds", 0.3f) / 1.5f;
        Invoke(nameof(WoodsAddSound), Random.Range(1f, 1.1f));
    }

    private void Update()
    {
        transform.localScale -= 10 * Time.deltaTime  * new Vector3(0.01f, 0.01f, 0.01f);
    }
    IEnumerator MoveToTarget()
    {
        float startTime = Time.time; // ����� ������ ��������
        float journeyLength = Vector3.Distance(startPosition, targetPosition); // ���������� ����� ��������� � �������� ���������
        float journeyHeight = height; // ������ �������� ������������ ��������� �������
        while (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed; // ���������� ����������
            float fracJourney = distCovered / journeyLength; // ���������� ����� ����
            transform.position = Vector3.Lerp(startPosition, targetPosition, fracJourney) + journeyHeight * Mathf.Sin(fracJourney * Mathf.PI) * Vector3.up;
            yield return null;
        }
    }
    private void WoodsAddSound()
    {
        audioSource.volume = volume;
        audioSource.Play();
    }
}
