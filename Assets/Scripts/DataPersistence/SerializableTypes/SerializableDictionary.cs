using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<Tkey, TValue> : Dictionary<Tkey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<Tkey> keys = new List<Tkey>();
    [SerializeField]
    private List<TValue> values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        keys.Clear(); 
        values.Clear();

        foreach(KeyValuePair<Tkey, TValue> kvp in this)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();

        if(keys.Count != values.Count)
            Debug.Log("Number of keys : " + keys.Count + "isn't equal to number of values : " + values.Count);

        for(int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}
