using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private int score;
    [SerializeField] private Animator caracterAnim;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private bool applyCameraShake;
    [SerializeField] private bool isPlayer;
    private CameraShake cameraShake;
    private AudioPlayer audioPlayer;
    private ScoreKeeper scoreKeeper;
    private LevelManager levelManager;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        //Accessing the script from the camera
        cameraShake = Camera.main.GetComponent<CameraShake>();

        audioPlayer = FindObjectOfType<AudioPlayer>();

        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        levelManager = FindObjectOfType<LevelManager>();

        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    //Method to take the health off
    public void TakeDamage(int damage)
    {
        health -= damage;

        audioPlayer.PlayDamageClip();

        //As soon as doesn't have health, destroy the gameobject(HealthManager)
        if(health <= 0)
        {
            //Calling the player and enemy destroy animation
            if (caracterAnim != null)
            {
                caracterAnim.SetTrigger("death");
            }

            //Destroying the gameobject after the animation ends
            Die();
        }
    }

    //Method to destroy the gameObject and checkout who is and who isn't the player
    //Who isn't the player, trigger the method to score the game
    private void Die()
    {
        if (!isPlayer)
        {
           scoreKeeper.IncreaseScore(score); 
        }
        else
        {
            //levelManager.LoadGameOver();
            enemySpawner.IsLooping = false;
        }

        Destroy(gameObject, 0.5f);
    }

    //Method to instantiate the particle system effect
    private void PlayHitEffect()
    {
        //If there is a particle system atteched on the variable
        if (hitEffect != null)
        {
            //Instantiate the particle
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);

            //Destroying the particle system
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    //Checking out the collision between objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Saving into the variable the object that carries the script DamagaManager
        DamageManager damageManager = collision.GetComponent<DamageManager>();

        //If there is something if this script
        if(damageManager != null )
        {
          
          //I call the function to get the damage, and subtract from the health
          TakeDamage(damageManager.GetDamage());

          //Playing the shooteffect
          PlayHitEffect();

          //Calling the method shake camera
          ShakeCamera();
          
          //And I destroy this object that carries the script DamageManager
          damageManager.Hit();
           
        }
    }

    //Method to get get the total health
    public int GetHealth()
    {
        return health;
    }

    //Method to control the camera shake
    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
