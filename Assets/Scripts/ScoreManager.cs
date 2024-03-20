using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    public void AddScore(bool isPlayerTwo, int points)
    {
        if (isPlayerTwo)
        {
            player2Score += points;
            player2ScoreText.text = "Score: " + player2Score;
        }
        else
        {
            player1Score += points;
            player1ScoreText.text = "Score: " + player1Score;
        }
    }
}
