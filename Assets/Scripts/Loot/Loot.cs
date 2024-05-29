using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLoot", menuName = "Loot")]
public abstract class Loot : ScriptableObject
{
    public string lootName;
    public Sprite lootSprite;
    public int dropChance;
    public int points;

    public abstract void TouchPlayer(GameObject obj);
}
