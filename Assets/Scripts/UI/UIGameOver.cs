using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreTxt;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update()
    {
        UpdateScore();
    }

    //Method to get the final score of the game and put on the gui
    private void UpdateScore()
    {
        if (scoreKeeper != null)
        {
            finalScoreTxt.text = "YOU SCORED:\n" + scoreKeeper.GetFinalScore();

        }
    }
}
