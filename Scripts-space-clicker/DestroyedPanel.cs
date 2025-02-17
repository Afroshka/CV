using UnityEngine;

public class DestroyedPanel : MonoBehaviour
{
    private void Update()
    {
        // ��������� ������� ���� ��� �������
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // ��������� ������� �������
            Vector3 touchPosition = GetTouchPosition();

            // �������� ��������� �� ������
            if (IsTouchingObject(touchPosition))
            {
                // ����������� �������
                Destroy(gameObject);
            }
        }
    }

    private Vector3 GetTouchPosition()
    {
        // ���� ���� �������, ���������� ��� �������
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return Camera.main.ScreenToWorldPoint(touch.position);
        }
        // ����� ���������� ������� ����
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool IsTouchingObject(Vector3 touchPosition)
    {
        // �������� ��������� �� ������ � ������� Raycast
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }
}
