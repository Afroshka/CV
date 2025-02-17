using UnityEngine;

[CreateAssetMenu(fileName = "New Woods Card", menuName = "Cards/Woods")] 
public class WoodsCard : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    public string price;
    public string levelsToAdd;
}
