using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WavesConfig> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    private WavesConfig currentWave;
    private bool isLooping = true;


    // Start is called before the first frame update
    void Start()
    {
        //Calling the couroutine
        StartCoroutine(SpawnEnemiesWaves());

    }

    public WavesConfig GetCurrentWave()
    {
        //Returning the data value
        return currentWave; 
    }

    IEnumerator SpawnEnemiesWaves()
    {
        //Do all this code while isLooping is true
        do
        {
            //Checking out through the waves list all the waves I have there inside
            //It means I will repeat the for as much as I have of waves into my list
            
            ////Instantiating enemy ramdomly
            //int randomWavesIndex = Random.Range(0, waveConfigs.Count);
            //currentWave = waveConfigs[randomWavesIndex];

            foreach (WavesConfig wave in waveConfigs)
            {
                //Giving the current wave all the elements inside the list
                currentWave = wave;

                //Instantiating the enemies according with the quantative of the enemies
                //I will repeat this for as much as I have the enemies on the prefabList. If I have 3, then repeat 3 so
                //saved on the data variable
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingWayPoint().position,
                    Quaternion.identity,
                    transform);

                    //Getting the delay between enemies
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                //Getting the delay between the waves
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
        
    }
}
