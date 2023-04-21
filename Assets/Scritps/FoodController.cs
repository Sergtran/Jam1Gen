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
        particleDeath.Stop();
        
    }
  
    public void Init(GenericPool<FoodController> _foodPool, Transform parent)
    {
        transform.localScale = Vector3.one * 1;
        transform.forward = parent.transform.forward;
        foodPool = _foodPool;
        transform.SetParent(parent);
    }
    void Update()
    {


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    particleDeath.Play();
    //    particleBorn.Stop();
    //    StartCoroutine(FoodDeath());

    //}

    private void OnCollisionEnter(Collision collision)
    {
        particleDeath.Play();
        particleBorn.Stop();
        StartCoroutine(FoodDeath());
    }
    public void RecycleBullet()
    {
        foodPool.RecycleItem(this);
    }

    IEnumerator FoodDeath()
    {        
        for (int i = 1; i > 0; i--)
        {
            //gameObject.transform.localScale=(Vector3.one * i*0.1f);
            yield return new WaitForSeconds(0.05f);

        }
        gameObject.SetActive(false);
        RecycleBullet();
       
    }
}

