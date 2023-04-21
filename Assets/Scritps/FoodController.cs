using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    GenericPool<FoodController> foodPool;
    [SerializeField] ParticleSystem particleBorn;
    [SerializeField] ParticleSystem particleDeath;
    

    
    void Start()
    {
        particleBorn.Play();
        
    }
  
    public void Init(GenericPool<FoodController> _foodPool, Transform parent)
    {
        transform.forward = parent.transform.forward;
        foodPool = _foodPool;
        transform.SetParent(parent);
    }
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FoodDeath());

    }
    public void RecycleBullet()
    {
        foodPool.RecycleItem(this);
    }

    IEnumerator FoodDeath()
    {
        
        particleDeath.Play();
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        RecycleBullet();
       
    }
}

