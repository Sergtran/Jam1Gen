using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]

public class GenericSpawner<T> where T : Component
{
    public GenericPool<T> pool = new GenericPool<T>();
    public float initialSpawnDelay = 1;
    public float spawnRate = 3;
    public float randomFactor = 1;
    public Collider[]spawnArea;
    public bool fixedPosBorn;
    public Transform PosToBorn;

    private float timer;
    private float nextSpawnTime = 3;
    private bool initialDelayDone;

    private iGenericSpawnerOwner<T> owner;
    public void Init(iGenericSpawnerOwner<T> _owner)
    {
        owner = _owner;
        pool.Init();
    }

    public void Tick()
    {
        timer += Time.deltaTime;
        if (!initialDelayDone)
        {
            if (timer < initialSpawnDelay) return;
            {
                initialDelayDone = true;
                SpawnNewItem();
                timer = 0;
            }
        }
        if (timer >= nextSpawnTime)
        {
            SpawnNewItem();
            GetNextSapawnTime();
            timer = 0;
        }
    }

    private void GetNextSapawnTime()
    {        
        nextSpawnTime = spawnRate + Random.Range(-randomFactor, randomFactor);
    }

    private void SpawnNewItem()
    {
        var newItem = pool.GetFreeItem();
        if (!fixedPosBorn)
        {
            var randomArea = Random.Range(0, spawnArea.Length);
            var center = spawnArea[randomArea].transform.position;
            var upLimit = center + spawnArea[randomArea].bounds.extents;
            var downLimit = center - spawnArea[randomArea].bounds.extents;
            var randomPos = center;
            randomPos.y = spawnArea[randomArea].bounds.extents.y + 3;
            randomPos.x = Random.Range(downLimit.x, upLimit.x);
            randomPos.z = Random.Range(downLimit.z, upLimit.z);
            newItem.transform.position = randomPos;
        }
        else
        {
            newItem.transform.position = PosToBorn.position;
        }

        newItem.gameObject.SetActive(true);
        owner.OnSpawnedNewItem(newItem, pool);
    }
}
public interface iGenericSpawnerOwner<T> where T : Component
{
    public void OnSpawnedNewItem(T newItem, GenericPool<T> pool);
}
