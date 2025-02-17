using System.Collections;
using UnityEngine;

public class Gare : MonoBehaviour
{
    public IEnumerator GareMoveForwardCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 gareStartPos = transform.position;
        Vector3 gareEndPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 30);
        float duration = 1f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            transform.position = Vector3.Lerp(gareStartPos, gareEndPos, t);
            yield return null;
        }
    }
}
