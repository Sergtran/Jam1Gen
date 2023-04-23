using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour, iGenericSpawnerOwner<FoodController>
{
    public GenericSpawner<FoodController> spawner;

    public void Awake()
    {
        spawner.Init(this);
    }

    public void Update()
    {
        
        spawner.Tick();
    }
    public void OnSpawnedNewItem(FoodController newItem, GenericPool<FoodController> pool)
    {
        newItem.Init(pool, transform);

    }
}