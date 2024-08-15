using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] UIinfos;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    private void Update()
    {
        //Condition to control the gui infos

        if (enemySpawner != null)
        {
            //If the game is playing and the enemies is being invoked 
            if(enemySpawner.IsLooping)
            {
                //Keep the player gui actived
                UIinfos[0].gameObject.SetActive(true);
                UIinfos[1].gameObject.SetActive(false);
            }
            else //Otherwise, if the player died, calls gameover and call off the player gui
            {
                UIinfos[1].gameObject.SetActive(true);
                UIinfos[0].gameObject.SetActive(false);
            }
        }
    }
}
