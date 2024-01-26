using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLoot", menuName = "Loot")]
public class Loot : ScriptableObject
{
    public string lootName;
    public Sprite lootSprite;
    public int dropChance;
}
