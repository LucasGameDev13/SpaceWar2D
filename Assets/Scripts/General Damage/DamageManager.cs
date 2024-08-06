using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;

    //Method to return the object damage
    public int GetDamage()
    {
        return damageValue;
    }

    //Method to destroy the object(DamageManager)
    public void Hit()
    {
        Destroy(gameObject);
    }  
}
