using UnityEngine;

public class WoodsAdded : MonoBehaviour
{
    [SerializeField] private Animator woodsAddedAnim;
    void Start()
    {
        woodsAddedAnim.SetTrigger("WoodsAdded");
    }
}
