using System.Collections;
using UnityEngine;

public class CameraMove: MonoBehaviour
{
    [SerializeField] private Gare gare;
    public void MoveForward()
    {
        StartCoroutine(CameraMoveForwardCoroutine());
        StartCoroutine(gare.GareMoveForwardCoroutine());
    }
    private IEnumerator CameraMoveForwardCoroutine()
    {
        Vector3 camStartPos = Camera.main.transform.position;
        Vector3 camEndPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 30);
        float duration = 1f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            Camera.main.transform.position = Vector3.Lerp(camStartPos, camEndPos, t);
            yield return null;
        }
    }
}
