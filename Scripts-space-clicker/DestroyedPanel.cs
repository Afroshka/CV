using UnityEngine;

public class DestroyedPanel : MonoBehaviour
{
    private void Update()
    {
        // Обработка нажатия мыши или касания
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Получение позиции нажатия
            Vector3 touchPosition = GetTouchPosition();

            // Проверка попадания на объект
            if (IsTouchingObject(touchPosition))
            {
                // Уничтожение объекта
                Destroy(gameObject);
            }
        }
    }

    private Vector3 GetTouchPosition()
    {
        // Если есть касание, возвращаем его позицию
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return Camera.main.ScreenToWorldPoint(touch.position);
        }
        // Иначе возвращаем позицию мыши
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool IsTouchingObject(Vector3 touchPosition)
    {
        // Проверка попадания на объект с помощью Raycast
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }
}
