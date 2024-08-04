using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WavesConfig> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    private WavesConfig currentWave;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnEnemiesWaves());

    }

    public WavesConfig GetCurrentWave()
    {
        //Returning the data value
        return currentWave; 
    }

    IEnumerator SpawnEnemiesWaves()
    {
        foreach (WavesConfig wave in waveConfigs)
        {
            currentWave = wave;

            //Instantiating the enemies according with the quantative of the enemies saved on the data variable
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);

                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
