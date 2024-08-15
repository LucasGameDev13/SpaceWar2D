using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private ShootController shootController;
    private int gameScore;
    private int finalScore;

    //Variables to the bulletLevel
    private int scoreLevelBullet;
    private int maxLevel;
    [SerializeField] private int scoreNextLevel;

    public int MaxLevel
    {
        get { return maxLevel; }
        set { maxLevel = value; }
    }

    private void Awake()
    {
        shootController = FindObjectOfType<ShootController>();
    }

    private void Start()
    {
        //Setting up the score to the next level and the level max limit
        //scoreNextLevel = 100;
        maxLevel = shootController.GetBulletAmount() - 1;
    }

    //Updating all the time the final score
    private void Update()
    {
        finalScore = gameScore;
    }

    //Returning the current score
    public int GetCurrentScore()
    {
        return gameScore;
    }

    //Returning the score to update the final score
    public int GetFinalScore()
    {
        return finalScore;  
    }

    //Returning the score to control the bullet level
    public int GetCurrentScoreNextLevel()
    {
        return scoreNextLevel;
    }

    //Increasing the variable gameScore
    public void IncreaseScore(int score)
    {
        gameScore += score;
        
        Mathf.Clamp(gameScore, 0, int.MaxValue);

        IncreaseLevelBullet();
    }

    //Method to increase the bullets level
    public void IncreaseLevelBullet()
    {
        // If my level is below than the max limit
        if (shootController.BulletLevel < maxLevel)
        {
            //Checking out if my score is equal than the limit to the next level
            if (gameScore >= scoreNextLevel)
            {
                //Increase the limit to the next level
                //Level Up the bullet
                scoreNextLevel *= 5;
                shootController.BulletLevel++;
            }
        }

        //Debug
        //Debug.Log($"Score:{gameScore} = {scoreNextLevel} = BulletLevel: {shootController.BulletLevel}");
    }
}
