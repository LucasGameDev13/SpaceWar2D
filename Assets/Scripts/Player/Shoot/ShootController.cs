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
    private AudioPlayer audioPlayer;


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

    public int BulletLevel
    {
        get { return bulletLevel; }
        set { bulletLevel = value; }
    }

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //If useAi is true on the console, it means that the object is the IA
        //Then isFiring is true to them to keep shooting continuously
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

    //Variable to return the maximum value into the projectilePrefab
    public int GetBulletAmount()
    {
        return projectilePrefab.Length;   
    }
    
    private void Fire()
    {
        //Check if shooting is activated and no coroutine is currently running
        if (isFiring && fireCoroutine == null)
        {
            // Start the firing coroutine and store its reference
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        // If shooting is deactivated and a coroutine is running
        else if (!isFiring && fireCoroutine != null)
        {
            // Stop the firing coroutine
            StopCoroutine(fireCoroutine);
            // Reset the coroutine reference to null
            fireCoroutine = null;
        }
    }

    //Method to instantiate the bullets 
    private void BulletType(int index)
    {
        //Instantiating a bullet
        GameObject projectile = Instantiate(projectilePrefab[index], transform.position, Quaternion.identity);

        //Saving on a local variable, the Rig2D from the bullet that will be instantiated
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        //If there is and rig2D on this object
        if (rb != null)
        {
            //Accesing its velocity and make the bullet to follow a direction
            rb.velocity = transform.up * projectileSpeed;
        }

        //Destroy the bullet after its lifetime
        Destroy(projectile, projectileLifeTime);
    }


    IEnumerator FireContinuously()
    {
        //Looping the bullets while isFiring is true
        while(true)
        {
            //Giving the bullet to the IA or to the player
            if (useAI)
            {
                BulletType(0);
                audioPlayer.PlayEnemyShootingClip();
            }
            else
            {
                BulletType(bulletLevel);
                audioPlayer.PlayShootingClip();
            }


            //Randomizing the bullets delay
            float timeToNextProjectile = Random.Range(delayBetweenBullets - delayVariance, 
                                                      delayBetweenBullets + delayVariance);  
            //Limiting the bullets delay between a minimun value and maximun one
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimunDelay, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);           
        } 
    }
}
