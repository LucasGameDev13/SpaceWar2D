using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private ShootController shootController;

    [Header("Player Health Settings")]
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private Slider healthBar;

    [Header("Player Score Settings")]
    private ScoreKeeper scoreKeeper;
    [SerializeField] private TextMeshProUGUI scoreText;


    [SerializeField] private Image nextLevelBar;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject maxLevelAnimation;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //Setting up the game gui with the health information, the bullet level and the bullet xp
        healthBar.maxValue = healthManager.GetHealth();
        nextLevelBar.fillAmount = 0;
        levelText.text = $"Level: {(shootController.BulletLevel + 1).ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
        //Updating the health bar everytime
        healthBar.value = healthManager.GetHealth();

        //Updating the gamescore of the gui everytime
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000000");

        //Updating the level feedback everytime
        levelText.text = $"Level: {(shootController.BulletLevel + 1).ToString()}";   

        //Checking if the bullet level is lower than the max level, update the bullet xp bar
        if (shootController.BulletLevel < scoreKeeper.MaxLevel)
        {
            nextLevelBar.fillAmount = (float)scoreKeeper.GetCurrentScore() / (float)scoreKeeper.GetCurrentScoreNextLevel();
            maxLevelAnimation.SetActive(false);
        }
        else //Otherwise, fill it up completely and show up the feedback that it is on the maximum level
        {
            nextLevelBar.fillAmount = float.MaxValue;
            maxLevelAnimation.SetActive(true);
        }
    }
}
