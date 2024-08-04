using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WavesConfig wavesConfig;
    List<Transform> wayPoints;
    private int wayPointsIndex = 0;


    private void Awake()
    {
        //Acessing the enemySpawner Script
        enemySpawner = FindObjectOfType<EnemySpawner>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //Acessing the wavesConfig value through the enemySpawner script
        wavesConfig = enemySpawner.GetCurrentWave();

        //Save all the wayPoints as soon as my enemy exists on the scene
        //Give to the enemy all the ways it will need to go through
        wayPoints = wavesConfig.GetWayPoints();
        transform.position = wayPoints[wayPointsIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        //Giving the moviment to the enemy according with the path's index
        if(wayPointsIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointsIndex].position;
            float delta = wavesConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if(transform.position == targetPosition)
            {
                wayPointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
