using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject itemPrefab;

    [SerializeField]
    private List<Loot> lootList = new List<Loot>();

    [SerializeField]
    private float 
        dropForce,
        spinSpeed;

    Loot GetItem()
    {
        int randomNumber = Random.Range(1, 101);

        List<Loot> possibleItems = new List<Loot>();

        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }

        return null;
    }

    public void InstantiateLoot(Vector3 spawnPos)
    {
        Loot droppedItem = GetItem();
        if(droppedItem != null)
        {
            GameObject lootObject = Instantiate(itemPrefab, spawnPos, Quaternion.identity);
            lootObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            lootObject.GetComponent<Drops>().lootSO = droppedItem;

            Vector2 dropDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootObject.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f) * spinSpeed);
            lootObject.GetComponent<Rigidbody2D>().AddForce(dropDir * dropForce, ForceMode2D.Impulse);
        }
    }

}
