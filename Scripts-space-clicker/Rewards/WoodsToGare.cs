using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsToGare : MonoBehaviour
{
    private readonly float speed = 20f; // �������� �����������
    private float height; // ������ ��������
    private Vector3 startPosition; // ��������� ������� �������
    private RectTransform buttonPositionUI;
    private Vector3 targetPosition; // �������� ������� �������
    private bool isMoving = true; // ����, �����������, �������� �� ������

    void Start()
    {
        targetPosition = GameObject.Find("WallFlames").transform.position;
        buttonPositionUI = GameObject.Find("WoodsTarget").GetComponent<RectTransform>();
        transform.LookAt(Camera.main.transform.position);
        startPosition = new Vector3(buttonPositionUI.position.x, buttonPositionUI.position.y, buttonPositionUI.position.z);
        height = Random.Range(1, 6);
        StartCoroutine(MoveToTarget());
    }

    private void FixedUpdate()
    {
        transform.localScale += new Vector3(1.5f, 1.5f, 0) * 1 * Time.deltaTime;
    }

    private Vector3 FinishPosition()
    {
        float randomNumber = Random.Range(-5, 5);
        Vector3 finishPos = new Vector3(targetPosition.x + randomNumber, targetPosition.y, targetPosition.z);
        return finishPos;
    }
    IEnumerator MoveToTarget()
    {
        targetPosition = FinishPosition();
        float startTime = Time.time; // ����� ������ ��������
        float journeyLength = Vector3.Distance(startPosition, targetPosition); // ���������� ����� ��������� � �������� ���������
        float journeyHeight = height; // ������ �������� ������������ ��������� �������
        while (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed; // ���������� ����������
            float fracJourney = distCovered / journeyLength; // ���������� ����� ����
            transform.position = Vector3.Lerp(startPosition, targetPosition, fracJourney) + Vector3.up * Mathf.Sin(fracJourney * Mathf.PI) * journeyHeight;
            yield return null;
        }
    }
}
