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

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = healthManager.GetHealth();
        nextLevelBar.fillAmount = 0;
        levelText.text = $"Level: {(shootController.BulletLevel + 1).ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = healthManager.GetHealth();

        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000000");

        levelText.text = $"Level: {(shootController.BulletLevel + 1).ToString()}";   

        if (shootController.BulletLevel < scoreKeeper.MaxLevel)
        {
            nextLevelBar.fillAmount = (float)scoreKeeper.GetCurrentScore() / (float)scoreKeeper.GetCurrentScoreNextLevel();
        }
        else
        {
            nextLevelBar.fillAmount = float.MaxValue;
        }
    }
}
