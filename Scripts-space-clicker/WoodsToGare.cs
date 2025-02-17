using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsToGare : MonoBehaviour
{
    private Transform target; // объект, к которому нужно переместиться
    private readonly float speed = 20f; // скорость перемещения
    private float height; // высота параболы
    private Vector3 startPosition; // начальная позиция объекта
    private RectTransform buttonPositionUI;
    private Vector3 targetPosition; // конечная позиция объекта
    private bool isMoving = true; // флаг, указывающий, движется ли объект

    void Start()
    {
        target = GameObject.Find("WallFlames").transform;
        buttonPositionUI = GameObject.Find("WoodsButton").GetComponent<RectTransform>();
        transform.LookAt(Camera.main.transform.position);
        startPosition = new Vector3(buttonPositionUI.position.x, buttonPositionUI.position.y, buttonPositionUI.position.z);
        targetPosition = target.position;
        height = Random.Range(1, 6);
            StartCoroutine(MoveToTarget());
    }

    private void FixedUpdate()
    {
        transform.localScale += new Vector3(1.5f, 1.5f, 0) * 1 * Time.deltaTime;
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
            transform.position = Vector3.Lerp(startPosition, targetPosition, fracJourney) + Vector3.up * Mathf.Sin(fracJourney * Mathf.PI) * journeyHeight;
            yield return null;
        }
    }
}
