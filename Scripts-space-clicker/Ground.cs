using System.Collections;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Material[] materials;

    private MeshRenderer rendererGO;

    private void Start()
    {
        rendererGO = GetComponent<MeshRenderer>();
        rendererGO.material = materials[GetTargetToChangeMaterial()];
    }

    public void ChangeGroundMaterial()
    {
        StartCoroutine(ChangeMaterialCoroutine());
    }

    private IEnumerator ChangeMaterialCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        rendererGO.material = materials[GetTargetToChangeMaterial()];
    }

    private int GetTargetToChangeMaterial()
    {
        var target = PlayerPrefs.GetInt("LastTarget", 0);
        int number = 0;
        switch (target)
        {
            case <= 2:
                number = 0;
                break;
            case <= 7:
                number = 1;
                break;
            case <= 11:
                number = 2;
                break;
            case <= 15:
                number = 3;
                break;
            case <= 20:
                number = 4;
                break;
            case <= 29:
                number = 5;
                break;
            case <= 31:
                number = 6;
                break;
        }
        return number;
    }
}
