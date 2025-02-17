using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float speed = 2f;
    public float verticalMagnitude = 0.5f;
    public float horizontalMagnitude = 0.5f;
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        float horizontalOffset = Mathf.Sin(Time.time * speed) * horizontalMagnitude;
        float verticalOffset = Mathf.Cos(Time.time * speed) * verticalMagnitude;

        Vector3 newPosition = startingPosition + new Vector3(horizontalOffset, verticalOffset, 0);
        transform.position = newPosition;
    }

}

