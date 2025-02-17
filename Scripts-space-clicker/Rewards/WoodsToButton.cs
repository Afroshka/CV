using System.Collections;
using UnityEngine;

public class WoodsToButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private readonly float speed = 35f; // скорость перемещения
    private float height; // высота параболы
    private Vector3 startPosition; // начальная позиция объекта
    private Vector3 targetPosition; // конечная позиция объекта
    private readonly bool isMoving = true; // флаг, указывающий, движется ли объект

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
        float startTime = Time.time; // время начала движения
        float journeyLength = Vector3.Distance(startPosition, targetPosition); // расстояние между начальной и конечной позициями
        float journeyHeight = height; // высота параболы относительно начальной позиции
        while (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed; // пройденное расстояние
            float fracJourney = distCovered / journeyLength; // пройденная часть пути
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
