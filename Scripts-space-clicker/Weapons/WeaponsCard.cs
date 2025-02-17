using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Card", menuName = "Cards/Weapons")]
public class WeaponsCard : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    public uint cardLevel;

    public uint speed;

    public GameObject weapon;

}
