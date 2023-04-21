using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


[Serializable]
public class GenericPool<T> where T : Component
{
    public Transform placeBorn;
    public T[] originalPrefabs;
    public int initialSize = 5;
    private List<T> poolItems = new List<T>();
    private List<bool> activeItems = new List<bool>();

    public void Init()
    {
        GrowPool(initialSize);
    }
    public void GrowPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var idx = Random.Range(0, originalPrefabs.Length);
            var newItem = GameObject.Instantiate(originalPrefabs[idx], placeBorn);
            poolItems.Add(newItem);
            activeItems.Add(false);
            newItem.gameObject.SetActive(false);
        }
    }

    public T GetFreeItem()
    {
        for (int i = 0; i < poolItems.Count; i++)
        {
            if (activeItems[i] == false)
            {
                activeItems[i] = true;
                return poolItems[i];
            }
        }
        var lastIdx = poolItems.Count;
        GrowPool(5);
        activeItems[lastIdx] = true;
        return poolItems[lastIdx];
    }
    public void RecycleItem(T item)
    {
        var idx = poolItems.IndexOf(item);
        activeItems[idx] = false;
    }
}
