using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health = 50;

    //Method to take the health off
    public void TakeDamage(int damage)
    {
        health -= damage;

        //As soon as doesn't have health, destroy the gameobject(HealthManager)
        if(health <= 0)
        {
            Destroy(gameObject);
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
          
          //And I destroy this object that carries the script DamageManager
          damageManager.Hit();
           
        }
    }
}
