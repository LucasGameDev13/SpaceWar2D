using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Config", menuName = "New Wave/Wave")]
public class WavesConfig : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeBetweenEnemySpawn = 1f;
    [SerializeField] private float spawnTimeVariance;
    [SerializeField] private float minimumSpawnTime = 0.2f;


    //Returning the total of enemies at the list
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    //Returning an expecific enemy from the list
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    //Method to return the position of the first path into my path object father
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    //Saving all the paths inside of a local variable
    public List<Transform> GetWayPoints()
    {
        //Local variable list
        List<Transform> wayPoints = new List<Transform>();

        //Save each paths inside of the pathprefab into the local variable list
        foreach(Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }

    //Getting the enemy's speed
    public float GetMoveSpeed()
    {
        
        return moveSpeed;
    }

    //Method to return a random value time between the spawn time and the maxium float value
    public float GetRandomSpawnTime()
    {
        //This local var saves the random value
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariance, 
                                       timeBetweenEnemySpawn + spawnTimeVariance);

        //This value limits the random value between a maximum value
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
