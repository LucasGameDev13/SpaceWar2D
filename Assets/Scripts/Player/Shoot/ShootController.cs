using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject[] projectilePrefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLifeTime;
    [SerializeField] private float delayBetweenBullets;
    [SerializeField] private int bulletLevel;


    [Header("AI")]
    [SerializeField] private float delayVariance;
    [SerializeField] private float minimunDelay;
    [SerializeField] private bool useAI;
    private bool isFiring;
    private Coroutine fireCoroutine;

    public bool IsFiring
    {
        get { return isFiring; }
        set { isFiring = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    private void BulletType(int index)
    {
        GameObject projectile = Instantiate(projectilePrefab[index], transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = transform.up * projectileSpeed;
        }

        Destroy(projectile, projectileLifeTime);
    }


    IEnumerator FireContinuously()
    {
        while(true)
        {
            if (useAI)
            {
                BulletType(0);
            }
            else
            {
                BulletType(bulletLevel);
            }

            float timeToNextProjectile = Random.Range(delayBetweenBullets - delayVariance, 
                                                      delayBetweenBullets + delayVariance);  
            
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimunDelay, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);           
        } 
    }
}
